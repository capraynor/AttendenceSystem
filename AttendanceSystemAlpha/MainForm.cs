﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Media;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using AttendanceSystemAlpha.Properties;
using AttendenceSystem_Alp;
using AttendenceSystem_Alp.PC;
using HDFingerPrintHelper;
using RemObjects.DataAbstract;
using Helpers;
using Telerik.WinControls.UI;
//数据类型 C#-> C++
using FP_HANDLE = System.IntPtr;
using int8_t = System.Char;
using int16_t = System.Int16;
using int32_t = System.Int32;
using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using INT = System.Int32;
using UINT = System.UInt32;
//数据类型 C#-> C++


namespace AttendanceSystemAlpha
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        
        #region Private fields
        private DataModule fDataModule;
        private DataTable _propertiesTable;
        private LoginForm loginForm;
        private RadFrmShowClasses frmShowClasses;
        private RadfrmChooseClasses frmChooseClasses;
        private string _teacherName = "";
        private string _currentPasswd = "AAC0A9DAA4185875786C9ED154F0DECE";
        
        private DataTable dmTable;
        private DataTable xsidTable;
        private DataTable xkTable;
        private int _buffDatabaseNum;
        private Briefcase propertieBriefcase;
        private DataTable _mngPropertiesTable;
        private Briefcase _mngPropertieBriefcase;
        private DateTime classTime;
        private string jsid = "";
        
        private string mngTeacherName;
        private string mngCurrentPasswd;
        private Briefcase mngchooseClassBriefcase;
        private DataTable mngdmTable;
        private DataTable mngSKtable;
        private DataTable jieciDisplayTable;
        private long JieCi;
        private string mngClassName;
        FP_HANDLE FpHandle;

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object[] propertyValue);
        private volatile Boolean ContinueOpration = true;
        private int nRet = 0;
        private ushort FingerprinterVerifyID = 0;
        private ushort FingerprinterScore = 0;
        private ManualRollCall frmmanualRollCall;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            
            xsidTable = new DataTable("学生信息");
            fDataModule = new DataModule();
            
            if (System.IO.File.Exists(Properties.Settings.Default.PropertiesBriefcaseFolder)) return;
            try
            {
                if (!Directory.Exists(string.Format(Properties.Settings.Default.OfflineFolder, " ")))
                Directory.CreateDirectory(string.Format(Properties.Settings.Default.OfflineFolder, " "));
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
                MessageBox.Show("出现错误： " + exception.Message);
                return;
            }
            
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
           
            this.Visible = false;
            //平板和笔记本的区别
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
            //else
            //{
            //    this.FormBorderStyle = FormBorderStyle.None;
            //    this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            //    this.WindowState = FormWindowState.Maximized;
            //}
            
            //平板和笔记本的区别
            this.Width = 1280;
            this.Height = 775;
            string __serverUrl = File.ReadAllText(@"ServerUrl.txt");
            
            fDataModule.setServerURL(__serverUrl);
            Properties.Settings.Default.ServerUrl = __serverUrl;
            
            frmShowClasses = new RadFrmShowClasses(fDataModule);
            frmChooseClasses = new RadfrmChooseClasses();
            
            //**********饼图*********//

            List<string> xData = new List<string>() { "实到：0", "未到:50" };
            List<int> yData = new List<int>() {0 , 50 };
            //chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            //chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            chart1.Series[0].Points.DataBindXY(xData, yData);
            chart2.Series[0].Points.DataBindXY(xData, yData);
            //***********饼图*********//
            this.Visible = true;
            SetMngControlInvisible();
            panel19.Visible = panel22.Visible = false;
        }


        private void mainPageView_MouseUp(object sender, MouseEventArgs e)
        {
          
            switch (mainPageView.SelectedPage.Name)
            {
                case "viewpageLoadData":
                    
                    break;
                case "viewpageCall":
                    
                    break;
                case "viewpageDataManagement":
                    if (!Directory.Exists(string.Format(Properties.Settings.Default.OfflineFolder, "")) || Directory.GetFiles(string.Format(Properties.Settings.Default.OfflineFolder, "")).Length == 0)
                    {
                        MessageBox.Show("没有离线数据 请先下载离线数据");
                    }
                    else
                    {
                        _mngPropertieBriefcase = new FileBriefcase(Properties.Settings.Default.PropertiesBriefcaseFolder, true);
                        _mngPropertiesTable = _mngPropertieBriefcase.FindTable("PropertiesTable");
                        
                    }
                    
                    break;
            }
        }


        /// <summary>
        /// 结束点名按钮函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radButton1_Click(object sender, EventArgs e)
        {

            DataTable ClassStatusTable = frmChooseClasses._chooseClassBriefcase.FindTable("ClassStatus");
            // todo manangement
             DataRow mngClassStatusRow = ClassStatusTable.Select("Table编号 = '" + frmChooseClasses.Jieci.ToString() + "'")
                    .First();

            mngClassStatusRow.BeginEdit();
            mngClassStatusRow["签到情况"] = "已签到";
            mngClassStatusRow.EndEdit();
            frmChooseClasses._chooseClassBriefcase.AddTable(ClassStatusTable);
            frmChooseClasses._chooseClassBriefcase.WriteBriefcase();
            DataTable sktable = frmChooseClasses._chooseClassBriefcase.FindTable("SKTABLE");
            DataRow skRow = null;
            skRow = sktable.Select("SKNO = '" + frmChooseClasses.Jieci.ToString() + "'").First();
            skRow.BeginEdit();
            skRow["SKDATE"] = DateTimePicker1.Value;
            skRow.EndEdit();
            frmChooseClasses._chooseClassBriefcase.AddTable(OfflineHelper.TableListToDataTable(EnumerableExtension.ToList<SKTABLE_07_VIEW>(sktable), "SKTABLE"));
            frmChooseClasses._chooseClassBriefcase.WriteBriefcase();
            
            radButton1.Enabled = false;
            rbtnStartcall.Enabled = true;
            lbStudentClass.Text = "";
            lbStudentId.Text = "";
            lbStudentXy.Text = "";
            lbStudentName.Text = "";
            lbDczt.Text = "";
            lbDcsj.Text = "";
            pboxPhoto.Image = Properties.Resources.attendance_list_icon;
            ContinueOpration = false;
            HDFingerprintHelper.FpCloseUsb(FpHandle);
            lbStudentName.Text = "学生姓名";
            panel19.Visible = panel22.Visible = false;
            radButton1.Enabled = false;
            rbtnStartcall.Enabled = true;
            BtnManualRollCall.Enabled = false;
        }
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
            dmRows = dmTable.Select("DKZT = 3 or DKZT = 5");
            return dmRows.Count();
        }
        

        private void ShowOfflineInformations()
        {
            //DataTable mngxkTable = null;
            DataTable dtResault = new DataTable();
            if (!dtResault.Columns.Contains("到课状态"))
            {
                dtResault.Columns.Add("姓名", typeof (string));
                dtResault.Columns.Add("到课状态", typeof (string));
                dtResault.Columns.Add("学号", typeof (string));
                dtResault.Columns.Add("到课时间", typeof (DateTime));
            }

            //mngxkTable = mngchooseClassBriefcase.FindTable("XKTABLE_VIEW1");//从briefcase中将选课表拉出来
            //mngGridView.DataSource = mngdmTable;
            int _studentTotal = 0;
            int _sdrs = 0;
            double _dkpercent = 0.0;
            _studentTotal = mngdmTable.Rows.Count;
            //_studentTotal = (CountArriveSudentNumber(mngdmTable) + CountLateStudentNumber(mngdmTable) +
            //                CountLeaveEarly(mngdmTable) + CountAbsentStudent(mngdmTable));//todo: 直接数人数
            _sdrs = (CountArriveSudentNumber(mngdmTable) + CountLateStudentNumber(mngdmTable));
            _dkpercent = (_sdrs / Convert.ToDouble(_studentTotal));
            //lbMngStudentTotal.Text = _studentTotal.ToString();
            //lbMngsdrs.Text = _sdrs.ToString();
            //lbMngDkpercent.Text = string.Format("{0:P}", _dkpercent);
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
                    case "4":
                    {
                        resaultRow["到课状态"] = "请假";
                        break;
                    }
                    case "5":
                    {
                        resaultRow["到课状态"] = "未签到";
                        break;
                    }
                }
                resaultRow["姓名"] = Row["XSNAME"].ToString();
                //resaultRow["到课时间"] = Convert.ToDateTime(Row["DMSJ1"]);\
                if (Row["DMSJ1"] != DBNull.Value)
                {
                    resaultRow["到课时间"] = Convert.ToDateTime(Row["DMSJ1"]);
                }

                dtResault.Rows.Add(resaultRow);
            }
           
            mngGridView.DataSource = dtResault;
            //lbMngOfflineStatus.Text = "未提交";
            //**********饼图*********//

            List<string> xData = new List<string>() { "实到：" + _sdrs + "人", "未到" + (_studentTotal - _sdrs) + "人" };
            List<int> yData = new List<int>() { _sdrs, _studentTotal-_sdrs };
            //chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            //chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            chart2.Series[0].Points.DataBindXY(xData, yData);
            //***********饼图*********//
            
        }

      

        private void radButton2_Click(object sender, EventArgs e)
        {            
            try
            {
                loginForm = new LoginForm(fDataModule , jsid); // todo get userID
                loginForm.ShowDialog();
                if (!loginForm.IsLogin()) return;
                ProgressHelper.StartProgressThread();
                int __count = mngdmTable.Rows.Count;
                int i = 0;
                foreach (DataRow dr in mngdmTable.Rows)
                {
                    dr.BeginEdit();
                    dr["POSTDATE"] = DateTime.Now;
                    dr["POSTMANNO"] = Convert.ToDecimal(fDataModule.GetUserID());
                    if ((Int16) dr["DKZT"] == 5)
                    {
                        dr["DKZT"] = (Int16)3;
                    }
                    dr.EndEdit();
                    ProgressHelper.SetProgress((int) (20*(++i/__count)));
                }
                ProgressHelper.SetProgress(20);//progress:  0-20
                var dmtableList = EnumerableExtension.ToList<DMTABLE_08_NOPIC_VIEW>(mngdmTable);
                mngchooseClassBriefcase.AddTable(OfflineHelper.TableListToDataTable(dmtableList,JieCi.ToString()));
                i = 0;
                foreach (var dmtable08 in dmtableList)
                {
                    fDataModule.UpdateDmtable(dmtable08); // dmtable update完成
                    ProgressHelper.SetProgress(20+ (int) (70*(++i/__count)));
                }
                fDataModule.ApplyChanges(); 
                ProgressHelper.SetProgress(90);
                //mngSKtable = _chooseClassBriefcase.FindTable() // todo update sktable 点名方式 早退人数
                long _skno = JieCi;
                fDataModule.GetSktableQueryUpload(_skno);
                if (!fDataModule.Context.SKTABLE_07_VIEW.Any()) // 选择 sktable需要上传的那一列
                {
                    throw new Exception("数据库异常 找不到该教师的相关信息 \n请重试或者联系管理员");
                }

                //rowSktable07:需要上传的那一列
                SKTABLE_07_VIEW rowSktable07 = fDataModule.Context.SKTABLE_07_VIEW.First();
                rowSktable07.EDITDATE = DateTime.Now;
                //rowSktable07.DMFS = Convert.ToInt16(2);
                rowSktable07.EDITMANNO = Convert.ToInt64(fDataModule.GetUserID());
                
                rowSktable07.CDRS = Convert.ToInt16(CountLateStudentNumber(mngdmTable));
                rowSktable07.KKRS = Convert.ToInt16(CountAbsentStudent(mngdmTable));
                rowSktable07.ZCRS = Convert.ToInt16(CountArriveSudentNumber(mngdmTable));
                
                
                
                //SKTABLE_07 rowSktable07 = new SKTABLE_07();
                //rowSktable07.EDITDATE = DateTime.Now;
                rowSktable07.DMFS = Convert.ToInt16(1); // 一次点名
                rowSktable07.RZFS = Convert.ToInt16(2); // 指纹认证
                //rowSktable07.EDITMANNO = Convert.ToInt64(fDataModule.GetUserID());
                rowSktable07.ZTRS = 0;
                //rowSktable07.ZTRS = Convert.ToInt16(CountLeaveEarly(mngdmTable));
                rowSktable07.CDRS = Convert.ToInt16(CountLateStudentNumber(mngdmTable));
                rowSktable07.SKDATE =
                    Convert.ToDateTime(
                        mngSKtable.Select("SKNO = '" + rowSktable07.SKNO.ToString() + "'").First()["SKDATE"]);
                rowSktable07.SKZT = 1;

                fDataModule.UpdateSktable(rowSktable07); // sktable 提交完成
                ProgressHelper.SetProgress(95);
                fDataModule.ApplyChanges();//提交更改

                DataTable mngClassStatusTable = mngchooseClassBriefcase.FindTable("ClassStatus");
                
                DataRow mngClassStatusRow = mngClassStatusTable.Select("Table编号 = '" + rowSktable07.SKNO + "'")
                        .First();
                    
                mngClassStatusRow.BeginEdit();
                mngClassStatusRow["离线数据提交情况"] = "已提交";
                mngClassStatusRow.EndEdit();
                mngchooseClassBriefcase.AddTable(mngClassStatusTable);
                mngchooseClassBriefcase.WriteBriefcase();
                ProgressHelper.SetProgress(100);
                ProgressHelper.StopProgressThread();
                ProgressHelper.SetProgress(0);
                //lbMngOfflineStatus.Text = "数据提交成功";
                toolStripOperationStatus.Text = "数据提交成功";
                MessageBox.Show("数据提交成功");
                jsid = "";
                loginForm.Close();

            }
            catch (Exception exception)
            {
                ProgressHelper.StopProgressThread();
                ProgressHelper.SetProgress(0);
                //lbMngOfflineStatus.Text = "数据提交失败 请将以下信息提供给管理员：" +exception.Message;
                MessageBox.Show("数据提交失败 请将以下信息提供给管理员：" + exception.Message);
                return;
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripTimeLabel.Text = DateTime.Now.ToString();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            loginForm = new LoginForm(fDataModule);
            loginForm.ShowDialog(); // 登录
            if (loginForm.IsLogin())   // 判断登录结果
            {
                frmShowClasses.ShowDialog();
            }
            if (!File.Exists(Properties.Settings.Default.PropertiesBriefcaseFolder)) return;
            Briefcase ____briefcase = new FileBriefcase(Properties.Settings.Default.PropertiesBriefcaseFolder, true);
            DataTable ____datatable = ____briefcase.FindTable("PropertiesTable");
            lboxClassName.DataSource = ____datatable;
            this.lboxClassName.DisplayMember = "开课名称";
            lboxClassName.ValueMember = "开课编号";
            loginForm.Close();
        }

        private void rbtnStartcall_Click_1(object sender, EventArgs e)
        {
            xsidTable = new DataTable("学生信息");
            
            if (!Directory.Exists(string.Format(Properties.Settings.Default.OfflineFolder, "")) || System.IO.Directory.GetFiles(string.Format(Properties.Settings.Default.OfflineFolder, "")).Length == 0)
            {
                MessageBox.Show("没有离线数据 请先下载离线数据");
                return;
            }
            toolStripOperationStatus.Text = "开始点名";
            frmChooseClasses.ShowDialog(); // 获得各种信息 弹窗 
            if (!frmChooseClasses.flag) return;
            dmTable = frmChooseClasses.DmTable;
            
            propertieBriefcase = frmChooseClasses.propertieBriefcase;
            if (!xsidTable.Columns.Contains("学生学号"))
            {
                xsidTable.Columns.Add("学生学号");
            }
            if (!xsidTable.Columns.Contains("指纹识别号"))
            {
                xsidTable.Columns.Add("指纹识别号");
            }

            //选择上课时间
            FrmChooseDate frmChooseDate = new FrmChooseDate(frmChooseClasses.SjSkdate , frmChooseClasses.YdSkdate);
            frmChooseDate.ShowDialog();
            if (frmChooseDate.isChanged)
            {
                DateTimePicker1.Value = frmChooseDate.dt;
                frmChooseDate.Close();
            }
            else
            {

                frmChooseDate.Close();
                MessageBox.Show("您取消了操作");
                toolStripOperationStatus.Text = "您取消了点名操作";
                return;
            }
            //选择上课时间
            xkTable = frmChooseClasses._chooseClassBriefcase.FindTable("XKTABLE_VIEW1");
            
            ProgressHelper.StartProgressThread();
            while ((FpHandle = HDFingerprintHelper.FpOpenUsb(0xFFFFFFFF, 1000)) == IntPtr.Zero)
            {
                
            }// 初始化指纹仪
            
            uint16_t fingerId = 0;
            nRet =  HDFingerprintHelper.FpEmpty(FpHandle, 0); // 清空指纹仪
            if (nRet != 0)
            {
                ProgressHelper.StopProgressThread();
                MessageBox.Show("指纹仪初始化失败 错误代码:" + nRet.ToString());
                return;
            }
            ProgressHelper.SetProgress(10);
            int __count = xkTable.Rows.Count;
            int i = 0;
            foreach (DataRow dataRows in xkTable.Rows.Cast<DataRow>().Where(dataRows => dataRows["ZW2"] != DBNull.Value))
            {
                HDFingerprintHelper.Download1Fingerprint(FpHandle, dataRows["ZW2"].ToString(), fingerId); // 下载一条指纹字符串到指纹仪中

                try
                {
                    DataRow xsidRow = xsidTable.NewRow();
                    xsidRow["学生学号"] = dataRows["XSID"].ToString();
                    xsidRow["指纹识别号"] = fingerId.ToString();
                    xsidTable.Rows.Add(xsidRow);
                    fingerId++; // 指纹编号递增
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                //ProgressHelper.SetProgress((int)(80 * (++i / __count)));
                ProgressHelper.SetProgress((int)Math.Ceiling((20.0 + 80.0 * ((double)i / (double)__count))));
                i += 1;
            }
            lbTeacherName.Text = frmChooseClasses.TeacherName;
            lbClassName.Text = frmChooseClasses.ClassName;
            preparedTime.Value = frmChooseClasses.SjSkdate; 
            lbClassName.Text = frmChooseClasses.ClassName;
            rbtnStartcall.Enabled = false;
            radButton1.Enabled = true;
            panel19.Visible = panel22.Visible = true; // 设置信息区域可见
            //**********饼图*********//

            List<string> xData = new List<string>() { "实到：0 人", "未到：" + frmChooseClasses.DmTable.Rows.Count+"人" };
            List<int> yData = new List<int>() { 0, frmChooseClasses.DmTable.Rows.Count };
            //chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            //chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            chart1.Series[0].Points.DataBindXY(xData, yData);
            //***********饼图*********//
            //this.lbYdrs.Text = frmChooseClasses.DmTable.Rows.Count.ToString();
            //this.lbSdrs.Text = "0";
            //this.lbMngDkpercent.Text = "0.00%"; // 这段代码是用来初始化label显示的。
            ContinueOpration = true;
            
            Thread verifyThread = new Thread(VerifyFingerprint);
            verifyThread.IsBackground = true;
            verifyThread.Start();
           
            
            ProgressHelper.SetProgress(100);
            
            radButton1.Enabled = true;
            rbtnStartcall.Enabled = false;
            BtnManualRollCall.Enabled = true;
            ProgressHelper.StopProgressThread();
        }

        private void rbtnMngShowInformation_Click(object sender, EventArgs e)
        {
            frmChooseClasses.ShowDialog();
            if (!frmChooseClasses.flag) return;
            mngdmTable = frmChooseClasses.DmTable;
            mngTeacherName = frmChooseClasses.TeacherName;
            JieCi = frmChooseClasses.Jieci;
            mngClassName = frmChooseClasses.ClassName;
            dateTimePicker2.Value = frmChooseClasses.SjSkdate;
            mngchooseClassBriefcase = frmChooseClasses._chooseClassBriefcase;
            jsid = mngchooseClassBriefcase.Properties[GlobalParams.PropertiesTeacherID]; // 获取教师工号 用于上传登录
            ShowOfflineInformations(); // 离线数据显示
            mngGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            mngGridView.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            mngGridView.Columns["到课时间"].Width = 75;
            //*********以上测试良好 ****************//
            lbMngTeacherName.Text = mngTeacherName;
            lbMngClassName.Text = mngClassName;
            lbMngjieci.Text = string.Format("第{0}节", frmChooseClasses.Jieci);
            lbMngCallMethod.Text = "指纹点名";
            
            radButton2.Enabled = true;
            mngSKtable = mngchooseClassBriefcase.FindTable("SKTABLE");
            
            SetMngControlVisible();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel18.Visible = false;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.Exig_mouse_off;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.Exit_mouse_on;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.Exig_mouse_off;
            pictureBox2.BorderStyle = BorderStyle.None;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.Exit_mouse_on;
            pictureBox2.BorderStyle = BorderStyle.None;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dr2 = MessageBox.Show("确定退出吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr2 != DialogResult.OK) return;
            this.Close();
            Application.Exit();
        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {
            if (!File.Exists(Properties.Settings.Default.PropertiesBriefcaseFolder)) return;
            Briefcase ____briefcase = new FileBriefcase(Properties.Settings.Default.PropertiesBriefcaseFolder, true);
            DataTable ____datatable = ____briefcase.FindTable("PropertiesTable");
            lboxClassName.DataSource = ____datatable;
            this.lboxClassName.DisplayMember = "开课名称";
            lboxClassName.ValueMember = "开课编号";
        }

        private void VerifyFingerprint()
        {
            while (ContinueOpration)
            {
                DataTable classTable = propertieBriefcase.FindTable("ClassNameTable"); // 班级表
                int sdrs = 0;
                int dkrs = 0;
                int similarity = 0;
                int IdentifyNum = 0;
                string XSID = "";
                string xsName = "";
                byte[] xszpBytes = null;
                
                nRet =  HDFingerprintHelper.StartVerify(FpHandle, "fingerprint.bmp", ref  FingerprinterVerifyID, ref  FingerprinterScore,
                   3000); // 新的指纹仪验证语句 如果没有检测到指纹 返回值为9 即没有搜索到指纹
                
                if (File.Exists("fingerprint.bmp"))
                {
                    FileStream fs = new FileStream("fingerprint.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
                    BinaryReader br = new BinaryReader(fs);
                    MemoryStream ms = new MemoryStream(br.ReadBytes((int)fs.Length));
                    try
                    {
                        SetControlPropertyThreadSafe(pboxPhoto, "Image", new object[] { Image.FromStream(ms) });
                    }
                    catch (Exception)
                    {
                        
                    }
                    fs.Close();
                }
                
                DataRow[] xsidRows;
                DataRow[] dmRows;
                DataRow[] xkRows;

                classTime = DateTimePicker1.Value;
                 xsidRows = xsidTable.Select("指纹识别号 = '" + FingerprinterVerifyID.ToString() + "'");

                System.Media.SoundPlayer player; // 声音 player 声明
                try
                {
                    switch (nRet)
                    {
                        case 0: // 这个分支被lock了 lock对象：ThreadLocker.CallingBriefcaseLocker
                        {

                            lock (ThreadLocker.CallingBriefcaseLocker)
                            {
                                XSID = xsidRows.First()["学生学号"].ToString();
                                dmRows = dmTable.Select("XSID = '" + XSID + "'");

                                // Briefcase briefcase =
                                // new FileBriefcase(string.Format(Properties.Settings.Default.OfflineFolder, cbboxClassname.SelectedValue), true);

                                dmRows.First().BeginEdit();
                                //dmRows.First()["DMSJ1"] = DateTime.Now; //Convert.ToInt16(1);


                                if ((DateTime.Compare(DateTimePicker1.Value, DateTime.Now.AddMinutes(15)) > 0) || (DateTime.Compare(DateTimePicker1.Value.AddHours(2), DateTime.Now) < 0))
                                {
                                    dmRows.First().EndEdit();
                                    SetControlPropertyThreadSafe(lbStudentName , "Text" , new object[]{"还未到点名时间"});
                                    player = new SoundPlayer(Resources.beepFail);
                                    player.Play();//播放声音
                                    player.Dispose();
                                    continue;
                                }

                                Boolean errFlag = dmTable.Rows.Cast<DataRow>().Any(dr => dr["DMSJ1"] != DBNull.Value && DateTime.Compare((DateTime) dr["DMSJ1"], DateTime.Now) > 0); // 判断当前时间是否在数据库最大的时间之前。如果是，该变量应为true
                                if (errFlag)
                                { // 如果为false，跳出循环
                                    continue;
                                }


                                player = new SoundPlayer(Resources.beepSuccess);
                                player.Play(); // 播放声音
                                player.Dispose();
                    
                                if (dmRows.First()["DMSJ1"] == DBNull.Value || (Convert.ToDateTime(dmRows.First()["DMSJ1"]) > DateTime.Now)) // 判断是否在点名时间范围内
                                {
                                    dmRows.First()["DMSJ1"] = DateTime.Now;
                                }

                                if (DateTimePicker1.Value > Convert.ToDateTime(dmRows.First()["DMSJ1"]))
                                {
                                    dmRows.First()["DKZT"] = 0;
                                    //lbDczt.Text = "按时到课";
                                    SetControlPropertyThreadSafe(lbDczt, "Text", new object[] { "按时到课" });
                                }
                                else
                                {
                                    dmRows.First()["DKZT"] = 1;
                                    //lbDczt.Text = "迟到";
                                    SetControlPropertyThreadSafe(lbDczt, "Text", new object[] { "迟到" });
                                }
                                dmRows.First().EndEdit();

                                //briefcase.RemoveTable(GlobalParams.SKNO); //briefcase直接addtable 代表更新
                                //briefcase.WriteBriefcase();


                                //dmTable.TableName = GlobalParams.SKNO;
                                dmTable = OfflineHelper.TableListToDataTable(EnumerableExtension.ToList<DMTABLE_08_NOPIC_VIEW>(dmTable),
                                    frmChooseClasses.Jieci.ToString());
                                frmChooseClasses._chooseClassBriefcase.AddTable(dmTable);
                                frmChooseClasses._chooseClassBriefcase.Properties[Settings.Default.PropertiesLastCheckin] = frmChooseClasses.Jieci.ToString();
                                frmChooseClasses._chooseClassBriefcase.WriteBriefcase();//写入briefcase
                                sdrs = CountArriveSudentNumber(dmTable) + CountLateStudentNumber(dmTable);
                                //显示信息
                                xkRows = xkTable.Select("XSID = '" + XSID + "'");

                                DataRow bjRow = classTable.Select("BJID = '" + xkRows.First()["BJID"].ToString() + "'").First();

                                //lbStudentXy.Text = bjRow["XYNAME"].ToString();
                                SetControlPropertyThreadSafe(lbStudentXy, "Text", new object[] { bjRow["XYNAME"].ToString() });
                                //lbStudentClass.Text = bjRow["BJNAME"].ToString();
                                SetControlPropertyThreadSafe(lbStudentClass, "Text", new object[] { bjRow["BJNAME"].ToString() });

                                xsName = xkRows.First()["XSNAME"].ToString();
                                if (xkRows.First()["XSZP"] != DBNull.Value)
                                {
                                    xszpBytes = (byte[])xkRows.First()["XSZP"];
                                    Stream ms = new MemoryStream(xszpBytes);
                                    ms.Write(xszpBytes, 0, xszpBytes.Length);
                                    //pboxPhoto.Image = Image.FromStream(ms);
                                    SetControlPropertyThreadSafe(pboxPhoto, "Image", new object[] { Image.FromStream(ms) });
                                }
                                else
                                {
                                    //pboxPhoto.Image = Properties.Resources.attendance_list_icon;
                                    SetControlPropertyThreadSafe(pboxPhoto, "Image", new object[] { Resources.attendance_list_icon });
                                }

                                //lbStudentName.Text = xsName;
                                SetControlPropertyThreadSafe(lbStudentName, "Text", new object[] { xsName });
                                //lbStudentId.Text = XSID;
                                SetControlPropertyThreadSafe(lbStudentId, "Text", new object[] { XSID });
                                //lbDcsj.Text = Convert.ToDateTime(dmRows.First()["DMSJ1"]).ToString("t", DateTimeFormatInfo.InvariantInfo);
                                SetControlPropertyThreadSafe(lbDcsj, "Text", new object[] { Convert.ToDateTime(dmRows.First()["DMSJ1"]).ToString("t", DateTimeFormatInfo.InvariantInfo) });

                                //lbYdrs.Text =  briefcase.Properties[Properties.Settings.Default.PropertiesTotalStudentNumber];
                                //lbYdrs.Text = dmTable.Rows.Count.ToString();
                                //***********************更新label显示**********************************
                                //SetControlPropertyThreadSafe(lbYdrs, "Text", new object[] { dmTable.Rows.Count.ToString() });
                                ////lbDKPercent.Text = (Convert.ToDouble(sdrs) / Convert.ToDouble(lbYdrs.Text)).ToString("0.00%");
                                //SetControlPropertyThreadSafe(lbDKPercent, "Text", new object[] { (Convert.ToDouble(sdrs) / Convert.ToDouble(lbYdrs.Text)).ToString("0.00%") });
                                ////lbSdrs.Text = sdrs.ToString();
                                //SetControlPropertyThreadSafe(lbSdrs, "Text", new object[] { sdrs.ToString() });

                                ////lbCdrs.Text = CountLateStudentNumber(dmTable).ToString();
                                //SetControlPropertyThreadSafe(lbCdrs, "Text", new object[] { CountLateStudentNumber(dmTable).ToString() });
                                //***********************更新label显示**********************************
                                //**********饼图*********//

                                List<string> xData = new List<string>() { "实到:" + sdrs + "人", "未到" + (dmTable.Rows.Count-sdrs) + "人" };

                                List<int> yData = new List<int>() { sdrs, dmTable.Rows.Count - sdrs };
                                //chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
                                //chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
                                //chart1.Series[0].Points.DataBindXY(xData, yData);
                                //SetControlPropertyThreadSafe(chart1, "Series[0].Points.DataBindXY"  , new object[]{xData , yData} );
                                chart1.Invoke((MethodInvoker) delegate { chart1.Series[0].Points.DataBindXY(xData, yData); });
                                HDFingerprintHelper.LiftUrFinger(FpHandle , 5000);
                                //***********饼图*********//
                            }//Locker:ThreadLocker.CallingBriefcaseLocker
                        }
                            break;
                        case 9:
                            player = new SoundPlayer(Resources.beepFail);
                            player.Play();//播放声音
                            player.Dispose();
                            SetControlPropertyThreadSafe(lbStudentClass, "Text", new object[] { "" });
                            SetControlPropertyThreadSafe(lbStudentId, "Text", new object[] { "" });
                            SetControlPropertyThreadSafe(lbStudentXy, "Text", new object[] { "" });
                            SetControlPropertyThreadSafe(lbStudentName, "Text", new object[] { "请重扫指纹" });
                            SetControlPropertyThreadSafe(lbDczt, "Text", new object[] { "" });
                            SetControlPropertyThreadSafe(lbDcsj, "Text", new object[] { "" });
                            break;
                        default:
                            if (!ContinueOpration)
                            {
                                player = new SoundPlayer(Resources.beepSuccess);
                                player.Play();//播放声音
                                player.Dispose();
                                //lbStudentClass.Text = "";
                                SetControlPropertyThreadSafe(lbStudentClass, "Text", new object[] { "" });
                                //lbStudentId.Text = "";
                                SetControlPropertyThreadSafe(lbStudentId, "Text", new object[] { "" });
                                //lbStudentXy.Text = "";
                                SetControlPropertyThreadSafe(lbStudentXy, "Text", new object[] { "" });
                                //lbStudentName.Text = "请重扫指纹";
                                SetControlPropertyThreadSafe(lbStudentName, "Text", new object[] { "学生姓名" });
                                //lbDczt.Text = "";
                                SetControlPropertyThreadSafe(lbDczt, "Text", new object[] { "" });
                                //lbDcsj.Text = "";
                                SetControlPropertyThreadSafe(lbDcsj, "Text", new object[] { "" });
                                //pboxPhoto.Image = Properties.Resources.attendance_list_icon;
                                //SetControlPropertyThreadSafe(pboxPhoto, "Image", new object[] { Properties.Resources.attendance_list_icon });
                            }
                            else
                            {
                                MessageBox.Show("指纹仪被拔出或未连接 请重新插入指纹仪 并点击确定 错误代码" + nRet.ToString()+FpHandle.ToString());
                                FpHandle = IntPtr.Zero;
                                while (FpHandle == IntPtr.Zero)
                                {
                                    FpHandle = HDFingerprintHelper.FpOpenUsb(0xFFFFFFFF, 1000);
                                    if (FpHandle == IntPtr.Zero)
                                    {
                                        MessageBox.Show("指纹仪初始化失败，请重新插入指纹仪");
                                    }
                                }
                                MessageBox.Show("指纹仪初始化成功");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("出现了一个错误。请将错误代码报告给管理员。错误代码：" + e.Message+"单击 确定 继续点名操作");
                }
            }
            
            //if (nRet == 512)
        }
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object[] propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control,  propertyValue );
            }
        }
        

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void DateTimePicker1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        /// <summary>
        /// 将数据管理控件设置为不可见
        /// </summary>
        private void SetMngControlInvisible()
        {
            PnMngClassInfo.Visible = false;
            mngGridView.Visible = false;
        }
        /// <summary>
        /// 将数据管理控件设置为可见
        /// </summary>
        private void SetMngControlVisible()
        {
            PnMngClassInfo.Visible = true;
            mngGridView.Visible = true;
            
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(string.Format(Properties.Settings.Default.OfflineFolder, "")) || System.IO.Directory.GetFiles(string.Format(Properties.Settings.Default.OfflineFolder, "")).Length == 0)
            {
                MessageBox.Show("没有离线数据 请先下载离线数据");
                return;
            }
        }
        //手动签到部分->>
        private void BtnManualRollCall_Click(object sender, EventArgs e)
        {
            Briefcase classBriefcase = new FileBriefcase(string.Format(Properties.Settings.Default.OfflineFolder,Properties.Settings.Default.CurrentRollCallClassNO), true); // 根据properties中的CurrentRollCallClassNO选中课程 并提取密码

            string currentPasswd = classBriefcase.Properties[Properties.Settings.Default.PropertiesBriefcasePasswd];
            frmVerifyOfflinePasswd frmVerifyOfflinePasswd = new frmVerifyOfflinePasswd(currentPasswd);
            frmVerifyOfflinePasswd.ShowDialog();
            if (frmVerifyOfflinePasswd.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            lock (ThreadLocker.CallingBriefcaseLocker)
            {
                Briefcase manualRollCallBriefcase = frmChooseClasses._chooseClassBriefcase;
                frmmanualRollCall = new ManualRollCall(manualRollCallBriefcase, frmChooseClasses.Jieci, ref dmTable, DateTimePicker1.Value);
            }
            frmmanualRollCall.ShowDialog();
            lock (ThreadLocker.CallingBriefcaseLocker)
            {
                dmTable = frmChooseClasses._chooseClassBriefcase.FindTable(frmChooseClasses.Jieci.ToString());
                int sdrs = CountArriveSudentNumber(dmTable) + CountLateStudentNumber(dmTable);
                List<string> xData = new List<string>() { "实到:" + sdrs + "人", "未到" + (dmTable.Rows.Count - sdrs) + "人" };

                List<int> yData = new List<int>() { sdrs, dmTable.Rows.Count - sdrs };
                //chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
                //chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
                //chart1.Series[0].Points.DataBindXY(xData, yData);
                //SetControlPropertyThreadSafe(chart1, "Series[0].Points.DataBindXY"  , new object[]{xData , yData} );
                chart1.Invoke((MethodInvoker)delegate { chart1.Series[0].Points.DataBindXY(xData, yData); });
            }
        }
        //<<-手动签到部分
    }
}
