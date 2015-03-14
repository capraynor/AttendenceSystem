using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AttendanceSystemAlpha
{
    public partial class frmVerifyOfflinePasswd : Telerik.WinControls.UI.RadForm
    {
        private string passwd;
        public frmVerifyOfflinePasswd(string passwd)
        {
            InitializeComponent();
            this.passwd = passwd;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == passwd)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名密码错误");
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
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
