using Mapping;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MMI
{
    public enum eMapState : int
    {
        EMPTY = 0,
        EXIST = 1,
    }
    public enum eMapTarget : int
    {
        FLIPY1 = 0,
        FLIPY2,
        PALLETY1,
        PALLETY2,
        GOOD_TRAY1,
        GOOD_TRAY2,
        REWORK_TRAY,
        NG_TRAY,
    };

    public enum MapState : int
    {
        EMPTY = 0,
        EXIST = 1,
        GOOD = 2,
        REWORK = 3,
        NG = 4,
    }
    

    public partial class FormAuto1 : Form
    {
        private FormMain frmMain = null;
        private Form_Map frm_Map = null;

        public readonly Stopwatch swRun = new Stopwatch();
        public readonly Stopwatch swStop = new Stopwatch();

        public TimeSpan tsRun = new TimeSpan();
        public TimeSpan tsStop = new TimeSpan();

        ToolTip toolTip = new ToolTip();
        string strTip = "";

        //
        private Map Flip1Map = new Map();
        private Map Flip2Map = new Map();
        private Map Pallette1Map = new Map();
        private Map Pallette2Map = new Map();

        private Map FrontPkMap = new Map();
        private Map RearPkMap = new Map();

        private Map GoodTray1Map = new Map();
        private Map GoodTray2Map = new Map();
        private Map RewTrayMap = new Map();
        private Map NGTrayMap = new Map();
        //

        public FormAuto1()
        {
            InitializeComponent();
        }
        public FormAuto1(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            swRun.Reset();
            swStop.Reset();
        }
        private void FormAuto1_Shown(object sender, EventArgs e)
        {
            lblTargetUPH.Text = MmiGV.iTragetUPH.ToString();

            toolTip.OwnerDraw = true;
            toolTip.Draw += new DrawToolTipEventHandler(toolTip_Draw);
            toolTip.Popup += new PopupEventHandler(toolTip_Popup);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {

            if (!MmiGV.bFormHomeShow)
            {
                MmiGV.bFormHomeShow = true;
                Form_Home frm_Home = new Form_Home();

                frm_Home.TopMost = true;
                frm_Home.TopLevel = true;

                frm_Home.Show();
            }
        }

        private void spTabLaser_DoubleClick(object sender, EventArgs e)
        {
            MmiGV.frmMain.frm_Laser.CheckDocking();
        }

        private void btnLOTInput_Click(object sender, EventArgs e)
        {
            if (MmiGV.frmMain.frm_LotInput.Display())
            {
                lblLotID.Text = MmiGV.LotInfo.strLotID;
                lblLotCount.Text = MmiGV.LotInfo.LotCnt.ToString();

                //SeqGV.LotInfo = MmiGV.LotInfo;
                MmiGV.pShMem.WLotInfo.strLotID = MmiGV.LotInfo.strLotID;
                MmiGV.pShMem.WLotInfo.nLotCount = MmiGV.LotInfo.LotCnt;
                MmiGV.pShMem.SetLotInfo();

            }
        }

        private void tmRun_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToString("HHmmss") == "000000")
            {
                swRun.Reset();
                swStop.Reset();
            }

            if (swRun.IsRunning)
            {
                tsRun = swRun.Elapsed;
                lblRunningTime.Text = $"{tsRun.Hours:D2}:{tsRun.Minutes:D2}:{tsRun.Seconds:D2}";
            }
            if (swStop.IsRunning)
            {
                tsStop = swStop.Elapsed;
                lblStopTime.Text = $"{tsStop.Hours:D2}:{tsStop.Minutes:D2}:{tsStop.Seconds:D2}";
            }

            SetGrid();
            UpdateGrid();
        }

        private void SetGrid()
        {
            if (MmiGV.bDrawInfoGrid)
            {
                Flip1Map.MapConverter = null;
                Flip2Map.MapConverter = null;
                Pallette1Map.MapConverter = null;
                Pallette2Map.MapConverter = null;

                FrontPkMap.MapConverter = null;
                RearPkMap.MapConverter = null;

                GoodTray1Map.MapConverter = null;
                GoodTray2Map.MapConverter = null;
                RewTrayMap.MapConverter = null;
                NGTrayMap.MapConverter = null;

                //
                Flip1Map.MapConverter = new SMECConverter();
                Flip2Map.MapConverter = new SMECConverter();
                Pallette1Map.MapConverter = new SMECConverter();
                Pallette2Map.MapConverter = new SMECConverter();

                FrontPkMap.MapConverter = new SMECConverter();
                RearPkMap.MapConverter = new SMECConverter();

                GoodTray1Map.MapConverter = new SMECConverter();
                GoodTray2Map.MapConverter = new SMECConverter();
                RewTrayMap.MapConverter = new SMECConverter();
                NGTrayMap.MapConverter = new SMECConverter();
                //
                //
                MmiGV.bDrawInfoGrid = false;
                MmiGV.bUpdateInfoGrid = true;
            }
        }

        public void UpdateGrid()
        {
            CUtil util = CUtil.GetInstance;

            if (MmiGV.bUpdateInfoGrid)
            {
                Mapping.StripMapViewer[] strips = new StripMapViewer[10];
                strips[0] = FlipMapView1;
                strips[1] = FlipMapView2;
                strips[2] = PalMapView1;
                strips[3] = PalMapView2;
                strips[4] = FrontPkMapView;
                strips[5] = RearPkMapView;
                strips[6] = Good1MapView;
                strips[7] = Good2MapView;
                strips[8] = ReworkMapView;
                strips[9] = NgMapView;

                for (int k = 0; k < 10; k++)
                {
                    strips[k].colors = new Color[5];
                    strips[k].colors[0] = Color.White;  // empty
                    strips[k].colors[1] = Color.Blue;   // exist
                    strips[k].colors[2] = Color.Green;  // good
                    strips[k].colors[3] = Color.Yellow; // Rework
                    strips[k].colors[4] = Color.Red;    // NG
                }

                ///
                int x = (int)MmiGV.pShMem.WRecipeData.Unit_X_Count;
                int y = (int)MmiGV.pShMem.WRecipeData.Unit_Y_Count;

                Flip1Map.defUnit = new UnitData(x, y);
                Flip2Map.defUnit = new UnitData(x, y);
                Pallette1Map.defUnit = new UnitData(x, y);
                Pallette2Map.defUnit = new UnitData(x, y);

                // Data 갱신
                for (int m = 0; m < y; m++)
                {
                    for (int k = 0; k < x; k++)
                    {
                        // Flip1
                        if (MmiGV.pShMem.RFlip1Map.Map[k,m] == (int)MapState.EXIST)
                        {
                            int result = MmiGV.pShMem.RFlip1VisionResult.Result[k,m];
                            bool bRet1 = util.GetBit(result, 1);    // GOOD
                            bool bRet2 = util.GetBit(result, 2);    // REWORK
                            bool bRet3 = util.GetBit(result, 3);    // NG
                            if (bRet1) Flip1Map.defUnit.Coloridx[k, m] = (int)MapState.GOOD;
                            else if (bRet2) Flip1Map.defUnit.Coloridx[k, m] = (int)MapState.REWORK;
                            else if (bRet3) Flip1Map.defUnit.Coloridx[k, m] = (int)MapState.NG;
                            else Flip1Map.defUnit.Coloridx[k, m] = (int)MapState.EXIST;
                        }
                        else Flip1Map.defUnit.Coloridx[k, m] = (int)MapState.EMPTY;
                        Flip1Map.defUnit.msg[k, m] = (k * y + m + 1).ToString();

                        // Flip2
                        if (MmiGV.pShMem.RFlip2Map.Map[k,m] == (int)MapState.EXIST)
                        {
                            int result = MmiGV.pShMem.RFlip2VisionResult.Result[k,m];
                            bool bRet1 = util.GetBit(result, 1);    // GOOD
                            bool bRet2 = util.GetBit(result, 2);    // REWORK
                            bool bRet3 = util.GetBit(result, 3);    // NG
                            if (bRet1) Flip2Map.defUnit.Coloridx[k, m] = (int)MapState.GOOD;
                            else if (bRet2) Flip2Map.defUnit.Coloridx[k, m] = (int)MapState.REWORK;
                            else if (bRet3) Flip2Map.defUnit.Coloridx[k, m] = (int)MapState.NG;
                            else Flip2Map.defUnit.Coloridx[k, m] = (int)MapState.EXIST;
                        }
                        else Flip2Map.defUnit.Coloridx[k, m] = (int)MapState.EMPTY;
                        Flip2Map.defUnit.msg[k, m] = (k * y + m + 1).ToString();

                        // Pallet1
                        if (MmiGV.pShMem.RPallet1Map.Map[k,m] == (int)MapState.EXIST)
                        {
                            int result = MmiGV.pShMem.RPallet1VisionResult.Result[k,m];
                            bool bRet1 = util.GetBit(result, 5);    // GOOD
                            bool bRet2 = util.GetBit(result, 6);    // REWORK
                            bool bRet3 = util.GetBit(result, 7);    // NG
                            if (bRet1) Pallette1Map.defUnit.Coloridx[k, m] = (int)MapState.GOOD;
                            else if (bRet2) Pallette1Map.defUnit.Coloridx[k, m] = (int)MapState.REWORK;
                            else if (bRet3) Pallette1Map.defUnit.Coloridx[k, m] = (int)MapState.NG;
                            else Pallette1Map.defUnit.Coloridx[k, m] = (int)MapState.EXIST;
                        }
                        else Pallette1Map.defUnit.Coloridx[k, m] = (int)MapState.EMPTY;
                        Pallette1Map.defUnit.msg[k, m] = (k * y + m + 1).ToString();

                        // Pallet2
                        if (MmiGV.pShMem.RPallet2Map.Map[k,m] == (int)MapState.EXIST)
                        {
                            int result = MmiGV.pShMem.RPallet2VisionResult.Result[k,m];
                            bool bRet1 = util.GetBit(result, 5);    // GOOD
                            bool bRet2 = util.GetBit(result, 6);    // REWORK
                            bool bRet3 = util.GetBit(result, 7);    // NG
                            if (bRet1) Pallette2Map.defUnit.Coloridx[k, m] = (int)MapState.GOOD;
                            else if (bRet2) Pallette2Map.defUnit.Coloridx[k, m] = (int)MapState.REWORK;
                            else if (bRet3) Pallette2Map.defUnit.Coloridx[k, m] = (int)MapState.NG;
                            else Pallette2Map.defUnit.Coloridx[k, m] = (int)MapState.EXIST;
                        }
                        else Pallette2Map.defUnit.Coloridx[k, m] = (int)MapState.EMPTY;
                        Pallette2Map.defUnit.msg[k, m] = (k * y + m + 1).ToString();
                    }
                }
                Flip1Map.Apply();
                Flip2Map.Apply();
                Pallette1Map.Apply();
                Pallette2Map.Apply();

                FrontPkMap.defUnit = new UnitData(8, 1);
                RearPkMap.defUnit = new UnitData(8, 1);

                // Data 갱신
                for (int m = 0; m < 8; m++)
                {
                    int result = MmiGV.pShMem.RFrontPkVisionResult.Result[m];
                    bool bRet1 = util.GetBit(result, 9);    // GOOD
                    bool bRet2 = util.GetBit(result, 10);    // REWORK
                    bool bRet3 = util.GetBit(result, 11);    // NG
                    if (bRet1) FrontPkMap.defUnit.Coloridx[m, 0] = (int)MapState.GOOD;
                    else if (bRet2) FrontPkMap.defUnit.Coloridx[m, 0] = (int)MapState.REWORK;
                    else if (bRet3) FrontPkMap.defUnit.Coloridx[m, 0] = (int)MapState.NG;
                    else FrontPkMap.defUnit.Coloridx[m, 0] = (int)MapState.EMPTY;
                    FrontPkMap.defUnit.msg[m,0] = (m + 1).ToString();

                    result = MmiGV.pShMem.RRearPkVisionResult.Result[m];
                    bRet1 = util.GetBit(result, 9);    // GOOD
                    bRet2 = util.GetBit(result, 10);    // REWORK
                    bRet3 = util.GetBit(result, 11);    // NG
                    if (bRet1) RearPkMap.defUnit.Coloridx[m, 0] = (int)MapState.GOOD;
                    else if (bRet2) RearPkMap.defUnit.Coloridx[m, 0] = (int)MapState.REWORK;
                    else if (bRet3) RearPkMap.defUnit.Coloridx[m, 0] = (int)MapState.NG;
                    else RearPkMap.defUnit.Coloridx[m, 0] = (int)MapState.EMPTY;
                    RearPkMap.defUnit.msg[m, 0] = (m + 1).ToString();
                }
                FrontPkMap.Apply();
                RearPkMap.Apply();

                //
                x = (int)MmiGV.pShMem.WRecipeData.Tray_X_Count;
                y = (int)MmiGV.pShMem.WRecipeData.Tray_Y_Count;

                GoodTray1Map.defUnit = new UnitData(x, y);
                GoodTray2Map.defUnit = new UnitData(x, y);
                RewTrayMap.defUnit = new UnitData(x, y);
                NGTrayMap.defUnit = new UnitData(x, y);

                // Data 갱신
                // Data 갱신
                for (int m = 0; m < y; m++)
                {
                    for (int k = 0; k < x; k++)
                    {
                        // Good Tray1
                        if (MmiGV.pShMem.RGoodTray1Map.Map[k,m] == (int)MapState.EXIST)
                        {
                            int result = MmiGV.pShMem.RGoodTray1VisionResult.Result[k,m];
                            bool bRet1 = util.GetBit(result, 1);    // GOOD
                            bool bRet2 = util.GetBit(result, 2);    // REWORK
                            bool bRet3 = util.GetBit(result, 3);    // NG
                            if (bRet1) GoodTray1Map.defUnit.Coloridx[k, m] = (int)MapState.GOOD;
                            else if (bRet2) GoodTray1Map.defUnit.Coloridx[k, m] = (int)MapState.REWORK;
                            else if (bRet3) GoodTray1Map.defUnit.Coloridx[k, m] = (int)MapState.NG;
                            else GoodTray1Map.defUnit.Coloridx[k, m] = (int)MapState.EXIST;
                        }
                        else GoodTray1Map.defUnit.Coloridx[k, m] = (int)MapState.EMPTY;
                        GoodTray1Map.defUnit.msg[k, m] = (k * y + m + 1).ToString();

                        // Good Tray2
                        if (MmiGV.pShMem.RGoodTray2Map.Map[k,m] == (int)MapState.EXIST)
                        {
                            int result = MmiGV.pShMem.RGoodTray2VisionResult.Result[k,m];
                            bool bRet1 = util.GetBit(result, 1);    // GOOD
                            bool bRet2 = util.GetBit(result, 2);    // REWORK
                            bool bRet3 = util.GetBit(result, 3);    // NG
                            if (bRet1) GoodTray2Map.defUnit.Coloridx[k, m] = (int)MapState.GOOD;
                            else if (bRet2) GoodTray2Map.defUnit.Coloridx[k, m] = (int)MapState.REWORK;
                            else if (bRet3) GoodTray2Map.defUnit.Coloridx[k, m] = (int)MapState.NG;
                            else GoodTray2Map.defUnit.Coloridx[k, m] = (int)MapState.EXIST;
                        }
                        else GoodTray2Map.defUnit.Coloridx[k, m] = (int)MapState.EMPTY;
                        GoodTray2Map.defUnit.msg[k, m] = (k * y + m + 1).ToString();

                        // Rework Tray
                        if (MmiGV.pShMem.RRewTrayMap.Map[k,m] == (int)MapState.EXIST)
                        {
                            int result = MmiGV.pShMem.RRewTrayVisionResult.Result[k,m];
                            bool bRet1 = util.GetBit(result, 1);    // GOOD
                            bool bRet2 = util.GetBit(result, 2);    // REWORK
                            bool bRet3 = util.GetBit(result, 3);    // NG
                            if (bRet1) RewTrayMap.defUnit.Coloridx[k, m] = (int)MapState.GOOD;
                            else if (bRet2) RewTrayMap.defUnit.Coloridx[k, m] = (int)MapState.REWORK;
                            else if (bRet3) RewTrayMap.defUnit.Coloridx[k, m] = (int)MapState.NG;
                            else RewTrayMap.defUnit.Coloridx[k, m] = (int)MapState.EXIST;
                        }
                        else RewTrayMap.defUnit.Coloridx[k, m] = (int)MapState.EMPTY;
                        RewTrayMap.defUnit.msg[k, m] = (k * y + m + 1).ToString();

                        // NG Tray
                        if (MmiGV.pShMem.RNGTrayMap.Map[k,m] == (int)MapState.EXIST)
                        {
                            int result = MmiGV.pShMem.RNGTrayVisionResult.Result[k,m];
                            bool bRet1 = util.GetBit(result, 1);    // GOOD
                            bool bRet2 = util.GetBit(result, 2);    // REWORK
                            bool bRet3 = util.GetBit(result, 3);    // NG
                            if (bRet1) NGTrayMap.defUnit.Coloridx[k, m] = (int)MapState.GOOD;
                            else if (bRet2) NGTrayMap.defUnit.Coloridx[k, m] = (int)MapState.REWORK;
                            else if (bRet3) NGTrayMap.defUnit.Coloridx[k, m] = (int)MapState.NG;
                            else NGTrayMap.defUnit.Coloridx[k, m] = (int)MapState.EXIST;
                        }
                        else NGTrayMap.defUnit.Coloridx[k, m] = (int)MapState.EMPTY;
                        NGTrayMap.defUnit.msg[k, m] = (k * y + m + 1).ToString();
                    }
                }

                GoodTray1Map.Apply();
                GoodTray2Map.Apply();
                RewTrayMap.Apply();
                NGTrayMap.Apply();

                FlipMapView1.Map = Flip1Map;
                FlipMapView2.Map = Flip2Map;
                PalMapView1.Map = Pallette1Map;
                PalMapView2.Map = Pallette2Map;

                FrontPkMapView.Map = FrontPkMap;
                RearPkMapView.Map = RearPkMap;

                Good1MapView.Map = GoodTray1Map;
                Good2MapView.Map = GoodTray2Map;
                ReworkMapView.Map = RewTrayMap;
                NgMapView.Map = NGTrayMap;


                //click 정보
                //if (PalMapView1.ChkUnit != null)
                //{
                //    string X = PalMapView1.ChkUnit.Column.ToString();
                //    string Y = PalMapView1.ChkUnit.Row.ToString();
                //}

            }
        }

        private void btnTargetUPH_Click(object sender, EventArgs e)
        {
            CIniHelper iniHelper = new CIniHelper("MachineConfig.ini");

            if (frmMain.frm_NumPad.Display())
            {
                int uData = (int)frmMain.frm_NumPad.GetValue();
                if (uData >= 1)
                {
                    lblTargetUPH.Text = uData.ToString();
                    MmiGV.iTragetUPH = uData;
                    iniHelper.WriteInteger("TARGET UPH", uData, "UPH");
                }
                else
                {
                    MmiGV.frmMain.frm_Msg.ShowMessage("You shold input 0 over.");
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {


        }

        private void btnSeqOperation(object sender, EventArgs e)
        {
            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            Debug.Assert(MMILog != null);

            DevComponents.DotNetBar.ButtonX p_Button = sender as DevComponents.DotNetBar.ButtonX;

            uint tag = Convert.ToUInt32(p_Button.Tag);
            if (MmiGV.pShMem.GetDM(2) == 0)
            {
                MmiGV.pShMem.SetDM(2, tag);
                MMILog.AddMMILog(p_Button.Text + " Clicked");
            }
        }

        private void btnGoodTray1_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (frmMain.frm_Msg.Display("Do you want Eject Good Tray1?"))
            {
                MmiGV.pShMem.SetTenKey(88);
            }
        }

        private void btnGoodTray2_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (frmMain.frm_Msg.Display("Do you want Eject Good Tray2?"))
            {
                MmiGV.pShMem.SetTenKey(97);
            }
        }

        private void btnReworkTray_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (frmMain.frm_Msg.Display("Do you want Eject Rework Tray?"))
            {
                MmiGV.pShMem.SetTenKey(109);
            }
        }

        private void btnNGTray_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (frmMain.frm_Msg.Display("Do you want Eject NG Tray?"))
            {
                MmiGV.pShMem.SetTenKey(119);
            }
        }

        private void MapView_Selected(object sender, UnitSelectedEventArgs e)
        {
            Mapping.StripMapViewer pViewer = sender as Mapping.StripMapViewer;
            int nTarget = int.TryParse(pViewer.Tag.ToString(), out nTarget) ? nTarget : -1;

            if (nTarget > -1)
            {
                if ((nTarget >= 0) && (nTarget <= 3))
                {
                    frm_Map = new Form_Map();
                    frm_Map.Display((eMapTarget)nTarget);
                }
                else
                {
                    if (pViewer.SelectedUnit != null)
                    {
                        //toolTip.AutoPopDelay = 5000;
                        //toolTip.InitialDelay = 1000;
                        //toolTip.ReshowDelay = 500;
                        toolTip.ShowAlways = true;
                        toolTip.IsBalloon = false;
                        toolTip.UseAnimation = true;

                        
                        int x = pViewer.SelectedUnit.Column;
                        int y = pViewer.SelectedUnit.Row;
                        int result = 0;
                        if ((eMapTarget)nTarget == eMapTarget.GOOD_TRAY1)
                        {
                            result = MmiGV.pShMem.RGoodTray1VisionResult.Result[x, y];
                        }
                        else if ((eMapTarget)nTarget == eMapTarget.GOOD_TRAY2)
                        {
                            result = MmiGV.pShMem.RGoodTray2VisionResult.Result[x, y];
                        }
                        else if ((eMapTarget)nTarget == eMapTarget.REWORK_TRAY)
                        {
                            result = MmiGV.pShMem.RRewTrayVisionResult.Result[x, y];
                        }
                        else if ((eMapTarget)nTarget == eMapTarget.NG_TRAY)
                        {
                            result = MmiGV.pShMem.RNGTrayVisionResult.Result[x, y];
                        }
                        strTip = $"Vision Result[{x}][{y}] = {result}";

                        toolTip.SetToolTip(pViewer, strTip);
                        //pViewer.ChkUnit = null;
                    }
                }
            }
        }
        void toolTip_Popup(object sender, PopupEventArgs e)
        {
            // on popip set the size of tool tip
            e.ToolTipSize = TextRenderer.MeasureText(strTip, new Font("Tahoma", 16.0f));
        }

        void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            Font f = new Font("Tahoma", 14.0f);
            e.DrawBackground();
            e.DrawBorder();
            strTip = e.ToolTipText;
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, new PointF(2, 2));
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void Good1MapView_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        #region SCAN TRIGGER

        // The panel is laid out and its inputs are collected here, but nothing is
        // sent to SEQ yet: the shared memory DLL that carries the recipe has
        // been extended in source and still has to be rebuilt and dropped into
        // C:\WORK\DLL. SendScanTriggerRecipe() is the one place those calls go.
        //
        // The computed rows - speed, line count, scan time, pitch in encoder
        // counts - stay empty until then. Every one of them is SEQ's to work out
        // from the recipe, and working them out a second time here would give the
        // operator two answers that can disagree.
        //
        // The four inputs are entered through frm_NumPad rather than typed, the
        // same way Target UPH is on the PRODUCT panel: the machine runs on a
        // touch screen with no keyboard in front of it.

        private bool ReadScanTriggerNumPad(out double dValue)
        {
            dValue = 0.0;

            if (!frmMain.frm_NumPad.Display()) return false;

            dValue = frmMain.frm_NumPad.GetValue();
            return true;
        }

        private void btnTrigStart_Click(object sender, EventArgs e)
        {
            double dValue;
            if (!ReadScanTriggerNumPad(out dValue)) return;

            lblTrigStart.Text = dValue.ToString("F3");
            ClearScanTriggerDisplay();
        }

        private void btnTrigEnd_Click(object sender, EventArgs e)
        {
            double dValue;
            if (!ReadScanTriggerNumPad(out dValue)) return;

            lblTrigEnd.Text = dValue.ToString("F3");
            ClearScanTriggerDisplay();
        }

        private void btnTrigPitch_Click(object sender, EventArgs e)
        {
            double dValue;
            if (!ReadScanTriggerNumPad(out dValue)) return;

            lblTrigPitch.Text = dValue.ToString("F2");
            ClearScanTriggerDisplay();
        }

        private void btnTrigRate_Click(object sender, EventArgs e)
        {
            double dValue;
            if (!ReadScanTriggerNumPad(out dValue)) return;

            lblTrigRate.Text = dValue.ToString("F2");
            ClearScanTriggerDisplay();
        }

        private bool TryReadScanTriggerRecipe(out double dStart, out double dEnd,
                                              out double dPitch, out double dRate)
        {
            dStart = dEnd = dPitch = dRate = 0.0;

            if (!double.TryParse(lblTrigStart.Text, out dStart)) return false;
            if (!double.TryParse(lblTrigEnd.Text,   out dEnd))   return false;
            if (!double.TryParse(lblTrigPitch.Text, out dPitch)) return false;
            if (!double.TryParse(lblTrigRate.Text,  out dRate))  return false;

            return true;
        }

        // Only the computed rows. The state row carries the last message and is
        // written by the caller, so clearing it here would wipe what was just set.
        private void ClearScanTriggerDisplay()
        {
            lblScanTrigSpeed.Text  = "-";
            lblScanTrigLines.Text  = "-";
            lblScanTrigTime.Text   = "-";
            lblScanTrigCounts.Text = "-";
        }

        private void SendScanTriggerRecipe(double dStart, double dEnd,
                                           double dPitch, double dRate)
        {
            // Once SharedMemDll carries the recipe:
            //
            //   MmiGV.pShMem.WScanTriggerRecipe.uAxisNo    = 0;
            //   MmiGV.pShMem.WScanTriggerRecipe.dTrigStart = dStart;
            //   MmiGV.pShMem.WScanTriggerRecipe.dTrigEnd   = dEnd;
            //   MmiGV.pShMem.WScanTriggerRecipe.dPitch     = dPitch;
            //   MmiGV.pShMem.WScanTriggerRecipe.dLineRate  = dRate;
            //   MmiGV.pShMem.SetScanTriggerRecipe();
            //   MmiGV.pShMem.GetScanTriggerDisplay();
            //
            // then fill the computed rows from RScanTriggerDisplay and enable
            // START only when nValidateCode is 0.
        }

        private void btnScanTrigSet_Click(object sender, EventArgs e)
        {
            double dStart, dEnd, dPitch, dRate;

            if (!TryReadScanTriggerRecipe(out dStart, out dEnd, out dPitch, out dRate))
            {
                ClearScanTriggerDisplay();
                lblScanTrigState.Text = "BAD NUMBER";
                return;
            }

            // Only the checks that need no machine knowledge. Everything else -
            // whether the pitch is a whole number of encoder counts, whether the
            // speed fits the axis - is SEQ's to judge.
            if (dEnd <= dStart || dPitch <= 0.0 || dRate <= 0.0)
            {
                ClearScanTriggerDisplay();
                lblScanTrigState.Text = "BAD RANGE";
                return;
            }

            SendScanTriggerRecipe(dStart, dEnd, dPitch, dRate);
            lblScanTrigState.Text = "NO DLL";
        }

        private void btnScanTrigStart_Click(object sender, EventArgs e)
        {
            // MmiGV.pShMem.SetScanTriggerStart();
            lblScanTrigState.Text = "NO DLL";
        }

        private void btnScanTrigStop_Click(object sender, EventArgs e)
        {
            // MmiGV.pShMem.SetScanTriggerStop();
            lblScanTrigState.Text = "NO DLL";
        }

        #endregion
    }
}
