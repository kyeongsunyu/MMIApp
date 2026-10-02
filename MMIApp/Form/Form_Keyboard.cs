using System;
using System.Windows.Forms;

namespace MMI
{
    // The software keyboard CKeyboard opens when a text box is touched and
    // System Data has the input on SOFTWARE. It edits a copy of the text and
    // hands it back on OK; CANCEL leaves the box as it was. Keys typed on an
    // attached keyboard work here too, with Enter for OK and Esc for CANCEL.
    public partial class Form_Keyboard : Form
    {
        private string strText = "";
        private int nMaxLength = 32767;
        private bool bPassword = false;
        private bool bUpper = true;
        private bool bAccepted = false;

        public Form_Keyboard()
        {
            InitializeComponent();
        }

        public bool Edit(string strInitial, int nMax, bool bIsPassword, out string strResult)
        {
            strText = strInitial ?? "";
            nMaxLength = (nMax > 0) ? nMax : 32767;
            bPassword = bIsPassword;
            bAccepted = false;
            ShowKeys();
            ShowText();

            ShowDialog(CPopup.Owner);

            strResult = strText;
            return bAccepted;
        }

        private void ShowText()
        {
            lblText.Text = bPassword ? new string('●', strText.Length) : strText;
        }

        // Letter keys show the case they will type.
        private void ShowKeys()
        {
            foreach (Control c in Controls)
            {
                string strTag = Convert.ToString(c.Tag);
                if (strTag.Length == 1 && char.IsLetter(strTag[0]))
                {
                    c.Text = bUpper ? strTag.ToUpperInvariant() : strTag;
                }
            }
            btnKeyShift.Checked = bUpper;
        }

        private void Type(char ch)
        {
            if (strText.Length >= nMaxLength) return;
            strText += ch;
            ShowText();
        }

        private void Backspace()
        {
            if (strText.Length == 0) return;
            strText = strText.Substring(0, strText.Length - 1);
            ShowText();
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            string strTag = Convert.ToString(((Control)sender).Tag);
            switch (strTag)
            {
                case "BKSP":  Backspace(); break;
                case "SHIFT": bUpper = !bUpper; ShowKeys(); break;
                case "SPACE": Type(' '); break;
                case "CLEAR": strText = ""; ShowText(); break;
                default:
                    char ch = strTag[0];
                    Type(char.IsLetter(ch) && bUpper ? char.ToUpperInvariant(ch) : ch);
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bAccepted = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_Keyboard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')        btnOK_Click(sender, e);
            else if (e.KeyChar == '\x1b') btnCancel_Click(sender, e);
            else if (e.KeyChar == '\b')   Backspace();
            else if (!char.IsControl(e.KeyChar)) Type(e.KeyChar);
            e.Handled = true;
        }

        // The keys are buttons, and Enter or Space would otherwise press
        // whichever one was touched last.
        private void Form_Keyboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnOK_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true;
                Type(' ');
            }
        }
    }
}
