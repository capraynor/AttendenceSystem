﻿using System;
using System.Windows.Forms;
using System.Linq;
using RemObjects.DataAbstract.Linq;

namespace AttendenceSystem_Alp
{
    public partial class MainForm : Form
    {
        #region Private fields
        private DataModule fDataModule;
        #endregion

        public MainForm()
        {
            this.InitializeComponent();

            this.fDataModule = new DataModule();
        }
    }
}
