using System;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms.PropertyGridInternal;
using AttendenceSystem_Alp;
using AttendenceSystem_Alp.PC;
using RemObjects.DataAbstract;
using RemObjects.DataAbstract.Linq;
using FingerprintHelper;
using Helpers;
namespace AttendanceSystemAlpha
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        
        #region Private fields
        private DataModule fDataModule;
        private DataTable _propertiesTable;
        private LoginForm loginForm;
        private string _teacherName = "";
        private string _currentPasswd = "AAC0A9DAA4185875786C9ED154F0DECE";
        private Briefcase _chooseClassBriefcase = null;
        private DataTable dmTable;
        private DataTable xsidTable;
        private DataTable xkTable;
        private int _buffDatabaseNum;
        #endregion

        public MainForm()
        {
            this.InitializeComponent();
            this.xsidTable = new DataTable("学生信息");
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
            else if (mainPageView.SelectedPage.Name == "viewpageCall")
            {


                if (System.IO.Directory.GetFiles(string.Format(Properties.Settings.Default.OfflineFolder , "")).Length == 0)
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
            string offlineFolder = Properties.Settings.Default.OfflineFolder;
            if (!System.IO.Directory.Exists(offlineFolder))
            {
                System.IO.Directory.CreateDirectory(offlineFolder);
            }
            if (!System.IO.File.Exists(Properties.Settings.Default.PropertiesBriefcaseFolder))
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
            if (cbboxJieCi.SelectedValue.ToString() == "System.Data.DataRowView") return;
            dmTable = _chooseClassBriefcase.FindTable(cbboxJieCi.Text.ToString());
            try
            {
                xsidTable.Columns.Add("学生学号");
                xsidTable.Columns.Add("指纹识别号");
            }
            catch (Exception exception )
            {
                Console.WriteLine(exception.Message);
            }
            DataRow xsidRow = xsidTable.NewRow();
            xkTable = _chooseClassBriefcase.FindTable("XKTABLE_VIEW1");
            while (axZKFPEngX1.InitEngine() != 0)
            {

            }
            _buffDatabaseNum = FingerHelper.CreateFastBufDatabase(axZKFPEngX1);
            foreach (DataRow dataRows in xkTable.Rows)
            {
                int fingerID =
                    Convert.ToInt32(dataRows["XSID"].ToString().Substring(dataRows["XSID"].ToString().Length - 6));
                FingerHelper.AddFingerprintTemplate(dataRows["ZW1"].ToString(), axZKFPEngX1, _buffDatabaseNum, fingerID);
                xsidRow["学生学号"] = dataRows["XSID"].ToString();
                xsidRow["指纹识别号"] = fingerID.ToString();
                xsidTable.Rows.Add(xsidRow);
            }
            gboxClassmsg.Enabled = false;
            gboxStudentMsg.Enabled = true;
            gboxMsg.Enabled = true;
        }

        private void cbboxClassname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_propertiesTable.Select("开课编号 like '" + cbboxClassname.SelectedValue + "'").Length == 0) return;
            _teacherName = _propertiesTable.Select("开课编号 like '" + cbboxClassname.SelectedValue + "'").First()["教师姓名"].ToString();
            tboxTeachername.Text = _teacherName;//todo:离线密码验证
            _chooseClassBriefcase = new FileBriefcase(string.Format(Properties.Settings.Default.OfflineFolder, cbboxClassname.SelectedValue) , true);
            _currentPasswd = _chooseClassBriefcase.Properties[Properties.Settings.Default.PropertiesBriefcasePasswd];
            if (CheckPasswd())
            {
                pboxPasswd.BackColor = Color.LawnGreen;
                ShowClassInformations();
            }
            else
            {
                pboxPasswd.BackColor = Color.OrangeRed;
                HideInformations();
            }
        }

        private void tboxPasswd_TextChanged(object sender, EventArgs e)
        {
            if (CheckPasswd())
            {
                pboxPasswd.BackColor = Color.LawnGreen;
                ShowClassInformations();
            }
            else
            {
                pboxPasswd.BackColor = Color.OrangeRed;
                HideInformations();
            }
        }

        private Boolean CheckPasswd()
        {
            return (tboxPasswd.Text == _currentPasswd);
        }

        private void ShowClassInformations()
        {
            pnClassmsg.Enabled = true;
        }

        private void HideInformations()
        {
            pnClassmsg.Enabled = false;
        }

        private void pnClassmsg_EnabledChanged(object sender, EventArgs e)
        {
            if (!pnClassmsg.Enabled) return;
            try
            {
                DataTable xktTable = _chooseClassBriefcase.FindTable("SKTABLE");
                cbboxJieCi.DisplayMember = "SKNO";
                cbboxJieCi.ValueMember = "SKDATE";
                cbboxJieCi.DataSource = xktTable;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void cbboxJieCi_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTimePicker1.Value = (DateTime)cbboxJieCi.SelectedValue;
            tboxTeachername.Text = _teacherName;
        }

        private void axZKFPEngX1_OnCapture(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent e)
        {
            int similarity = 0;
            int IdentifyNum = 0;
            string XSID = "";
            string xsName = "";
            byte[] xszpBytes = null;
            int fingerPrintID = FingerHelper.VeryfyAFingerPrint(axZKFPEngX1, _buffDatabaseNum, e, ref similarity, ref IdentifyNum);
            DataRow[] xsidRows;
            DataRow[] dmRows;
            DataRow[] xkRows;
            xsidRows = xsidTable.Select("指纹识别号 like '%" + fingerPrintID.ToString() + "%'");
            if (xsidRows.Count() != 0 && similarity > 9)
            {

                XSID = xsidRows.First()["学生学号"].ToString();
                dmRows = dmTable.Select("XSID like '%" + XSID + "%'");

                Briefcase briefcase =
                    new FileBriefcase(string.Format(Properties.Settings.Default.OfflineFolder, cbboxClassname.SelectedValue), true);

                dmRows.First().BeginEdit();
                //dmRows.First()["DMSJ1"] = DateTime.Now; //Convert.ToInt16(1);
                dmRows.First()["DKZT"] = 1;
                dmRows.First().EndEdit();

                //briefcase.RemoveTable(GlobalParams.SKNO); //briefcase直接addtable 代表更新
                //briefcase.WriteBriefcase();


                //dmTable.TableName = GlobalParams.SKNO;

                dmTable = OfflineHelper.TableListToDataTable(Helpers.EnumerableExtension.ToList<DMTABLE_08>(dmTable),
                    cbboxJieCi.Text);
                briefcase.AddTable(dmTable);
                briefcase.WriteBriefcase();//写入briefcase

                //显示信息
                xkRows = xkTable.Select("XSID like '%" + XSID + "%'");
                xsName = xkRows.First()["XSNAME"].ToString();
                xszpBytes = (byte[])xkRows.First()["XSZP"];
                Stream ms = new MemoryStream(xszpBytes);
                ms.Write(xszpBytes, 0, xszpBytes.Length);
                pboxPhoto.Image = Image.FromStream(ms);
                lbStudentName.Text = xsName;
                lbStudentId.Text = XSID;

            }
            else
            {
                lbStudentId.Text = "请重新扫描指纹";
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            gboxClassmsg.Enabled = true;
            gboxStudentMsg.Enabled = false;
            gboxMsg.Enabled = false;
            axZKFPEngX1.EndEngine();
        }
        //todo:获取datatable并上传
        /// <summary>
        /// 上传数据
        /// </summary>
        /// <param name="fDataModule">datamodule</param>
        /// <param name="dmTable">要传入的DMtable 从briefcase中获取</param>
        /// <param name="skno">上课编号 用于更新 sKTABLE</param>
        /// <param name="postmanno">提交人员编号</param>
        public static void UploadData(DataModule fDataModule, DataTable dmTable, long skno, Decimal postmanno)
        {
            foreach (DMTABLE_08 dmtableRows in EnumerableExtension.ToList<DMTABLE_08>(dmTable))
            {
                dmtableRows.POSTDATE = DateTime.Now;
                dmtableRows.POSTMANNO = postmanno;
                fDataModule.UpdateDmtable(dmtableRows);
            }
            fDataModule.ApplyChanges();
        }
    }
}
