
namespace MMI
{
    partial class Form_Calendar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDATE = new DevComponents.DotNetBar.ButtonX();
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // btnDATE
            // 
            this.btnDATE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDATE.BackColor = System.Drawing.Color.Black;
            this.btnDATE.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnDATE.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDATE.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDATE.Location = new System.Drawing.Point(0, 0);
            this.btnDATE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDATE.Name = "btnDATE";
            this.btnDATE.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnDATE.Size = new System.Drawing.Size(220, 37);
            this.btnDATE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDATE.TabIndex = 41;
            this.btnDATE.Tag = "1";
            this.btnDATE.Text = "YYYY-MM-DD";
            this.btnDATE.ThemeAware = true;
            // 
            // Calendar
            // 
            this.Calendar.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendar.Location = new System.Drawing.Point(0, 37);
            this.Calendar.MaximumSize = new System.Drawing.Size(500, 500);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 42;
            this.Calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateChanged);
            // 
            // Form_Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 199);
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.btnDATE);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Calendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Form_Calendar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.ButtonX btnDATE;
        public System.Windows.Forms.MonthCalendar Calendar;
    }
}