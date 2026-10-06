using System;

namespace MMI
{
    public enum eKeyboardMode
    {
        SOFTWARE = 0,   // the on-screen keyboard opens when a text box is touched
        HARDWARE = 1,   // a keyboard is attached; nothing pops up
    }

    // The settings the System Data screen owns.
    //
    // They live in MachineConfig.ini so they can also be read and changed in
    // the file. A key that is missing is written with its default the first
    // time it is read, so a new machine shows every setting in the file after
    // its first start. Values out of range are pulled back into range.
    static class CSystemConfig
    {
        public const string IniFile = "MachineConfig.ini";

        private const string SectionSystem  = "SYSTEM";
        private const string SectionMachine = "MACHINE";
        private const string SectionVision  = "VISION";

        public const int LogKeepDaysMin = 1;
        public const int LogKeepDaysMax = 3650;
        public const int LifeTimeWarnPercentMin = 50;
        public const int LifeTimeWarnPercentMax = 99;

        public static readonly string[] Languages = { "EN", "KO", "ZH", "VI" };

        public static string MachineName = "MMI";

        // Log files last written more than this many days ago are deleted,
        // MMI and SEQ logs alike.
        public static int LogKeepDays = 90;

        // Folders the log purge walks, separated by ';'. A relative folder is
        // taken from the MMI working folder. MMI writes under LOG there, SEQ
        // under C:\WORK\LOG.
        public static string LogFolders = @"LOG;C:\WORK\LOG";

        // A life time item at or past this share of its limit shows as a
        // warning; at or past the limit it shows as over.
        public static int LifeTimeWarnPercent = 90;

        public static eKeyboardMode Keyboard = eKeyboardMode.SOFTWARE;

        // The language the program starts in: EN, KO, ZH or VI.
        public static string Language = "EN";

        // Auto > VISION scan link (the line scan camera taking the lines of a
        // TRIGGER scan). Kept by the VISION screen, read and written here.
        //
        // VisionWiring says where the trigger pulses go: A into a Coaxlink I/O
        // input, the grabber passing a line trigger to the camera over
        // CoaXPress; B straight into the camera. The camera's own trigger
        // setting matches the wiring and is set up beforehand, not by the MMI.
        //
        // VisionFeaturesA / B are the grabber (Device module) features each
        // wiring needs, "Feature=Value" separated by ';', applied in order when
        // the link comes on and put back when it goes off. The defaults fit the
        // Coaxlink with the trigger on input IIN11; a different input or a
        // different firmware is changed here, in the file.
        public static string VisionWiring = "B";
        public static string VisionFeaturesA =
            "CameraControlMethod=RC;LineInputToolSelector=LIN1;LineInputToolSource=IIN11;" +
            "LineInputToolActivation=RisingEdge;CycleTriggerSource=LIN1";
        public static string VisionFeaturesB = "CameraControlMethod=NC";
        public static bool VisionScanLink = false;

        public static void Load()
        {
            CIniHelper ini = new CIniHelper(IniFile);

            MachineName = ReadString(ini, SectionMachine, "NAME", MachineName);

            LogKeepDays = Clamp(ReadInteger(ini, SectionSystem, "LOG KEEP DAYS", LogKeepDays),
                                LogKeepDaysMin, LogKeepDaysMax);
            LogFolders = ReadString(ini, SectionSystem, "LOG FOLDERS", LogFolders);
            LifeTimeWarnPercent = Clamp(ReadInteger(ini, SectionSystem, "LIFE TIME WARN PERCENT", LifeTimeWarnPercent),
                                        LifeTimeWarnPercentMin, LifeTimeWarnPercentMax);

            string strKeyboard = ReadString(ini, SectionSystem, "KEYBOARD", Keyboard.ToString());
            eKeyboardMode mode;
            Keyboard = Enum.TryParse(strKeyboard.Trim(), true, out mode) ? mode : eKeyboardMode.SOFTWARE;

            Language = NormalizeLanguage(ReadString(ini, SectionSystem, "LANGUAGE", Language));

            VisionWiring = ReadString(ini, SectionVision, "WIRING", VisionWiring).Trim().ToUpperInvariant() == "A" ? "A" : "B";
            VisionFeaturesA = ReadString(ini, SectionVision, "GRABBER FEATURES A", VisionFeaturesA);
            VisionFeaturesB = ReadString(ini, SectionVision, "GRABBER FEATURES B", VisionFeaturesB);
            VisionScanLink = ReadInteger(ini, SectionVision, "SCAN LINK", VisionScanLink ? 1 : 0) != 0;
        }

        public static void SaveVision()
        {
            CIniHelper ini = new CIniHelper(IniFile);

            ini.WriteString("WIRING", VisionWiring, SectionVision);
            ini.WriteInteger("SCAN LINK", VisionScanLink ? 1 : 0, SectionVision);
        }

        // "A=1;B=2" as ordered pairs; blanks and entries without '=' are skipped.
        public static System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>> ParseFeatures(string s)
        {
            var list = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>();
            foreach (string part in (s ?? "").Split(';'))
            {
                int i = part.IndexOf('=');
                if (i <= 0) continue;
                string k = part.Substring(0, i).Trim(), v = part.Substring(i + 1).Trim();
                if (k.Length > 0) list.Add(new System.Collections.Generic.KeyValuePair<string, string>(k, v));
            }
            return list;
        }

        public static void Save()
        {
            CIniHelper ini = new CIniHelper(IniFile);

            ini.WriteString("NAME", MachineName, SectionMachine);
            ini.WriteInteger("LOG KEEP DAYS", LogKeepDays, SectionSystem);
            ini.WriteString("LOG FOLDERS", LogFolders, SectionSystem);
            ini.WriteInteger("LIFE TIME WARN PERCENT", LifeTimeWarnPercent, SectionSystem);
            ini.WriteString("KEYBOARD", Keyboard.ToString(), SectionSystem);
            ini.WriteString("LANGUAGE", Language, SectionSystem);
        }

        public static string NormalizeLanguage(string strLanguage)
        {
            string strCode = (strLanguage ?? "").Trim().ToUpperInvariant();
            return Array.IndexOf(Languages, strCode) >= 0 ? strCode : Languages[0];
        }

        public static int Clamp(int nValue, int nMin, int nMax)
        {
            return Math.Max(nMin, Math.Min(nMax, nValue));
        }

        private static string ReadString(CIniHelper ini, string strSection, string strKey, string strDefault)
        {
            if (!ini.KeyExists(strKey, strSection))
            {
                ini.WriteString(strKey, strDefault, strSection);
                return strDefault;
            }
            return ini.ReadString(strKey, strSection);
        }

        private static int ReadInteger(CIniHelper ini, string strSection, string strKey, int nDefault)
        {
            if (!ini.KeyExists(strKey, strSection))
            {
                ini.WriteInteger(strKey, nDefault, strSection);
                return nDefault;
            }
            int nValue;
            return int.TryParse(ini.ReadString(strKey, strSection).Trim(), out nValue) ? nValue : nDefault;
        }
    }
}
