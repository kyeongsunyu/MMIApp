using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMI
{
    public partial class FormDataLampBuzzer : Form
    {
        private FormMain frmMain = null;

        public FormDataLampBuzzer()
        {
            InitializeComponent();
        }
        public FormDataLampBuzzer(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        private void FormDataLampBuzzer_Load(object sender, EventArgs e)
        {
            InitGrid();
            LoadData();
        }

        private void InitGrid()
        {
            gdLampBuzzer[0, 0] = "NO";
            gdLampBuzzer[0, 1] = "STATUS";
            gdLampBuzzer[0, 2] = "LAMP";
            gdLampBuzzer[0, 5] = "BUZZER";

            gdLampBuzzer[1, 2] = "RED";
            gdLampBuzzer[1, 3] = "YELLOW";
            gdLampBuzzer[1, 4] = "GREEEN";
            gdLampBuzzer[1, 5] = "COUNT";
            gdLampBuzzer[1, 6] = "ON TIME";
            gdLampBuzzer[1, 7] = "OFF TIME";

            gdLampBuzzer.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            CellRange rng = gdLampBuzzer.GetCellRange(0, 0, 1, 0);
            gdLampBuzzer.MergedRanges.Add(rng);

            rng = gdLampBuzzer.GetCellRange(0, 1, 1, 1);
            gdLampBuzzer.MergedRanges.Add(rng);

            rng = gdLampBuzzer.GetCellRange(0, 2, 0, 4);
            gdLampBuzzer.MergedRanges.Add(rng);

            rng = gdLampBuzzer.GetCellRange(0, 5, 0, 7);
            gdLampBuzzer.MergedRanges.Add(rng);

            gdLampBuzzer.Cols[0].Width = 70;
            gdLampBuzzer.Cols[1].Width = 670;
            gdLampBuzzer.Cols[2].Width = 100;
            gdLampBuzzer.Cols[3].Width = 100;
            gdLampBuzzer.Cols[4].Width = 100;
            gdLampBuzzer.Cols[5].Width = 100;
            gdLampBuzzer.Cols[6].Width = 100;
            gdLampBuzzer.Cols[7].Width = 100;

        }

        public void LoadData()
        {
            string sSQL = "";

            sSQL = "SELECT * FROM LAMPBUZZER ORDER BY IDX ASC";

            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderLampBuzzer))
            {
                int i = 0;
                while (SQLiteDB.ReaderLampBuzzer.Read())
                {
                    string str = SQLiteDB.ReaderLampBuzzer["IDX"].ToString();
                    if (str == "999")
                    {
                        gdLampBuzzer[2, 0] = str;
                        gdLampBuzzer[2, 1] = SQLiteDB.ReaderLampBuzzer["ITEM_NAME"].ToString();

                        MmiGV.LampBuzzerData[998, 0] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_RED"].ToString());
                        MmiGV.LampBuzzerData[998, 1] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_YELLOW"].ToString());
                        MmiGV.LampBuzzerData[998, 2] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_GREEN"].ToString());
                        MmiGV.LampBuzzerData[998, 3] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_COUNT"].ToString());
                        MmiGV.LampBuzzerData[998, 4] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_ONTIME"].ToString());
                        MmiGV.LampBuzzerData[998, 5] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_OFFTIME"].ToString());
                        UpdateData(2, 998);
                    }
                    else if (str == "1000")
                    {
                        gdLampBuzzer[3, 0] = str;
                        gdLampBuzzer[3, 1] = SQLiteDB.ReaderLampBuzzer["ITEM_NAME"].ToString();

                        MmiGV.LampBuzzerData[999, 0] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_RED"].ToString());
                        MmiGV.LampBuzzerData[999, 1] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_YELLOW"].ToString());
                        MmiGV.LampBuzzerData[999, 2] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_GREEN"].ToString());
                        MmiGV.LampBuzzerData[999, 3] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_COUNT"].ToString());
                        MmiGV.LampBuzzerData[999, 4] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_ONTIME"].ToString());
                        MmiGV.LampBuzzerData[999, 5] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_OFFTIME"].ToString());
                        UpdateData(3, 999);
                    }
                    else
                    {
                        gdLampBuzzer[i + 4, 0] = SQLiteDB.ReaderLampBuzzer["IDX"].ToString();
                        gdLampBuzzer[i + 4, 1] = SQLiteDB.ReaderLampBuzzer["ITEM_NAME"].ToString();
                        MmiGV.LampBuzzerData[i, 0] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_RED"].ToString());
                        MmiGV.LampBuzzerData[i, 1] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_YELLOW"].ToString());
                        MmiGV.LampBuzzerData[i, 2] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_GREEN"].ToString());
                        MmiGV.LampBuzzerData[i, 3] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_COUNT"].ToString());
                        MmiGV.LampBuzzerData[i, 4] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_ONTIME"].ToString());
                        MmiGV.LampBuzzerData[i, 5] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_OFFTIME"].ToString());
                        UpdateData(i + 4, i);
                    }
                    i++;
                }
                gdLampBuzzer.Rows.Count = i + 2;
                SQLiteDB.ReaderLampBuzzer.Close();
            }
        }

        public void UpdateData(int iRow, int iIdx)
        {
            switch (MmiGV.LampBuzzerData[iIdx, 0])
            {
                case 0: gdLampBuzzer[iRow, 2] = "OFF"; break;
                case 1: gdLampBuzzer[iRow, 2] = "ON"; break;
                case 2: gdLampBuzzer[iRow, 2] = "BLINK"; break;
            }
            switch (MmiGV.LampBuzzerData[iIdx, 1])
            {
                case 0: gdLampBuzzer[iRow, 3] = "OFF"; break;
                case 1: gdLampBuzzer[iRow, 3] = "ON"; break;
                case 2: gdLampBuzzer[iRow, 3] = "BLINK"; break;
            }
            switch (MmiGV.LampBuzzerData[iIdx, 2])
            {
                case 0: gdLampBuzzer[iRow, 4] = "OFF"; break;
                case 1: gdLampBuzzer[iRow, 4] = "ON"; break;
                case 2: gdLampBuzzer[iRow, 4] = "BLINK"; break;
            }

            gdLampBuzzer[iRow, 5] = MmiGV.LampBuzzerData[iIdx, 3];
            gdLampBuzzer[iRow, 6] = MmiGV.LampBuzzerData[iIdx, 4];
            gdLampBuzzer[iRow, 7] = MmiGV.LampBuzzerData[iIdx, 5];

            rdRedOFF.Checked = (MmiGV.LampBuzzerData[iIdx, 0] == 0) ? true : false;
            rdRedON.Checked = (MmiGV.LampBuzzerData[iIdx, 0] == 1) ? true : false;
            rdRedBLINK.Checked = (MmiGV.LampBuzzerData[iIdx, 0] == 2) ? true : false;

            rdYellowOFF.Checked = (MmiGV.LampBuzzerData[iIdx, 1] == 0) ? true : false;
            rdYellowON.Checked = (MmiGV.LampBuzzerData[iIdx, 1] == 1) ? true : false;
            rdYellowBLINK.Checked = (MmiGV.LampBuzzerData[iIdx, 1] == 2) ? true : false;

            rdGreenOFF.Checked = (MmiGV.LampBuzzerData[iIdx, 2] == 0) ? true : false;
            rdGreenON.Checked = (MmiGV.LampBuzzerData[iIdx, 2] == 1) ? true : false;
            rdGreenBLINK.Checked = (MmiGV.LampBuzzerData[iIdx, 2] == 2) ? true : false;

            lblBuzzerCount.Text = string.Format("{0:D4}", MmiGV.LampBuzzerData[iIdx, 3].ToString());
            lblOnTime.Text = string.Format("{0:D4}", MmiGV.LampBuzzerData[iIdx, 4].ToString());
            lblOffTime.Text = string.Format("{0:D4}", MmiGV.LampBuzzerData[iIdx, 5].ToString());

            pnGreenLamp.BackColor = 
                ((rdGreenON.Checked || rdGreenBLINK.Checked) ? Color.Lime : Color.Silver);
            pnYellowLamp.BackColor = 
                ((rdYellowON.Checked || rdYellowBLINK.Checked) ?  Color.Yellow : Color.Silver);
            pnRedLamp.BackColor = 
                ((rdRedON.Checked || rdRedBLINK.Checked) ? Color.Red : Color.Silver);

            lblTitle.Text = gdLampBuzzer[iRow, 0] + ":" + gdLampBuzzer[iRow, 1];
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            string sSQL = "";
            string sData = "";
            int iCode = 0;
            int[] iData = new int[10];

            for(int iIdx=0; iIdx<gdLampBuzzer.Rows.Count-2; iIdx++)
            {
                iCode = int.Parse(gdLampBuzzer[iIdx + 2, 0].ToString());
                for(int i=0; i < 3; i++)
                { 
                    sData = gdLampBuzzer[iIdx + 2, 2 + i].ToString();
                    if (sData.Equals("OFF"))
                    {
                        iData[i] = 0;
                    }
                    else if (sData.Equals("ON"))
                    {
                        iData[i] = 1;
                    }
                    else if (sData.Equals("BLINK"))
                    {
                        iData[i] = 2;
                    }
                }
                sSQL = "UPDATE LAMPBUZZER SET ";
                sSQL += " LAMP_RED       = " + iData[0].ToString() + ",";
                sSQL += " LAMP_YELLOW    = " + iData[1].ToString() + ",";
                sSQL += " LAMP_GREEN     = " + iData[2].ToString() + ",";
                sSQL += " BUZZER_COUNT   = " + gdLampBuzzer[iIdx + 2, 5].ToString() + ",";
                sSQL += " BUZZER_ONTIME  = " + gdLampBuzzer[iIdx + 2, 6].ToString() + ",";
                sSQL += " BUZZER_OFFTIME = " + gdLampBuzzer[iIdx + 2, 7].ToString();
                //sSQL += " IO_NUM = "         + gdLampBuzzer[iIdx + 2, 8].ToString();
                sSQL += " WHERE IDX      = " + iCode.ToString();
                SQLiteDB.Execute(sSQL);
                if(iIdx%15 == 0)
                {
                    Thread.Sleep(1);
                }
            }

            MmiGV.pShMem.WLampBuzzer.uLampBuzzer = MmiGV.LampBuzzerData;
            MmiGV.pShMem.SetLampBuzzer();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            string sSQL = "";


            sSQL = "DELETE FROM LAMPBUZZER";
            SQLiteDB.Execute(sSQL);

            sSQL = "INSERT INTO LAMPBUZZER (IDX, ITEM_NAME, LAMP_RED, LAMP_YELLOW, LAMP_GREEN, BUZZER_COUNT, BUZZER_ONTIME, BUZZER_OFFTIME)";
            sSQL += " VALUES (999, 'START', 0, 0, 1, 0, 0, 0)";
            SQLiteDB.Execute(sSQL);

            sSQL = "INSERT INTO LAMPBUZZER (IDX, ITEM_NAME, LAMP_RED, LAMP_YELLOW, LAMP_GREEN, BUZZER_COUNT, BUZZER_ONTIME, BUZZER_OFFTIME)";
            sSQL += " VALUES (1000, 'STOP', 0, 0, 0, 0, 0, 0)";
            SQLiteDB.Execute(sSQL);

            sSQL = "INSERT INTO LAMPBUZZER (IDX, ITEM_NAME)";
            sSQL += " SELECT ERROR.IDX, ERROR.ERR_NAME";
            sSQL += " FROM ERROR WHERE ERROR.IDX <= 998";
            SQLiteDB.Execute(sSQL);

            for (int iIdx = 0; iIdx < 847; iIdx++)
            {
                sSQL = "UPDATE LAMPBUZZER SET ";
                sSQL += " LAMP_RED       =    2,";
                sSQL += " LAMP_YELLOW    =    0,";
                sSQL += " LAMP_GREEN     =    0,";
                sSQL += " BUZZER_COUNT   =   50,";
                sSQL += " BUZZER_ONTIME  = 3000,";
                sSQL += " BUZZER_OFFTIME = 1000,";
                sSQL += " IO_NUM = 1";
                sSQL += " WHERE IDX      =" + (iIdx + 1).ToString();
                SQLiteDB.Execute(sSQL);
            }
            for (int iIdx = 847; iIdx < 998; iIdx++)
            {
                sSQL = "UPDATE LAMPBUZZER SET ";
                sSQL += " LAMP_RED       =    0,";
                sSQL += " LAMP_YELLOW    =    2,";
                sSQL += " LAMP_GREEN     =    0,";
                sSQL += " BUZZER_COUNT   =   5,";
                sSQL += " BUZZER_ONTIME  = 3000,";
                sSQL += " BUZZER_OFFTIME = 1000,";
                sSQL += " IO_NUM = 2";
                sSQL += " WHERE IDX      =" + (iIdx + 1).ToString();
                SQLiteDB.Execute(sSQL);
            }
            LoadData();
        }

        private void gdLampBuzzer_Click(object sender, EventArgs e)
        {
            int iRow = gdLampBuzzer.Row;
            int iIdx = int.Parse(gdLampBuzzer[iRow, 0].ToString()) - 1;
            UpdateData(iRow, iIdx);
        }

        private void gdLampBuzzer_DoubleClick(object sender, EventArgs e)
        {
            int iRow = gdLampBuzzer.Row;
            int iCol = gdLampBuzzer.Col;
            string str = gdLampBuzzer[iRow, 0].ToString();
            int iCode = int.Parse(gdLampBuzzer[iRow, 0].ToString())-1;
            uint uData = 0;

            if(iRow>0)
            {
                switch (iCol)
                {
                    case 2:
                        MmiGV.LampBuzzerData[iCode, 0]++;
                        MmiGV.LampBuzzerData[iCode, 0] = MmiGV.LampBuzzerData[iCode, 0] % 3;
                        break;
                    case 3:
                        MmiGV.LampBuzzerData[iCode, 1]++;
                        MmiGV.LampBuzzerData[iCode, 1] = MmiGV.LampBuzzerData[iCode, 1] % 3;
                        break;
                    case 4:
                        MmiGV.LampBuzzerData[iCode, 2]++;
                        MmiGV.LampBuzzerData[iCode, 2] = MmiGV.LampBuzzerData[iCode, 2] % 3;
                        break;
                    case 5:
                        if (frmMain.frm_NumPad.Display())
                        {
                            uData = (uint)frmMain.frm_NumPad.GetValue();
                            MmiGV.LampBuzzerData[iCode, 3] = (uData > 5000 ? 5000 : uData);
                        }
                        break;
                    case 6:
                        if (frmMain.frm_NumPad.Display())
                        {
                            uData = (uint)frmMain.frm_NumPad.GetValue();
                            MmiGV.LampBuzzerData[iCode, 4] = (uData > 5000 ? 5000 : uData);
                        }
                        break;
                    case 7:
                        if (frmMain.frm_NumPad.Display())
                        {
                            uData = (uint)frmMain.frm_NumPad.GetValue();
                            MmiGV.LampBuzzerData[iCode, 5] = (uData > 5000 ? 5000 : uData);
                        }
                        break;
                    case 8:
                        if (frmMain.frm_NumPad.Display())
                        {
                            uData = (uint)frmMain.frm_NumPad.GetValue();
                            MmiGV.LampBuzzerData[iCode, 6] = (uData > 5000 ? 5000 : uData);
                        }
                        break;
                }
            }
            UpdateData(iRow, iCode);
        }

        private void lblBuzzerCount_Click(object sender, EventArgs e)
        {
            int iRow = gdLampBuzzer.Row;
            int iIdx = int.Parse(gdLampBuzzer[iRow, 0].ToString()) - 1;
            uint uData = 0;

            if (frmMain.frm_NumPad.Display())
            {
                uData = (uint)frmMain.frm_NumPad.GetValue();
                MmiGV.LampBuzzerData[iIdx, 3] = (uData > 100 ? 100 : uData);
                UpdateData(iRow, iIdx);
            }
        }

        private void lblOnTime_Click(object sender, EventArgs e)
        {
            int iRow = gdLampBuzzer.Row;
            int iIdx = int.Parse(gdLampBuzzer[iRow, 0].ToString()) - 1;
            uint uData = 0;

            if (frmMain.frm_NumPad.Display())
            {
                uData = (uint)frmMain.frm_NumPad.GetValue();
                MmiGV.LampBuzzerData[iIdx, 4] = (uData > 5000 ? 5000 : uData);
                UpdateData(iRow, iIdx);
            }
        }

        private void lblOffTime_Click(object sender, EventArgs e)
        {
            int iRow = gdLampBuzzer.Row;
            int iIdx = int.Parse(gdLampBuzzer[iRow, 0].ToString()) - 1;
            uint uData = 0;

            if (frmMain.frm_NumPad.Display())
            {
                uData = (uint)frmMain.frm_NumPad.GetValue();
                MmiGV.LampBuzzerData[iIdx, 5] = (uData > 5000 ? 5000 : uData);
                UpdateData(iRow, iIdx);
            }
        }
    }
}
