namespace AttendanceSystemAlpha
{
    partial class OfflinePasswdForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbOfflinePasswdStatus = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbLoadpasswd = new System.Windows.Forms.Label();
            this.tboxLoadpasswd = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tboxRepeatPasswd = new System.Windows.Forms.TextBox();
            this.rbtnFinish = new Telerik.WinControls.UI.RadButton();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.lbMsg = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radButton1);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.rbtnFinish);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 339);
            this.panel2.TabIndex = 13;
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.radButton1.Location = new System.Drawing.Point(232, 272);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(155, 54);
            this.radButton1.TabIndex = 14;
            this.radButton1.Text = "取    消";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbOfflinePasswdStatus);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.lbLoadpasswd);
            this.groupBox3.Controls.Add(this.tboxLoadpasswd);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.tboxRepeatPasswd);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(642, 258);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // lbOfflinePasswdStatus
            // 
            this.lbOfflinePasswdStatus.AutoSize = true;
            this.lbOfflinePasswdStatus.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOfflinePasswdStatus.Location = new System.Drawing.Point(554, 148);
            this.lbOfflinePasswdStatus.Name = "lbOfflinePasswdStatus";
            this.lbOfflinePasswdStatus.Size = new System.Drawing.Size(60, 54);
            this.lbOfflinePasswdStatus.TabIndex = 14;
            this.lbOfflinePasswdStatus.Text = "        \r\n        ";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(248, 219);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(191, 31);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "本次会话记住密码";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // lbLoadpasswd
            // 
            this.lbLoadpasswd.AutoSize = true;
            this.lbLoadpasswd.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLoadpasswd.Location = new System.Drawing.Point(82, 91);
            this.lbLoadpasswd.Name = "lbLoadpasswd";
            this.lbLoadpasswd.Size = new System.Drawing.Size(160, 46);
            this.lbLoadpasswd.TabIndex = 4;
            this.lbLoadpasswd.Text = "课程密码";
            // 
            // tboxLoadpasswd
            // 
            this.tboxLoadpasswd.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tboxLoadpasswd.Location = new System.Drawing.Point(248, 88);
            this.tboxLoadpasswd.Name = "tboxLoadpasswd";
            this.tboxLoadpasswd.PasswordChar = '*';
            this.tboxLoadpasswd.Size = new System.Drawing.Size(300, 54);
            this.tboxLoadpasswd.TabIndex = 5;
            this.tboxLoadpasswd.Click += new System.EventHandler(this.tboxLoadpasswd_Click);
            this.tboxLoadpasswd.TextChanged += new System.EventHandler(this.tboxRepeatPasswd_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(82, 148);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(160, 46);
            this.label27.TabIndex = 11;
            this.label27.Text = "确认密码";
            // 
            // tboxRepeatPasswd
            // 
            this.tboxRepeatPasswd.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tboxRepeatPasswd.Location = new System.Drawing.Point(248, 148);
            this.tboxRepeatPasswd.Name = "tboxRepeatPasswd";
            this.tboxRepeatPasswd.PasswordChar = '*';
            this.tboxRepeatPasswd.Size = new System.Drawing.Size(300, 54);
            this.tboxRepeatPasswd.TabIndex = 10;
            this.tboxRepeatPasswd.Click += new System.EventHandler(this.tboxRepeatPasswd_Click);
            this.tboxRepeatPasswd.TextChanged += new System.EventHandler(this.tboxRepeatPasswd_TextChanged);
            // 
            // rbtnFinish
            // 
            this.rbtnFinish.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.rbtnFinish.Location = new System.Drawing.Point(393, 272);
            this.rbtnFinish.Name = "rbtnFinish";
            this.rbtnFinish.Size = new System.Drawing.Size(155, 54);
            this.rbtnFinish.TabIndex = 3;
            this.rbtnFinish.Text = "开始下载";
            this.rbtnFinish.Click += new System.EventHandler(this.rbtnFinish_Click);
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.LightBlue;
            this.lbMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbMsg.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg.Location = new System.Drawing.Point(0, 0);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(644, 86);
            this.lbMsg.TabIndex = 14;
            this.lbMsg.Text = "请输入课程密码";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OfflinePasswdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 357);
            this.ControlBox = false;
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OfflinePasswdForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OfflinePasswdForm";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.OfflinePasswdForm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbLoadpasswd;
        private System.Windows.Forms.TextBox tboxLoadpasswd;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tboxRepeatPasswd;
        private Telerik.WinControls.UI.RadButton rbtnFinish;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.CheckBox checkBox1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private System.Windows.Forms.Label lbOfflinePasswdStatus;

    }
}
