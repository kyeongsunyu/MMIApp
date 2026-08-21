using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MMI
{
    public enum CORRECTION
    {
        [Description("05")] COR_5X5 = 95,
        [Description("09")] COR_9X9 = 96,
        [Description("13")] COR_13X13 = 97,
        [Description("17")] COR_17X17 = 98,
        [Description("33")] COR_33X33 = 99
    }

    struct SEQ_EXIT
    {
        [MarshalAs(UnmanagedType.I1)] public bool bExit;

        public SEQ_EXIT(bool bExit = false)
        {
            this.bExit = bExit;
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct USER_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string strUserName;
    }


    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DEVICE_INFO
    {
        [MarshalAs(UnmanagedType.I4)]
        public int iDeviceNumber;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string strDeviceName;
    }


    public struct DEVICE_DATA
    {
        public int iTrayXCnt;
        public int iTrayYCnt;
    }

    public struct LOT_INFO
    {
        public string strLotID;
        public int LotCnt;
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

    public struct MACHINE_STATUS
    {
        public int nDeviceNo;
        public int UPH;
        public int TPH;
        public int unloadingcount;
        public int[] HomeState;
        public int inputcnt;
        public int outputcnt;
    }
}
