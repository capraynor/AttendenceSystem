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
    public partial class FrmChooseDate : Telerik.WinControls.UI.RadForm
    {
        public DateTime dt = DateTime.Now;
        public Boolean isChanged = false;
        private DateTime _pDateTime = DateTime.Now;
        public FrmChooseDate(DateTime YdSkSj , DateTime SjSksj)
        {
            InitializeComponent();
            _pDateTime = YdSkSj;
            radDateTimePicker2.Value = YdSkSj;
            radDateTimePicker1.Value = SjSksj;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            isChanged = true;
            if (radDateTimePicker1.Value.Date != DateTime.Now.Date)
            {
                MessageBox.Show("请选择一个合适的时间");
                return;
            }
            dt = radDateTimePicker1.Value;
            this.Hide();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            isChanged = false;
            this.Hide();
        }

        private void FrmChooseDate_Load(object sender, EventArgs e)
        {

        }
    }
}
