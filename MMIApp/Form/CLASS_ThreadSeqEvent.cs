using System;
using System.Diagnostics;
using System.Threading;
using SharedMemDll;

namespace MMI
{
    // Takes the events SEQ pushes (SEQ_EVENT_CHANNEL in SharedMemBase.h) as
    // they come, instead of waiting for the next poll.
    //
    // CThreadMain still polls everything it did before; this thread adds what
    // a poll cannot give: every change in the order SEQ saw it, written to
    // the MMI log, and the end of a scan even when SEQ has already moved on
    // from DONE by the time the next poll would have looked.
    //
    // It blocks on SEQ's signal, so it costs nothing while SEQ is quiet.
    class CThreadSeqEvent
    {
        // SEQ_EVENT_CODE in SharedMemBase.h.
        private const int EventAlarm            = 1;
        private const int EventRunState         = 2;
        private const int EventSystemInit       = 3;
        private const int EventScanTriggerState = 4;
        private const int EventText             = 5;

        // SCANTRIGGER state numbers, as on the Auto and engineer screens.
        private const int ScanTriggerDone    = 7;
        private const int ScanTriggerAborted = 8;

        private const int WaitMs = 200;

        public static void Execute()
        {
            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            SEQ_EVENT ev = new SEQ_EVENT();
            int nLostSeen = 0;

            while (!MmiGV.bProgramExit)
            {
                if (MmiGV.pShMem == null)
                {
                    Thread.Sleep(WaitMs);
                    continue;
                }

                try
                {
                    MmiGV.pShMem.WaitSeqEvent(WaitMs);
                    while (MmiGV.pShMem.GetSeqEvent(ev))
                    {
                        Handle(ev, MMILog);
                        ev = new SEQ_EVENT();
                    }

                    int nLost = MmiGV.pShMem.GetSeqEventLost();
                    if (nLost != nLostSeen)
                    {
                        MMILog.AddMMILogWarning(0, "SEQ event ring full: " + (nLost - nLostSeen) + " events dropped");
                        nLostSeen = nLost;
                    }
                }
                catch (Exception ex)
                {
                    MMILog.AddMMILog("SEQ event: " + ex.Message);
                    Thread.Sleep(WaitMs);
                }
            }
            Trace.WriteLine("SEQ Event Thread Close..");
        }

        private static void Handle(SEQ_EVENT ev, CThreadMMILog MMILog)
        {
            switch (ev.nCode)
            {
                case EventAlarm:
                    MMILog.AddMMILog(ev.nArg[0] == 0
                        ? string.Format("SEQ event #{0}: alarm cleared (was E{1:0000})", ev.uSerial, ev.nArg[1])
                        : string.Format("SEQ event #{0}: alarm E{1:0000} {2} (was E{3:0000})",
                                        ev.uSerial, ev.nArg[0], AlarmName(ev.nArg[0]), ev.nArg[1]));
                    break;

                case EventRunState:
                    MMILog.AddMMILog(string.Format("SEQ event #{0}: auto run {1}", ev.uSerial,
                                                   ev.nArg[0] != 0 ? "started" : "stopped"));
                    break;

                case EventSystemInit:
                    MMILog.AddMMILog(string.Format("SEQ event #{0}: system initialize {1} -> {2}",
                                                   ev.uSerial, ev.nArg[1], ev.nArg[0]));
                    break;

                case EventScanTriggerState:
                    MMILog.AddMMILog(string.Format("SEQ event #{0}: scan trigger state {1} -> {2}",
                                                   ev.uSerial, ev.nArg[1], ev.nArg[0]));
                    if (ev.nArg[0] == ScanTriggerDone || ev.nArg[0] == ScanTriggerAborted)
                    {
                        ScanTriggerFinished(ev.nArg[0]);
                    }
                    break;

                case EventText:
                    MMILog.AddMMILog(string.Format("SEQ event #{0}: {1}", ev.uSerial, ev.strText));
                    break;

                default:
                    MMILog.AddMMILog(string.Format("SEQ event #{0}: code {1} ({2}, {3}, {4}, {5}) {6}", ev.uSerial,
                                                   ev.nCode, ev.nArg[0], ev.nArg[1], ev.nArg[2], ev.nArg[3], ev.strText));
                    break;
            }
        }

        private static string AlarmName(int nCode)
        {
            MmiGV.TErrorBuff err;
            return MmiGV.dicErrorList.TryGetValue(nCode, out err) ? err.name : "";
        }

        // The Auto panel follows a scan by polling, and SEQ may already be back
        // at IDLE when the next poll looks. Read the final numbers once and tell
        // the panel the cycle is over.
        private static void ScanTriggerFinished(int nState)
        {
            FormAuto1 frmAuto = (MmiGV.frmMain != null) ? MmiGV.frmMain.frmAuto1 : null;
            if (frmAuto == null || !frmAuto.bScanTriggerWatch) return;

            bool bRead = MmiGV.pShMem.GetScanTriggerDisplay();
            frmAuto.ScanTriggerFinished(nState, bRead);
        }
    }
}
