using System;
using System.Data;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms.PropertyGridInternal;
using AttendenceSystem_Alp;
using AttendenceSystem_Alp.PC;
using RemObjects.DataAbstract;
using RemObjects.DataAbstract.Linq;
namespace AttendanceSystemAlpha
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        
        #region Private fields
        private DataModule fDataModule;
        private DataTable _propertiesTable;
        private LoginForm loginForm;
        private string _teacherName = "";
        private string _currentPasswd = "";
        #endregion

        public MainForm(string teacherName)
        {
            this._teacherName = teacherName;
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
            if (mainPageView.SelectedPage.Name == "viewpageLoadData")
            {
                if (loginForm.IsLogin()) //todo :将kktablequery写出来
                {
                    DisplayOfflineInformations();
                }
                else
                {
                    pnLoad.Enabled = false;
                    loginForm.ShowDialog();
                    if (!loginForm.IsLogin()) return;
                    pnLoad.Visible = true;
                    DisplayOfflineInformations();
                    pnLoad.Enabled = true;
                    pnLoad.Refresh();
                }
            }
            else if (mainPageView.SelectedPage.Name == "viewpageLoadData")
            {
                

                if (System.IO.Directory.GetFiles(Properties.Settings.Default.OfflineFolder).Length == 0)
                {
                    MessageBox.Show("没有离线数据 请先下载离线数据");
                }
                else
                {
                    Briefcase propertieBriefcase = new FileBriefcase(Properties.Settings.Default.PropertiesBriefcaseFolder , true);
                    _propertiesTable = propertieBriefcase.FindTable("PropertiesTable");
                    cbboxClassname.DataSource = _propertiesTable;
                    cbboxClassname.DisplayMember = "开课名称";
                    cbboxClassname.ValueMember = "开课编号";
                }
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
            if (fDataModule.ServerToBriefcase(tboxLoadpasswd.Text))
            {
                lbOfflineStatus.Text = "下载完成";
            }
        }

        private void rbtnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void rbtnStartcall_Click(object sender, EventArgs e)
        {

        }

        private void cbboxClassname_SelectedIndexChanged(object sender, EventArgs e)
        {
            _teacherName = _propertiesTable.Select("开课编号 like '" + cbboxClassname.SelectedValue + "'").First()["教师姓名"].ToString();
            tboxTeachername.Text = _teacherName;//todo:离线密码验证
        }

        private void tboxPasswd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
