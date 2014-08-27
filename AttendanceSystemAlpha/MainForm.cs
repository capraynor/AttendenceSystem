using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms.PropertyGridInternal;
using System.Windows.Forms.VisualStyles;
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
        private DataTable jieciDisplayTable;
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

            //this.lbTeacherName.Text = fDataModule.getTeacherName();
            //this.clboxClassnames.Items.Clear();
            clboxClassnames.DataSource = fDataModule.Context.JSANDKKVIEWRO;
            clboxClassnames.DisplayMember = "KKNAME";
            clboxClassnames.ValueMember = "KKNO";
            //rbtnFinish.Enabled = false;
            //foreach (KKTABLE_05 kktable05 in this.fDataModule.Context.KKTABLE_05)
            //{
            //    if (string.IsNullOrWhiteSpace(kktable05.KKNAME)) continue;
            //    clboxClassnames.Items.Add(kktable05.KKNAME);
            //}
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
            
            CheckedListBox.CheckedItemCollection ckeckedList = clboxClassnames.CheckedItems;
            
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
                    
                    //DataRow bflistRow = null;
                    if (!bClistTable.Columns.Contains("开课编号"))
                    {
                        bClistTable.Columns.Add("开课编号", type: Type.GetType("System.String"));
                        bClistTable.Columns.Add("教师姓名", type: Type.GetType("System.String"));
                        bClistTable.Columns.Add("开课名称", type: Type.GetType("System.String"));
                    }
                    
                    propertiesBriefcase.AddTable(bClistTable);
                    
                    propertiesBriefcase.WriteBriefcase();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("下载数据失败\n原因： " + exception.Message);
                    return;
                }
                
            }
            int i = 0;
            try
            {
                i = fDataModule.ServerToBriefcase(Properties.Settings.Default.CurrentDownloadPasswd, clboxClassnames.CheckedItems); // 开始下载离线数据
            }
            catch (Exception exception)
            {
                MessageBox.Show("下载数据时出现错误 原因：\n" + exception.Message);
                return;
            }
            toolStripOperationStatus.Text = string.Format("操作完成 , 【{0}】门课程被下载", i);
        }

        private void rbtnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void rbtnStartcall_Click(object sender, EventArgs e)
        {
            if (cbboxJieCi.SelectedValue.ToString() == "System.Data.DataRowView") return;
            
            dmTable = _chooseClassBriefcase.FindTable(cbboxJieCi.SelectedValue.ToString());
            DataTable sktable = _chooseClassBriefcase.FindTable("SKTABLE");
            DataRow skRow = null;
            skRow =  sktable.Select("SKNO = '" + cbboxJieCi.SelectedValue + "'").First();
            skRow.BeginEdit();
            skRow["SKDATE"] = DateTimePicker1.Value;
            skRow.EndEdit();
            _chooseClassBriefcase.AddTable(OfflineHelper.TableListToDataTable(EnumerableExtension.ToList<SKTABLE_07_VIEW>(sktable) , "SKTABLE"));
            _chooseClassBriefcase.WriteBriefcase();

            if (!xsidTable.Columns.Contains("学生学号"))
            {
                xsidTable.Columns.Add("学生学号");
            }
            if (!xsidTable.Columns.Contains("指纹识别号"))
            {
                xsidTable.Columns.Add("指纹识别号");
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
                try
                {
                    xsidTable.Rows.Add(xsidRow);
                }
                catch (Exception)
                {
                    
                    
                }
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
            //GBoxChooseLesson.Enabled = true;
        }

        private void HideInformations()
        {
            //GBoxChooseLesson.Enabled = false;
        }

        private void pnClassmsg_EnabledChanged(object sender, EventArgs e)
        {
          //  if (!GBoxChooseLesson.Enabled) return;
            try
            {
                DataTable skTable = _chooseClassBriefcase.FindTable("SKTABLE");
                cbboxJieCi.DisplayMember = "SKDATE";
                cbboxJieCi.ValueMember = "SKNO";
                cbboxJieCi.DataSource = skTable;
                cbboxCallWay.Text = "指纹点名";
                tboxClassplace.Text = "明德楼 D0505";
                cbboxCalltimes.Text = "1";
            }
            catch (Exception exception)
            {
                MessageBox.Show("出现一个错误.请将以下信息提供给管理员\n" + exception.Message);
                return;
            }
        }

        private void cbboxJieCi_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTimePicker1.Value = Convert.ToDateTime(cbboxJieCi.Text);
            tboxTeachername.Text = _teacherName;
        }

        private void axZKFPEngX1_OnCapture(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent e)
        {
            DataTable classTable = propertieBriefcase.FindTable("ClassNameTable"); // 班级表
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
            if (xsidRows.Count() != 0 && similarity > 8)
            {

                XSID = xsidRows.First()["学生学号"].ToString();
                dmRows = dmTable.Select("XSID like '%" + XSID + "%'");

                Briefcase briefcase =
                    new FileBriefcase(string.Format(Properties.Settings.Default.OfflineFolder, cbboxClassname.SelectedValue), true);

                dmRows.First().BeginEdit();
                //dmRows.First()["DMSJ1"] = DateTime.Now; //Convert.ToInt16(1);

                if (dmRows.First()["DMSJ1"] == null || (Convert.ToDateTime(dmRows.First()["DMSJ1"]) > DateTime.Now))
                {
                    dmRows.First()["DMSJ1"] = DateTime.Now;
                }

                if (DateTimePicker1.Value > Convert.ToDateTime(dmRows.First()["DMSJ1"]))
                {
                    dmRows.First()["DKZT"] = 0;
                    lbDczt.Text = "按时到课";
                }
                else
                {
                    dmRows.First()["DKZT"] = 1;
                    lbDczt.Text = "迟到";
                }
                dmRows.First().EndEdit();

                //briefcase.RemoveTable(GlobalParams.SKNO); //briefcase直接addtable 代表更新
                //briefcase.WriteBriefcase();


                //dmTable.TableName = GlobalParams.SKNO;

                dmTable = OfflineHelper.TableListToDataTable(Helpers.EnumerableExtension.ToList<DMTABLE_08_NOPIC_VIEW>(dmTable),
                    cbboxJieCi.SelectedValue.ToString());
                briefcase.AddTable(dmTable);
                briefcase.Properties[Properties.Settings.Default.PropertiesLastCheckin] = cbboxJieCi.SelectedValue.ToString();
                briefcase.WriteBriefcase();//写入briefcase
                sdrs = CountArriveSudentNumber(dmTable)+CountLateStudentNumber(dmTable);

                //显示信息
                xkRows = xkTable.Select("XSID like '%" + XSID + "%'");
                
                DataRow bjRow = classTable.Select("BJID = '" + xkRows.First()["BJID"].ToString() + "'").First();

                lbStudentClass.Text = "12级软件3班";
                
                lbStudentXy.Text = bjRow["XYNAME"].ToString();
                lbStudentClass.Text = bjRow["BJNAME"].ToString();
                xsName = xkRows.First()["XSNAME"].ToString();
                xszpBytes = (byte[])xkRows.First()["XSZP"];
                Stream ms = new MemoryStream(xszpBytes);
                ms.Write(xszpBytes, 0, xszpBytes.Length);
                pboxPhoto.Image = Image.FromStream(ms);
                lbStudentName.Text = xsName;
                lbStudentId.Text = XSID;
                lbDcsj.Text = Convert.ToDateTime(dmRows.First()["DMSJ1"]).ToString("t", DateTimeFormatInfo.InvariantInfo);
                
                //lbYdrs.Text =  briefcase.Properties[Properties.Settings.Default.PropertiesTotalStudentNumber];
                lbYdrs.Text = dmTable.Rows.Count.ToString();
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
            foreach (DataRow dmtableRows in dmTable.Rows)
            {
                
            }

            DataTable ClassStatusTable = _chooseClassBriefcase.FindTable("ClassStatus");
            DataRow mngClassStatusRow = ClassStatusTable.Select("Table编号 = '" + cbboxJieCi.SelectedValue + "'")
                    .First();

            mngClassStatusRow.BeginEdit();
            mngClassStatusRow["点名情况"] = "已点名";
            mngClassStatusRow.EndEdit();
            mngchooseClassBriefcase.AddTable(ClassStatusTable);
            mngchooseClassBriefcase.WriteBriefcase();

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
            dmRows = dmTable.Select("DKZT = '0'");
            return dmRows.Count();
        }

        private static int CountLateStudentNumber(DataTable dmTable)
        {
            DataRow[] dmRows;
            dmRows = dmTable.Select( "DKZT = '1'");
            return dmRows.Count();
        }

        private static int CountLeaveEarly(DataTable dmTable)
        {
            DataRow[] dmRows;
            dmRows = dmTable.Select("DKZT = '2'");
            return dmRows.Count();
        }

        private static int CountAbsentStudent(DataTable dmTable)
        {
            DataRow[] dmRows;
            dmRows = dmTable.Select("DKZT = 3");
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
            //PnMngChooseLesson.Enabled = true;
        }

        private void HideMngInformations()
        {
            //PnMngChooseLesson.Enabled = false;
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
            //if (!PnMngChooseLesson.Enabled) return;
            try
            {
               // DataTable mngxkTable = mngchooseClassBriefcase.FindTable("SKTABLE");
                cbboxMngJieCi.DisplayMember = "SKDATE";
                cbboxMngJieCi.ValueMember = "SKNO";
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
            if (cbboxMngJieCi.SelectedValue == "System.Data.DataRowView") return;
            dateTimePicker2.Value = Convert.ToDateTime(cbboxMngJieCi.Text);
            tbMngTeacherName.Text = mngTeacherName;
            cbboxMngCheckinMethod.Text = "指纹点名";
        }

        private void rbtnMngShowInformation_Click(object sender, EventArgs e)
        {
            DataTable mngxkTable = null;
            DataTable dtResault = new DataTable();
            if (!dtResault.Columns.Contains("到课状态"))
            {
                dtResault.Columns.Add("姓名", typeof (string));
                dtResault.Columns.Add("到课状态", typeof (string));
                dtResault.Columns.Add("学号", typeof (string));
            }

            
            if (cbboxMngJieCi.SelectedValue.ToString() == "System.Data.DataRowView") return;
            mngdmTable =mngchooseClassBriefcase.FindTable(cbboxMngJieCi.SelectedValue.ToString());//从briefcase中将点名表拉出来
            mngxkTable = mngchooseClassBriefcase.FindTable("XKTABLE_VIEW1");//从briefcase中将选课表拉出来
            //mngGridView.DataSource = mngdmTable;
            int _studentTotal = 0;
            int _sdrs = 0;
            double _dkpercent = 0.0;
            _studentTotal = (CountArriveSudentNumber(mngdmTable) + CountLateStudentNumber(mngdmTable) +
                            CountLeaveEarly(mngdmTable) + CountAbsentStudent(mngdmTable));
            _sdrs = (CountArriveSudentNumber(mngdmTable) + CountLateStudentNumber(mngdmTable));
            _dkpercent = (_sdrs / Convert.ToDouble(_studentTotal));
            lbMngStudentTotal.Text = _studentTotal.ToString();
            lbMngsdrs.Text = _sdrs.ToString();
            lbMngDkpercent.Text = string.Format("{0:P}", _dkpercent);
            foreach (DataRow Row in mngdmTable.Rows)
            {
                DataRow resaultRow = dtResault.NewRow();
                resaultRow["学号"] = Convert.ToString(Row["XSID"]);
                resaultRow["到课状态"] = Convert.ToString(Row["DKZT"]);
                switch (Convert.ToString(Row["DKZT"]))
                {
                    case "0":
                    {
                        resaultRow["到课状态"] = "正常到课";
                        break;
                    }
                    case "1":
                    {
                        resaultRow["到课状态"] = "迟到";
                        break;
                    }
                    case "2":
                    {
                        resaultRow["到课状态"] = "早退";
                        break;
                    }
                    case"3":
                    {
                        resaultRow["到课状态"] = "旷课";
                        break;
                    }
                }
                resaultRow["姓名"] = Row["XSNAME"].ToString();
                dtResault.Rows.Add(resaultRow);
            }

            //foreach (DataRow resaultRow in dtResault.Rows)
            //{
            //    DataRow[] xktableRows =  mngxkTable.Select("XSID like '%" + Convert.ToString(resaultRow["学号"]) + "%'");
            //    if (xktableRows.Any())
            //    {
            //        resaultRow.BeginEdit();
            //        resaultRow["姓名"] = xktableRows.First()["XSNAME"].ToString();
            //        resaultRow.EndEdit();
            //    }
            //}
            mngGridView.DataSource = dtResault;
            lbMngOfflineStatus.Text = "未提交";


            //mngGridView.Columns["fucker"].HeaderText
            //  mngGridView.Columns["fucker"].IsVisible
            // mngGridView.Columns["fucker"].vis
        }

        private void mngGridView_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            //mngGridView.Columns["XSID"].HeaderText = "学号";
            //mngGridView.Columns["DKZT"].HeaderText = "到课状态";
            
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
                var dmtableList = EnumerableExtension.ToList<DMTABLE_08_NOPIC_VIEW>(mngdmTable);
                mngchooseClassBriefcase.AddTable(OfflineHelper.TableListToDataTable(dmtableList,cbboxMngJieCi.SelectedValue.ToString()));
                foreach (var dmtable08 in dmtableList)
                {
                    fDataModule.UpdateDmtable(dmtable08); // dmtable update完成
                }
                
                //mngSKtable = _chooseClassBriefcase.FindTable() // todo update sktable 点名方式 早退人数
                long _skno = (long) this.cbboxMngJieCi.SelectedValue;
                fDataModule.GetSktableQueryUpload(_skno);
                if (!fDataModule.Context.SKTABLE_07_VIEW.Any()) // 选择 sktable需要上传的那一列
                {
                    throw new Exception("数据库异常 找不到该教师的相关信息 \n请重试或者联系管理员");
                }

                //rowSktable07:需要上传的那一列
                SKTABLE_07_VIEW rowSktable07 = fDataModule.Context.SKTABLE_07_VIEW.First();
                rowSktable07.EDITDATE = DateTime.Now;
                //rowSktable07.DMFS = Convert.ToInt16(2);
                rowSktable07.EDITMANNO = Convert.ToDecimal(fDataModule.GetUserID());
                rowSktable07.ZTRS = 0;
                rowSktable07.CDRS = Convert.ToInt16(CountLateStudentNumber(mngdmTable));
                rowSktable07.KKRS = Convert.ToInt16(CountAbsentStudent(mngdmTable));
                rowSktable07.ZCRS = Convert.ToInt16(CountArriveSudentNumber(mngdmTable));
                fDataModule.ApplyChanges();
               // fDataModule.UpdateSktable(rowSktable07); // sktable 提交完成
                //SKTABLE_07 rowSktable07 = new SKTABLE_07();
                
                rowSktable07.SKNO = Convert.ToInt64(cbboxMngJieCi.SelectedValue);
                
                //rowSktable07.EDITDATE = DateTime.Now;
                rowSktable07.DMFS = Convert.ToInt16(1); // 一次点名
                rowSktable07.RZFS = Convert.ToInt16(2); // 指纹认证
                //rowSktable07.EDITMANNO = Convert.ToInt64(fDataModule.GetUserID());
                //rowSktable07.ZTRS = Convert.ToInt16(CountLeaveEarly(mngdmTable));
                rowSktable07.CDRS = Convert.ToInt16(CountLateStudentNumber(mngdmTable));
                rowSktable07.SKDATE =
                    Convert.ToDateTime(
                        mngSKtable.Select("SKNO = '" + rowSktable07.SKNO.ToString() + "'").First()["SKDATE"]);
                //rowSktable07.ZCRS = Convert.ToInt16(CountArriveSudentNumber(mngdmTable));
                //rowSktable07.KKRS = Convert.ToInt16(CountAbsentStudent(mngdmTable));

                //rowSktable07.KKNO = fDataModule.Context.SKTABLE_07.First().KKNO;
                //rowSktable07.SKDATE = fDataModule.Context.SKTABLE_07.First().SKDATE;
                //rowSktable07.LSJS = fDataModule.Context.SKTABLE_07.First().LSJS;

                //DataTable _tempSktable = null;
                //_tempSktable = OfflineHelper.TableListToDataTable(fDataModule.Context.SKTABLE_07.ToList(),
                //    "_SKTABLE_singleRow");
                //var _sktablelist = Helpers.EnumerableExtension.ToList<SKTABLE_07>(_tempSktable);
                //foreach (SKTABLE_07 sktableitem in _sktablelist)
                //{
                //    fDataModule.UpdateSktable(sktableitem);
                //}
                
                fDataModule.ApplyChanges();//提交更改

                DataTable mngClassStatusTable = mngchooseClassBriefcase.FindTable("ClassStatus");
                
                        
                
                DataRow mngClassStatusRow = mngClassStatusTable.Select("Table编号 = '" + rowSktable07.SKNO + "'")
                        .First();
                    
                mngClassStatusRow.BeginEdit();
                mngClassStatusRow["离线数据提交情况"] = "已提交";
                mngClassStatusRow.EndEdit();
                mngchooseClassBriefcase.AddTable(mngClassStatusTable);
                mngchooseClassBriefcase.WriteBriefcase();

                lbMngOfflineStatus.Text = "数据提交成功";


            }
            catch (Exception exception)
            {
                lbMngOfflineStatus.Text = "数据提交失败 请将以下信息提供给管理员：" +exception.Message;
                MessageBox.Show(exception.Message);
                
                return;
            }
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            //groupBox2.Enabled = false;
            groupBox1.Enabled = true;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {

        }

        private void cbboxMngClassName_DrawItem(object sender, DrawItemEventArgs e)
        {
            
        }

        private void cbboxJieCi_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void cbboxMngJieCi_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.DrawBackground();

            //try
            //{

            //    // Get the item text    
            //    DataRow dr = (DataRow)((ComboBox)sender).Items[e.Index];
                

            //    // Determine the forecolor based on whether or not the item is selected    
            //    Brush brush;
            //    if (true)// compare  date with your list.  
            //    {
            //        brush = Brushes.Red;
            //    }
            //    else
            //    {
            //        brush = Brushes.Green;
            //    }

            //    // Draw the text    
            //    e.Graphics.DrawString(dr["SKNO"].ToString(), ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
            //}
            //catch (Exception)
            //{

            //    return;
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripTimeLabel.Text = DateTime.Now.ToString();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
