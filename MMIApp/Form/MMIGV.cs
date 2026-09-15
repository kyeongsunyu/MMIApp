using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using static C1.Util.Win.Win32;
using SharedMemDll;

namespace MMI
{
    class MmiGV
    {
        #region SINGLETON
        private static readonly Lazy<MmiGV> instance = new Lazy<MmiGV>(() => new MmiGV());

        public static MmiGV GetInstance
        {
            get { return instance.Value; }
        }
        #endregion SINGLETON

        #region ENUM_VAR

        public enum eCAPTION_NAME : int
        {
            CAPTION_MAIN_MENU_AUTO = 1,
        }

        public enum eFormShowMode
        {
            MODAL = 0X01,
            MODALLESS = 0X02,
            NONVISIBLE = 0X03,
        }
        public enum eSCRNO
        {
            AUTO_VIEW       = 1,
            AUTO1           = 11,
            AUTO2           = 12,

            MANUAL_VIEW     = 2,
            MANUAL_LIST     = 21,
            MANUAL_OP       = 22,

            MOTOR_VIEW      = 3,
            MOTOR_SETTING   = 31,

            DATA_VIEW       = 4,
            DATA_RECIPE     = 41,
            DATA_SYSTEMPARAM= 42,
            DATA_OPTION     = 43,
            DATA_LAMPBUZZER = 44,
            DATA_USERREGIST = 45,
            DATA_MOTOR_CONFIG = 46,

            MONITOR_VIEW    = 5,
            MONITOR_IO      = 51,
            MONITOR_DMBIT   = 52,

            ALARM_VIEW      = 6,
            ALARM_LIST      = 61,

            LOG_VIEW        = 7,
            LOG             = 71,
            LOG_ERROR       = 72,
            LOG_MTBAMTBF    = 73,

            CALIB           = 8,
        }

        public enum eUserLevel
        {
            USER_LEVEL_NONE = 0,
            USER_LEVEL_OPERATOR = 1,
            USER_LEVEL_MAINTENANCE = 2,
            USER_LEVEL_ENGINEER = 3,
            USER_LEVEL_MASTER=4,
        }
        #endregion ENUM_VAR


        public struct TMotorConfigData
        {
            public uint uAxisNo;
            public uint uPulseRate;
            public uint uMaxSpeed;
            public uint uJogVel;
            public uint uHomeVel;
            public uint uMotorType;
            public uint uUse;
        }

        //public struct TMotorData
        //{
        //    public string[,] PosName;
        //    public double[,] PosArray;
        //    public double[,] SpeedArray;
        //    public double[,] AccelArray;
        //    public double[,] DecelArray;

        //    public TMotorData(int AxisSze, int PosSize)
        //    {
        //        PosName = new string[AxisSze, PosSize];
        //        PosArray = new double[AxisSze, PosSize];
        //        SpeedArray = new double[AxisSze, PosSize];
        //        AccelArray = new double[AxisSze, PosSize];
        //        DecelArray = new double[AxisSze, PosSize];
        //    }
        //}

        public struct TMotorData
        {
            public string[] PosName;
            public double[] dPosArray;
            public double[] dSpeedArray;
            public double[] dAccelArray;
            public double[] dDecelArray;
            public double[] iPosArray;
            public double[] iSpeedArray;
            public double[] iAccelArray;
            public double[] iDecelArray;


            public void Init(int PosSize)
            {
                PosName     = new string[PosSize];
                dPosArray   = new double[PosSize];
                dSpeedArray = new double[PosSize];
                dAccelArray = new double[PosSize];
                dDecelArray = new double[PosSize];
                iPosArray   = new double[PosSize];
                iSpeedArray = new double[PosSize];
                iAccelArray = new double[PosSize];
                iDecelArray = new double[PosSize];
            }
        }


        public struct TDMData
        {
            public string[] DMName;
            public uint[] DMValue;
            public uint[] DMSave;

            public TDMData(int nSize)
            {
                DMName = new string[nSize];
                DMValue = new uint[nSize];
                DMSave = new uint[nSize];
            }
        }

        public struct TUseSkipData
        {
            public bool[] bUseSkip1;
            public bool[] bUseSkip2;

            public TUseSkipData(int nSize)
            {
                bUseSkip1 = new bool[nSize];
                bUseSkip2 = new bool[nSize];
            }
        }

        public struct UserInfo
        {
            public static int iUserLevel;
            public static string strUserName;
            public static string strUserPassword;
        }

        public struct TErrorBuff
        {
            public string name, msg1, msg2;
            public bool type, mtba;
        }


