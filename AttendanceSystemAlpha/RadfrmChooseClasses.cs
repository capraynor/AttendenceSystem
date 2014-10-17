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
        public DateTime SjSkdate;
        public DateTime YdSkdate;
        public DateTime YdXkdate;
        public DateTime SjXkdate;
        public string TeacherName = "";
        public DataTable DmTable = null;
        public bool flag = false;
        public RadfrmChooseClasses()
        {
            
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void RadfrmChooseClasses_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            propertieBriefcase = new FileBriefcase(Properties.Settings.Default.PropertiesBriefcaseFolder, true);
            _propertiesTable = propertieBriefcase.FindTable("PropertiesTable");
            comboBox1.DataSource = _propertiesTable;
            comboBox1.DisplayMember = "开课名称";
            comboBox1.ValueMember = "开课编号";
            this.Height = 354;
            this.Width = 725;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_propertiesTable.Select("开课编号 = '" + comboBox1.SelectedValue + "'").Length == 0) return;
            TeacherName = _propertiesTable.Select("开课编号 = '" + comboBox1.SelectedValue + "'").First()["教师姓名"].ToString();
            //教师姓名
            _chooseClassBriefcase = new FileBriefcase(string.Format(Properties.Settings.Default.OfflineFolder, comboBox1.SelectedValue), true);

            currentPasswd = _chooseClassBriefcase.Properties[Properties.Settings.Default.PropertiesBriefcasePasswd];
            //密码
            ClassName = comboBox1.Text;
            //开课名称
            ClassNumber = Convert.ToInt64(comboBox1.SelectedValue);
            //开课编号
            DataTable skTable = _chooseClassBriefcase.FindTable("SKTABLE");
            cbboxJieCi.DisplayMember = "SKDATE";
            cbboxJieCi.ValueMember = "SKNO";
            cbboxJieCi.DataSource = skTable;
            try
            {
                cbboxJieCi.DisplayMember = "SKDATE";
                cbboxJieCi.ValueMember = "SKNO";
                cbboxJieCi.DataSource = skTable;
                TimeSpan classSpan = TimeSpan.MaxValue;
                foreach (System.Data.DataRowView itemsRow in cbboxJieCi.Items)
                {
                    if (classSpan > ((DateTime)itemsRow["SKDATE"] - DateTime.Now) && ((DateTime)itemsRow["SKDATE"]).Date == DateTime.Now.Date)
                    {
                        classSpan = (DateTime)itemsRow["SKDATE"] - DateTime.Now;
                        cbboxJieCi.SelectedItem = itemsRow;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("出现一个错误.请将以下信息提供给管理员\n" + exception.Message);
                return;
            }

        }

        private void comboBox2_EnabledChanged(object sender, EventArgs e)
        {
            
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Jieci = Convert.ToInt64(cbboxJieCi.SelectedValue);
            DataRowView __tempDRV = (DataRowView) cbboxJieCi.SelectedItem;
            DataRow __tempDr = __tempDRV.Row;
            YdSkdate = (DateTime) __tempDr["YDSKDATE"];
            YdXkdate = (DateTime) __tempDr["YDXKDATE"];
            SjSkdate = (DateTime) __tempDr["SKDATE"];
            SjXkdate = (DateTime) __tempDr["XKDATE"];
            Jieci = (long) __tempDr["SKNO"];
            if (currentPasswd != textBox1.Text || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请输入正确的密码");
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }
            DmTable = _chooseClassBriefcase.FindTable(Jieci.ToString());
            Properties.Settings.Default.CurrentRollCallClassNO = comboBox1.SelectedValue.ToString();
            flag = true;
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SjSkdate = Convert.ToDateTime(cbboxJieCi.Text);
            Jieci = Convert.ToInt64(cbboxJieCi.SelectedValue);
            radButton1.Enabled = true;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            flag = false;
        }
    }
}
