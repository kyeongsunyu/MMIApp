using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MMI
{
    // The software keyboard, for machines run from the touch screen alone.
    //
    // System Data chooses the input (CSystemConfig.Keyboard). With SOFTWARE,
    // touching a text box opens Form_Keyboard on its text and puts back what
    // was typed; with HARDWARE nothing pops up and an attached keyboard is
    // used. The choice is read at each touch, so a change on System Data
    // takes effect at once.
    //
    // Attach(form) hooks every editable text box on a form. It is safe to
    // call again after a form adds controls of its own: a box is hooked once.
    static class CKeyboard
    {
        // Pop-ups that carry their own keypad.
        private static readonly HashSet<string> formsWithKeypad = new HashSet<string>
        {
            "Form_Keyboard", "Form_PWD", "Form_NumPad", "Form_NumAdd", "Form_TenKey", "Form_TimeInput",
        };

        private static readonly ConditionalWeakTable<TextBox, object> hooked = new ConditionalWeakTable<TextBox, object>();

        public static bool IsSoftware
        {
            get { return CSystemConfig.Keyboard == eKeyboardMode.SOFTWARE; }
        }

        public static void Attach(Form form)
        {
            if (form == null || formsWithKeypad.Contains(form.GetType().Name)) return;
            AttachTree(form);
        }

        private static void AttachTree(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // A form parented inside this one is attached on its own.
                if (c is Form) continue;

                TextBox tb = c as TextBox;
                if (tb != null)
                {
                    object marker;
                    if (!hooked.TryGetValue(tb, out marker))
                    {
                        hooked.Add(tb, null);
                        tb.Click += TextBox_Click;
                    }
                }
                if (c.HasChildren) AttachTree(c);
            }
        }

        // Click rather than Enter: focus moving in by Tab or by the program
        // must not open the keyboard, only a touch.
        private static void TextBox_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (!IsSoftware || tb.ReadOnly || !tb.Enabled) return;

            bool bPassword = tb.UseSystemPasswordChar || tb.PasswordChar != '\0';
            string strText;
            if (!CPopup.Get<Form_Keyboard>().Edit(tb.Text, tb.MaxLength, bPassword, out strText)) return;

            tb.Text = strText;
            tb.SelectionStart = tb.TextLength;
        }
    }
}
