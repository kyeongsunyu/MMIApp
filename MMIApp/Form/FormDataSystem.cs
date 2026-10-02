using System;
using System.Drawing;
using System.Windows.Forms;

namespace MMI
{
    // Data > System Data.
    //
    // The machine-wide settings that are not part of a recipe, kept in
    // MachineConfig.ini through CSystemConfig:
    //
    //   Machine        the name at the head of the top bar
    //   Log Retention  how many days of MMI and SEQ log files are kept, and
    //                  the folders the purge walks
    //   Life Time      the share of a limit at which an item shows WARN
    //   Input          software (on-screen) or hardware keyboard
    //   Language       the language the program starts in
    //
    // Changes are staged on the screen and saved together with APPLY, which
    // asks for the password. CANCEL puts the screen back to what is saved.
    public partial class FormDataSystem : Form
    {
        private FormMain frmMain = null;

        private int nLogKeepDays;
        private int nLifeTimeWarnPercent;
        private eKeyboardMode keyboard;
        private string strLanguage;

        // The screen is being filled from the saved settings, not edited.
        private bool bFilling = false;

        public FormDataSystem()
        {
            InitializeComponent();
        }

        public FormDataSystem(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        private void FormDataSystem_Load(object sender, EventArgs e)
        {
            FillFromSaved();
        }

        private void FormDataSystem_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && !IsStaged())
            {
                FillFromSaved();
            }
        }

        private void FillFromSaved()
        {
            bFilling = true;
            txtMachineName.Text = CSystemConfig.MachineName;
            nLogKeepDays = CSystemConfig.LogKeepDays;
            nLifeTimeWarnPercent = CSystemConfig.LifeTimeWarnPercent;
            keyboard = CSystemConfig.Keyboard;
            strLanguage = CSystemConfig.Language;
            bFilling = false;

            lstLogFolders.Items.Clear();
            foreach (string strFolder in CLogRetention.Folders())
            {
                lstLogFolders.Items.Add(strFolder);
            }
            ShowStaged();
        }

        private bool IsStaged()
        {
            return txtMachineName.Text.Trim() != CSystemConfig.MachineName
                || nLogKeepDays != CSystemConfig.LogKeepDays
                || nLifeTimeWarnPercent != CSystemConfig.LifeTimeWarnPercent
                || keyboard != CSystemConfig.Keyboard
                || strLanguage != CSystemConfig.Language;
        }

        private void ShowStaged()
        {
            lblLogKeepDays.Text = nLogKeepDays.ToString();
            lblLogKeepDays.ForeColor = (nLogKeepDays != CSystemConfig.LogKeepDays) ? HmiTheme.Accent : HmiTheme.Text;
            lblLogCutOff.Text = "Files last written before "
                              + CLogRetention.CutOffFor(DateTime.Now, nLogKeepDays).ToString("yyyy-MM-dd")
                              + " are deleted.";

            lblLifeTimeWarn.Text = nLifeTimeWarnPercent.ToString();
            lblLifeTimeWarn.ForeColor = (nLifeTimeWarnPercent != CSystemConfig.LifeTimeWarnPercent) ? HmiTheme.Accent : HmiTheme.Text;

            btnKeyboardSoftware.Checked = (keyboard == eKeyboardMode.SOFTWARE);
            btnKeyboardHardware.Checked = (keyboard == eKeyboardMode.HARDWARE);

            btnLanguageEN.Checked = (strLanguage == "EN");
            btnLanguageKO.Checked = (strLanguage == "KO");
            btnLanguageZH.Checked = (strLanguage == "ZH");

            txtMachineName.ForeColor = (txtMachineName.Text.Trim() != CSystemConfig.MachineName) ? HmiTheme.Accent : HmiTheme.Text;

            lblStaged.Text = IsStaged() ? "Changes not applied." : "";
        }

        private void ShowResult(string strText, Color color)
        {
            lblResult.Text = strText;
            lblResult.ForeColor = color;
        }

