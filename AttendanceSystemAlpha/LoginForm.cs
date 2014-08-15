using System;
using System.Drawing;
using AttendenceSystem_Alp;

namespace AttendanceSystemAlpha
{
    public partial class LoginForm : Telerik.WinControls.UI.RadForm
    {
        private bool isLogin;
        private DataModule _fDataModule;
        public bool IsLogin()
        {
            return isLogin;
        }
        public LoginForm(DataModule fDataModule)
        {
            InitializeComponent();
            this._fDataModule = fDataModule;
        }

        private void rbtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            tboxPasswd.Text = "";
            tboxUsername.Text = "";
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            isLogin = false;
        }

        private void rbtnLogin_Click(object sender, EventArgs e)
        {
            _fDataModule.SetUserID(tboxUsername.Text);
            _fDataModule.SetPasswd(tboxPasswd.Text);
            _fDataModule.SetUp(_fDataModule.GetServerUrl());
            isLogin = _fDataModule.login();
            if (isLogin)
            {
                this.lbMsg.BackColor = Color.LightBlue;
                this.Hide();
            }
            else
            {
                this.lbMsg.BackColor = Color.Red;
                lblStatus.Text = "用户名或密码错误";
            }
        }
    }
}
