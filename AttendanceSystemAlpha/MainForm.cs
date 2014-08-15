using System;
using System.Data;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using AttendenceSystem_Alp;
using AttendenceSystem_Alp.PC;
using RemObjects.DataAbstract;
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
        /// <summary>
        /// 显示信息
        /// </summary>
        private void DisplayOfflineInformations()
        {
            pnLoad.Visible = true;

            this.lbTeacherName.Text = fDataModule.getTeacherName();
            this.clboxClassnames.Items.Clear();

            foreach (KKTABLE_05 kktable05 in this.fDataModule.Context.KKTABLE_05)
            {
                clboxClassnames.Items.Add(kktable05.KKNAME);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            loginForm = new LoginForm(fDataModule);
        }

        private void mainPageView_MouseUp(object sender, MouseEventArgs e)
        {
            if (mainPageView.SelectedPage.Name != "viewpageLoadData") return;
            if (loginForm.IsLogin()) //todo :将kktablequery写出来
            {
                DisplayOfflineInformations();
            }
            else
            {
                pnLoad.Visible = false;
                loginForm.Show();
                if (!loginForm.IsLogin()) return;
                pnLoad.Visible = true;
                DisplayOfflineInformations();
            }
        }

        private void rbtnFinish_Click(object sender, EventArgs e)
        {
            string offlineFolder = ".\\Resources\\OfflineData\\";
            if (!System.IO.Directory.Exists(offlineFolder))
            {
                System.IO.Directory.CreateDirectory(offlineFolder);
            }
            if (!System.IO.File.Exists(".\\Resources\\Properties.daBriefcase"))
            {
                Briefcase propertiesBriefcase = new FileBriefcase(".\\Resources\\Properties.daBriefcase");
                DataTable bClistTable = new DataTable("PropertiesTable");
                DataRow bflistRow = null;
                bClistTable.Columns.Add("开课编号", type: Type.GetType("System.String"));
                bClistTable.Columns.Add("教师姓名", type: Type.GetType("System.String"));
                bClistTable.Columns.Add("开课名称", type: Type.GetType("System.String"));
                propertiesBriefcase.AddTable(bClistTable);
                propertiesBriefcase.WriteBriefcase();
                
            }
            if (fDataModule.ServerToBriefcase(tboxPasswd.Text))
            {
                lbOfflineStatus.Text = "下载完成";
            }
        }

        private void rbtnCancel_Click(object sender, EventArgs e)
        {
            mainPageView.TabIndex = 0;
        }
    }
}
