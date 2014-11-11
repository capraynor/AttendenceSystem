using System;
using System.Drawing;
using System.Windows.Forms;
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
        public LoginForm(DataModule fDataModule , string username = "NotSpecificatedYet")
        {
            InitializeComponent();
            _fDataModule = fDataModule;
            if ("NotSpecificatedYet" != username)
            {
                tboxUsername.Text = username;
                tboxUsername.Enabled = false;
            }
            else
            {
                tboxUsername.Enabled = true;
            }

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
            if (string.IsNullOrWhiteSpace(tboxPasswd.Text) || string.IsNullOrWhiteSpace(tboxUsername.Text))
            {
                MessageBox.Show("请输入用户名或者密码");
                return;
            }
            try
            {
                _fDataModule.SetUserID(tboxUsername.Text);
                _fDataModule.SetPasswd(tboxPasswd.Text);
                _fDataModule.SetUp(Properties.Settings.Default.ServerUrl);
                isLogin = _fDataModule.login();
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("出现一个错误.请将以下信息提供给管理员\n" + exception.Message);
                return;
            }

            if (isLogin)
            {
                Hide();
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }

        private void pnLogin_VisibleChanged(object sender, EventArgs e)
        {
            this.Width = 488;
            this.Height = 309;
        }
    }
}
