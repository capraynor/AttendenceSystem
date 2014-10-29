using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Windows.Forms;

namespace AttendenceSystem_Alp
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            this.TopMost = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ProgressValue >= 100)
            {
                Properties.Settings.Default.ProgressValue = 100;
                this.Close();
            }
            progressBar1.Value = Properties.Settings.Default.ProgressValue;
        }

        private void ProgressForm_Deactivate(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CloseProgressForm)
            {
                this.Close();
            }
        }

        
    }
}
