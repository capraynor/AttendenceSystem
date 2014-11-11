using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AttendenceSystem_Alp.PC;
using AttendenceSystem_Alp.Properties;
using RemObjects.DataAbstract.Server;
using RemObjects.InternetPack;
using RemObjects.SDK;
using RemObjects.DataAbstract;
using RemObjects.DataAbstract.Linq;

namespace AttendenceSystem_Alp
{
    public partial class DataModule : Component
    {
        
        #region FuncDefinition

        /// <summary>
        /// datamodule实例化以后需要运行此函数
        /// </summary>
        /// <param name="urLstring">relativityserver的地址</param>
        public void SetUp(string urLstring)
        {
            if (urLstring == null) throw new ArgumentNullException("urLstring");
            this.clientChannel.TargetUrl = urLstring;
        }

        public string GetUserID()
        {
            return Properties.Settings.Default.UserId;
        }

        public void SetUserID(string UserID)
        {
            Properties.Settings.Default.UserId = UserID;
        }
        

        public void SetPasswd(string Password)
        {
            Properties.Settings.Default.Password = Password;
        }

        public string GetServerUrl()
        {
            return Properties.Settings.Default.ServerUrl;
        }
        public string getTeacherName()
        {
            return Properties.Settings.Default.UserName;
        }

        public void setServerURL(string serverUrl)
        {
            Properties.Settings.Default.ServerUrl = serverUrl;
        }
        
        
        public bool JstableQuery()
        {
            IQueryable<JSANDKKVIEWRO> jstable03S =
                from c in
                    remoteDataAdapter.GetTable<JSANDKKVIEWRO>() where c.JSID == Convert.ToInt64(Settings.Default.UserId)
                select c;
            this.Context.JSANDKKVIEWRO = jstable03S.ToList();
            return true;
        }
        /// <summary>
        /// 获取教师对应的开课表 并存储于datamodule.context.kktable中
        /// </summary>
        /// <param name="jsid">教师编号</param>
        /// <returns>操作成功：true 操作失败：false</returns>
        public bool GetkkQueryTables(long jsid)
        {
            try
            {
                IQueryable<JSANDKKVIEWRO > kktable05S =
                    from c in
                        this.remoteDataAdapter.GetTable<JSANDKKVIEWRO>()
                        where  c.JSID == jsid
                    select c;
                this.Context.JSANDKKVIEWRO = kktable05S.ToList();
                return true; //获取数据成功
            }
            catch (Exception exception)
            {
                MessageBox.Show("获取数据失败  请重新启动软件 信息：\n" + exception.Message);
                return false;//获取数据失败
            }

        }

        public void GetSktableQueryUpload(long skno)
        {
            IQueryable<SKTABLE_07_VIEW> sktable07S =
                from c in
                    this.remoteDataAdapter.GetTable<SKTABLE_07_VIEW>()
                where c.SKNO == skno
                select c;
            this.Context.SKTABLE_07_VIEW = sktable07S.ToList();
        }
        public void GetSktableQuery(long kkno)
        {
            IQueryable<SKTABLE_07_VIEW> sktable07S =
                from c in
                    this.remoteDataAdapter.GetTable<SKTABLE_07_VIEW>() where c.KKNO == kkno
                select c;
            this.Context.SKTABLE_07_VIEW = sktable07S.ToList();
        }

