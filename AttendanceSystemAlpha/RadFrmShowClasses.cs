using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AttendenceSystem_Alp;
using AttendenceSystem_Alp.PC;
using Telerik.WinControls;

namespace AttendanceSystemAlpha
{
    public partial class RadFrmShowClasses : Telerik.WinControls.UI.RadForm
    {
        private long ____KKNO = 0;
        private DataModule ____fDataModule = null;
        private OfflinePasswdForm offlinePasswd = null;
        public RadFrmShowClasses(DataModule fDataModule)
        {
            ____fDataModule = fDataModule;
            offlinePasswd = new OfflinePasswdForm();
            InitializeComponent();
        }

        

        private void RadFrmShowClasses_Load(object sender, EventArgs e)
        {
            this.Width = 754;
            this.Height = 390;
            listBox1.DataSource = ____fDataModule.Context.JSANDKKVIEWRO;
            listBox1.DisplayMember = "KKNAME";
            listBox1.ValueMember = "KKNO";
            
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RadFrmShowClasses_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            offlinePasswd.ShowDialog(); //获得离线密码
            ListBox.SelectedObjectCollection checkedToDownload = listBox1.SelectedItems;
            ____fDataModule.ServerToBrief
                (Properties.Settings.Default.CurrentDownloadPasswd, checkedToDownload);
        }
    }
}
