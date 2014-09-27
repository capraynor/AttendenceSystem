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
        public ManualRollCall(ref Briefcase _classBriefcase , long _jieci)
        {
            this.classBriefcase = _classBriefcase;
            this.jieci = _jieci;
            InitializeComponent();
        }

        private void ManualRollCall_Load(object sender, EventArgs e)
        {
            
        }
    }
}