        /// <summary>
        /// 将服务器的数据离线至本地 
        /// todo:老版本函数 需要重点测试
        /// </summary>
        /// <param name="offlinePasswd"></param>
        /// <param name="checkedItem"></param>
        public int ServerToBriefcase
            (string offlinePasswd, CheckedListBox.SelectedObjectCollection checkedItem)
        {
           
            
            int i = 0;// 你懂的0,0
            
            foreach (var jsandkktable05S in this.Context.JSANDKKVIEWRO)
            {
                try
                {
                    bool flag = false;
                    foreach (JSANDKKVIEWRO jsandkkItem in checkedItem)
                    {
                        flag = (jsandkktable05S.KKNO == jsandkkItem.KKNO);
                    }
                    if (!flag) continue; // 判断该课程是否选中
                    if (
                        !File.Exists(
                            string.Format(GlobalParams.CurrentOfflineDataFile, jsandkktable05S.KKNO.ToString()) +
                            ".daBriefcase"))
                    {
                        StartDownloadData(jsandkktable05S, offlinePasswd);
                        i++;
                    }
                    else
                    {
                        DialogResult dr =
                            MessageBox.Show("课程“" + jsandkktable05S.KKNAME + "”的离线数据存在，要刷新离线数据吗？\n未提交的更改将会被删除",
                                "刷新本地离线数据", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr != DialogResult.OK) continue;
                        DialogResult dr2 = MessageBox.Show("真的确定吗，未提交的数据将被永久删除", "刷新本地离线数据", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question);
                        if (dr2 != DialogResult.OK) continue;
                        File.Delete(
                            string.Format(GlobalParams.CurrentOfflineDataFile, jsandkktable05S.KKNO.ToString()) +
                            ".daBriefcase");
                        StartDownloadData(jsandkktable05S, offlinePasswd);
                        i++;
                    }
                }
                catch (Exception exception)
                {
                    ProgressHelper.StopProgressThread();
                    ProgressHelper.SetProgress(0);
                    MessageBox.Show(exception.Message);
                }
                finally
                {
                    ProgressHelper.StopProgressThread();
                }
            }
            //判断班级表是否被下载 如果没下载 下载
            Briefcase propertiesBriefcase = new FileBriefcase(GlobalParams.PropertiesBriefcaseName, true);
            DataTable classNameTable = null;
            
            
                IQueryable<BJTABLE_09_VIEWRO> bjtable09Viewros =
                    from c in this.remoteDataAdapter.GetTable<BJTABLE_09_VIEWRO>() select c;
                this.Context.BJTABLE_09_VIEWRO = bjtable09Viewros.ToList();

                classNameTable = OfflineHelper.TableListToDataTable(bjtable09Viewros.ToList(), "ClassNameTable");

                propertiesBriefcase.AddTable(classNameTable);
                propertiesBriefcase.WriteBriefcase();
            
            return i;
        }

