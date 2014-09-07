namespace AttendanceSystemAlpha
{
    partial class FrmChooseDate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.radDateTimePicker1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 21.75F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 77);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.label2.Location = new System.Drawing.Point(161, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 52);
            this.label2.TabIndex = 17;
            this.label2.Text = "请选择时间";
            // 
            // radDateTimePicker1
            // 
            this.radDateTimePicker1.CalendarSize = new System.Drawing.Size(300, 300);
            this.radDateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.radDateTimePicker1.Font = new System.Drawing.Font("宋体", 15F);
            this.radDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.radDateTimePicker1.Location = new System.Drawing.Point(35, 122);
            this.radDateTimePicker1.Name = "radDateTimePicker1";
            this.radDateTimePicker1.ShowUpDown = true;
            this.radDateTimePicker1.Size = new System.Drawing.Size(494, 72);
            this.radDateTimePicker1.TabIndex = 19;
            this.radDateTimePicker1.TabStop = false;
            this.radDateTimePicker1.Text = "2014-09-07 13:53";
            this.radDateTimePicker1.ThemeName = "TelerikMetroTouch";
            this.radDateTimePicker1.Value = new System.DateTime(2014, 9, 7, 13, 53, 30, 7);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.radDateTimePicker1.GetChildAt(0))).Font = new System.Drawing.Font("微软雅黑", 35F);
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.radButton1.Location = new System.Drawing.Point(212, 218);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(154, 49);
            this.radButton1.TabIndex = 20;
            this.radButton1.Text = "确    定";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.radButton2.Location = new System.Drawing.Point(380, 218);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(154, 49);
            this.radButton2.TabIndex = 21;
            this.radButton2.Text = "取    消";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // FrmChooseDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 309);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radDateTimePicker1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmChooseDate";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FrmChooseDate";
            this.ThemeName = "TelerikMetroTouch";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
    }
}
