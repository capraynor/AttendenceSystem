using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace AttendanceSystemAlpha
{
    /// <summary>
    /// 选择时间窗口
    /// </summary>
    public partial class FrmChooseDate : Telerik.WinControls.UI.RadForm
    {
        public DateTime dt = DateTime.Now;//该变量用于传值 获得时间

        public Boolean isChanged = false;//标记变量 单击了 确定 还是 取消 

        private DateTime _pDateTime = DateTime.Now;

        public FrmChooseDate(DateTime YdSkSj , DateTime SjSksj)
        {//构造函数
            InitializeComponent();

            _pDateTime = YdSkSj;//上课时间

            radDateTimePicker2.Value = YdSkSj;//预定上课时间
            
            radDateTimePicker1.Value = SjSksj;//实际上课时间
        }

        private void radButton1_Click(object sender, EventArgs e)//确定按钮
        {
            isChanged = true;

            if (radDateTimePicker1.Value.Date != DateTime.Now.Date)//如果时间不是今天
            {

                MessageBox.Show("请选择一个合适的时间");
                
                return;
            
            }
            dt = radDateTimePicker1.Value;//用于传值
            this.Hide();//关闭窗口 需要改成this.close
        }

        private void radButton2_Click(object sender, EventArgs e)
        {//取消按钮
            isChanged = false;
            this.Hide();//关闭窗口
        }

        private void FrmChooseDate_Load(object sender, EventArgs e)
        {

        }
    }
}
