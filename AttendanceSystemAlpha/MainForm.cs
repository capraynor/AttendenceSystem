using System;
using System.Windows.Forms;
using System.Linq;
using RemObjects.DataAbstract.Linq;

namespace AttendanceSystemAlpha
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        private LoginForm loginForm;
        #region Private fields
        private DataModule fDataModule;
        #endregion

        public MainForm()
        {
            this.InitializeComponent();

            this.fDataModule = new DataModule();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loginForm = new LoginForm();
        }

        private void mainPageView_MouseUp(object sender, MouseEventArgs e)
        {
            if (mainPageView.SelectedPage.Name == "viewpageLoadData")
            {
                if (loginForm.IsLogin())
                {

                }
                else
                {
                    loginForm.Show();
                }
            }
        }
    }
}