        private bool StartDownloadData(JSANDKKVIEWRO kktable05, string offlinePasswd) // 一门开课课程
        {
            ProgressHelper.StartProgressThread();
            Briefcase newBriefcase = new FileBriefcase(string.Format(GlobalParams.CurrentOfflineDataFile, kktable05.KKNO.ToString()));
            ProgressHelper.SetProgress(5); // 进度 百分之5
            DataTable classRecordTable = null;
            DataRow classRecordRow = null;
            classRecordTable = new DataTable("ClassStatus");
            if (!classRecordTable.Columns.Contains("Table编号"))
            {
                classRecordTable.Columns.Add("Table编号", type: Type.GetType("System.String"));
                classRecordTable.Columns.Add("课次", type: Type.GetType("System.String"));
                classRecordTable.Columns.Add("签到情况", type: Type.GetType("System.String"));
                classRecordTable.Columns.Add("离线数据提交情况", type: Type.GetType("System.String"));
            }
            newBriefcase.Properties.Add(GlobalParams.PropertiesLastModified, DateTime.Now.ToString());
            newBriefcase.Properties.Add(GlobalParams.PropertiesTeacherName, Properties.Settings.Default.UserName);
            ProgressHelper.SetProgress(6); // 进度 百分之6
            newBriefcase.Properties.Add(GlobalParams.PropertiesTeacherID, Properties.Settings.Default.UserId);
            newBriefcase.Properties.Add(GlobalParams.PropertiesPasswd, offlinePasswd);
            newBriefcase.Properties.Add(GlobalParams.PropertiesClassName, kktable05.KKNAME);
            newBriefcase.Properties.Add(GlobalParams.PropertiesLastCheckin, "1");
            ProgressHelper.SetProgress(10); //进度 百分之10
            newBriefcase.Properties.Add(GlobalParams.PropertiesTotalStudentNumber, kktable05.XXRS.ToString());
            IQueryable<XKTABLE_VIEWRO> xktableView1s =
                from c in
                    remoteDataAdapter.GetTable<XKTABLE_VIEWRO>() where c.KKNO == kktable05.KKNO
                select c;
            ProgressHelper.SetProgress(20);//进度 百分之15

            newBriefcase.AddTable(OfflineHelper.TableListToDataTable(xktableView1s.ToList(), "XKTABLE_VIEW1")); // 将XKTABLE离线出来 带出学生信息

            IQueryable<SKTABLE_07_VIEW> sktableView1s =
                from c in
                    remoteDataAdapter.GetTable<SKTABLE_07_VIEW>()
                where c.KKNO == kktable05.KKNO && c.SKDATE > new DateTime(2014, 10, 14)
                select c;
            //进度 百分之二十
            newBriefcase.AddTable(OfflineHelper.TableListToDataTable(sktableView1s.ToList(), "SKTABLE"));  // 将SKTABLE离线出来 带出每节课的课程信息
            //百分之20
            ProgressHelper.SetProgress(20);
            
            foreach (var sktableView1 in sktableView1s)
            {
                Properties.Settings.Default.ProgressValue += 2;
                IQueryable<DMTABLE_08_NOPIC_VIEW> dmtable08S =
                    from c in
                        remoteDataAdapter.GetTable<DMTABLE_08_NOPIC_VIEW>()where  c.SKNO == sktableView1.SKNO
                    select c;
                newBriefcase.AddTable(OfflineHelper.TableListToDataTable(dmtable08S.ToList(), sktableView1.SKNO.ToString()));
                classRecordRow = classRecordTable.NewRow();
                classRecordRow[0] = sktableView1.SKNO.ToString();
                classRecordRow[1] = sktableView1.SKDATE.ToString();
                if (sktableView1.SKZT == 0)
                {
                    classRecordRow[2] = GlobalParams.DidNotSigned;
                    classRecordRow[3] = GlobalParams.NotSubmitYet;
                }
                else
                {
                    classRecordRow[2] = GlobalParams.Signed;
                    classRecordRow[3] = GlobalParams.Submitted;
                }
                classRecordTable.Rows.Add(classRecordRow);
            }
            ProgressHelper.SetProgress(80);
            newBriefcase.AddTable(classRecordTable); // briefcase里有几个table
            newBriefcase.WriteBriefcase();
            Briefcase propertiesBriefcase = new FileBriefcase(GlobalParams.PropertiesBriefcaseName, true);
            DataTable propertiesTable = propertiesBriefcase.FindTable("PropertiesTable");
            DataRow propertiesRow = null;
            propertiesRow = propertiesTable.NewRow();
            propertiesRow[0] = kktable05.KKNO.ToString();
            propertiesRow[1] = Properties.Settings.Default.UserName;
            propertiesRow[2] = kktable05.KKNAME;
            DataRow[] dataRows = propertiesTable.Select("开课编号 = '" + kktable05.KKNO.ToString() + "'");
            if (dataRows.Length >= 1)
            {

                foreach (var dataRow in dataRows)
                {
                    dataRow.Delete();
                }
                propertiesTable.Rows.Add(propertiesRow);
            }
            else
            {
                propertiesTable.Rows.Add(propertiesRow);
            }
            ProgressHelper.SetProgress(90);
            propertiesBriefcase.RemoveTable("PropertiesTable");

            propertiesBriefcase.AddTable(propertiesTable);
            propertiesBriefcase.WriteBriefcase();
            ProgressHelper.SetProgress(100);
            ProgressHelper.StopProgressThread();
            ProgressHelper.SetProgress(0);
            MessageBox.Show(string.Format("操作成功 课程 【{0}】 已被下载 ", kktable05.KKNAME));
            return true;
        }

        /// <summary>
        /// 上传点名表中的一条记录
        /// </summary>
        /// <param name="dmRows">点名表中的一条记录</param>
        /// <returns>成功 返回true 否则 返回false</returns>
        public void UpdateDmtable(DMTABLE_08_NOPIC_VIEW dmRows)
        {
            remoteDataAdapter.UpdateRow(dmRows);
        }

        public void UpdateSktable(SKTABLE_07_VIEW skRows)
        {
            remoteDataAdapter.UpdateRow(skRows);
        }

        #endregion
        #region Constants
        private const String RelativityConnectionString = @"User Id=""{0}"";Password=""{1}"";Domain=""{2}"";Schema=""{3}""";
        private DataContext _context;

        public DataContext Context
        {
            get { return _context ?? (_context = new DataContext()); }
        }

        #endregion

        #region Constructors
        public DataModule()
        {
            this.InitializeComponent();
            this.message.ClientID = Guid.NewGuid();

            // Loading Relativity Domain and DomainSchema names from the
            // application settings
            this.DomainName = Properties.Settings.Default.Domain;
            this.SchemaName = Properties.Settings.Default.Schema;

            this.IsLoggedOn = false;
        }

