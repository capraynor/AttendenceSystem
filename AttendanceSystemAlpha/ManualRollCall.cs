using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RemObjects.DataAbstract;
using Telerik.WinControls;

namespace AttendanceSystemAlpha
{
    public partial class ManualRollCall : Telerik.WinControls.UI.RadForm
    {
        private long jieci;
        private Briefcase classBriefcase;
        public ManualRollCall(ref Briefcase _classBriefcase , long _jieci , DateTime RollcallTime)
        {
            this.classBriefcase = _classBriefcase;
            this.jieci = _jieci;
            InitializeComponent();
        }

        private void ManualRollCall_Load(object sender, EventArgs e)
        {
            DataTable dtResault = new DataTable();
            if (!dtResault.Columns.Contains("到课状态"))
            {
                dtResault.Columns.Add("姓名", typeof(string));
                dtResault.Columns.Add("到课状态", typeof(string));
                dtResault.Columns.Add("学号", typeof(string));
                dtResault.Columns.Add("到课时间", typeof(DateTime));
            }
        }
        private void ChangeOnedmtableRecord(long xsid, Int16 dkzt)
        {

        }

        private void RefreshDisplay()
        {
            
        }

        private void GetDmtable()
        {
            
        }

        private void UpdateTableToBriefCase()
        {
            
        }

    }
}
