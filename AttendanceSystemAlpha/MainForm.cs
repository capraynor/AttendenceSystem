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
using stdole;
using Telerik.WinControls.UI;

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
        private Briefcase propertieBriefcase;
        private DataTable _mngPropertiesTable;
        private Briefcase _mngPropertieBriefcase;
        private DateTime classTime;
        private int sdrs = 0;
        private string mngTeacherName;
        private string mngCurrentPasswd;
        private Briefcase mngchooseClassBriefcase;
        private DataTable mngdmTable;
        private DataTable mngSKtable;
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
                if (string.IsNullOrWhiteSpace(kktable05.KKNAME)) continue;
                clboxClassnames.Items.Add(kktable05.KKNAME);
            }
            //判断listbox是否为空
            
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            loginForm = new LoginForm(fDataModule);
           // DateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void mainPageView_MouseUp(object sender, MouseEventArgs e)
        {
            switch (mainPageView.SelectedPage.Name)
            {
                case "viewpageLoadData":
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
                    break;
                case "viewpageCall":
                    if (!Directory.Exists(string.Format(Properties.Settings.Default.OfflineFolder , "")) || System.IO.Directory.GetFiles(string.Format(Properties.Settings.Default.OfflineFolder , "")).Length == 0)
                    {
                        MessageBox.Show("没有离线数据 请先下载离线数据");
                    }
                    else
                    {
                        propertieBriefcase = new FileBriefcase(Properties.Settings.Default.PropertiesBriefcaseFolder , true);
                        _propertiesTable = propertieBriefcase.FindTable("PropertiesTable");
                        cbboxClassname.DataSource = _propertiesTable;
                        cbboxClassname.DisplayMember = "开课名称";
                        cbboxClassname.ValueMember = "开课编号";
                    }
                    break;
                case "viewpageDataManagement":
                    if (!Directory.Exists(string.Format(Properties.Settings.Default.OfflineFolder, "")) || System.IO.Directory.GetFiles(string.Format(Properties.Settings.Default.OfflineFolder, "")).Length == 0)
                    {
                        MessageBox.Show("没有离线数据 请先下载离线数据");
                    }
                    else
                    {
                        _mngPropertieBriefcase = new FileBriefcase(Properties.Settings.Default.PropertiesBriefcaseFolder, true);
                        _mngPropertiesTable = _mngPropertieBriefcase.FindTable("PropertiesTable");
                        cbboxMngClassName.DataSource = _mngPropertiesTable;
                        cbboxMngClassName.DisplayMember = "开课名称";
                        cbboxMngClassName.ValueMember = "开课编号";
                    }
                    break;
            }
        }

        private void rbtnFinish_Click(object sender, EventArgs e)
        {
            string offlineFolder = Properties.Settings.Default.OfflineFolder;
            if (!System.IO.Directory.Exists(string.Format(offlineFolder,"")))
            {
                System.IO.Directory.CreateDirectory(string.Format(offlineFolder,""));
            }
            if (!System.IO.File.Exists(Properties.Settings.Default.PropertiesBriefcaseFolder))
            {
                try
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
                catch (Exception exception)
                {
                    lbOfflineStatus.Text = ("下载数据失败 原因： \n" + exception.Message);
                    return;
                }
                
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
            xsidTable.Clear();
            if (cbboxJieCi.SelectedValue.ToString() == "System.Data.DataRowView") return;
            dmTable = _chooseClassBriefcase.FindTable(cbboxJieCi.Text.ToString());
            xsidTable.Columns.Add("学生学号");
            xsidTable.Columns.Add("指纹识别号");

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
            GBoxChooseLesson.Enabled = true;
        }

        private void HideInformations()
        {
            GBoxChooseLesson.Enabled = false;
        }

        private void pnClassmsg_EnabledChanged(object sender, EventArgs e)
        {
            if (!GBoxChooseLesson.Enabled) return;
            try
            {
                DataTable xktTable = _chooseClassBriefcase.FindTable("SKTABLE");
                cbboxJieCi.DisplayMember = "SKNO";
                cbboxJieCi.ValueMember = "SKDATE";
                cbboxJieCi.DataSource = xktTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("出现一个错误.请将以下信息提供给管理员\n" + exception.Message);
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
            int sdrs = 0;
            int dkrs = 0;
            int similarity = 0;
            int IdentifyNum = 0;
            string XSID = "";
            string xsName = "";
            byte[] xszpBytes = null;
            int fingerPrintID = FingerHelper.VeryfyAFingerPrint(axZKFPEngX1, _buffDatabaseNum, e, ref similarity, ref IdentifyNum);
            DataRow[] xsidRows;
            DataRow[] dmRows;
            DataRow[] xkRows;
            
            classTime = DateTimePicker1.Value;
            xsidRows = xsidTable.Select("指纹识别号 like '%" + fingerPrintID.ToString() + "%'");
            if (xsidRows.Count() != 0 && similarity > 9)
            {

                XSID = xsidRows.First()["学生学号"].ToString();
                dmRows = dmTable.Select("XSID like '%" + XSID + "%'");

                Briefcase briefcase =
                    new FileBriefcase(string.Format(Properties.Settings.Default.OfflineFolder, cbboxClassname.SelectedValue), true);

                dmRows.First().BeginEdit();
                //dmRows.First()["DMSJ1"] = DateTime.Now; //Convert.ToInt16(1);
                if ((DateTime)cbboxJieCi.SelectedValue >  DateTime.Now)
                {
                    dmRows.First()["DKZT"] = 0;
                    lbDczt.Text = "按时到课";
                }
                else
                {
                    dmRows.First()["DKZT"] = 1;
                    lbDczt.Text = "迟到";
                }
                dmRows.First()["DMSJ1"] = DateTime.Now;
                dmRows.First().EndEdit();

                //briefcase.RemoveTable(GlobalParams.SKNO); //briefcase直接addtable 代表更新
                //briefcase.WriteBriefcase();


                //dmTable.TableName = GlobalParams.SKNO;

                dmTable = OfflineHelper.TableListToDataTable(Helpers.EnumerableExtension.ToList<DMTABLE_08>(dmTable),
                    cbboxJieCi.Text);
                briefcase.AddTable(dmTable);
                briefcase.Properties[Properties.Settings.Default.PropertiesLastCheckin] = cbboxJieCi.Text;
                briefcase.WriteBriefcase();//写入briefcase
                sdrs = CountArriveSudentNumber(dmTable);

                //显示信息
                xkRows = xkTable.Select("XSID like '%" + XSID + "%'");
                xsName = xkRows.First()["XSNAME"].ToString();
                xszpBytes = (byte[])xkRows.First()["XSZP"];
                Stream ms = new MemoryStream(xszpBytes);
                ms.Write(xszpBytes, 0, xszpBytes.Length);
                pboxPhoto.Image = Image.FromStream(ms);
                lbStudentName.Text = xsName;
                lbStudentId.Text = XSID;
                lbDcsj.Text = DateTime.Now.TimeOfDay.ToString();
                lbYdrs.Text =  briefcase.Properties[Properties.Settings.Default.PropertiesTotalStudentNumber];
                lbDKPercent.Text = (Convert.ToDouble(sdrs) / Convert.ToDouble(lbYdrs.Text)).ToString("0.00%");
                lbSdrs.Text = sdrs.ToString();
                lbCdrs.Text = CountLateStudentNumber(dmTable).ToString();
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
        //public static void UploadData(DataModule fDataModule, DataTable dmTable, long skno, Decimal postmanno)
        //{
        //    foreach (DMTABLE_08 dmtableRows in EnumerableExtension.ToList<DMTABLE_08>(dmTable))
        //    {
        //        dmtableRows.POSTDATE = DateTime.Now;
        //        dmtableRows.POSTMANNO = postmanno;
        //        fDataModule.UpdateDmtable(dmtableRows);
        //    }
        //    fDataModule.ApplyChanges();
        //}

        private static int CountArriveSudentNumber(DataTable dmTable)
        {
            DataRow[] dmRows;
            dmRows = dmTable.Select("DKZT = '0' AND DKZT = 1");
            return dmRows.Count();
        }

        private static int CountLateStudentNumber(DataTable dmTable)
        {
            DataRow[] dmRows;
            dmRows = dmTable.Select( "DKZT = '1'");
            return dmRows.Count();
        }

        private void cbboxMngClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_mngPropertiesTable.Select("开课编号 like '" + cbboxMngClassName.SelectedValue + "'").Length == 0) return;
            mngTeacherName = _mngPropertiesTable.Select("开课编号 like '" + cbboxMngClassName.SelectedValue + "'").First()["教师姓名"].ToString();
            tbMngTeacherName.Text = mngTeacherName;//todo:离线密码验证
            mngchooseClassBriefcase = new FileBriefcase(string.Format(Properties.Settings.Default.OfflineFolder, cbboxMngClassName.SelectedValue), true);
            mngSKtable = mngchooseClassBriefcase.FindTable("SKTABLE");
            mngCurrentPasswd = mngchooseClassBriefcase.Properties[Properties.Settings.Default.PropertiesBriefcasePasswd];
            if (MngChkPasswd())
            {
                pictureBox1.BackColor = Color.LawnGreen;
                ShowMngClassInformations();
            }
            else
            {
                pictureBox1.BackColor = Color.OrangeRed;
                HideMngInformations();
            }
            
        }

        private Boolean MngChkPasswd()
        {
            return (tbMngOfflinePasswd.Text == mngCurrentPasswd);
        }
        private void ShowMngClassInformations()
        {
            PnMngChooseLesson.Enabled = true;
        }

        private void HideMngInformations()
        {
            PnMngChooseLesson.Enabled = false;
        }

        private void tbMngOfflinePasswd_TextChanged(object sender, EventArgs e)
        {
            if (MngChkPasswd())
            {
                pboxPasswd.BackColor = Color.OrangeRed;
                ShowMngClassInformations();
            }
            else
            {
                pboxPasswd.BackColor = Color.LawnGreen;
                HideMngInformations();
            }
        }

        private void PnMngChooseLesson_EnabledChanged(object sender, EventArgs e)
        {
            if (!PnMngChooseLesson.Enabled) return;
            try
            {
               // DataTable mngxkTable = mngchooseClassBriefcase.FindTable("SKTABLE");
                cbboxMngJieCi.DisplayMember = "SKNO";
                cbboxMngJieCi.ValueMember = "SKDATE";
                cbboxMngJieCi.DataSource = mngSKtable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("出现一个错误.请将以下信息提供给管理员\n" + exception.Message);
                return;
            }
        }

        private void cbboxMngJieCi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbboxMngJieCi.Text == "System.Data.DataRowView") return;
            dateTimePicker2.Value = (DateTime)cbboxMngJieCi.SelectedValue;
            tbMngTeacherName.Text = mngTeacherName;
            cbboxMngCheckinMethod.Text = "指纹点名";
        }

        private void rbtnMngShowInformation_Click(object sender, EventArgs e)
        {
            DataTable mngxkTable = null;
            DataTable dtResault = new DataTable();
            dtResault.Columns.Add("姓名", typeof (string));
            dtResault.Columns.Add("到课状态", typeof (Int16));
            dtResault.Columns.Add("学号", typeof (string));
            if (cbboxMngJieCi.SelectedValue.ToString() == "System.Data.DataRowView") return;
            mngdmTable =mngchooseClassBriefcase.FindTable(cbboxMngJieCi.Text.ToString());//从briefcase中将表拉出来
            mngxkTable = mngchooseClassBriefcase.FindTable(cbboxMngJieCi.Text.ToString());//从briefcase中将表拉出来
            mngGridView.DataSource = mngdmTable;
            lbMngStudentTotal.Text = CountArriveSudentNumber(mngdmTable).ToString();
            //mngGridView.Columns["fucker"].HeaderText
            //  mngGridView.Columns["fucker"].IsVisible
            // mngGridView.Columns["fucker"].vis
        }

        private void mngGridView_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            mngGridView.Columns["XSID"].HeaderText = "学号";
            mngGridView.Columns["DKZT"].HeaderText = "到课状态";
            
        }

        private void mngGridView_CreateRow(object sender, GridViewCreateRowEventArgs e)
        {
            
        }

        private void radButton2_Click(object sender, EventArgs e)
        {

            try
            {
                loginForm.ShowDialog();
                foreach (DataRow dr in mngdmTable.Rows)
                {
                    dr["POSTDATE"] = DateTime.Now;
                    dr["POSTMANNO"] = Convert.ToDecimal(fDataModule.GetUserID());
                }
                var dmtableList = EnumerableExtension.ToList<DMTABLE_08>(mngdmTable);
                mngchooseClassBriefcase.AddTable(OfflineHelper.TableListToDataTable(dmtableList,cbboxMngJieCi.Text));
                foreach (var dmtable08 in dmtableList)
                {
                    fDataModule.UpdateDmtable(dmtable08);
                }

                fDataModule.ApplyChanges();
                
                lbMngOfflineStatus.Text = "数据提交成功";
            }
            catch (Exception exception)
            {
                lbMngOfflineStatus.Text = "数据提交失败 原因： " + exception.Message;
                return;
            }
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
