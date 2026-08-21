using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MMI
{
    public partial class Form_Language : Form
    {
        private FormMain frmMain = null;

        int m_iProgressValue = 0;
        string m_strSelectedLang = "";

        public Form_Language()
        {
            InitializeComponent();
        }

        public Form_Language(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            InitControl();
        }
        private void InitControl()
        {
            cbSelect.Items.Add("English");
            cbSelect.Items.Add("中 文");
            cbSelect.Items.Add("한 글");

            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            m_iProgressValue = 0;

        }
        private void btnSET_Click(object sender, EventArgs e)
        {
            btnSET.Enabled = false;
            if (cbSelect.Text.Length != 0)
            {
                if (cbSelect.Text == "English")
                {
                    m_strSelectedLang = "English";
                }
                if (cbSelect.Text == "中 文")
                {
                    m_strSelectedLang = "Chinese";
                }
                if (cbSelect.Text == "한 글")
                {
                    m_strSelectedLang = "Korean";
                }

                if(MmiGV.strCurrentLanguage != m_strSelectedLang)
                {
                    timerProgress.Enabled = true;
                    Thread thread = StartLanguageThread(m_strSelectedLang);
                }

            }
            btnSET.Enabled = true;
        }
        public Thread StartLanguageThread(String strLang)
        {
            var t = new Thread(() => LanguageThread(strLang));
            t.Start();

            return t;
        }
        public void LanguageThread(Object pObject)
        {

            String strSelectedLang = (String)pObject;

            MmiGV.strCurrentLanguage = strSelectedLang;

            XmlDocument doc = new XmlDocument();
            //XmlElement pElement; ;
            //XmlNode node;

            String file = AppDomain.CurrentDomain.BaseDirectory + "LANGUAGE\\LANG.xml";
            doc.Load(file);

            // 루트노드
            XmlNode root = doc.CreateElement("UICaption");

            XmlNodeList xnList = doc.SelectNodes("/UICaption/CaptionID");

            int index = 0;
            foreach (XmlNode xn in xnList)
            {
                int nCaptionNo = int.Parse(xn.Attributes["ID"].Value);
                string strCapName = "";
                if (strSelectedLang.Contains("English"))
                {
                    strCapName = xn.Attributes["English"].Value;
                }
                else if (strSelectedLang.Contains("Chinese"))
                {
                    strCapName = xn.Attributes["Chinese"].Value;
                }
                else if (strSelectedLang.Contains("Korean"))
                {
                    strCapName = xn.Attributes["Korean"].Value;
                }
                MmiGV.m_dicUICaption[nCaptionNo] = strCapName;
                index++;
                m_iProgressValue = index * 100 / xnList.Count;
                Thread.Sleep(1);
            }
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            if(m_iProgressValue == progressBar.Maximum)
            {
                timerProgress.Enabled = false;
                Close();
            }
        }
    }
}
