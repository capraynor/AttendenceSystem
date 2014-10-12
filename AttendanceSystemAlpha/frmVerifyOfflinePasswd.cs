using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AttendanceSystemAlpha
{
    public partial class frmVerifyOfflinePasswd : Telerik.WinControls.UI.RadForm
    {
        private string passwd;
        public frmVerifyOfflinePasswd(string _passwd)
        {
            InitializeComponent();
            passwd = _passwd;
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
    }
}
