using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.RightsManagement;
using System.Text;

namespace MMI
{
    class CIniHelper   // revision 11
    {
        #region SINGLETON
        private static readonly Lazy<CIniHelper> instance = new Lazy<CIniHelper>(() => new CIniHelper());

        public static CIniHelper GetInstance
        {
            get { return instance.Value; }
        }
        #endregion SINGLETON

        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;
        //string EXE = "MachineConfig";

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);


        [DllImport("kernel32")]
        static extern int GetPrivateProfileInt(string Section, string Key, int nDefault, string lpFileName);

        [DllImport("kernel32", EntryPoint = "WritePrivateProfileInt", CallingConvention = CallingConvention.Winapi)]
        static extern long WritePrivateProfileInt(string Section, string Key, int lpDefault, string FilePath);

        public CIniHelper(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        public string ReadString(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void WriteString(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public int ReadInteger(string Key, string Section = null)
        {
            int nRet = GetPrivateProfileInt(Section ?? EXE, Key, 0, Path);
            return nRet;
        }
        public void WriteInteger(string Key, int Value, string Section =null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value.ToString(), Path);
        }


        public void DeleteKey(string Key, string Section = null)
        {
            WriteString(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            WriteString(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return ReadString(Key, Section).Length > 0;
        }
    }
}
