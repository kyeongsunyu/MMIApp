using C1.Win.C1FlexGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static C1.Util.Win.Win32;
using WMPLib;

namespace MMI
{
    public partial class FormAlarmList : Form
    {
        private FormMain frmMain = null;

        private int iAlarmCode;

        WindowsMediaPlayer wmp = new WindowsMediaPlayer();

        public FormAlarmList()
        {
            InitializeComponent();
        }
        public FormAlarmList(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        private void FormAlarmList_Load(object sender, EventArgs e)
        {
            InitGrid();
            InitControl();

            InitScreen();
            DisplayData();
        }

        private void FormAlarmList_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        private void InitGrid()
        {
            gdAlarm[0, 0] = "CODE";
            gdAlarm[0, 1] = "ALARM LIST";

            gdAlarm.Cols[0].Width = 80;
            gdAlarm.Cols[1].Width = 575;
            
            gdAlarm.Cols[0].StyleFixed.Font = new Font("Tahoma", 14, FontStyle.Bold);
            gdAlarm.Cols[1].StyleFixed.Font = new Font("Tahoma", 14, FontStyle.Bold);

            gdAlarm.Cols[0].StyleFixed.TextAlign = TextAlignEnum.CenterCenter;
            gdAlarm.Cols[1].StyleFixed.TextAlign = TextAlignEnum.CenterCenter;

            gdAlarm.Cols[0].Style.Font = new Font("Tahoma", 12, FontStyle.Bold);
            gdAlarm.Cols[1].Style.Font = new Font("Tahoma", 12, FontStyle.Bold);
            
            gdAlarm.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            gdAlarm.Cols[1].TextAlign = TextAlignEnum.LeftCenter;

            gdAlarm.Cols[1].AllowEditing = false;
            gdAlarm.Cols[1].StyleNew.BackColor = Color.Bisque;
        }
        private void InitControl()
        {
            pictureErrPoint.BackColor = Color.Transparent;
            pictureErrPoint.Parent = pictureBox;
            pictureErrPoint.Location = new Point(0, 0);

            pictureBox.Enabled = false;

            txtOccurrenceFactor.ReadOnly = true;
            txtTroubleShooting.ReadOnly = true;

            btnImageOpen.Visible = false;

            //wmp.URL = AppDomain.CurrentDomain.BaseDirectory + "MP3\\alarm1.mp3";
            wmp.controls.stop();
        }

        private void InitScreen()
        {
            String strSQL = "";

            #region AUTORUN_RECORD
            strSQL = "SELECT * FROM ERROR WHERE IDX = 9998";
            if(SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderAlarm))
            {
                if (!SQLiteDB.ReaderAlarm.Read())
                {
                    strSQL = "INSERT INTO ERROR (IDX, ERR_NAME)";
                    strSQL += " VALUES(9998, 'AUTO RUN')";
                    SQLiteDB.Execute(strSQL);
                }
                SQLiteDB.ReaderAlarm.Close();
            }
            #endregion AUTORUN_RECORD

            #region STOP_RECORD
            strSQL = "SELECT * FROM ERROR WHERE IDX = 9999";
            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderAlarm))
            {
                if (!SQLiteDB.ReaderAlarm.Read())
                {
                    strSQL = "INSERT INTO ERROR (IDX, ERR_NAME)";
                    strSQL += " VALUES(9999, 'STOP')";
                    SQLiteDB.Execute(strSQL);
                }
                SQLiteDB.ReaderAlarm.Close();
            }
            #endregion STOP_RECORD