        public static LOT_INFO LotInfo = new LOT_INFO()
        {
            strLotID = "",
            LotCnt = 0,
        };

        public static DEVICE_INFO DeviceInfo = new DEVICE_INFO()
        {
            iDeviceNumber = 0,
            strDeviceName = "",
        };

        public static CSharedMemory pShMem;

        public static bool bInitSystem = false;
        public static bool bMMIReady = false;
        public static bool bProgramExit;
        public static bool bPasswordSkip = false;

        public static int iCurrAxis = 0;
        public static int iDevNo = 1;
        public static string strCurrentDevName = ""; 
        public static int NumOf_Device = 500;
        public static int NumOf_DeviceData = 100;
        public static int iScreenNo = (int)eSCRNO.AUTO1;

        public static int iMTBAMaxRec;
        public static int iMTBADeleteRec;
        public static int iUserLevelTimeOut;
        public static uint iErrorCode = 0;
        public static uint iPrevErrorCode = 0;

        public static int iTragetUPH = 1;

        public static string strCurrentLanguage;
        public static Dictionary<int, String> m_dicUICaption = new Dictionary<int, string>();

        public static string[] strDeviceName = new string[NumOf_Device + 1];
        public static string[,] strDeviceData = new string[NumOf_Device + 1, NumOf_DeviceData + 1];
        public static double[,] dDeviceData = new double[NumOf_Device + 1, NumOf_DeviceData + 1];
        public static string[,] strPosName = new string[60, 100];
        public static string[] strAxisName = new string[60];

        public static TMotorConfigData[] mtConfigData = new TMotorConfigData[60];
        public static TMotorData[] mtData = new TMotorData[60];
        public static TMotorData[] mtSettingData = new TMotorData[60];

        public const int MAX_DM = 300;
        public static TDMData dmData = new TDMData(MAX_DM);
        public static TUseSkipData UseSkipData = new TUseSkipData(32);
        public static uint[,] LampBuzzerData = new uint[1000, 10];

        public static FormMain frmMain = new FormMain();

        public static ConcurrentDictionary<int, TErrorBuff> dicErrorList = new ConcurrentDictionary<int, TErrorBuff>();

        public static CScanTimer tmDownTime = new CScanTimer();

        public static readonly ConcurrentQueue<string> MmiLogQueue = new ConcurrentQueue<string>();
        public static readonly ConcurrentQueue<string> SeqLogQueue = new ConcurrentQueue<string>();

        public static bool bFormHomeShow = false;

        //add by chs
        #region FORM_VIEW
        public static Form ViewMainForm = null;
        public static Form bfViewMainForm = null;

        public static Form ViewAutoForm = null;
        public static Form bfViewAutoForm = null;

        public static Form ViewManualForm = null;
        public static Form bfViewManualForm = null;

        public static Form ViewMotorForm = null;
        public static Form bfViewMotorForm = null;

        public static Form ViewDataForm = null;
        public static Form bfViewDataForm = null;

        public static Form ViewMonitorForm = null;
        public static Form bfViewMonitorForm = null;

        public static Form ViewAlarmForm = null;
        public static Form bfViewAlarmForm = null;

        public static Form ViewLogForm = null;
        public static Form bfViewLogForm = null;

        #endregion FORM_VIEW



        public static void InitData()
        {
            pShMem = new CSharedMemory();
            UserInfo.strUserName = "NO USER";

            CRecipeCtl.CurMaterialRcp.LoadRcpMaterial(true);
            iDevNo = CRecipeCtl.CurMaterialRcp.Material_IDX;
            strCurrentDevName = CRecipeCtl.CurMaterialRcp.Material_NAME;

            frmMain.DisplayCurDevice();

            for (int i = 0; i < 60; i++)
            {
                mtData[i].Init(100);
                mtSettingData[i].Init(100);
            }

            //for (int i = 0; i < 60; i++)
            //{
            //    MotorSettingData[i].dPos = new double[100];
            //    MotorSettingData[i].dVel = new double[100];
            //    MotorSettingData[i].dAcc = new double[100];
            //    MotorSettingData[i].dDec = new double[100];
            //    MotorSettingData[i].iPos = new int[100];
            //    MotorSettingData[i].iVel = new int[100];
            //    MotorSettingData[i].iAcc = new int[100];
            //    MotorSettingData[i].iDec = new int[100];
            //}
        }

        public static bool ReadDM()
        {
            try
            {
                //dmData.DMValue = SeqGV.dm.Data;
                return true;
            }
            catch(Exception e)
            {
                e.Message.ToString();
            }

            return false;
        }
    }
}
