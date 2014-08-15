using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AttendenceSystemClientBeta;
using AttendenceSystem_Alp.PC;
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

        public void SetUp(string urLstring)
        {
            if (urLstring == null) throw new ArgumentNullException("urLstring");
            this.clientChannel.TargetUrl = urLstring;
        }

        public bool JstableQuery()
        {
            IQueryable<JSTABLE_03> jstable03S =
                from c in
                    remoteDataAdapter.GetTable<JSTABLE_03>(new DataParameter[]
                    {new DataParameter("JSID", Convert.ToInt64(Properties.Settings.Default.UserId)),})
                select c;
            this.Context.JSTABLE_03 = jstable03S.ToList();
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
                IQueryable<KKTABLE_05> kktable05S =
                    from c in
                        this.remoteDataAdapter.GetTable<KKTABLE_05>
                        (new DataParameter[] { new DataParameter("JSID", jsid), })
                    select c;
                this.Context.KKTABLE_05 = kktable05S.ToList();
                return true; //获取数据成功
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;//获取数据失败
            }

        }
        public void ServerToBriefcase(string offlinePasswd)
        {

            foreach (var kktable05 in this.Context.KKTABLE_05)
            {
                
                if (
                    File.Exists(string.Format(GlobalParams.CurrentOfflineDataFile, kktable05.KKNO.ToString()) +
                                ".daBriefcase"))
                {
                    MessageBox.Show("课程" + kktable05.KKNAME + "的离线数据存在，将下载最新的离线数据");
                }

                Briefcase newBriefcase = new FileBriefcase(string.Format(GlobalParams.CurrentOfflineDataFile, kktable05.KKNO.ToString()));

                DataTable classRecordTable = null;
                DataRow classRecordRow = null;
                classRecordTable = new DataTable("ClassStatus");
                classRecordTable.Columns.Add("Table编号", type: Type.GetType("System.String"));
                classRecordTable.Columns.Add("课次", type: Type.GetType("System.String"));
                classRecordTable.Columns.Add("签到情况", type: Type.GetType("System.String"));
                classRecordTable.Columns.Add("离线数据提交情况", type: Type.GetType("System.String"));
                newBriefcase.Properties.Add(GlobalParams.PropertiesLastModified, DateTime.Now.ToString());
                newBriefcase.Properties.Add(GlobalParams.PropertiesTeacherName, GlobalParams.jsname);
                newBriefcase.Properties.Add(GlobalParams.PropertiesTeacherID,Properties.Settings.Default.UserId);
                newBriefcase.Properties.Add(GlobalParams.PropertiesPasswd, offlinePasswd);
                newBriefcase.Properties.Add(GlobalParams.PropertiesClassName, kktable05.KKNAME);
                IQueryable<XKTABLE_VIEW1> xktableView1s =
                    from c in
                        remoteDataAdapter.GetTable<XKTABLE_VIEW1>(new DataParameter[] { new DataParameter("KKNO", kktable05.KKNO), })
                    select c;
                newBriefcase.AddTable(OfflineHelper.TableListToDataTable(xktableView1s.ToList(), "XKTABLE_VIEW1")); // 将XKTABLE离线出来 带出学生信息

                IQueryable<SKTABLE_VIEW1> sktableView1s =
                    from c in
                        remoteDataAdapter.GetTable<SKTABLE_VIEW1>(new DataParameter[] { new DataParameter("KKNO", kktable05.KKNO), })
                    select c;

                newBriefcase.AddTable(OfflineHelper.TableListToDataTable(sktableView1s.ToList(), "SKTABLE"));  // 将SKTABLE离线出来 带出每节课的课程信息
                foreach (var sktableView1 in sktableView1s)
                {
                    IQueryable<DMTABLE_08> dmtable08S =
                        from c in
                            remoteDataAdapter.GetTable<DMTABLE_08>(new DataParameter[] { new DataParameter("SKNO", sktableView1.SKNO), })
                        select c;
                    newBriefcase.AddTable(OfflineHelper.TableListToDataTable(dmtable08S.ToList(), sktableView1.SKNO.ToString()));
                    classRecordRow = classRecordTable.NewRow();
                    classRecordRow[0] = sktableView1.SKNO.ToString();
                    classRecordRow[1] = sktableView1.SKDATE.ToString();
                    classRecordRow[2] = GlobalParams.DidNotSigned;
                    classRecordRow[3] = GlobalParams.NotSubmitYet;
                    classRecordTable.Rows.Add(classRecordRow);
                }
                newBriefcase.AddTable(classRecordTable); // briefcase里有几个table
                newBriefcase.WriteBriefcase();
                Briefcase propertiesBriefcase = new FileBriefcase(GlobalParams.PropertiesBriefcaseName, true);
                DataTable propertiesTable = propertiesBriefcase.FindTable("PropertiesTable");
                DataRow propertiesRow = null;
                propertiesRow = propertiesTable.NewRow();
                propertiesRow[0] = kktable05.KKNO.ToString();
                propertiesRow[1] = GlobalParams.jsname;
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
                propertiesBriefcase.RemoveTable("PropertiesTable");

                propertiesBriefcase.AddTable(propertiesTable);
                propertiesBriefcase.WriteBriefcase();

            }
        }
        /// <summary>
        /// 上传点名表中的一条记录
        /// </summary>
        /// <param name="dmRows">点名表中的一条记录</param>
        /// <returns>成功 返回true 否则 返回false</returns>
        public bool UpdateDmtable(DMTABLE_08 dmRows)
        {
            try
            {
                this.remoteDataAdapter.UpdateRow(dmRows);
                return true;
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
                return false;
            }
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
        /// 从properties中获取登录数据 并进行登录
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
            else
            {
                //todo 在properties中将教师名字改一下
                if (!JstableQuery())
                {
                    MessageBox.Show("出现错误 请重新启动软件");
                }
                Properties.Settings.Default.UserName = this.Context.JSTABLE_03.First().JSNAME;
                return true;
            }
        }
    }
}