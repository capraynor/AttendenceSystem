namespace AttendanceSystemAlpha
{
    partial class RadFrmShowClasses
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radPanel3 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).BeginInit();
            this.radPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.Font = new System.Drawing.Font("微软雅黑", 21.75F);
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "sfdsf"});
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(754, 260);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.Click += new System.EventHandler(this.checkedListBox1_Click);
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.SteelBlue;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(754, 57);
            this.radPanel1.TabIndex = 1;
            this.radPanel1.Text = "请选择需要下载的课程";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radButton2);
            this.radPanel2.Controls.Add(this.radButton1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 317);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(754, 73);
            this.radPanel2.TabIndex = 2;
            // 
            // radButton2
            // 
            this.radButton2.BackColor = System.Drawing.Color.White;
            this.radButton2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.radButton2.Location = new System.Drawing.Point(585, 8);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(157, 53);
            this.radButton2.TabIndex = 1;
            this.radButton2.Text = "退出";
            this.radButton2.ThemeName = "TelerikMetro";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold);
            this.radButton1.Location = new System.Drawing.Point(422, 8);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(157, 53);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "下载课程";
            this.radButton1.ThemeName = "TelerikMetro";
            this.radButton1.Visible = false;
            // 
            // radPanel3
            // 
            this.radPanel3.Controls.Add(this.checkedListBox1);
            this.radPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel3.Location = new System.Drawing.Point(0, 57);
            this.radPanel3.Name = "radPanel3";
            this.radPanel3.Size = new System.Drawing.Size(754, 260);
            this.radPanel3.TabIndex = 3;
            this.radPanel3.Text = "radPanel3";
            // 
            // RadFrmShowClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 390);
            this.Controls.Add(this.radPanel3);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RadFrmShowClasses";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RadFrmShowClasses";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.RadFrmShowClasses_Load);
            this.SizeChanged += new System.EventHandler(this.RadFrmShowClasses_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel3)).EndInit();
            this.radPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadPanel radPanel3;
        private Telerik.WinControls.UI.RadButton radButton2;
    }
}