        private bool ReadNumber(int nMin, int nMax, out int nValue)
        {
            nValue = 0;
            if (!frmMain.frm_NumPad.Display()) return false;

            double dValue = Math.Round(frmMain.frm_NumPad.GetValue());
            if (dValue < nMin || dValue > nMax)
            {
                ShowResult("Enter a value from " + nMin + " to " + nMax + ".", HmiTheme.Warning);
                return false;
            }
            nValue = (int)dValue;
            return true;
        }

        private void txtMachineName_TextChanged(object sender, EventArgs e)
        {
            if (bFilling) return;
            ShowStaged();
        }

        private void btnLogKeepDays_Click(object sender, EventArgs e)
        {
            int nValue;
            if (!ReadNumber(CSystemConfig.LogKeepDaysMin, CSystemConfig.LogKeepDaysMax, out nValue)) return;
            nLogKeepDays = nValue;
            ShowStaged();
        }

        private void btnLifeTimeWarn_Click(object sender, EventArgs e)
        {
            int nValue;
            if (!ReadNumber(CSystemConfig.LifeTimeWarnPercentMin, CSystemConfig.LifeTimeWarnPercentMax, out nValue)) return;
            nLifeTimeWarnPercent = nValue;
            ShowStaged();
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            keyboard = (sender == btnKeyboardHardware) ? eKeyboardMode.HARDWARE : eKeyboardMode.SOFTWARE;
            ShowStaged();
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            strLanguage = Convert.ToString(((Control)sender).Tag);
            ShowStaged();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string strName = txtMachineName.Text.Trim();
            if (strName.Length == 0)
            {
                ShowResult("The machine name cannot be empty.", HmiTheme.Warning);
                return;
            }
            if (!IsStaged())
            {
                ShowResult("Nothing to apply.", HmiTheme.TextMuted);
                return;
            }
            if (!frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo)) return;

            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            LogChange(MMILog, "Machine name", CSystemConfig.MachineName, strName);
            LogChange(MMILog, "Log keep days", CSystemConfig.LogKeepDays, nLogKeepDays);
            LogChange(MMILog, "Life time warn %", CSystemConfig.LifeTimeWarnPercent, nLifeTimeWarnPercent);
            LogChange(MMILog, "Keyboard", CSystemConfig.Keyboard, keyboard);
            LogChange(MMILog, "Language", CSystemConfig.Language, strLanguage);

            bool bKeepDaysChanged = (nLogKeepDays != CSystemConfig.LogKeepDays);

            CSystemConfig.MachineName = strName;
            CSystemConfig.LogKeepDays = nLogKeepDays;
            CSystemConfig.LifeTimeWarnPercent = nLifeTimeWarnPercent;
            CSystemConfig.Keyboard = keyboard;
            CSystemConfig.Language = strLanguage;
            CSystemConfig.Save();

            frmMain.ApplySystemConfig();
            ShowStaged();
            ShowResult("System data saved.", HmiTheme.Normal);

            // A shorter keep period takes effect now rather than within the hour.
            if (bKeepDaysChanged)
            {
                PurgeNow();
            }
        }

        private static void LogChange(CThreadMMILog MMILog, string strWhat, object before, object after)
        {
            if (Equals(before, after)) return;
            MMILog.AddMMILog("System Data " + strWhat + " : " + before + " -> " + after);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FillFromSaved();
            ShowResult("Changes discarded.", HmiTheme.TextMuted);
        }

        private void btnPurgeNow_Click(object sender, EventArgs e)
        {
            if (nLogKeepDays != CSystemConfig.LogKeepDays)
            {
                ShowResult("APPLY the keep period first; the purge uses the saved one.", HmiTheme.Warning);
                return;
            }
            PurgeNow();
        }

        private void PurgeNow()
        {
            Cursor = Cursors.WaitCursor;
            CLogRetention.Result r;
            try
            {
                r = CLogRetention.PurgeAndLog();
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (r == null)
            {
                lblPurgeResult.Text = "A purge is already running.";
                return;
            }
            lblPurgeResult.Text = string.Format("{0:HH:mm:ss}  {1} files ({2:N0} KB) and {3} folders deleted, {4} skipped.",
                DateTime.Now, r.FilesDeleted, r.BytesFreed / 1024, r.FoldersDeleted, r.Failures);
        }
    }
}
