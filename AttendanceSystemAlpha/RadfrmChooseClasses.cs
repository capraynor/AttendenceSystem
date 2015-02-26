using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private string _currentPasswd = "           55555555555            ";//当前密码 初始化为一个不可能的值

        //选择课程窗口
        //已删除窗口类内变量.
        public RadfrmChooseClasses()
        {
            
            InitializeComponent();
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //之前用于验证离线密码.目前已经废弃.
        }

        private void RadfrmChooseClasses_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            FormChooseClassParams.PropertieBriefcase = new FileBriefcase(Properties.Settings.Default.PropertiesBriefcaseFolder, true);
            FormChooseClassParams.PropertiesTable = FormChooseClassParams.PropertieBriefcase.FindTable("PropertiesTable");
            comboBox1.DisplayMember = "开课名称";
            comboBox1.ValueMember = "开课编号";
            comboBox1.DataSource = FormChooseClassParams.PropertiesTable;
            this.Height = 354;
            this.Width = 725;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormChooseClassParams.PropertiesTable.Select("开课编号 = '" + comboBox1.SelectedValue + "'").Length == 0) return;
            FormChooseClassParams.TeacherName = FormChooseClassParams.PropertiesTable.Select("开课编号 = '" + comboBox1.SelectedValue + "'").First()["教师姓名"].ToString();
            //教师姓名
            FormChooseClassParams.ChooseClassBriefcase = new FileBriefcase(string.Format(Properties.Settings.Default.OfflineFolder, comboBox1.SelectedValue), true);//Combobox1:选择这节课要上哪门课

            _currentPasswd =FormChooseClassParams.ChooseClassBriefcase.Properties[Properties.Settings.Default.PropertiesBriefcasePasswd];
            //密码
            FormChooseClassParams.ClassName = comboBox1.Text;
            //开课名称
            FormChooseClassParams.ClassNumber = Convert.ToInt64(comboBox1.SelectedValue);
            //开课编号
            DataTable skTable = FormChooseClassParams.ChooseClassBriefcase.FindTable("SKTABLE");
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
            if (_currentPasswd != textBox1.Text || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请输入正确的密码");
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }
            if (!Properties.Settings.Default.NeedUpload)
            {
                if (((DataRowView)cbboxJieCi.SelectedItem).Row["SKZT"].ToString() == "1")
                {
                    MessageBox.Show("本节课已经进行了点名操作，无法再次点名");
                    return;
                }
            }
            FormChooseClassParams.Jieci = Convert.ToInt64(cbboxJieCi.SelectedValue);
            DataRowView __tempDRV = (DataRowView) cbboxJieCi.SelectedItem;
            DataRow __tempDr = __tempDRV.Row;
            FormChooseClassParams.YdSkdate = (DateTime) __tempDr["YDSKDATE"];
            FormChooseClassParams.YdXkdate = (DateTime) __tempDr["YDXKDATE"];
            FormChooseClassParams.SjSkdate = (DateTime) __tempDr["SKDATE"];
            FormChooseClassParams.SjXkdate = (DateTime) __tempDr["XKDATE"];
            FormChooseClassParams.Jieci = (long)__tempDr["SKNO"];



            FormChooseClassParams.DmTable = FormChooseClassParams.ChooseClassBriefcase.FindTable(FormChooseClassParams.Jieci.ToString());
            Properties.Settings.Default.CurrentRollCallClassNO = comboBox1.SelectedValue.ToString();
            FormChooseClassParams.Flag = true;
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormChooseClassParams.SjSkdate = Convert.ToDateTime(cbboxJieCi.Text);
            FormChooseClassParams.Jieci = Convert.ToInt64(cbboxJieCi.SelectedValue);
            radButton1.Enabled = true;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            FormChooseClassParams.Flag = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //弹出键盘
            try
            {
                Process.Start(@"C:/Program Files/Common Files/microsoft shared/ink/tabtip.exe");
            }
            catch (Exception)
            {

            }
            //弹出键盘
        }
    }
}
