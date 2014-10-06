using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RemObjects.DataAbstract;
using Telerik.WinControls;

namespace AttendanceSystemAlpha
{
    public partial class ManualRollCall : Telerik.WinControls.UI.RadForm
    {
        private long jieci;
        private Briefcase classBriefcase;
        private DataTable _dmTable;
        private DateTime _rollCallTime;
        private DataTable displayTable;
        public ManualRollCall(Briefcase _classBriefcase , long _jieci ,ref DataTable dmTable , DateTime RollcallTime)
        {
            InitializeComponent();
            this.classBriefcase = _classBriefcase;
            this.jieci = _jieci;
            _dmTable = dmTable;
        }

        private void ManualRollCall_Load(object sender, EventArgs e)
        {
            displayTable = new DataTable();
            if (!displayTable.Columns.Contains("到课状态"))
            {
                displayTable.Columns.Add("姓名", typeof(string));
                displayTable.Columns.Add("学号", typeof(string));
                displayTable.Columns.Add("到课状态", typeof(string));
            }
            foreach (DataRow Row in _dmTable.Rows)
            {
                DataRow displayRow = displayTable.NewRow();
                if (Row["XSID"] != DBNull.Value)
                {
                    displayRow["学号"] = Convert.ToString(Row["XSID"]);
                }
                displayRow["到课状态"] = Convert.ToString(Row["DKZT"]);
                switch (Convert.ToString(Row["DKZT"]))
                {
                    case "0":
                        {
                            displayRow["到课状态"] = "正常到课";
                            break;
                        }
                    case "1":
                        {
                            displayRow["到课状态"] = "迟到";
                            break;
                        }
                    case "2":
                        {
                            displayRow["到课状态"] = "早退";
                            break;
                        }
                    case "3":
                        {
                            displayRow["到课状态"] = "旷课";
                            break;
                        }
                }
                if (Row["XSNAME"] != DBNull.Value)
                {
                    displayRow["姓名"] = Row["XSNAME"].ToString();
                }
                
                //resaultRow["到课时间"] = Convert.ToDateTime(Row["DMSJ1"]);\
                displayTable.Rows.Add(displayRow);
            }
            GridStudentName.DataSource = displayTable;
        }
        private void ChangeOnedmtableRecord(long xsid, Int16 dkzt)
        {

        }

        private void RefreshDisplay()
        {
            
        }
        private void UpdateTableToBriefCase()
        {
            lock (ThreadLocker.CallingBriefcaseLocker)
            {

            }
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            
        }

        private void radButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void GridStudentName_SelectionChanged(object sender, EventArgs e)
        {
            if (GridStudentName.SelectedRows.Any()&& GridStudentName.CurrentRow.Cells[0].Value!=DBNull.Value)
            {
                lbStudentName.Text = (string)GridStudentName.CurrentRow.Cells[0].Value;
                lbDKZT.Text = (string) GridStudentName.CurrentRow.Cells[2].Value;

            }
        }

    }
}
