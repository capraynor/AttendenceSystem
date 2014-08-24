namespace AttendanceSystemAlpha
{
    partial class LoginForm
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
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.pnLogin = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnHead = new System.Windows.Forms.Panel();
            this.lbMsg = new System.Windows.Forms.Label();
            this.rbtnLogin = new Telerik.WinControls.UI.RadButton();
            this.rbtnCancel = new Telerik.WinControls.UI.RadButton();
            this.tboxPasswd = new System.Windows.Forms.TextBox();
            this.tboxUsername = new System.Windows.Forms.TextBox();
            this.lbPasswd = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.pnLogin.SuspendLayout();
            this.pnHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLogin
            // 
            this.pnLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLogin.Controls.Add(this.lblStatus);
            this.pnLogin.Controls.Add(this.pnHead);
            this.pnLogin.Controls.Add(this.rbtnLogin);
            this.pnLogin.Controls.Add(this.rbtnCancel);
            this.pnLogin.Controls.Add(this.tboxPasswd);
            this.pnLogin.Controls.Add(this.tboxUsername);
            this.pnLogin.Controls.Add(this.lbPasswd);
            this.pnLogin.Controls.Add(this.lbUsername);
            this.pnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLogin.Location = new System.Drawing.Point(0, 0);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(491, 289);
            this.pnLogin.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(11, 60);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 12);
            this.lblStatus.TabIndex = 7;
            // 
            // pnHead
            // 
            this.pnHead.BackColor = System.Drawing.Color.LightBlue;
            this.pnHead.Controls.Add(this.lbMsg);
            this.pnHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHead.Location = new System.Drawing.Point(0, 0);
            this.pnHead.Name = "pnHead";
            this.pnHead.Size = new System.Drawing.Size(489, 57);
            this.pnHead.TabIndex = 6;
            // 
            // lbMsg
            // 
            this.lbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMsg.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg.Location = new System.Drawing.Point(0, 0);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(489, 57);
            this.lbMsg.TabIndex = 0;
            this.lbMsg.Text = "请 登 录";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbtnLogin
            // 
            this.rbtnLogin.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnLogin.Location = new System.Drawing.Point(300, 217);
            this.rbtnLogin.Name = "rbtnLogin";
            this.rbtnLogin.Size = new System.Drawing.Size(155, 54);
            this.rbtnLogin.TabIndex = 5;
            this.rbtnLogin.Text = "登 录";
            this.rbtnLogin.ThemeName = "TelerikMetro";
            this.rbtnLogin.Click += new System.EventHandler(this.rbtnLogin_Click);
            // 
            // rbtnCancel
            // 
            this.rbtnCancel.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnCancel.Location = new System.Drawing.Point(32, 217);
            this.rbtnCancel.Name = "rbtnCancel";
            this.rbtnCancel.Size = new System.Drawing.Size(155, 54);
            this.rbtnCancel.TabIndex = 4;
            this.rbtnCancel.Text = "取 消";
            this.rbtnCancel.ThemeName = "TelerikMetro";
            this.rbtnCancel.Click += new System.EventHandler(this.rbtnCancel_Click);
            // 
            // tboxPasswd
            // 
            this.tboxPasswd.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tboxPasswd.Location = new System.Drawing.Point(167, 156);
            this.tboxPasswd.Name = "tboxPasswd";
            this.tboxPasswd.PasswordChar = '*';
            this.tboxPasswd.Size = new System.Drawing.Size(288, 39);
            this.tboxPasswd.TabIndex = 3;
            this.tboxPasswd.Text = "Relativity";
            // 
            // tboxUsername
            // 
            this.tboxUsername.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tboxUsername.Location = new System.Drawing.Point(167, 84);
            this.tboxUsername.Name = "tboxUsername";
            this.tboxUsername.Size = new System.Drawing.Size(288, 39);
            this.tboxUsername.TabIndex = 2;
            this.tboxUsername.Text = "5";
            // 
            // lbPasswd
            // 
            this.lbPasswd.AutoSize = true;
            this.lbPasswd.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPasswd.Location = new System.Drawing.Point(26, 159);
            this.lbPasswd.Name = "lbPasswd";
            this.lbPasswd.Size = new System.Drawing.Size(93, 31);
            this.lbPasswd.TabIndex = 1;
            this.lbPasswd.Text = "密 码：";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUsername.Location = new System.Drawing.Point(26, 87);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(110, 31);
            this.lbUsername.TabIndex = 0;
            this.lbUsername.Text = "用户名：";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 289);
            this.Controls.Add(this.pnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            this.pnHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbtnLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.Panel pnHead;
        private System.Windows.Forms.Label lbMsg;
        private Telerik.WinControls.UI.RadButton rbtnLogin;
        private Telerik.WinControls.UI.RadButton rbtnCancel;
        private System.Windows.Forms.TextBox tboxPasswd;
        private System.Windows.Forms.TextBox tboxUsername;
        private System.Windows.Forms.Label lbPasswd;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lblStatus;
    }
}
