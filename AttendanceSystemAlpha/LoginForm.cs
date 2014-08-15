using System;

namespace AttendanceSystemAlpha
{
    public partial class LoginForm : Telerik.WinControls.UI.RadForm
    {
        private bool isLogin;

        public bool IsLogin()
        {
            return isLogin;
        }
        public LoginForm()
        {
            InitializeComponent();
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

        }
    }
}
