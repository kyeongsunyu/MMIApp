using C1.Framework;
using Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMI
{
    
    public partial class Form_Map : Form
    {
        private FormMain frmMain = null;
        private int x = 0, y = 0;
        private int nTarget = 0;
        private int nShift1 = 0;
        private int nShift2 = 0;
        private int nShift3 = 0;
        private Map map = new Map();
        private int[,] SeqMap = new int[50, 50];
        private int[,] SeqVision = new int[50, 50];

        public Form_Map()
        {
            InitializeComponent();
        }

        public Form_Map(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
            this.TopLevel = true;
            this.TopMost = true;
        }

        private void Form_Map_Load(object sender, EventArgs e)
        {
            cbMap.Items.Clear();
            cbMap.Items.Add("FLIP1");
            cbMap.Items.Add("FLIP2");
            cbMap.Items.Add("PALLET1");
            cbMap.Items.Add("PALLET2");
            cbMap.Items.Add("GOOD TRAY1");
            cbMap.Items.Add("GOOD TRAY2");
            cbMap.Items.Add("REWORK TRAY");
            cbMap.Items.Add("NG TRAY");

            cbMap.SelectedIndex = nTarget;

            MapView.colors = new Color[5];
            MapView.colors[0] = Color.White;  // empty
            MapView.colors[1] = Color.Blue;   // exist
            MapView.colors[2] = Color.Green;  // good
            MapView.colors[3] = Color.Yellow; // Rework
            MapView.colors[4] = Color.Red;    // NG

            map.MapConverter = null;
            map.MapConverter = new SMECConverter();

            InitMap((eMapTarget)nTarget);
        }

        private void Form_Map_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        public void Display(eMapTarget Target)
        {
            nTarget = (int)Target;
            ShowDialog();
        }
        
        private void InitMap(eMapTarget Target)
        {
            switch (Target)
            {
                case eMapTarget.FLIPY1:
                {
                    x = (int)MmiGV.pShMem.WRecipeData.Unit_X_Count;
                    y = (int)MmiGV.pShMem.WRecipeData.Unit_Y_Count;
                    SeqMap = (int[,])MmiGV.pShMem.RFlip1Map.Map.Clone();
                    SeqVision = (int[,])MmiGV.pShMem.RFlip1VisionResult.Result.Clone();
                    nShift1 = 1;
                    nShift2 = 2;
                    nShift3 = 3;
                    break;
                }
                case eMapTarget.FLIPY2:
                {
                    x = (int)MmiGV.pShMem.WRecipeData.Unit_X_Count;
                    y = (int)MmiGV.pShMem.WRecipeData.Unit_Y_Count;
                    SeqMap = (int[,])MmiGV.pShMem.RFlip2Map.Map.Clone();
                    SeqVision = (int[,])MmiGV.pShMem.RFlip2VisionResult.Result.Clone();
                    nShift1 = 1;
                    nShift2 = 2;
                    nShift3 = 3;
                    break;
                }
                case eMapTarget.PALLETY1:
                {
                    x = (int)MmiGV.pShMem.WRecipeData.Unit_X_Count;
                    y = (int)MmiGV.pShMem.WRecipeData.Unit_Y_Count;
                    SeqMap = (int[,])MmiGV.pShMem.RPallet1Map.Map.Clone();
                    SeqVision = (int[,])MmiGV.pShMem.RPallet1VisionResult.Result.Clone();
                    nShift1 = 5;
                    nShift2 = 6;
                    nShift3 = 7;
                    break;
                }
                case eMapTarget.PALLETY2:
                {
                    x = (int)MmiGV.pShMem.WRecipeData.Unit_X_Count;
                    y = (int)MmiGV.pShMem.WRecipeData.Unit_Y_Count;
                    SeqMap = (int[,])MmiGV.pShMem.RPallet2Map.Map.Clone();
                    SeqVision = (int[,])MmiGV.pShMem.RPallet2VisionResult.Result.Clone();
                    nShift1 = 5;
                    nShift2 = 6;
                    nShift3 = 7;
                    break;
                }
                case eMapTarget.GOOD_TRAY1:
                {
                    x = (int)MmiGV.pShMem.WRecipeData.Tray_X_Count;
                    y = (int)MmiGV.pShMem.WRecipeData.Tray_Y_Count;
                    SeqMap = (int[,])MmiGV.pShMem.RGoodTray1Map.Map.Clone();
                    SeqVision = MmiGV.pShMem.RGoodTray1VisionResult.Result;
                    nShift1 = 1;
                    nShift2 = 2;
                    nShift3 = 3;
                    break;
                }
                case eMapTarget.GOOD_TRAY2:
                {
                    x = (int)MmiGV.pShMem.WRecipeData.Tray_X_Count;
                    y = (int)MmiGV.pShMem.WRecipeData.Tray_Y_Count;
                    SeqMap = (int[,])MmiGV.pShMem.RGoodTray2Map.Map.Clone();
                    SeqVision = MmiGV.pShMem.RGoodTray2VisionResult.Result;
                    nShift1 = 1;
                    nShift2 = 2;
                    nShift3 = 3;
                    break;
                }
                case eMapTarget.REWORK_TRAY:
                {
                    x = (int)MmiGV.pShMem.WRecipeData.Tray_X_Count;
                    y = (int)MmiGV.pShMem.WRecipeData.Tray_Y_Count;
                    SeqMap = (int[,])MmiGV.pShMem.RRewTrayMap.Map.Clone();
                    SeqVision = MmiGV.pShMem.RRewTrayVisionResult.Result;
                    nShift1 = 1;
                    nShift2 = 2;
                    nShift3 = 3;
                    break;
                }
                case eMapTarget.NG_TRAY:
                {
                    x = (int)MmiGV.pShMem.WRecipeData.Tray_X_Count;
                    y = (int)MmiGV.pShMem.WRecipeData.Tray_Y_Count;
                    SeqMap = (int[,])MmiGV.pShMem.RNGTrayMap.Map.Clone();
                    SeqVision = MmiGV.pShMem.RNGTrayVisionResult.Result;
                    nShift1 = 1;
                    nShift2 = 2;
                    nShift3 = 3;
                    break;
                }
            }

            UpdateMap((eMapTarget)Target);
        }

        private void UpdateMap(eMapTarget Target)
        {
            CUtil util = CUtil.GetInstance;

           
            //switch (Target)
            //{
            //    case eMapTarget.FLIPY1:
            //    {
            //        x = (int)MmiGV.pShMem.WRecipeData.Unit_X_Count;
            //        y = (int)MmiGV.pShMem.WRecipeData.Unit_Y_Count;
            //        SeqMap = MmiGV.pShMem.RFlip1Map.Map;
            //        SeqVision = MmiGV.pShMem.RFlip1VisionResult.Result;
            //        nShift1 = 1;
            //        nShift2 = 2;
            //        nShift3 = 3;
            //        break;
            //    }
            //    case eMapTarget.FLIPY2:
            //    {
            //        x = (int)MmiGV.pShMem.WRecipeData.Unit_X_Count;
            //        y = (int)MmiGV.pShMem.WRecipeData.Unit_Y_Count;
            //        SeqMap = MmiGV.pShMem.RFlip2Map.Map;
            //        SeqVision = MmiGV.pShMem.RFlip2VisionResult.Result;
            //        nShift1 = 1;
            //        nShift2 = 2;
            //        nShift3 = 3; 
            //        break;
            //    }
            //    case eMapTarget.PALLETY1:
            //    {
            //        x = (int)MmiGV.pShMem.WRecipeData.Unit_X_Count;
            //        y = (int)MmiGV.pShMem.WRecipeData.Unit_Y_Count;
            //        SeqMap = MmiGV.pShMem.RPallet1Map.Map;
            //        SeqVision = MmiGV.pShMem.RPallet1VisionResult.Result;
            //        nShift1 = 5;
            //        nShift2 = 6;
            //        nShift3 = 7; 
            //        break;
            //    }
            //    case eMapTarget.PALLETY2:
            //    {
            //        x = (int)MmiGV.pShMem.WRecipeData.Unit_X_Count;
            //        y = (int)MmiGV.pShMem.WRecipeData.Unit_Y_Count;
            //        SeqMap = MmiGV.pShMem.RPallet2Map.Map;
            //        SeqVision = MmiGV.pShMem.RPallet2VisionResult.Result;
            //        nShift1 = 5;
            //        nShift2 = 6;
            //        nShift3 = 7;
            //        break;
            //    }
            //    //case eMapTarget.GOOD_TRAY1:
            //    //{
            //    //    x = (int)MmiGV.pShMem.WRecipeData.Tray_X_Count;
            //    //    y = (int)MmiGV.pShMem.WRecipeData.Tray_Y_Count;
            //    //    SeqMap = MmiGV.pShMem.RGoodTray1Map.Map;
            //    //    SeqVision = MmiGV.pShMem.RGoodTray1VisionResult.Result;
            //    //    nShift1 = 1;
            //    //    nShift2 = 2;
            //    //    nShift3 = 3;
            //    //    break;
            //    //}
            //    //case eMapTarget.GOOD_TRAY2:
            //    //{
            //    //    x = (int)MmiGV.pShMem.WRecipeData.Tray_X_Count;
            //    //    y = (int)MmiGV.pShMem.WRecipeData.Tray_Y_Count;
            //    //    SeqMap = MmiGV.pShMem.RGoodTray2Map.Map;
            //    //    SeqVision = MmiGV.pShMem.RGoodTray2VisionResult.Result;
            //    //    nShift1 = 1;
            //    //    nShift2 = 2;
            //    //    nShift3 = 3;
            //    //    break;
            //    //}
            //    //case eMapTarget.REWORK_TRAY:
            //    //{
            //    //    x = (int)MmiGV.pShMem.WRecipeData.Tray_X_Count;
            //    //    y = (int)MmiGV.pShMem.WRecipeData.Tray_Y_Count;
            //    //    SeqMap = MmiGV.pShMem.RRewTrayMap.Map;
            //    //    SeqVision = MmiGV.pShMem.RRewTrayVisionResult.Result;
            //    //    nShift1 = 1;
            //    //    nShift2 = 2;
            //    //    nShift3 = 3;
            //    //    break;
            //    //}
            //    //case eMapTarget.NG_TRAY:
            //    //{
            //    //    x = (int)MmiGV.pShMem.WRecipeData.Tray_X_Count;
            //    //    y = (int)MmiGV.pShMem.WRecipeData.Tray_Y_Count;
            //    //    SeqMap = MmiGV.pShMem.RNGTrayMap.Map;
            //    //    SeqVision = MmiGV.pShMem.RNGTrayVisionResult.Result;
            //    //    nShift1 = 1;
            //    //    nShift2 = 2;
            //    //    nShift3 = 3;
            //    //    break;
            //    //}
            //}

            map.defUnit = new UnitData(x, y);

            for (int m = 0; m < y; m++)
            {
                for (int k = 0; k < x; k++)
                {
                    if (SeqMap[k, m] == (int)MapState.EXIST)
                    {
                        int result = SeqVision[k, m];
                        bool bRet1 = util.GetBit(result, nShift1);    // GOOD
                        bool bRet2 = util.GetBit(result, nShift2);    // REWORK
                        bool bRet3 = util.GetBit(result, nShift3);    // NG
                        if (bRet1) map.defUnit.Coloridx[k, m] = (int)MapState.GOOD;
                        else if (bRet2) map.defUnit.Coloridx[k, m] = (int)MapState.REWORK;
                        else if (bRet3) map.defUnit.Coloridx[k, m] = (int)MapState.NG;
                        else map.defUnit.Coloridx[k, m] = (int)MapState.EXIST;
                    }
                    else map.defUnit.Coloridx[k, m] = (int)MapState.EMPTY;
                    map.defUnit.msg[k, m] = (k * y + m + 1).ToString();
                }
            }
            map.Apply();
            MapView.Map = map;
        }

        private void btnAllEmpty_Click(object sender, EventArgs e)
        {
            SetAllMap(eMapState.EMPTY);
            UpdateMap((eMapTarget)nTarget);
        }

        private void btnAllExist_Click(object sender, EventArgs e)
        {
            SetAllMap(eMapState.EXIST);
            UpdateMap((eMapTarget)nTarget);
        }

        private void SetAllMap(eMapState mapState)
        {
            for(int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    SeqMap[i, j] = (int)mapState;
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if((eMapTarget)nTarget == eMapTarget.FLIPY1){
                MmiGV.pShMem.WFlip1Map.Map = SeqMap;
                MmiGV.pShMem.SetFlip1Map();

                MmiGV.pShMem.WFlip1VisionResult.Result = SeqVision;
                MmiGV.pShMem.SetFlip1VisionResult();
            }
            else if ((eMapTarget)nTarget == eMapTarget.FLIPY2)
            {
                MmiGV.pShMem.WFlip2Map.Map = SeqMap;
                MmiGV.pShMem.SetFlip2Map();

                MmiGV.pShMem.WFlip2VisionResult.Result = SeqVision;
                MmiGV.pShMem.SetFlip2VisionResult();
            }
            else if ((eMapTarget)nTarget == eMapTarget.PALLETY1)
            {
                MmiGV.pShMem.WPallet1Map.Map = SeqMap;
                MmiGV.pShMem.SetPallet1Map();

                MmiGV.pShMem.WPallet1VisionResult.Result = SeqVision;
                MmiGV.pShMem.SetPallet1VisionResult();
            }
            else if ((eMapTarget)nTarget == eMapTarget.PALLETY2)
            {
                MmiGV.pShMem.WPallet2Map.Map = SeqMap;
                MmiGV.pShMem.SetPallet2Map();

                MmiGV.pShMem.WPallet2VisionResult.Result = SeqVision;
                MmiGV.pShMem.SetPallet2VisionResult();
            }
            else if ((eMapTarget)nTarget == eMapTarget.GOOD_TRAY1)
            {
                MmiGV.pShMem.WGoodTray1Map.Map = SeqMap;
                MmiGV.pShMem.SetGoodTray1Map();
            }
            else if ((eMapTarget)nTarget == eMapTarget.GOOD_TRAY2)
            {
                MmiGV.pShMem.WGoodTray2Map.Map = SeqMap;
                MmiGV.pShMem.SetGoodTray2Map();
            }
            else if ((eMapTarget)nTarget == eMapTarget.REWORK_TRAY)
            {
                MmiGV.pShMem.WRewTrayMap.Map = SeqMap;
                MmiGV.pShMem.SetReworkTrayMap();
            }
            else if ((eMapTarget)nTarget == eMapTarget.NG_TRAY)
            {
                MmiGV.pShMem.WNGTrayMap.Map = SeqMap;
                MmiGV.pShMem.SetNGTrayMap();
            }
        }

        private void cbMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            nTarget = cbMap.SelectedIndex;
            InitMap((eMapTarget)nTarget);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
