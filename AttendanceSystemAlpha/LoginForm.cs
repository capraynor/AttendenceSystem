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
            lbMsg.BackColor = Color.LightBlue;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            isLogin = false;
        }

        private void rbtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                _fDataModule.SetUserID(tboxUsername.Text);
                _fDataModule.SetPasswd(tboxPasswd.Text);
                _fDataModule.SetUp(Properties.Settings.Default.ServerUrl);
                isLogin = _fDataModule.login();
                if (isLogin)
                {
                    lbMsg.BackColor = Color.LightBlue;
                    Hide();
                }
                else
                {
                    this.lbMsg.BackColor = Color.Red;
                    MessageBox.Show("用户名或密码错误");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("出现一个错误.请将以下信息提供给管理员\n" + exception.Message);
            }
        }

        private void pnLogin_VisibleChanged(object sender, EventArgs e)
        {
            this.Width = 491;
            this.Height = 289;
        }
    }
}
