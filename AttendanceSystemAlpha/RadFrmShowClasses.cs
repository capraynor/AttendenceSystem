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

        private void checkedListBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked) return;
            for (int i = 0; i < ((CheckedListBox)sender).Items.Count; i++)
            {
                ((CheckedListBox)sender).SetItemChecked(i, false);
            }
            e.NewValue = CheckState.Checked;
            offlinePasswd.ShowDialog(); //获得离线密码
            CheckedListBox.SelectedObjectCollection checkedToDownload = checkedListBox1.SelectedItems;
            ____fDataModule.ServerToBriefcase(Properties.Settings.Default.CurrentDownloadPasswd, checkedToDownload);
            //MessageBox.Show(((IQueryable<JSANDKKVIEWRO>) checkedToDownload).First().KKNAME + "下载完成");
            foreach (JSANDKKVIEWRO jsandkkviewro in checkedToDownload)
            {
                
                MessageBox.Show(jsandkkviewro.KKNAME + "下载完成");
                break;
            }
            

            //todo : 调出离线密码框 获得离线密码 下载数据。操作在此进行 
            //todo： 点名：点击 开始点名 弹出提示框 返回选择的课程并开始点名 所有的操作在mainform中进行
            //todo: 结束点名 新增 密码验证

        }

        private void RadFrmShowClasses_Load(object sender, EventArgs e)
        {
            this.Width = 754;
            this.Height = 390;
            checkedListBox1.DataSource = ____fDataModule.Context.JSANDKKVIEWRO;
            checkedListBox1.DisplayMember = "KKNAME";
            checkedListBox1.ValueMember = "KKNO";
            
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RadFrmShowClasses_SizeChanged(object sender, EventArgs e)
        {
            
        }
    }
}
