using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace MMI
{
    // One instance of each pop-up for the whole program.
    //
    //     CPopup.Get<Form_NumPad>().Display()     modal pop-ups
    //     CPopup.Show<Form_Home>()                modeless pop-ups
    //
    // The instance is made on first use, with the main frame passed in when
    // the pop-up has a (FormMain) constructor, and is given the current
    // language and the software keyboard. Closing a modeless pop-up hides it
    // instead of disposing it, so showing it again brings back the same
    // window with its state, and a second request while it is open only
    // brings it to the front. An instance that was disposed anyway is made
    // again on the next request.
    static class CPopup
    {
        private static readonly Dictionary<Type, Form> instances = new Dictionary<Type, Form>();

        // The main frame; set once by FormMain before it makes any pop-up.
        public static FormMain Owner { get; set; }

        public static T Get<T>() where T : Form
        {
            Form frm;
            if (instances.TryGetValue(typeof(T), out frm) && !frm.IsDisposed)
            {
                return (T)frm;
            }
            T made = Create<T>();
            instances[typeof(T)] = made;
            return made;
        }

        // Shows a modeless pop-up, or brings it forward if it is already up.
        public static T Show<T>() where T : Form
        {
            T frm = Get<T>();
            if (frm.Visible)
            {
                if (frm.WindowState == FormWindowState.Minimized) frm.WindowState = FormWindowState.Normal;
                frm.Activate();
            }
            else
            {
                frm.Show();
            }
            return frm;
        }

        public static IEnumerable<Form> All
        {
            get
            {
                foreach (Form frm in instances.Values)
                {
                    if (!frm.IsDisposed) yield return frm;
                }
            }
        }

        private static T Create<T>() where T : Form
        {
            ConstructorInfo withOwner = typeof(T).GetConstructor(new[] { typeof(FormMain) });
            T frm = (withOwner != null && Owner != null)
                  ? (T)withOwner.Invoke(new object[] { Owner })
                  : (T)Activator.CreateInstance(typeof(T));

            frm.FormClosing += HideInsteadOfClose;
            CLanguage.Apply(frm);
            CKeyboard.Attach(frm);
            return frm;
        }

        private static void HideInsteadOfClose(object sender, FormClosingEventArgs e)
        {
            Form frm = (Form)sender;
            // A modal pop-up is only hidden by Close anyway; the program
            // closing takes everything with it.
            if (frm.Modal || e.CloseReason != CloseReason.UserClosing || e.Cancel) return;
            e.Cancel = true;
            frm.Hide();
        }
    }
}
