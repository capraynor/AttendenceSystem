using System;
using System.Diagnostics;
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
            } // 检查是否输入了用户名和密码
            try
            {
                _fDataModule.SetUserID(tboxUsername.Text);
                _fDataModule.SetPasswd(tboxPasswd.Text);
                _fDataModule.SetUp(Properties.Settings.Default.ServerUrl);
                isLogin = _fDataModule.login();
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("啊哦，服务器提出了一个问题：\n" + exception.Message);
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

        private void tboxUsername_Click(object sender, EventArgs e)
        {
            //弹出键盘
            try
            {
                Process.Start(@"C:/Program Files/Common Files/microsoft shared/ink/tabtip.exe");
            }
            catch (Exception)
            {

            }
            //弹出键盘
        }

        private void tboxPasswd_Click(object sender, EventArgs e)
        {
            //弹出键盘
            try
            {
                Process.Start(@"C:/Program Files/Common Files/microsoft shared/ink/tabtip.exe");
            }
            catch (Exception)
            {

            }
            //弹出键盘
        }
    }
}
