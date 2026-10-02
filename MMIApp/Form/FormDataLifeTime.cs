using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MMI
{
    // Data > Life Time.
    //
    // One row per consumable SEQ counts. The rows come from MACHINEPARAM, so
    // another machine changes its items in the DB rather than in this screen:
    //
    //   MACHINEPARAM.IDX    item number; SystemData.dData[IDX] carries the
    //                       limit to SEQ, and SEQ counts into DM 100 + IDX
    //   MACHINEPARAM.ITEM   the name shown; rows with no name are not shown
    //   MACHINEPARAM.DATA   the limit
    //   MACHINEPARAM.UNIT   the unit shown beside the counts
    //
    // Limits are staged with SET LIMIT and saved together with APPLY, which
    // asks for the password and sends the whole SystemData block to SEQ, as
    // the old System Param screen did. RESET COUNT clears the selected item's
    // count in SEQ after the part has been replaced. Neither is allowed while
    // the machine runs.
    public partial class FormDataLifeTime : Form
    {
        private FormMain frmMain = null;

        public const int CountDmBase = 100;
        public const int MaxItems = 100;   // SystemData.dData has 100 slots

        private const int ColNo      = 0;
        private const int ColItem    = 1;
        private const int ColLimit   = 2;
        private const int ColCurrent = 3;
        private const int ColRemain  = 4;
        private const int ColUse     = 5;
        private const int ColState   = 6;

        private sealed class LifeTimeItem
        {
            public int Idx;
            public string Name;
            public string Unit;
            public double Limit;
            public double StagedLimit;
            public uint Current;

            public bool IsStaged { get { return StagedLimit != Limit; } }
        }

        private readonly List<LifeTimeItem> items = new List<LifeTimeItem>();

        // The names the old System Param screen showed for SEQ's _eSysData
        // items, written into MACHINEPARAM once so the rows are not blank.
        private static readonly string[] DefaultItemNames =
        {
            "Front Picker Z1", "Front Picker Z2", "Front Picker Z3", "Front Picker Z4",
            "Front Picker Z5", "Front Picker Z6", "Front Picker Z7", "Front Picker Z8",
            "Rear Picker Z1",  "Rear Picker Z2",  "Rear Picker Z3",  "Rear Picker Z4",
            "Rear Picker Z5",  "Rear Picker Z6",  "Rear Picker Z7",  "Rear Picker Z8",
            "Sponge Clean",
            "Good Tray 1 Unload", "Good Tray 2 Unload", "Rework Tray Unload", "NG Tray Unload",
        };

        public FormDataLifeTime()
        {
            InitializeComponent();
        }

        public FormDataLifeTime(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
            SetupGrid();
        }

        // Machines set up before this screen have MACHINEPARAM rows with no
        // names (or DATA1, DATA2 placeholders). Those get the item names SEQ
        // uses; a name someone has typed is left alone.
        public static void EnsureItemNames()
        {
            for (int i = 0; i < DefaultItemNames.Length; i++)
            {
                string strSQL = "UPDATE MACHINEPARAM SET ITEM = '" + DefaultItemNames[i] + "', UNIT = 'EA'"
                              + " WHERE IDX = " + i
                              + " AND (ITEM IS NULL OR TRIM(ITEM) = '' OR ITEM = 'DATA" + (i + 1) + "')";
                SQLiteDB.Execute(strSQL);
            }
        }

        private void SetupGrid()
        {
            HmiTheme.StyleGrid(dgvLifeTime);
            dgvLifeTime.ColumnHeadersHeight = 36;
            dgvLifeTime.RowTemplate.Height = 34;

            AddColumn("No",      56,  DataGridViewContentAlignment.MiddleCenter);
            AddColumn("Item",    300, DataGridViewContentAlignment.MiddleLeft);
            AddColumn("Limit",   150, DataGridViewContentAlignment.MiddleRight);
            AddColumn("Current", 150, DataGridViewContentAlignment.MiddleRight);
            AddColumn("Remain",  150, DataGridViewContentAlignment.MiddleRight);
            AddColumn("Use",     180, DataGridViewContentAlignment.MiddleCenter);
            AddColumn("State",   90,  DataGridViewContentAlignment.MiddleCenter);
            dgvLifeTime.Columns[ColItem].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void AddColumn(string strHeader, int nWidth, DataGridViewContentAlignment align)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
            {
                HeaderText = strHeader,
                Width = nWidth,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ReadOnly = true,
            };
            col.DefaultCellStyle.Alignment = align;
            dgvLifeTime.Columns.Add(col);
        }

        private void FormDataLifeTime_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void FormDataLifeTime_VisibleChanged(object sender, EventArgs e)
        {
            tmUpdate.Enabled = Visible;
            if (Visible)
            {
                RefreshCounts();
            }
        }

        private void LoadItems()
        {
            items.Clear();
            string strSQL = "SELECT * FROM MACHINEPARAM ORDER BY IDX ASC";
            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderMachineParam))
            {
                while (SQLiteDB.ReaderMachineParam.Read())
                {
                    int nIdx = Convert.ToInt32(SQLiteDB.ReaderMachineParam["IDX"]);
                    string strName = string.Format("{0}", SQLiteDB.ReaderMachineParam["ITEM"]).Trim();
                    if (nIdx < 0 || nIdx >= MaxItems || strName.Length == 0) continue;

                    double dLimit;
                    double.TryParse(string.Format("{0}", SQLiteDB.ReaderMachineParam["DATA"]), out dLimit);

                    items.Add(new LifeTimeItem
                    {
                        Idx = nIdx,
                        Name = strName,
                        Unit = string.Format("{0}", SQLiteDB.ReaderMachineParam["UNIT"]).Trim(),
                        Limit = dLimit,
                        StagedLimit = dLimit,
                    });
                }
            }
            if (SQLiteDB.ReaderMachineParam != null) SQLiteDB.ReaderMachineParam.Close();

            dgvLifeTime.Rows.Clear();
            foreach (LifeTimeItem item in items)
            {
                dgvLifeTime.Rows.Add(item.Idx + 1, item.Name, "", "", "", "", "");
            }
            RefreshCounts();
            ShowSelected();
            lblResult.Text = items.Count + " items.";
        }

        private void tmUpdate_Tick(object sender, EventArgs e)
        {
            RefreshCounts();
        }

        private void RefreshCounts()
        {
            for (int i = 0; i < items.Count; i++)
            {
                LifeTimeItem item = items[i];
                if (MmiGV.pShMem != null)
                {
                    item.Current = MmiGV.pShMem.GetDM(CountDmBase + item.Idx);
                }
                PaintRow(i, item);
            }
            ShowSelected();
            ShowSummary();
        }

        private static double UsePercent(LifeTimeItem item)
        {
            if (item.StagedLimit <= 0) return 0;
            return item.Current * 100.0 / item.StagedLimit;
        }

        // OK / WARN / OVER against the staged limit, so a limit being edited
        // shows what it will mean before it is applied.
        private static int StateOf(LifeTimeItem item)
        {
            if (item.StagedLimit <= 0) return 0;
            double dUse = UsePercent(item);
            if (dUse >= 100) return 2;
            if (dUse >= CSystemConfig.LifeTimeWarnPercent) return 1;
            return 0;
        }

        private static Color StateColor(int nState)
        {
            switch (nState)
            {
                case 2:  return HmiTheme.Alarm;
                case 1:  return HmiTheme.Warning;
                default: return HmiTheme.Normal;
            }
        }

        private static string StateText(int nState)
        {
            switch (nState)
            {
                case 2:  return "OVER";
                case 1:  return "WARN";
                default: return "OK";
            }
        }

        private string WithUnit(double dValue, string strUnit)
        {
            return dValue.ToString("N0") + (strUnit.Length > 0 ? " " + strUnit : "");
        }

        private void PaintRow(int nRow, LifeTimeItem item)
        {
            DataGridViewRow row = dgvLifeTime.Rows[nRow];
            int nState = StateOf(item);
            double dRemain = Math.Max(0, item.StagedLimit - item.Current);

            row.Cells[ColLimit].Value = WithUnit(item.StagedLimit, item.Unit);
            row.Cells[ColLimit].Style.ForeColor = item.IsStaged ? HmiTheme.Accent : HmiTheme.Text;
            row.Cells[ColCurrent].Value = WithUnit(item.Current, item.Unit);
            row.Cells[ColRemain].Value = WithUnit(dRemain, item.Unit);
            row.Cells[ColUse].Value = UsePercent(item).ToString("F1") + " %";
            row.Cells[ColState].Value = StateText(nState);
            row.Cells[ColState].Style.ForeColor = StateColor(nState);
        }

        // The use column is drawn as a bar so worn parts stand out down the
        // list without reading every number.
        private void dgvLifeTime_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != ColUse || e.RowIndex >= items.Count) return;

            LifeTimeItem item = items[e.RowIndex];
            e.PaintBackground(e.CellBounds, true);

            Rectangle track = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 8,
                                            e.CellBounds.Width - 16, e.CellBounds.Height - 16);
            using (SolidBrush b = new SolidBrush(HmiTheme.Control))
            {
                e.Graphics.FillRectangle(b, track);
            }
            double dUse = Math.Min(100, UsePercent(item));
            int nFill = (int)(track.Width * dUse / 100.0);
            if (nFill > 0)
            {
                using (SolidBrush b = new SolidBrush(StateColor(StateOf(item))))
                {
                    e.Graphics.FillRectangle(b, new Rectangle(track.X, track.Y, nFill, track.Height));
                }
            }
            TextRenderer.DrawText(e.Graphics, Convert.ToString(e.FormattedValue), HmiTheme.FontBold, track,
                HmiTheme.Text, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            e.Handled = true;
        }

        private LifeTimeItem SelectedItem()
        {
            if (dgvLifeTime.CurrentRow == null) return null;
            int nRow = dgvLifeTime.CurrentRow.Index;
            return (nRow >= 0 && nRow < items.Count) ? items[nRow] : null;
        }

        private void dgvLifeTime_SelectionChanged(object sender, EventArgs e)
        {
            ShowSelected();
        }

        private void ShowSelected()
        {
            LifeTimeItem item = SelectedItem();
            if (item == null)
            {
                lblSelName.Text = "-";
                lblSelLimit.Text = "-";
                lblSelCurrent.Text = "-";
                lblSelRemain.Text = "-";
                lblSelUse.Text = "-";
                lblSelUse.ForeColor = HmiTheme.Text;
                lblSelDm.Text = "-";
                return;
            }
            int nState = StateOf(item);
            lblSelName.Text = item.Name;
            lblSelLimit.Text = WithUnit(item.StagedLimit, item.Unit) + (item.IsStaged ? "  (not applied)" : "");
            lblSelCurrent.Text = WithUnit(item.Current, item.Unit);
            lblSelRemain.Text = WithUnit(Math.Max(0, item.StagedLimit - item.Current), item.Unit);
            lblSelUse.Text = UsePercent(item).ToString("F1") + " %  " + StateText(nState);
            lblSelUse.ForeColor = StateColor(nState);
            lblSelDm.Text = "DM " + (CountDmBase + item.Idx) + "   /   SystemData " + item.Idx;
        }

        private void ShowSummary()
        {
            int nWarn = 0, nOver = 0, nStaged = 0;
            foreach (LifeTimeItem item in items)
            {
                int nState = StateOf(item);
                if (nState == 1) nWarn++;
                if (nState == 2) nOver++;
                if (item.IsStaged) nStaged++;
            }
            lblSumOver.Text = nOver.ToString();
            lblSumOver.ForeColor = nOver > 0 ? HmiTheme.Alarm : HmiTheme.Text;
            lblSumWarn.Text = nWarn.ToString();
            lblSumWarn.ForeColor = nWarn > 0 ? HmiTheme.Warning : HmiTheme.Text;
            lblSumStaged.Text = nStaged.ToString();
            lblSumStaged.ForeColor = nStaged > 0 ? HmiTheme.Accent : HmiTheme.Text;
            lblWarnRule.Text = "WARN from " + CSystemConfig.LifeTimeWarnPercent + " % of the limit, OVER at the limit."
                             + " The percentage is set on System Data.";
        }

        private bool MachineRunning()
        {
            if (MmiGV.dmData.DMValue[1] != 1) return false;
            lblResult.Text = "Not while the machine runs.";
            lblResult.ForeColor = HmiTheme.Warning;
            return true;
        }

        private void ShowResult(string strText, Color color)
        {
            lblResult.Text = strText;
            lblResult.ForeColor = color;
        }

        private void btnSetLimit_Click(object sender, EventArgs e)
        {
            LifeTimeItem item = SelectedItem();
            if (item == null) return;
            if (!frmMain.frm_NumPad.Display()) return;

            double dValue = Math.Round(frmMain.frm_NumPad.GetValue());
            if (dValue < 0)
            {
                ShowResult("A limit cannot be negative.", HmiTheme.Warning);
                return;
            }
            item.StagedLimit = dValue;
            RefreshCounts();
            ShowResult(item.Name + ": limit " + dValue.ToString("N0") + " staged. APPLY saves it.", HmiTheme.Accent);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (MachineRunning()) return;

            bool bAnyStaged = items.Exists(i => i.IsStaged);
            if (!bAnyStaged)
            {
                ShowResult("Nothing to apply.", HmiTheme.TextMuted);
                return;
            }
            if (!frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo)) return;

            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            foreach (LifeTimeItem item in items)
            {
                if (!item.IsStaged) continue;
                SQLiteDB.Execute("UPDATE MACHINEPARAM SET DATA = '" + item.StagedLimit + "' WHERE IDX = " + item.Idx);
                MMILog.AddMMILog("Life Time limit " + item.Name + " : " + item.Limit + " -> " + item.StagedLimit);
                item.Limit = item.StagedLimit;
                MmiGV.pShMem.WSystemData.dData[item.Idx] = item.Limit;
            }
            MmiGV.pShMem.SetSystemData();

            RefreshCounts();
            ShowResult("Limits saved and sent to SEQ.", HmiTheme.Normal);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (LifeTimeItem item in items)
            {
                item.StagedLimit = item.Limit;
            }
            RefreshCounts();
            ShowResult("Staged limits discarded.", HmiTheme.TextMuted);
        }

        private void btnResetCount_Click(object sender, EventArgs e)
        {
            LifeTimeItem item = SelectedItem();
            if (item == null) return;
            if (MachineRunning()) return;
            if (!frmMain.frm_Msg.Display("Reset the count of " + item.Name + " to 0?\r\nDo this after the part has been replaced.")) return;
            if (!frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo)) return;

            uint uBefore = MmiGV.pShMem.GetDM(CountDmBase + item.Idx);
            MmiGV.pShMem.SetDM(CountDmBase + item.Idx, 0);
            CThreadMMILog.GetInstance.AddMMILog("Life Time count reset " + item.Name + " : " + uBefore + " -> 0");

            RefreshCounts();
            ShowResult(item.Name + ": count reset.", HmiTheme.Normal);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadItems();
            ShowResult("Reloaded from the DB.", HmiTheme.TextMuted);
        }
    }
}
