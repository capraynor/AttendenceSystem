using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
            this.Close();
        }

        private void rbtnFinish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tboxLoadpasswd.Text))
            {
                lbOfflinePasswdStatus.Text = "请输入\n课程密码";
            }
            if (tboxLoadpasswd.Text != tboxRepeatPasswd.Text)
            {
                lbOfflinePasswdStatus.Text = "两次密码\n需一致";
                tboxRepeatPasswd.BackColor = Color.Orange;
                return;
            }
            Properties.Settings.Default.CurrentDownloadPasswd = tboxLoadpasswd.Text;
            lbOfflinePasswdStatus.Text = "           ";
            //if (checkBox1.Checked)
            //{
            //    Properties.Settings.Default.DownloadPasswd = tboxLoadpasswd.Text;
            //    Properties.Settings.Default.SaveOfflinePasswd = true;
                
            //}
            this.tboxLoadpasswd.Text = "";
            this.tboxRepeatPasswd.Text = "";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tboxRepeatPasswd_TextChanged(object sender, EventArgs e)
        {
            //if (tboxRepeatPasswd.Text == tboxLoadpasswd.Text)
            //{
            //    lbOfflinePasswdStatus.BackColor = Color.Green;
            //    lbOfflinePasswdStatus.Text = "输入正确";
            //}
            //else
            //{
            //    lbOfflinePasswdStatus.BackColor = Color.Orange;
            //    lbOfflinePasswdStatus.Text = "两次密码\n需一致";
            //}
        }

        private void OfflinePasswdForm_Load(object sender, EventArgs e)
        {
            this.Width = 644;
            this.Height = 357;
            if (Properties.Settings.Default.SaveOfflinePasswd)
            {
                tboxRepeatPasswd.Text = tboxLoadpasswd.Text = Properties.Settings.Default.DownloadPasswd;
            }
            tboxRepeatPasswd.BackColor = Color.White;
            lbOfflinePasswdStatus.BackColor = Color.White;
            lbOfflinePasswdStatus.Text = "          ";

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tboxLoadpasswd_Click(object sender, EventArgs e)
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

        private void tboxRepeatPasswd_Click(object sender, EventArgs e)
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
