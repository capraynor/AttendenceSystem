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
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.BorderPanel = new System.Windows.Forms.Panel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.pnListBox = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.BorderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.pnListBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radButton2);
            this.radPanel2.Controls.Add(this.radButton1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 336);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(852, 78);
            this.radPanel2.TabIndex = 2;
            // 
            // radButton2
            // 
            this.radButton2.BackColor = System.Drawing.Color.White;
            this.radButton2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.radButton2.Location = new System.Drawing.Point(687, 12);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(155, 54);
            this.radButton2.TabIndex = 1;
            this.radButton2.Text = "退    出";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.radButton1.Location = new System.Drawing.Point(526, 12);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(155, 54);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "下载课程";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // BorderPanel
            // 
            this.BorderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BorderPanel.Controls.Add(this.pnListBox);
            this.BorderPanel.Controls.Add(this.radPanel1);
            this.BorderPanel.Controls.Add(this.radPanel2);
            this.BorderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BorderPanel.Location = new System.Drawing.Point(0, 0);
            this.BorderPanel.Name = "BorderPanel";
            this.BorderPanel.Size = new System.Drawing.Size(854, 416);
            this.BorderPanel.TabIndex = 4;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.LightBlue;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(852, 85);
            this.radPanel1.TabIndex = 4;
            this.radPanel1.Text = "请选择需要下载的课程";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnListBox
            // 
            this.pnListBox.Controls.Add(this.listBox1);
            this.pnListBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnListBox.Location = new System.Drawing.Point(52, 85);
            this.pnListBox.Name = "pnListBox";
            this.pnListBox.Size = new System.Drawing.Size(800, 251);
            this.pnListBox.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("微软雅黑", 21.75F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 38;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(800, 251);
            this.listBox1.TabIndex = 0;
            // 
            // RadFrmShowClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 416);
            this.Controls.Add(this.BorderPanel);
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
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.BorderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.pnListBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private System.Windows.Forms.Panel BorderPanel;
        private System.Windows.Forms.Panel pnListBox;
        private System.Windows.Forms.ListBox listBox1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
    }
}
