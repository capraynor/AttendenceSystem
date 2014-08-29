using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RemObjects.DataAbstract;
using Telerik.WinControls;

namespace AttendanceSystemAlpha
{
    public partial class RadfrmChooseClasses : Telerik.WinControls.UI.RadForm
    {
        public DataTable _propertiesTable;
        private string currentPasswd = "           55555555555            ";
        public Briefcase propertieBriefcase = null;
        public Briefcase _chooseClassBriefcase = null;
        public long ClassNumber = 0;
        public string ClassName = "";
        public long Jieci = 0;
        public DateTime ClassDate = new DateTime();
        public string TeacherName = "";
        public DataTable DmTable = null;
        public RadfrmChooseClasses()
        {
            
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (currentPasswd != textBox1.Text)
            {
                pictureBox1.BackColor = Color.OrangeRed;
                cbboxJieCi.Enabled = false;

            }
            else
            {
                pictureBox1.BackColor = Color.LawnGreen;
                cbboxJieCi.Enabled = true;
            }
        }

        private void RadfrmChooseClasses_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.pictureBox1.BackColor = Color.White;

            propertieBriefcase = new FileBriefcase(Properties.Settings.Default.PropertiesBriefcaseFolder, true);
            _propertiesTable = propertieBriefcase.FindTable("PropertiesTable");
            comboBox1.DataSource = _propertiesTable;
            comboBox1.DisplayMember = "开课名称";
            comboBox1.ValueMember = "开课编号";
            this.Height = 328;
            this.Width = 719;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_propertiesTable.Select("开课编号 like '" + comboBox1.SelectedValue + "'").Length == 0) return;
            TeacherName = _propertiesTable.Select("开课编号 like '" + comboBox1.SelectedValue + "'").First()["教师姓名"].ToString();
            //教师姓名
            _chooseClassBriefcase = new FileBriefcase(string.Format(Properties.Settings.Default.OfflineFolder, comboBox1.SelectedValue), true);

            currentPasswd = _chooseClassBriefcase.Properties[Properties.Settings.Default.PropertiesBriefcasePasswd];
            //密码
            ClassName = comboBox1.Text;
            //开课名称
            ClassNumber = Convert.ToInt64(comboBox1.SelectedValue);
            //开课编号


        }

        private void comboBox2_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable skTable = _chooseClassBriefcase.FindTable("SKTABLE");
                cbboxJieCi.DisplayMember = "SKDATE";
                cbboxJieCi.ValueMember = "SKNO";
                cbboxJieCi.DataSource = skTable;
                
                //cbboxCallWay.Text = "指纹点名";
                //tboxClassplace.Text = "明德楼 D0505";
                //cbboxCalltimes.Text = "1";
            }
            catch (Exception exception)
            {
                MessageBox.Show("出现一个错误.请将以下信息提供给管理员\n" + exception.Message);
                return;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (currentPasswd != textBox1.Text)
            {
                MessageBox.Show("请输入正确而密码");
                return;
            }
            DmTable = _chooseClassBriefcase.FindTable(Jieci.ToString());
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassDate = Convert.ToDateTime(cbboxJieCi.Text);
            Jieci = Convert.ToInt64(cbboxJieCi.SelectedValue);
        }
    }
}
