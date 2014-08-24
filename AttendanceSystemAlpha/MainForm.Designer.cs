using System.Data;

namespace AttendanceSystemAlpha
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.pnHead = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainPageView = new Telerik.WinControls.UI.RadPageView();
            this.viewpageWelcome = new Telerik.WinControls.UI.RadPageViewPage();
            this.pboxWelcome = new System.Windows.Forms.PictureBox();
            this.viewpageLoadData = new Telerik.WinControls.UI.RadPageViewPage();
            this.pnLoad = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.tboxRepeatPasswd = new System.Windows.Forms.TextBox();
            this.lbOfflineStatus = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbTeacherName = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tboxLoadpasswd = new System.Windows.Forms.TextBox();
            this.lbLoadpasswd = new System.Windows.Forms.Label();
            this.rbtnFinish = new Telerik.WinControls.UI.RadButton();
            this.rbtnCancel = new Telerik.WinControls.UI.RadButton();
            this.clboxClassnames = new System.Windows.Forms.CheckedListBox();
            this.viewpageCall = new Telerik.WinControls.UI.RadPageViewPage();
            this.pnMaincall = new System.Windows.Forms.Panel();
            this.gboxMsg = new System.Windows.Forms.GroupBox();
            this.lbDKPercent = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.lbCdrs = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbSdrs = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbYdrs = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gboxStudentMsg = new System.Windows.Forms.GroupBox();
            this.lbDcsj = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbDczt = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbStudentXy = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbStudentClass = new System.Windows.Forms.Label();
            this.lbStudentName = new System.Windows.Forms.Label();
            this.lbStudentId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pboxPhoto = new System.Windows.Forms.PictureBox();
            this.gboxClassmsg = new System.Windows.Forms.GroupBox();
            this.GBoxChooseLesson = new System.Windows.Forms.Panel();
            this.axZKFPEngX1 = new AxZKFPEngXControl.AxZKFPEngX();
            this.cbboxCalltimes = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbboxCallWay = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tboxClassplace = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rbtnStartcall = new Telerik.WinControls.UI.RadButton();
            this.tboxTeachername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbboxJieCi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pboxPasswd = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxPasswd = new System.Windows.Forms.TextBox();
            this.cbboxClassname = new System.Windows.Forms.ComboBox();
            this.lbCname = new System.Windows.Forms.Label();
            this.viewpageDataManagement = new Telerik.WinControls.UI.RadPageViewPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.lbMngOfflineStatus = new System.Windows.Forms.Label();
            this.lbMngDkpercent = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lbMngsdrs = new System.Windows.Forms.Label();
            this.lbMngStudentTotal = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.mngGridView = new Telerik.WinControls.UI.RadGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PnMngChooseLesson = new System.Windows.Forms.Panel();
            this.cbboxMngCheckinMethod = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.rbtnMngShowInformation = new Telerik.WinControls.UI.RadButton();
            this.tbMngTeacherName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.cbboxMngJieCi = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbMngOfflinePasswd = new System.Windows.Forms.TextBox();
            this.cbboxMngClassName = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).BeginInit();
            this.mainPageView.SuspendLayout();
            this.viewpageWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxWelcome)).BeginInit();
            this.viewpageLoadData.SuspendLayout();
            this.pnLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnCancel)).BeginInit();
            this.viewpageCall.SuspendLayout();
            this.pnMaincall.SuspendLayout();
            this.gboxMsg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.gboxStudentMsg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPhoto)).BeginInit();
            this.gboxClassmsg.SuspendLayout();
            this.GBoxChooseLesson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axZKFPEngX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnStartcall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPasswd)).BeginInit();
            this.viewpageDataManagement.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mngGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mngGridView.MasterTemplate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.PnMngChooseLesson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnMngShowInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHead
            // 
            this.pnHead.BackColor = System.Drawing.Color.White;
            this.pnHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnHead.Controls.Add(this.pictureBox4);
            this.pnHead.Controls.Add(this.pictureBox3);
            this.pnHead.Controls.Add(this.pictureBox2);
            this.pnHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHead.Location = new System.Drawing.Point(0, 0);
            this.pnHead.Name = "pnHead";
            this.pnHead.Size = new System.Drawing.Size(999, 68);
            this.pnHead.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::AttendanceSystemAlpha.Properties.Resources.attendance_list_icon;
            this.pictureBox4.Location = new System.Drawing.Point(931, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 65);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::AttendanceSystemAlpha.Properties.Resources.title;
            this.pictureBox3.Location = new System.Drawing.Point(273, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(627, 68);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::AttendanceSystemAlpha.Properties.Resources.标志;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(233, 68);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mainPageView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 487);
            this.panel1.TabIndex = 1;
            // 
            // mainPageView
            // 
            this.mainPageView.Controls.Add(this.viewpageWelcome);
            this.mainPageView.Controls.Add(this.viewpageLoadData);
            this.mainPageView.Controls.Add(this.viewpageCall);
            this.mainPageView.Controls.Add(this.viewpageDataManagement);
            this.mainPageView.DefaultPage = this.viewpageWelcome;
            this.mainPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPageView.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainPageView.Location = new System.Drawing.Point(0, 0);
            this.mainPageView.Name = "mainPageView";
            this.mainPageView.SelectedPage = this.viewpageLoadData;
            this.mainPageView.Size = new System.Drawing.Size(999, 487);
            this.mainPageView.TabIndex = 0;
            this.mainPageView.ThemeName = "TelerikMetro";
            this.mainPageView.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage;
            this.mainPageView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPageView_MouseUp);
            // 
            // viewpageWelcome
            // 
            this.viewpageWelcome.Controls.Add(this.pboxWelcome);
            this.viewpageWelcome.ItemSize = new System.Drawing.SizeF(166F, 61F);
            this.viewpageWelcome.Location = new System.Drawing.Point(205, 4);
            this.viewpageWelcome.Name = "viewpageWelcome";
            this.viewpageWelcome.Size = new System.Drawing.Size(790, 479);
            this.viewpageWelcome.Text = "  首  页";
            // 
            // pboxWelcome
            // 
            this.pboxWelcome.BackgroundImage = global::AttendanceSystemAlpha.Properties.Resources.background;
            this.pboxWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxWelcome.Location = new System.Drawing.Point(0, 0);
            this.pboxWelcome.Name = "pboxWelcome";
            this.pboxWelcome.Size = new System.Drawing.Size(790, 479);
            this.pboxWelcome.TabIndex = 0;
            this.pboxWelcome.TabStop = false;
            // 
            // viewpageLoadData
            // 
            this.viewpageLoadData.Controls.Add(this.pnLoad);
            this.viewpageLoadData.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.viewpageLoadData.ItemSize = new System.Drawing.SizeF(166F, 61F);
            this.viewpageLoadData.Location = new System.Drawing.Point(205, 4);
            this.viewpageLoadData.Name = "viewpageLoadData";
            this.viewpageLoadData.Size = new System.Drawing.Size(790, 479);
            this.viewpageLoadData.Text = "数据离线";
            // 
            // pnLoad
            // 
            this.pnLoad.BackgroundImage = global::AttendanceSystemAlpha.Properties.Resources.offlineBackground;
            this.pnLoad.Controls.Add(this.label27);
            this.pnLoad.Controls.Add(this.tboxRepeatPasswd);
            this.pnLoad.Controls.Add(this.lbOfflineStatus);
            this.pnLoad.Controls.Add(this.label18);
            this.pnLoad.Controls.Add(this.lbTeacherName);
            this.pnLoad.Controls.Add(this.label17);
            this.pnLoad.Controls.Add(this.tboxLoadpasswd);
            this.pnLoad.Controls.Add(this.lbLoadpasswd);
            this.pnLoad.Controls.Add(this.rbtnFinish);
            this.pnLoad.Controls.Add(this.rbtnCancel);
            this.pnLoad.Controls.Add(this.clboxClassnames);
            this.pnLoad.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLoad.Location = new System.Drawing.Point(0, 0);
            this.pnLoad.Name = "pnLoad";
            this.pnLoad.Size = new System.Drawing.Size(794, 479);
            this.pnLoad.TabIndex = 0;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(372, 282);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(92, 27);
            this.label27.TabIndex = 11;
            this.label27.Text = "确认密码";
            // 
            // tboxRepeatPasswd
            // 
            this.tboxRepeatPasswd.Location = new System.Drawing.Point(470, 279);
            this.tboxRepeatPasswd.Name = "tboxRepeatPasswd";
            this.tboxRepeatPasswd.PasswordChar = '*';
            this.tboxRepeatPasswd.Size = new System.Drawing.Size(300, 34);
            this.tboxRepeatPasswd.TabIndex = 10;
            this.tboxRepeatPasswd.TextChanged += new System.EventHandler(this.tboxRepeatPasswd_TextChanged);
            // 
            // lbOfflineStatus
            // 
            this.lbOfflineStatus.AutoSize = true;
            this.lbOfflineStatus.Location = new System.Drawing.Point(457, 362);
            this.lbOfflineStatus.Name = "lbOfflineStatus";
            this.lbOfflineStatus.Size = new System.Drawing.Size(290, 27);
            this.lbOfflineStatus.TabIndex = 9;
            this.lbOfflineStatus.Text = "输入课程密码并点击\"开始下载\"";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 91);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(232, 27);
            this.label18.TabIndex = 8;
            this.label18.Text = "请勾选需要离线的课程：";
            // 
            // lbTeacherName
            // 
            this.lbTeacherName.AutoSize = true;
            this.lbTeacherName.Location = new System.Drawing.Point(125, 42);
            this.lbTeacherName.Name = "lbTeacherName";
            this.lbTeacherName.Size = new System.Drawing.Size(0, 27);
            this.lbTeacherName.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 42);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 27);
            this.label17.TabIndex = 6;
            this.label17.Text = "教师姓名：";
            // 
            // tboxLoadpasswd
            // 
            this.tboxLoadpasswd.Location = new System.Drawing.Point(470, 239);
            this.tboxLoadpasswd.Name = "tboxLoadpasswd";
            this.tboxLoadpasswd.PasswordChar = '*';
            this.tboxLoadpasswd.Size = new System.Drawing.Size(300, 34);
            this.tboxLoadpasswd.TabIndex = 5;
            this.tboxLoadpasswd.TextChanged += new System.EventHandler(this.tboxLoadpasswd_TextChanged);
            // 
            // lbLoadpasswd
            // 
            this.lbLoadpasswd.AutoSize = true;
            this.lbLoadpasswd.Location = new System.Drawing.Point(372, 239);
            this.lbLoadpasswd.Name = "lbLoadpasswd";
            this.lbLoadpasswd.Size = new System.Drawing.Size(92, 27);
            this.lbLoadpasswd.TabIndex = 4;
            this.lbLoadpasswd.Text = "课程密码";
            // 
            // rbtnFinish
            // 
            this.rbtnFinish.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFinish.Location = new System.Drawing.Point(640, 319);
            this.rbtnFinish.Name = "rbtnFinish";
            this.rbtnFinish.Size = new System.Drawing.Size(107, 40);
            this.rbtnFinish.TabIndex = 3;
            this.rbtnFinish.Text = "开始下载";
            this.rbtnFinish.ThemeName = "TelerikMetro";
            this.rbtnFinish.Click += new System.EventHandler(this.rbtnFinish_Click);
            // 
            // rbtnCancel
            // 
            this.rbtnCancel.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCancel.Location = new System.Drawing.Point(453, 319);
            this.rbtnCancel.Name = "rbtnCancel";
            this.rbtnCancel.Size = new System.Drawing.Size(107, 40);
            this.rbtnCancel.TabIndex = 2;
            this.rbtnCancel.Text = "取 消";
            this.rbtnCancel.ThemeName = "TelerikMetro";
            this.rbtnCancel.Click += new System.EventHandler(this.rbtnCancel_Click);
            // 
            // clboxClassnames
            // 
            this.clboxClassnames.FormattingEnabled = true;
            this.clboxClassnames.Location = new System.Drawing.Point(12, 121);
            this.clboxClassnames.Name = "clboxClassnames";
            this.clboxClassnames.Size = new System.Drawing.Size(331, 294);
            this.clboxClassnames.TabIndex = 1;
            // 
            // viewpageCall
            // 
            this.viewpageCall.Controls.Add(this.pnMaincall);
            this.viewpageCall.ItemSize = new System.Drawing.SizeF(166F, 61F);
            this.viewpageCall.Location = new System.Drawing.Point(205, 4);
            this.viewpageCall.Name = "viewpageCall";
            this.viewpageCall.Size = new System.Drawing.Size(790, 479);
            this.viewpageCall.Text = "课堂点名";
            // 
            // pnMaincall
            // 
            this.pnMaincall.Controls.Add(this.gboxMsg);
            this.pnMaincall.Controls.Add(this.gboxStudentMsg);
            this.pnMaincall.Controls.Add(this.gboxClassmsg);
            this.pnMaincall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMaincall.Location = new System.Drawing.Point(0, 0);
            this.pnMaincall.Name = "pnMaincall";
            this.pnMaincall.Size = new System.Drawing.Size(790, 479);
            this.pnMaincall.TabIndex = 0;
            // 
            // gboxMsg
            // 
            this.gboxMsg.Controls.Add(this.lbDKPercent);
            this.gboxMsg.Controls.Add(this.label31);
            this.gboxMsg.Controls.Add(this.radButton1);
            this.gboxMsg.Controls.Add(this.lbCdrs);
            this.gboxMsg.Controls.Add(this.label14);
            this.gboxMsg.Controls.Add(this.lbSdrs);
            this.gboxMsg.Controls.Add(this.label13);
            this.gboxMsg.Controls.Add(this.lbYdrs);
            this.gboxMsg.Controls.Add(this.label8);
            this.gboxMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxMsg.Enabled = false;
            this.gboxMsg.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gboxMsg.Location = new System.Drawing.Point(529, 251);
            this.gboxMsg.Name = "gboxMsg";
            this.gboxMsg.Size = new System.Drawing.Size(261, 228);
            this.gboxMsg.TabIndex = 2;
            this.gboxMsg.TabStop = false;
            this.gboxMsg.Text = "到课信息";
            // 
            // lbDKPercent
            // 
            this.lbDKPercent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDKPercent.AutoSize = true;
            this.lbDKPercent.Location = new System.Drawing.Point(123, 151);
            this.lbDKPercent.Name = "lbDKPercent";
            this.lbDKPercent.Size = new System.Drawing.Size(0, 27);
            this.lbDKPercent.TabIndex = 8;
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 151);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 27);
            this.label31.TabIndex = 7;
            this.label31.Text = "到课率";
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Location = new System.Drawing.Point(64, 182);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(158, 35);
            this.radButton1.TabIndex = 6;
            this.radButton1.Text = "结束点名";
            this.radButton1.ThemeName = "TelerikMetro";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // lbCdrs
            // 
            this.lbCdrs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbCdrs.AutoSize = true;
            this.lbCdrs.Location = new System.Drawing.Point(123, 111);
            this.lbCdrs.Name = "lbCdrs";
            this.lbCdrs.Size = new System.Drawing.Size(0, 27);
            this.lbCdrs.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 27);
            this.label14.TabIndex = 4;
            this.label14.Text = "迟到：";
            // 
            // lbSdrs
            // 
            this.lbSdrs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSdrs.AutoSize = true;
            this.lbSdrs.Location = new System.Drawing.Point(123, 71);
            this.lbSdrs.Name = "lbSdrs";
            this.lbSdrs.Size = new System.Drawing.Size(0, 27);
            this.lbSdrs.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 27);
            this.label13.TabIndex = 2;
            this.label13.Text = "实到：";
            // 
            // lbYdrs
            // 
            this.lbYdrs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbYdrs.AutoSize = true;
            this.lbYdrs.Location = new System.Drawing.Point(123, 31);
            this.lbYdrs.Name = "lbYdrs";
            this.lbYdrs.Size = new System.Drawing.Size(0, 27);
            this.lbYdrs.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 27);
            this.label8.TabIndex = 0;
            this.label8.Text = "应到：";
            // 
            // gboxStudentMsg
            // 
            this.gboxStudentMsg.Controls.Add(this.lbDcsj);
            this.gboxStudentMsg.Controls.Add(this.label12);
            this.gboxStudentMsg.Controls.Add(this.lbDczt);
            this.gboxStudentMsg.Controls.Add(this.label10);
            this.gboxStudentMsg.Controls.Add(this.lbStudentXy);
            this.gboxStudentMsg.Controls.Add(this.label9);
            this.gboxStudentMsg.Controls.Add(this.lbStudentClass);
            this.gboxStudentMsg.Controls.Add(this.lbStudentName);
            this.gboxStudentMsg.Controls.Add(this.lbStudentId);
            this.gboxStudentMsg.Controls.Add(this.label7);
            this.gboxStudentMsg.Controls.Add(this.label6);
            this.gboxStudentMsg.Controls.Add(this.label5);
            this.gboxStudentMsg.Controls.Add(this.pboxPhoto);
            this.gboxStudentMsg.Dock = System.Windows.Forms.DockStyle.Left;
            this.gboxStudentMsg.Enabled = false;
            this.gboxStudentMsg.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gboxStudentMsg.Location = new System.Drawing.Point(0, 251);
            this.gboxStudentMsg.Name = "gboxStudentMsg";
            this.gboxStudentMsg.Size = new System.Drawing.Size(529, 228);
            this.gboxStudentMsg.TabIndex = 1;
            this.gboxStudentMsg.TabStop = false;
            this.gboxStudentMsg.Text = "学生信息";
            // 
            // lbDcsj
            // 
            this.lbDcsj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDcsj.AutoSize = true;
            this.lbDcsj.Location = new System.Drawing.Point(384, 188);
            this.lbDcsj.Name = "lbDcsj";
            this.lbDcsj.Size = new System.Drawing.Size(0, 27);
            this.lbDcsj.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(384, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 27);
            this.label12.TabIndex = 11;
            this.label12.Text = "到课时间：";
            // 
            // lbDczt
            // 
            this.lbDczt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDczt.AutoSize = true;
            this.lbDczt.Location = new System.Drawing.Point(384, 86);
            this.lbDczt.Name = "lbDczt";
            this.lbDczt.Size = new System.Drawing.Size(0, 27);
            this.lbDczt.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(384, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 27);
            this.label10.TabIndex = 9;
            this.label10.Text = "到课状态：";
            // 
            // lbStudentXy
            // 
            this.lbStudentXy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStudentXy.AutoSize = true;
            this.lbStudentXy.Location = new System.Drawing.Point(253, 187);
            this.lbStudentXy.Name = "lbStudentXy";
            this.lbStudentXy.Size = new System.Drawing.Size(0, 27);
            this.lbStudentXy.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(156, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 27);
            this.label9.TabIndex = 7;
            this.label9.Text = "学院：";
            // 
            // lbStudentClass
            // 
            this.lbStudentClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStudentClass.AutoSize = true;
            this.lbStudentClass.Location = new System.Drawing.Point(253, 138);
            this.lbStudentClass.Name = "lbStudentClass";
            this.lbStudentClass.Size = new System.Drawing.Size(0, 27);
            this.lbStudentClass.TabIndex = 6;
            // 
            // lbStudentName
            // 
            this.lbStudentName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStudentName.AutoSize = true;
            this.lbStudentName.Location = new System.Drawing.Point(253, 86);
            this.lbStudentName.Name = "lbStudentName";
            this.lbStudentName.Size = new System.Drawing.Size(0, 27);
            this.lbStudentName.TabIndex = 5;
            // 
            // lbStudentId
            // 
            this.lbStudentId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStudentId.AutoSize = true;
            this.lbStudentId.Location = new System.Drawing.Point(253, 33);
            this.lbStudentId.Name = "lbStudentId";
            this.lbStudentId.Size = new System.Drawing.Size(0, 27);
            this.lbStudentId.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(156, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 27);
            this.label7.TabIndex = 3;
            this.label7.Text = "学号：";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 27);
            this.label6.TabIndex = 2;
            this.label6.Text = "班级：";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 27);
            this.label5.TabIndex = 1;
            this.label5.Text = "姓名：";
            // 
            // pboxPhoto
            // 
            this.pboxPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pboxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxPhoto.Location = new System.Drawing.Point(14, 36);
            this.pboxPhoto.Name = "pboxPhoto";
            this.pboxPhoto.Size = new System.Drawing.Size(136, 178);
            this.pboxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxPhoto.TabIndex = 0;
            this.pboxPhoto.TabStop = false;
            // 
            // gboxClassmsg
            // 
            this.gboxClassmsg.Controls.Add(this.GBoxChooseLesson);
            this.gboxClassmsg.Controls.Add(this.pboxPasswd);
            this.gboxClassmsg.Controls.Add(this.label4);
            this.gboxClassmsg.Controls.Add(this.tboxPasswd);
            this.gboxClassmsg.Controls.Add(this.cbboxClassname);
            this.gboxClassmsg.Controls.Add(this.lbCname);
            this.gboxClassmsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxClassmsg.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gboxClassmsg.Location = new System.Drawing.Point(0, 0);
            this.gboxClassmsg.Name = "gboxClassmsg";
            this.gboxClassmsg.Size = new System.Drawing.Size(790, 251);
            this.gboxClassmsg.TabIndex = 0;
            this.gboxClassmsg.TabStop = false;
            this.gboxClassmsg.Text = "课程信息";
            // 
            // GBoxChooseLesson
            // 
            this.GBoxChooseLesson.Controls.Add(this.axZKFPEngX1);
            this.GBoxChooseLesson.Controls.Add(this.cbboxCalltimes);
            this.GBoxChooseLesson.Controls.Add(this.label16);
            this.GBoxChooseLesson.Controls.Add(this.cbboxCallWay);
            this.GBoxChooseLesson.Controls.Add(this.label15);
            this.GBoxChooseLesson.Controls.Add(this.tboxClassplace);
            this.GBoxChooseLesson.Controls.Add(this.label11);
            this.GBoxChooseLesson.Controls.Add(this.rbtnStartcall);
            this.GBoxChooseLesson.Controls.Add(this.tboxTeachername);
            this.GBoxChooseLesson.Controls.Add(this.label3);
            this.GBoxChooseLesson.Controls.Add(this.DateTimePicker1);
            this.GBoxChooseLesson.Controls.Add(this.label2);
            this.GBoxChooseLesson.Controls.Add(this.cbboxJieCi);
            this.GBoxChooseLesson.Controls.Add(this.label1);
            this.GBoxChooseLesson.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GBoxChooseLesson.Enabled = false;
            this.GBoxChooseLesson.Location = new System.Drawing.Point(3, 77);
            this.GBoxChooseLesson.Name = "GBoxChooseLesson";
            this.GBoxChooseLesson.Size = new System.Drawing.Size(784, 171);
            this.GBoxChooseLesson.TabIndex = 13;
            this.GBoxChooseLesson.EnabledChanged += new System.EventHandler(this.pnClassmsg_EnabledChanged);
            // 
            // axZKFPEngX1
            // 
            this.axZKFPEngX1.Enabled = true;
            this.axZKFPEngX1.Location = new System.Drawing.Point(646, 117);
            this.axZKFPEngX1.Name = "axZKFPEngX1";
            this.axZKFPEngX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axZKFPEngX1.OcxState")));
            this.axZKFPEngX1.Size = new System.Drawing.Size(24, 24);
            this.axZKFPEngX1.TabIndex = 27;
            this.axZKFPEngX1.OnCapture += new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(this.axZKFPEngX1_OnCapture);
            // 
            // cbboxCalltimes
            // 
            this.cbboxCalltimes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbboxCalltimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxCalltimes.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbboxCalltimes.FormattingEnabled = true;
            this.cbboxCalltimes.Items.AddRange(new object[] {
            "1"});
            this.cbboxCalltimes.Location = new System.Drawing.Point(465, 105);
            this.cbboxCalltimes.Name = "cbboxCalltimes";
            this.cbboxCalltimes.Size = new System.Drawing.Size(131, 35);
            this.cbboxCalltimes.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(347, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 27);
            this.label16.TabIndex = 25;
            this.label16.Text = "点名次数：";
            // 
            // cbboxCallWay
            // 
            this.cbboxCallWay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbboxCallWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxCallWay.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbboxCallWay.FormattingEnabled = true;
            this.cbboxCallWay.Items.AddRange(new object[] {
            "指纹点名"});
            this.cbboxCallWay.Location = new System.Drawing.Point(465, 51);
            this.cbboxCallWay.Name = "cbboxCallWay";
            this.cbboxCallWay.Size = new System.Drawing.Size(205, 35);
            this.cbboxCallWay.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(347, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 27);
            this.label15.TabIndex = 23;
            this.label15.Text = "点名方式：";
            // 
            // tboxClassplace
            // 
            this.tboxClassplace.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tboxClassplace.Location = new System.Drawing.Point(129, 105);
            this.tboxClassplace.Name = "tboxClassplace";
            this.tboxClassplace.ReadOnly = true;
            this.tboxClassplace.Size = new System.Drawing.Size(131, 34);
            this.tboxClassplace.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(11, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 27);
            this.label11.TabIndex = 21;
            this.label11.Text = "授课地点：";
            // 
            // rbtnStartcall
            // 
            this.rbtnStartcall.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbtnStartcall.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnStartcall.Location = new System.Drawing.Point(685, 117);
            this.rbtnStartcall.Name = "rbtnStartcall";
            this.rbtnStartcall.Size = new System.Drawing.Size(89, 44);
            this.rbtnStartcall.TabIndex = 20;
            this.rbtnStartcall.Text = "开始点名";
            this.rbtnStartcall.ThemeName = "TelerikMetro";
            this.rbtnStartcall.Click += new System.EventHandler(this.rbtnStartcall_Click);
            // 
            // tboxTeachername
            // 
            this.tboxTeachername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tboxTeachername.Location = new System.Drawing.Point(129, 63);
            this.tboxTeachername.Name = "tboxTeachername";
            this.tboxTeachername.ReadOnly = true;
            this.tboxTeachername.Size = new System.Drawing.Size(131, 34);
            this.tboxTeachername.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(11, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 27);
            this.label3.TabIndex = 18;
            this.label3.Text = "授课教师：";
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DateTimePicker1.CalendarFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker1.Location = new System.Drawing.Point(465, 11);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.ShowUpDown = true;
            this.DateTimePicker1.Size = new System.Drawing.Size(225, 34);
            this.DateTimePicker1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(347, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 16;
            this.label2.Text = "授课时间：";
            // 
            // cbboxJieCi
            // 
            this.cbboxJieCi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbboxJieCi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxJieCi.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbboxJieCi.FormattingEnabled = true;
            this.cbboxJieCi.Location = new System.Drawing.Point(129, 10);
            this.cbboxJieCi.Name = "cbboxJieCi";
            this.cbboxJieCi.Size = new System.Drawing.Size(212, 35);
            this.cbboxJieCi.TabIndex = 15;
            this.cbboxJieCi.SelectedIndexChanged += new System.EventHandler(this.cbboxJieCi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 14;
            this.label1.Text = "节次：";
            // 
            // pboxPasswd
            // 
            this.pboxPasswd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pboxPasswd.Location = new System.Drawing.Point(739, 34);
            this.pboxPasswd.Name = "pboxPasswd";
            this.pboxPasswd.Size = new System.Drawing.Size(38, 34);
            this.pboxPasswd.TabIndex = 12;
            this.pboxPasswd.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(422, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 27);
            this.label4.TabIndex = 11;
            this.label4.Text = "离线密码：";
            // 
            // tboxPasswd
            // 
            this.tboxPasswd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tboxPasswd.Location = new System.Drawing.Point(540, 34);
            this.tboxPasswd.Name = "tboxPasswd";
            this.tboxPasswd.Size = new System.Drawing.Size(193, 34);
            this.tboxPasswd.TabIndex = 10;
            this.tboxPasswd.TextChanged += new System.EventHandler(this.tboxPasswd_TextChanged);
            // 
            // cbboxClassname
            // 
            this.cbboxClassname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbboxClassname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxClassname.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbboxClassname.FormattingEnabled = true;
            this.cbboxClassname.Location = new System.Drawing.Point(132, 33);
            this.cbboxClassname.Name = "cbboxClassname";
            this.cbboxClassname.Size = new System.Drawing.Size(270, 35);
            this.cbboxClassname.TabIndex = 4;
            this.cbboxClassname.SelectedIndexChanged += new System.EventHandler(this.cbboxClassname_SelectedIndexChanged);
            // 
            // lbCname
            // 
            this.lbCname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbCname.AutoSize = true;
            this.lbCname.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCname.Location = new System.Drawing.Point(14, 41);
            this.lbCname.Name = "lbCname";
            this.lbCname.Size = new System.Drawing.Size(112, 27);
            this.lbCname.TabIndex = 1;
            this.lbCname.Text = "开课名称：";
            // 
            // viewpageDataManagement
            // 
            this.viewpageDataManagement.Controls.Add(this.groupBox2);
            this.viewpageDataManagement.Controls.Add(this.groupBox1);
            this.viewpageDataManagement.ItemSize = new System.Drawing.SizeF(166F, 61F);
            this.viewpageDataManagement.Location = new System.Drawing.Point(205, 4);
            this.viewpageDataManagement.Name = "viewpageDataManagement";
            this.viewpageDataManagement.Size = new System.Drawing.Size(790, 479);
            this.viewpageDataManagement.Text = "数据管理";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radButton4);
            this.groupBox2.Controls.Add(this.radButton3);
            this.groupBox2.Controls.Add(this.radButton2);
            this.groupBox2.Controls.Add(this.lbMngOfflineStatus);
            this.groupBox2.Controls.Add(this.lbMngDkpercent);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.lbMngsdrs);
            this.groupBox2.Controls.Add(this.lbMngStudentTotal);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.mngGridView);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.groupBox2.Location = new System.Drawing.Point(4, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 246);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "到课情况浏览";
            // 
            // radButton4
            // 
            this.radButton4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.radButton4.Enabled = false;
            this.radButton4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton4.Location = new System.Drawing.Point(688, 193);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(89, 44);
            this.radButton4.TabIndex = 23;
            this.radButton4.Text = "<html><p>更改课程</p><p>/节次</p></html>";
            this.radButton4.ThemeName = "TelerikMetro";
            this.radButton4.Click += new System.EventHandler(this.radButton4_Click);
            // 
            // radButton3
            // 
            this.radButton3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.radButton3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton3.Location = new System.Drawing.Point(499, 193);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(89, 44);
            this.radButton3.TabIndex = 22;
            this.radButton3.Text = "刷新数据";
            this.radButton3.ThemeName = "TelerikMetro";
            this.radButton3.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // radButton2
            // 
            this.radButton2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.radButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton2.Location = new System.Drawing.Point(594, 193);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(89, 44);
            this.radButton2.TabIndex = 21;
            this.radButton2.Text = "提交数据";
            this.radButton2.ThemeName = "TelerikMetro";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // lbMngOfflineStatus
            // 
            this.lbMngOfflineStatus.AutoSize = true;
            this.lbMngOfflineStatus.Enabled = false;
            this.lbMngOfflineStatus.Location = new System.Drawing.Point(635, 141);
            this.lbMngOfflineStatus.Name = "lbMngOfflineStatus";
            this.lbMngOfflineStatus.Size = new System.Drawing.Size(81, 27);
            this.lbMngOfflineStatus.TabIndex = 11;
            this.lbMngOfflineStatus.Text = "label35";
            // 
            // lbMngDkpercent
            // 
            this.lbMngDkpercent.AutoSize = true;
            this.lbMngDkpercent.Enabled = false;
            this.lbMngDkpercent.Location = new System.Drawing.Point(635, 114);
            this.lbMngDkpercent.Name = "lbMngDkpercent";
            this.lbMngDkpercent.Size = new System.Drawing.Size(81, 27);
            this.lbMngDkpercent.TabIndex = 10;
            this.lbMngDkpercent.Text = "label36";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(497, 141);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(132, 27);
            this.label34.TabIndex = 9;
            this.label34.Text = "数据提交状态";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(537, 114);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(92, 27);
            this.label33.TabIndex = 8;
            this.label33.Text = "到课比率";
            // 
            // lbMngsdrs
            // 
            this.lbMngsdrs.AutoSize = true;
            this.lbMngsdrs.Enabled = false;
            this.lbMngsdrs.Location = new System.Drawing.Point(635, 87);
            this.lbMngsdrs.Name = "lbMngsdrs";
            this.lbMngsdrs.Size = new System.Drawing.Size(81, 27);
            this.lbMngsdrs.TabIndex = 5;
            this.lbMngsdrs.Text = "label29";
            // 
            // lbMngStudentTotal
            // 
            this.lbMngStudentTotal.AutoSize = true;
            this.lbMngStudentTotal.Enabled = false;
            this.lbMngStudentTotal.Location = new System.Drawing.Point(635, 60);
            this.lbMngStudentTotal.Name = "lbMngStudentTotal";
            this.lbMngStudentTotal.Size = new System.Drawing.Size(81, 27);
            this.lbMngStudentTotal.TabIndex = 4;
            this.lbMngStudentTotal.Text = "label28";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(577, 87);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 27);
            this.label21.TabIndex = 2;
            this.label21.Text = "实到";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(577, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 27);
            this.label19.TabIndex = 1;
            this.label19.Text = "应到";
            // 
            // mngGridView
            // 
            this.mngGridView.Location = new System.Drawing.Point(6, 33);
            // 
            // mngGridView
            // 
            this.mngGridView.MasterTemplate.AllowAddNewRow = false;
            this.mngGridView.MasterTemplate.AllowCellContextMenu = false;
            this.mngGridView.MasterTemplate.AllowColumnChooser = false;
            this.mngGridView.MasterTemplate.AllowDeleteRow = false;
            this.mngGridView.MasterTemplate.AllowEditRow = false;
            this.mngGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.mngGridView.Name = "mngGridView";
            this.mngGridView.Size = new System.Drawing.Size(467, 201);
            this.mngGridView.TabIndex = 0;
            this.mngGridView.Text = "radGridView1";
            this.mngGridView.ThemeName = "TelerikMetro";
            this.mngGridView.CreateRow += new Telerik.WinControls.UI.GridViewCreateRowEventHandler(this.mngGridView_CreateRow);
            this.mngGridView.DataBindingComplete += new Telerik.WinControls.UI.GridViewBindingCompleteEventHandler(this.mngGridView_DataBindingComplete);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PnMngChooseLesson);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.tbMngOfflinePasswd);
            this.groupBox1.Controls.Add(this.cbboxMngClassName);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 210);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "课程信息";
            // 
            // PnMngChooseLesson
            // 
            this.PnMngChooseLesson.Controls.Add(this.cbboxMngCheckinMethod);
            this.PnMngChooseLesson.Controls.Add(this.label20);
            this.PnMngChooseLesson.Controls.Add(this.rbtnMngShowInformation);
            this.PnMngChooseLesson.Controls.Add(this.tbMngTeacherName);
            this.PnMngChooseLesson.Controls.Add(this.label22);
            this.PnMngChooseLesson.Controls.Add(this.dateTimePicker2);
            this.PnMngChooseLesson.Controls.Add(this.label23);
            this.PnMngChooseLesson.Controls.Add(this.cbboxMngJieCi);
            this.PnMngChooseLesson.Controls.Add(this.label24);
            this.PnMngChooseLesson.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnMngChooseLesson.Enabled = false;
            this.PnMngChooseLesson.Location = new System.Drawing.Point(3, 90);
            this.PnMngChooseLesson.Name = "PnMngChooseLesson";
            this.PnMngChooseLesson.Size = new System.Drawing.Size(784, 117);
            this.PnMngChooseLesson.TabIndex = 13;
            this.PnMngChooseLesson.EnabledChanged += new System.EventHandler(this.PnMngChooseLesson_EnabledChanged);
            // 
            // cbboxMngCheckinMethod
            // 
            this.cbboxMngCheckinMethod.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbboxMngCheckinMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxMngCheckinMethod.Enabled = false;
            this.cbboxMngCheckinMethod.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbboxMngCheckinMethod.FormattingEnabled = true;
            this.cbboxMngCheckinMethod.Items.AddRange(new object[] {
            "指纹点名"});
            this.cbboxMngCheckinMethod.Location = new System.Drawing.Point(424, 60);
            this.cbboxMngCheckinMethod.Name = "cbboxMngCheckinMethod";
            this.cbboxMngCheckinMethod.Size = new System.Drawing.Size(205, 35);
            this.cbboxMngCheckinMethod.TabIndex = 24;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(306, 68);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 27);
            this.label20.TabIndex = 23;
            this.label20.Text = "点名方式：";
            // 
            // rbtnMngShowInformation
            // 
            this.rbtnMngShowInformation.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbtnMngShowInformation.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMngShowInformation.Location = new System.Drawing.Point(641, 58);
            this.rbtnMngShowInformation.Name = "rbtnMngShowInformation";
            this.rbtnMngShowInformation.Size = new System.Drawing.Size(89, 44);
            this.rbtnMngShowInformation.TabIndex = 20;
            this.rbtnMngShowInformation.Text = "查看信息";
            this.rbtnMngShowInformation.ThemeName = "TelerikMetro";
            this.rbtnMngShowInformation.Click += new System.EventHandler(this.rbtnMngShowInformation_Click);
            // 
            // tbMngTeacherName
            // 
            this.tbMngTeacherName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMngTeacherName.Location = new System.Drawing.Point(129, 61);
            this.tbMngTeacherName.Name = "tbMngTeacherName";
            this.tbMngTeacherName.ReadOnly = true;
            this.tbMngTeacherName.Size = new System.Drawing.Size(131, 34);
            this.tbMngTeacherName.TabIndex = 19;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(11, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(112, 27);
            this.label22.TabIndex = 18;
            this.label22.Text = "授课教师：";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(424, 8);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(270, 34);
            this.dateTimePicker2.TabIndex = 17;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(306, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(112, 27);
            this.label23.TabIndex = 16;
            this.label23.Text = "授课时间：";
            // 
            // cbboxMngJieCi
            // 
            this.cbboxMngJieCi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbboxMngJieCi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxMngJieCi.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbboxMngJieCi.FormattingEnabled = true;
            this.cbboxMngJieCi.Location = new System.Drawing.Point(129, 8);
            this.cbboxMngJieCi.Name = "cbboxMngJieCi";
            this.cbboxMngJieCi.Size = new System.Drawing.Size(171, 35);
            this.cbboxMngJieCi.TabIndex = 15;
            this.cbboxMngJieCi.SelectedIndexChanged += new System.EventHandler(this.cbboxMngJieCi_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(11, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 27);
            this.label24.TabIndex = 14;
            this.label24.Text = "节次：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Location = new System.Drawing.Point(739, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 34);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(422, 41);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(112, 27);
            this.label25.TabIndex = 11;
            this.label25.Text = "离线密码：";
            // 
            // tbMngOfflinePasswd
            // 
            this.tbMngOfflinePasswd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMngOfflinePasswd.Location = new System.Drawing.Point(540, 34);
            this.tbMngOfflinePasswd.Name = "tbMngOfflinePasswd";
            this.tbMngOfflinePasswd.Size = new System.Drawing.Size(193, 34);
            this.tbMngOfflinePasswd.TabIndex = 10;
            this.tbMngOfflinePasswd.TextChanged += new System.EventHandler(this.tbMngOfflinePasswd_TextChanged);
            // 
            // cbboxMngClassName
            // 
            this.cbboxMngClassName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbboxMngClassName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxMngClassName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbboxMngClassName.FormattingEnabled = true;
            this.cbboxMngClassName.Location = new System.Drawing.Point(132, 33);
            this.cbboxMngClassName.Name = "cbboxMngClassName";
            this.cbboxMngClassName.Size = new System.Drawing.Size(270, 35);
            this.cbboxMngClassName.TabIndex = 4;
            this.cbboxMngClassName.SelectedIndexChanged += new System.EventHandler(this.cbboxMngClassName_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(14, 41);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(112, 27);
            this.label26.TabIndex = 1;
            this.label26.Text = "开课名称：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnHead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPageView)).EndInit();
            this.mainPageView.ResumeLayout(false);
            this.viewpageWelcome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxWelcome)).EndInit();
            this.viewpageLoadData.ResumeLayout(false);
            this.pnLoad.ResumeLayout(false);
            this.pnLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnCancel)).EndInit();
            this.viewpageCall.ResumeLayout(false);
            this.pnMaincall.ResumeLayout(false);
            this.gboxMsg.ResumeLayout(false);
            this.gboxMsg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.gboxStudentMsg.ResumeLayout(false);
            this.gboxStudentMsg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPhoto)).EndInit();
            this.gboxClassmsg.ResumeLayout(false);
            this.gboxClassmsg.PerformLayout();
            this.GBoxChooseLesson.ResumeLayout(false);
            this.GBoxChooseLesson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axZKFPEngX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnStartcall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPasswd)).EndInit();
            this.viewpageDataManagement.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mngGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mngGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PnMngChooseLesson.ResumeLayout(false);
            this.PnMngChooseLesson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnMngShowInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private System.Windows.Forms.Panel pnHead;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadPageView mainPageView;
        private Telerik.WinControls.UI.RadPageViewPage viewpageLoadData;
        private Telerik.WinControls.UI.RadPageViewPage viewpageCall;
        private Telerik.WinControls.UI.RadPageViewPage viewpageDataManagement;
        private Telerik.WinControls.UI.RadPageViewPage viewpageWelcome;
        private System.Windows.Forms.PictureBox pboxWelcome;
        private System.Windows.Forms.Panel pnLoad;
        private System.Windows.Forms.CheckedListBox clboxClassnames;
        private Telerik.WinControls.UI.RadButton rbtnFinish;
        private Telerik.WinControls.UI.RadButton rbtnCancel;
        private System.Windows.Forms.TextBox tboxLoadpasswd;
        private System.Windows.Forms.Label lbLoadpasswd;
        private System.Windows.Forms.Panel pnMaincall;
        private System.Windows.Forms.GroupBox gboxClassmsg;
        private System.Windows.Forms.ComboBox cbboxClassname;
        private System.Windows.Forms.Label lbCname;
        private System.Windows.Forms.PictureBox pboxPasswd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxPasswd;
        private System.Windows.Forms.GroupBox gboxStudentMsg;
        private System.Windows.Forms.Label lbDcsj;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbDczt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbStudentXy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbStudentClass;
        private System.Windows.Forms.Label lbStudentName;
        private System.Windows.Forms.Label lbStudentId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pboxPhoto;
        private System.Windows.Forms.GroupBox gboxMsg;
        private System.Windows.Forms.Label lbCdrs;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbSdrs;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbYdrs;
        private System.Windows.Forms.Label label8;
        private Telerik.WinControls.UI.RadButton radButton1;
        private System.Windows.Forms.Panel GBoxChooseLesson;
        private System.Windows.Forms.ComboBox cbboxCalltimes;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbboxCallWay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tboxClassplace;
        private System.Windows.Forms.Label label11;
        private Telerik.WinControls.UI.RadButton rbtnStartcall;
        private System.Windows.Forms.TextBox tboxTeachername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbboxJieCi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbOfflineStatus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbTeacherName;
        private System.Windows.Forms.Label label17;
        private AxZKFPEngXControl.AxZKFPEngX axZKFPEngX1;
        private Telerik.WinControls.UI.RadGridView mngGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel PnMngChooseLesson;
        private System.Windows.Forms.ComboBox cbboxMngCheckinMethod;
        private System.Windows.Forms.Label label20;
        private Telerik.WinControls.UI.RadButton rbtnMngShowInformation;
        private System.Windows.Forms.TextBox tbMngTeacherName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbboxMngJieCi;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tbMngOfflinePasswd;
        private System.Windows.Forms.ComboBox cbboxMngClassName;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbMngsdrs;
        private System.Windows.Forms.Label lbMngStudentTotal;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbDKPercent;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lbMngOfflineStatus;
        private System.Windows.Forms.Label lbMngDkpercent;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadButton radButton4;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tboxRepeatPasswd;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

