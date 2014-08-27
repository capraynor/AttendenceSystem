using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AttendenceSystem_Alp;
using Telerik.WinControls;

namespace AttendanceSystemAlpha
{
    public partial class RadFrmShowClasses : Telerik.WinControls.UI.RadForm
    {
        public RadFrmShowClasses(DataModule fDataModule)
        {
            checkedListBox1.DataSource = fDataModule.Context.JSANDKKVIEWRO;
            checkedListBox1.DisplayMember = "KKNAME";
            checkedListBox1.ValueMember = "KKNO";
            InitializeComponent();
        }
    }
}