            #region ALARM_RECORD
            strSQL = "SELECT * FROM ERROR WHERE IDX <= 3000 ORDER BY IDX ASC";
            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderAlarm))
            {
                for (int i = 0; i < 2000; i++)
                {
                    if (SQLiteDB.ReaderAlarm.Read())
                    {
                        gdAlarm[i + 1, 0] = SQLiteDB.ReaderAlarm["IDX"].ToString();
                        gdAlarm[i + 1, 1] = SQLiteDB.ReaderAlarm["ERR_NAME"].ToString();
                        gdAlarm[i + 1, 2] = SQLiteDB.ReaderAlarm["ERR_DEBUG1"].ToString();
                        gdAlarm[i + 1, 3] = SQLiteDB.ReaderAlarm["ERR_DEBUG2"].ToString();
                        gdAlarm[i + 1, 4] = SQLiteDB.ReaderAlarm["TYPE"].ToString().ToUpper() == "TRUE" ? -1 : 0;
                        gdAlarm[i + 1, 5] = SQLiteDB.ReaderAlarm["MTBA"].ToString().ToUpper() == "TRUE" ? -1 : 0;
                        gdAlarm[i + 1, 6] = SQLiteDB.ReaderAlarm["FILE_NAME"].ToString();
                        gdAlarm[i + 1, 7] = SQLiteDB.ReaderAlarm["POS_X"].ToString();
                        gdAlarm[i + 1, 8] = SQLiteDB.ReaderAlarm["POS_Y"].ToString();
                    }
                    else
                    {
                        strSQL = "INSERT INTO ERROR (IDX, ERR_NAME) ";
                        strSQL += " VALUES (" + (i + 1).ToString() + "," + "' '" + ")";
                        SQLiteDB.Execute(strSQL);
                    }
                }
            }
            SQLiteDB.ReaderAlarm.Close();
            #endregion ALARM_RECORD
        }

        private void DisplayData()
        {
            int iErrPosX, iErrPosY;

            string sBMP = "";

            iAlarmCode = int.Parse(gdAlarm[gdAlarm.Row, 0].ToString());
            txtOccurrenceFactor.Text = gdAlarm[gdAlarm.Row, 2].ToString();
            txtTroubleShooting.Text = gdAlarm[gdAlarm.Row, 3].ToString();

            sBMP = gdAlarm[gdAlarm.Row, 6].ToString();
            //btnImageOpen.Text = sBMP;

            // File.Exists, not Directory.Exists: sBMP is a path to a bitmap, so the
            // old test could never be true and the alarm's own image was never
            // shown - every alarm fell through to the default.
            if (!File.Exists(sBMP))
            {
                sBMP = AppDomain.CurrentDomain.BaseDirectory + "ErrorImage\\Default.bmp";
            }

            // ErrorImage\ lives under the build output, which .gitignore excludes,
            // so a fresh clone has neither the alarm images nor the default. The
            // alarm code and its text are what the operator needs; a missing
            // picture must not take the screen down with a DirectoryNotFound.
            if (File.Exists(sBMP))
            {
                try
                {
                    pictureBox.Load(sBMP);
                }
                catch (Exception ex)
                {
                    pictureBox.Image = null;
                    Console.WriteLine("Alarm image load failed: {0}", ex.Message);
                }
            }
            else
            {
                pictureBox.Image = null;
                Console.WriteLine("Alarm image not found: {0}", sBMP);
            }

            try
            {
                iErrPosX = int.Parse(gdAlarm[gdAlarm.Row, 7].ToString());
            }
            catch (FormatException ex)
            {
                iErrPosX = 0;
                Console.WriteLine("Format Exception Error : {0}", ex.Message);
            }

            try
            {
                iErrPosY = int.Parse(gdAlarm[gdAlarm.Row, 8].ToString());
            }
            catch (FormatException ex)
            {
                iErrPosY = 0;
                Console.WriteLine("Format Exception Error : {0}", ex.Message);
            }
            pictureErrPoint.Left = iErrPosX - pictureErrPoint.Width / 2;
            pictureErrPoint.Top = iErrPosY - pictureErrPoint.Height / 2;

            string strAlarm = gdAlarm[gdAlarm.Row, 1].ToString().Trim();
            if(string.IsNullOrEmpty(strAlarm) || strAlarm=="")
            {
                pictureErrPoint.Visible = false;
            }
            else
            {
                pictureErrPoint.Visible = true;
            }
        }

        private void gdAlarm_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void gdAlarm_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            String strSQL = "";

            if (iAlarmCode > 0)
            {
                if (e.Col == 1)
                {
                    strSQL = "UPDATE ERROR SET";
                    strSQL += " ERR_NAME = '" + gdAlarm[e.Row, e.Col].ToString() + "'";
                    strSQL += " WHERE IDX = " + e.Row;

                    SQLiteDB.Execute(strSQL);
                }
            }
        }

        private void txtOccurrenceFactor_Leave(object sender, EventArgs e)
        {
            String strSQL = "";

            if (iAlarmCode > 0)
            {
                gdAlarm[gdAlarm.Row, 2] = txtOccurrenceFactor.Text;
                strSQL = "UPDATE ERROR SET";
                strSQL += " ERR_DEBUG1 = '" + txtOccurrenceFactor.Text + "'";
                strSQL += " WHERE IDX = " + iAlarmCode;

                SQLiteDB.Execute(strSQL);
            }
        }

        private void txtTroubleShooting_Leave(object sender, EventArgs e)
        {
            String strSQL = "";

            if (iAlarmCode > 0)
            {
                gdAlarm[gdAlarm.Row, 3] = txtTroubleShooting.Text;
                strSQL = "UPDATE ERROR SET";
                strSQL += " ERR_DEBUG2 = '" + txtTroubleShooting.Text + "'";
                strSQL += " WHERE IDX = " + iAlarmCode.ToString();

                SQLiteDB.Execute(strSQL);
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            String strSQL = "";

            pictureErrPoint.Left = e.X - pictureErrPoint.Width / 2;
            pictureErrPoint.Top = e.Y - pictureErrPoint.Height / 2;

            if (iAlarmCode > 0)
            {
                gdAlarm[gdAlarm.Row, 7] = e.X;
                gdAlarm[gdAlarm.Row, 8] = e.Y;

                strSQL = "UPDATE ERROR SET";
                strSQL += " POS_X = '" + e.X.ToString() + "',";
                strSQL += " POS_Y = '" + e.Y.ToString() + "'";

                strSQL += " WHERE IDX = " + iAlarmCode.ToString();

                SQLiteDB.Execute(strSQL);
            }
        }

        private void btnImageOpen_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            if (iAlarmCode > 0)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Load(openFileDialog.FileName);
                    //btnImageOpen.Text = openFileDialog.FileName;
                    gdAlarm[gdAlarm.Row, 6] = openFileDialog.FileName;

                    strSQL = "UPDATE ERROR SET";
                    strSQL += " FILE_NAME = '" + openFileDialog.FileName + "'";
                    strSQL += " WHERE IDX = " + iAlarmCode.ToString();

                    SQLiteDB.Execute(strSQL);

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(btnEdit.Checked)
            {
                btnEdit.Checked= false;
                gdAlarm.Cols[1].AllowEditing = false;
                gdAlarm.Cols[1].StyleNew.BackColor = Color.Bisque;

                pictureBox.Enabled = false;

                txtOccurrenceFactor.ReadOnly = true;
                txtOccurrenceFactor.BackColor = SystemColors.GradientInactiveCaption;
                
                txtTroubleShooting.ReadOnly = true;
                txtTroubleShooting.BackColor = SystemColors.GradientInactiveCaption;

                btnImageOpen.Visible = false;
            }
            else
            {
                btnEdit.Checked= true;
                gdAlarm.Cols[1].AllowEditing = true;
                gdAlarm.Cols[1].StyleNew.BackColor = Color.White;

                pictureBox.Enabled = true;

                txtOccurrenceFactor.ReadOnly = false;
                txtOccurrenceFactor.BackColor = Color.White;

                txtTroubleShooting.ReadOnly = false;
                txtTroubleShooting.BackColor = Color.White;

                btnImageOpen.Visible = true;
            }
        }

        private void btnMP3Play_Click(object sender, EventArgs e)
        {
            if (gdAlarm.Row > 0)
            {
                int iErrorCode = int.Parse(gdAlarm[gdAlarm.Row, 0].ToString());
                PlayMP3(iErrorCode);
            }
        }

        private void btnMP3Stop_Click(object sender, EventArgs e)
        {
            wmp.controls.stop();
        }
        private void PlayMP3(int code)
        {
            wmp.URL = AppDomain.CurrentDomain.BaseDirectory + "MP3\\Alarm" + code.ToString();
            wmp.controls.play();
        }
    }
}
