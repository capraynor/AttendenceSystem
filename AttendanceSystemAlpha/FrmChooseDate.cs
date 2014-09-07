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
        public FrmChooseDate()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            isChanged = true;
            dt = radDateTimePicker1.Value;
            this.Hide();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            isChanged = false;
            this.Hide();
        }
    }
}
