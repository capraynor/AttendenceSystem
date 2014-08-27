using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace AttendanceSystemAlpha
{
    public partial class OfflinePasswdForm : Telerik.WinControls.UI.RadForm
    {
        public OfflinePasswdForm()
        {
            InitializeComponent();
            if (!Properties.Settings.Default.SaveOfflinePasswd) return;
            tboxLoadpasswd.Text = Properties.Settings.Default.DownloadPasswd;
            tboxRepeatPasswd.Text = Properties.Settings.Default.DownloadPasswd;
        }

        private void rbtnFinish_Click(object sender, EventArgs e)
        {
            if (tboxLoadpasswd.Text != tboxRepeatPasswd.Text)
            {
                lbOfflinePasswdStatus.Text = "两次密码\n需一致";
                tboxRepeatPasswd.BackColor = Color.Orange;
                return;
            }
            lbOfflinePasswdStatus.Text = "           ";
            tboxRepeatPasswd.BackColor = Color.Green;
            if (!checkBox1.Checked) return;
            Properties.Settings.Default.DownloadPasswd = tboxLoadpasswd.Text;
            Properties.Settings.Default.SaveOfflinePasswd = true;
            this.tboxLoadpasswd.Text = "";
            this.tboxRepeatPasswd.Text = "";
            Properties.Settings.Default.CurrentDownloadPasswd = tboxLoadpasswd.Text;
            this.Close();
        }

        private void tboxRepeatPasswd_TextChanged(object sender, EventArgs e)
        {
            if (tboxRepeatPasswd.Text == tboxLoadpasswd.Text)
            {
                tboxRepeatPasswd.BackColor = Color.Green;
            }
            else
            {
                tboxRepeatPasswd.BackColor = Color.Orange;
            }
        }

        private void rbtnCancel_Click(object sender, EventArgs e)
        {
            this.tboxLoadpasswd.Text = "";
            this.tboxRepeatPasswd.Text = "";
            this.Close();
        }
    }
}