        public DataModule(IContainer container)
            : this()
        {
            if (container != null)
                container.Add(this);
        }
        #endregion

        #region Properties
        public RemObjects.DataAbstract.Linq.LinqRemoteDataAdapter DataAdapter
        {
            get
            {
                return this.remoteDataAdapter;
            }
        }

        public String DomainName { get; protected set; }
        
        public String SchemaName { get; protected set; }

        public Boolean IsLoggedOn { get; protected set; }

        public String UserId { get; protected set; }
        #endregion

        #region DataModule Events
        private void ClientChannel_OnLoginNeeded(object sender, LoginNeededEventArgs e)
        {
            // Performing login
            if (this.LogOn(Properties.Settings.Default.UserId, Properties.Settings.Default.Password))
            {
                e.Retry = true;
                e.LoginSuccessful = true;
                return;
            }

            String lUserId;
            String lPassword;

            using (LogOnForm lLoginForm = new LogOnForm())
            {
                if (lLoginForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Login cancelled");
                    return;
                }
                lUserId = lLoginForm.UserId;
                lPassword = lLoginForm.Password;
            }

            if (this.LogOn(lUserId, lPassword))
            {
                e.Retry = true;
                e.LoginSuccessful = true;
            }
            else
                MessageBox.Show("Login failed");
        }
        #endregion

        #region LogOn/LogOff Handling
        public Boolean LogOn(String userId, String password)
        {
            // Note that if your application will use more than 1 Schema in this Domain you should
            // make this Schema active before retrieving data (see the SetActiveSchema method)

            if (String.IsNullOrEmpty(userId))
                return false;

            this.IsLoggedOn = (new RemObjects.DataAbstract.Server.BaseLoginService_Proxy(this.message, this.clientChannel, "LoginService"))
                                                            .LoginEx(String.Format(DataModule.RelativityConnectionString, userId, password, this.DomainName, this.SchemaName));
            if (this.IsLoggedOn)
                this.UserId = userId;

            return this.IsLoggedOn;
        }

        public void LogOff()
        {
            if (this.IsLoggedOn)
            {
                (new RemObjects.DataAbstract.Server.BaseLoginService_Proxy(message, clientChannel, "LoginService")).Logout();
                this.IsLoggedOn = false;
            }
        }
        #endregion

        #region Selecting Schema
        public void SetActiveSchema(String schemaName)
        {
            this.remoteService.ServiceName = "DataService." + schemaName;
            this.SchemaName = schemaName;
        }
        #endregion
        /// <summary>
        /// 从properties中获取登录数据 并进行登录 登录成功后properties中的username会改变
        /// </summary>
        /// <returns>登录成功 返回 true否则返回false</returns>
        public bool login()
        {
            Boolean lLogged = false;
            String lLoginString = string.Format(RelativityConnectionString, Properties.Settings.Default.UserId,
                Properties.Settings.Default.Password, Properties.Settings.Default.Domain,
                Properties.Settings.Default.Schema);
            try
            {
                lLogged = (new BaseLoginService_Proxy(message, clientChannel, "LoginService")).LoginEx(lLoginString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库登录异常 请重启软件或联系管理员\n 异常信息:\n" + ex.Message);
                return false;
            }
            if (!lLogged)
            {
                return false;
            }
            if (!JstableQuery())
            {
                MessageBox.Show("出现错误 请重新启动软件");
                return false;
            }
            Properties.Settings.Default.UserName = this.Context.JSANDKKVIEWRO.First().JSNAME;
            GetkkQueryTables(Convert.ToInt64(Properties.Settings.Default.UserId));
            return true;
        }
        public void ApplyChanges()
        {
            remoteDataAdapter.ApplyChanges();
        }

        public void RefreshStudentInformation(long kkno ,Briefcase ClassBriefcase)
        {
            IQueryable<XKTABLE_VIEWRO> xktableView1s =
               from c in
                   remoteDataAdapter.GetTable<XKTABLE_VIEWRO>()
               where c.KKNO == kkno
               select c;

            ClassBriefcase.AddTable(OfflineHelper.TableListToDataTable(xktableView1s.ToList(), "XKTABLE_VIEW1")); // 将XKTABLE离线出来 带出学生信息
            ClassBriefcase.WriteBriefcase();
            
        }
    }
}