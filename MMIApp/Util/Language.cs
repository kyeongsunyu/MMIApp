using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace MMI
{
    // Screen captions in English, Korean, Chinese or Vietnamese, read from text files.
    //
    // The screens are designed in English; the designer text is the English
    // caption. Language\<code>.lang (EN, KO, ZH, VI) next to MMIApp.exe gives the
    // translations, one per line, UTF-8:
    //
    //     # comment
    //     Log In|로그인                   any control or code text "Log In"
    //     @FormMain.btnMenuAuto|자동      only that control, ahead of the above
    //
    // "\n" in a line stands for a line break. Text is matched with its outer
    // spaces trimmed. A caption the file does not list stays in English, so a
    // file can be filled in a screen at a time, and a new caption needs no
    // code change, only a line in each file.
    //
    // Apply(form) walks the form's controls. A control whose text the code
    // has changed since the last language pass (a value, a status) is left
    // alone: only text that is still the designer caption, or the caption
    // this class last put there, is replaced.
    //
    // Text the code sets goes through Text("..."), which looks up the same
    // phrase lines. Forms that set captions in code listen to Changed and set
    // them again.
    static class CLanguage
    {
        public const string Folder = "Language";

        private sealed class Caption
        {
            public string Original;
            public string Applied;
        }

        private static readonly Dictionary<string, string> phrases = new Dictionary<string, string>(StringComparer.Ordinal);
        private static readonly Dictionary<string, string> controls = new Dictionary<string, string>(StringComparer.Ordinal);
        private static readonly ConditionalWeakTable<Control, Caption> texts = new ConditionalWeakTable<Control, Caption>();
        private static readonly ConditionalWeakTable<Control, Caption> titles = new ConditionalWeakTable<Control, Caption>();

        public static string Current { get; private set; } = "EN";

        public static event EventHandler Changed;

        public static string FileOf(string strLanguage)
        {
            string strExeFolder = Path.GetDirectoryName(typeof(CLanguage).Assembly.Location);
            return Path.Combine(strExeFolder, Folder, strLanguage + ".lang");
        }

        // Loads a language file. A missing file leaves every caption in
        // English and says so in the MMI log; the program still runs.
        public static bool Load(string strLanguage)
        {
            strLanguage = CSystemConfig.NormalizeLanguage(strLanguage);
            phrases.Clear();
            controls.Clear();
            Current = strLanguage;

            string strFile = FileOf(strLanguage);
            if (!File.Exists(strFile))
            {
                CThreadMMILog.GetInstance.AddMMILog("Language file not found, captions stay in English: " + strFile);
                return false;
            }

            int nLineNo = 0;
            foreach (string strRaw in File.ReadAllLines(strFile, Encoding.UTF8))
            {
                nLineNo++;
                string strLine = strRaw.Trim();
                if (strLine.Length == 0 || strLine.StartsWith("#")) continue;

                int nBar = strLine.IndexOf('|');
                if (nBar <= 0)
                {
                    CThreadMMILog.GetInstance.AddMMILog("Language file " + strLanguage + " line " + nLineNo + " has no '|', skipped");
                    continue;
                }
                string strKey = Unescape(strLine.Substring(0, nBar).Trim());
                string strText = Unescape(strLine.Substring(nBar + 1).Trim());
                if (strText.Length == 0) continue;

                if (strKey.StartsWith("@"))
                {
                    controls[strKey.Substring(1)] = strText;
                }
                else
                {
                    phrases[strKey] = strText;
                }
            }
            return true;
        }

        private static string Unescape(string s)
        {
            return s.Replace("\\n", "\r\n");
        }

        // The caption for an English phrase in the current language.
        public static string Text(string strEnglish)
        {
            if (string.IsNullOrEmpty(strEnglish)) return strEnglish;
            string strText;
            return phrases.TryGetValue(strEnglish.Trim(), out strText) ? strText : strEnglish;
        }

        // Text(format) then string.Format, for captions with numbers in them.
        public static string Format(string strEnglishFormat, params object[] args)
        {
            return string.Format(Text(strEnglishFormat), args);
        }

        public static void RaiseChanged()
        {
            EventHandler h = Changed;
            if (h != null) h(null, EventArgs.Empty);
        }

        public static void Apply(Form form)
        {
            if (form == null) return;
            string strFormName = form.GetType().Name;
            ApplyText(strFormName, form, texts, form.Text, v => form.Text = v);
            ApplyTree(strFormName, form);
        }

        private static void ApplyTree(string strFormName, Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // A screen parented into another form is applied on its own,
                // under its own name.
                if (c is Form) continue;

                // Editable boxes hold what was typed, not a caption.
                if (!(c is TextBoxBase) && !(c is ComboBox) && !(c is ListControl) && !(c is DataGridView))
                {
                    ApplyText(strFormName, c, texts, c.Text, v => c.Text = v);
                }

                HmiCard card = c as HmiCard;
                if (card != null)
                {
                    ApplyText(strFormName, c, titles, card.TitleText, v => card.TitleText = v);
                }

                if (c.HasChildren) ApplyTree(strFormName, c);
            }
        }

        private static void ApplyText(string strFormName, Control c, ConditionalWeakTable<Control, Caption> table,
                                      string strNow, Action<string> set)
        {
            Caption cap;
            if (!table.TryGetValue(c, out cap))
            {
                cap = new Caption { Original = strNow, Applied = strNow };
                table.Add(c, cap);
            }
            else if (strNow != cap.Applied && strNow != cap.Original)
            {
                // The code has put its own text there since the last pass.
                return;
            }
            if (string.IsNullOrEmpty(cap.Original)) return;

            string strText;
            if (!controls.TryGetValue(strFormName + "." + c.Name, out strText))
            {
                strText = Text(cap.Original);
            }
            if (strText != strNow) set(strText);
            cap.Applied = strText;
        }
    }
}
