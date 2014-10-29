using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Services;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AttendanceSystemAlpha.Properties;
using AttendenceSystem_Alp;
using AttendenceSystem_Alp.PC;
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
        private int currentLine = 0;
        private DataTable xkTable;
        private DataTable bjTable;
        private DataTable backupDisplayTable;
        public ManualRollCall(Briefcase _classBriefcase , long _jieci ,ref DataTable dmTable , DateTime RollcallTime)
        {
            InitializeComponent();
            this.classBriefcase = _classBriefcase;
            this.jieci = _jieci;
            _dmTable = dmTable;
            _rollCallTime = RollcallTime;
            Briefcase propertieBriefcase = new FileBriefcase(Properties.Settings.Default.PropertiesBriefcaseFolder, true);
            bjTable = propertieBriefcase.FindTable("ClassNameTable");
            xkTable = classBriefcase.FindTable("XKTABLE_VIEW1");
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
                    case "4":
                        {
                            displayRow["到课状态"] = "请假";
                            break;
                        }
                    case "5":
                        {
                            displayRow["到课状态"] = "未签到";
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
            backupDisplayTable = displayTable;
            currentLine = GridStudentName.CurrentRow.Index;
            
            refreshChart();
            

        }
        /// <summary>
        /// 更改一个点名记录
        /// </summary>
        /// <param name="dkzt">到课状态 0 正常到课 1 迟到 2 早退 3 旷课 4 请假 </param>
        /// <param name="isArrive">学生是否来上课 true 来上课 false 没有来上课</param>
        private void ChangeOnedmtableRecord(Int16 dkzt, bool isArrive)
        {
            DataRow[] dmRows;
            DataRow[] displayRows;
            lock (ThreadLocker.CallingBriefcaseLocker)
            {
                dmRows =   _dmTable.Select("XSID = '" + GridStudentName.CurrentRow.Cells[1].Value.ToString() + "'");
                if (dmRows.Any())
                {
                    dmRows.First().BeginEdit();
                    dmRows.First()["DKZT"] = dkzt;
                    
                    if (isArrive && dkzt == 1)
                    {
                        dmRows.First()["DMSJ1"] = DateTime.Now;
                    }
                    else if (DateTime.Now <  _rollCallTime)
                    {
                        dmRows.First()["DMSJ1"] = DateTime.Now;
                    }
                    else
                    {
                        dmRows.First()["DMSJ1"] = _rollCallTime;
                    }
                    
                    dmRows.First().EndEdit();
                    displayRows = displayTable.Select("学号 = '" + GridStudentName.CurrentRow.Cells[1].Value + "'");
                    if (displayRows.Any())
                    {
                        displayRows.First().BeginEdit();
                        switch (dkzt)
                        {
                            case 0:
                                {
                                    displayRows.First()["到课状态"] = "正常到课";
                                    break;
                                }
                            case 1:
                                {
                                    displayRows.First()["到课状态"] = "迟到";
                                    break;
                                }
                            case 2:
                                {
                                    displayRows.First()["到课状态"] = "早退";
                                    break;
                                }
                            case 3:
                                {
                                    displayRows.First()["到课状态"] = "旷课";
                                    break;
                                }
                            case 4:
                            {
                                displayRows.First()["到课状态"] = "请假";
                                break;
                            }
                            case 5:
                            {
                                displayRows.First()["到课状态"] = "未签到";
                                break;
                            }
                        }
                        displayRows.First().EndEdit();
                    }
                }
                _dmTable =
                    OfflineHelper.TableListToDataTable(
                        Helpers.EnumerableExtension.ToList<DMTABLE_08_NOPIC_VIEW>(_dmTable), _dmTable.TableName);
                classBriefcase.AddTable(_dmTable);
                classBriefcase.WriteBriefcase();
            }
        }

        /// <summary>
        /// 显示照片等项目
        /// </summary>
        /// <param name="xkTable">选课表</param>
        /// <param name="bjTable">班级表</param>
        /// <param name="XSID">学生学号</param>
        private void RefreshDisplay(DataTable xkTable ,DataTable bjTable, string XSID)
        {
            lbDczt.Text = (string)GridStudentName.CurrentRow.Cells[2].Value;
            lbStudentId.Text = XSID;
            DataRow[] xkRows = xkTable.Select("XSID='" + XSID + "'");
            
            string bjid = xkRows.First()["BJID"].ToString();
            lbStudentClass.Text =  bjTable.Select("BJID = '" + bjid + "'").First()["BJNAME"].ToString();
            if (xkRows.First()["XSZP"] != DBNull.Value)
            {
                byte[] xszpBytes;
                xszpBytes = (byte[])xkRows.First()["XSZP"];
                Stream ms = new MemoryStream(xszpBytes);
                ms.Write(xszpBytes, 0, xszpBytes.Length);
                pictureBox1.Image = Image.FromStream(ms);
            }
            else
            {
                pictureBox1.Image = Resources.attendance_list_icon;
            }
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            ChangeOnedmtableRecord(0, true);
            //刷新label的显示
            if (GridStudentName.SelectedRows.Any() && GridStudentName.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                lbDczt.Text = (string)GridStudentName.CurrentRow.Cells[2].Value;
                lbStudentName.Text = (string)GridStudentName.CurrentRow.Cells[0].Value;
            }
            refreshChart();
            //if (btnChangeState.Text == "正常到课")
            //{

            //    btnChangeState.Text = "迟到";
                
                
            //    //刷新label的显示
            //}
            //else if (btnChangeState.Text == "迟到")
            //{
            //    btnChangeState.Text = "早退";
                
                
            //}
            //else if (btnChangeState.Text == "早退")
            //{
            //    btnChangeState.Text = "旷课";
                
            //}
            //else if (btnChangeState.Text == "旷课")
            //{
            //    btnChangeState.Text = "请假";
            //}
            //else if (btnChangeState.Text == "请假")
            //{
            //    btnChangeState.Text = "正常到课";
                
            //}
            //else if (btnChangeState.Text == "未签到")
            //{
            //    btnChangeState.Text = "正常到课";
            //    ChangeOnedmtableRecord(0, true);
            //    //刷新label的显示
            //    if (GridStudentName.SelectedRows.Any() && GridStudentName.CurrentRow.Cells[0].Value != DBNull.Value)
            //    {
            //        lbStudentName.Text = (string)GridStudentName.CurrentRow.Cells[0].Value;
            //        btnChangeState.Text = (string)GridStudentName.CurrentRow.Cells[2].Value;
            //    }
            //}
        }
        private void radButton7_Click(object sender, EventArgs e)//todo: 显示筛选
        {
            Int16 state = 6;
            if (radButton7.Text == "查看正常到课学生")
            {

                radButton7.Text = "查看非正常到课学生";
                state = 1;
            }
            else if (radButton7.Text == "查看非正常到课学生")
            {
                radButton7.Text = "查看正常到课学生";
                state = 2;

            }
            //else if (radButton7.Text == "只查看早退")
            //{
            //    radButton7.Text = "只查看未签到";
            //    state = 3;
            //}
            //else if (radButton7.Text == "只查看未签到")
            //{
            //    radButton7.Text = "只查看请假";
            //    state = 4;
            //}
            //else if (radButton7.Text == "只查看请假")
            //{
            //    radButton7.Text = "只查看正常到课";
            //    state = 5;

            //}
            //else if (radButton7.Text == "只查看正常到课")
            //{
            //    radButton7.Text = "只查看旷课";
            //    state = 6;
            //}

            switch (state)
            {
                case 1:
                {
                    (GridStudentName.DataSource as DataTable).DefaultView.RowFilter = string.Format("到课状态 = '{0}'", "正常到课");
                    break;
                }
                case 2:
                {
                    (GridStudentName.DataSource as DataTable).DefaultView.RowFilter = string.Format("到课状态 <> '{0}'", "正常到课");
                    break;
                }
                //case 3:
                //{
                //    (GridStudentName.DataSource as DataTable).DefaultView.RowFilter = string.Format("到课状态 = '{0}'", "早退");
                //    break;
                //}
                //case 4:
                //{
                //    (GridStudentName.DataSource as DataTable).DefaultView.RowFilter = string.Format("到课状态 = '{0}'", "未签到");
                //    break;
                //}
                //case 5:
                //{
                //    (GridStudentName.DataSource as DataTable).DefaultView.RowFilter = string.Format("到课状态 = '{0}'", "请假");
                //    break;
                //}
                //case 6:
                //{
                //    (GridStudentName.DataSource as DataTable).DefaultView.RowFilter = string.Format("到课状态 = '{0}'", "正常到课");
                //    break;
                //}
            }
        }

        private void GridStudentName_SelectionChanged(object sender, EventArgs e)
        {
            if (GridStudentName.SelectedRows.Any() && GridStudentName.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                lbStudentName.Text = (string)GridStudentName.CurrentRow.Cells[0].Value;
                currentLine = GridStudentName.CurrentRow.Index;
            }
            RefreshDisplay(xkTable, bjTable, GridStudentName.CurrentRow.Cells[1].Value.ToString());
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (currentLine == (GridStudentName.Rows.Count - 1))
            {
                currentLine = 0;
            }
            else
            {
                currentLine++;
            }
            GridStudentName.CurrentRow = GridStudentName.Rows[currentLine];
            if (GridStudentName.SelectedRows.Any() && GridStudentName.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                lbStudentName.Text = (string)GridStudentName.CurrentRow.Cells[0].Value;
            }
            RefreshDisplay(xkTable, bjTable, GridStudentName.CurrentRow.Cells[1].Value.ToString());
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (currentLine == 0)
            {
                currentLine = (GridStudentName.RowCount - 1);
            }
            else
            {
                currentLine--;
            }
            GridStudentName.CurrentRow = GridStudentName.Rows[currentLine];
            if (GridStudentName.SelectedRows.Any() && GridStudentName.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                lbStudentName.Text = (string)GridStudentName.CurrentRow.Cells[0].Value;
            }
            RefreshDisplay(xkTable, bjTable, GridStudentName.CurrentRow.Cells[1].Value.ToString());
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Height = 740;
            this.Width = 904;
        }

        private void ManualRollCall_VisibleChanged(object sender, EventArgs e)
        {
            //displayTable = new DataTable();
            //if (!displayTable.Columns.Contains("到课状态"))
            //{
            //    displayTable.Columns.Add("姓名", typeof(string));
            //    displayTable.Columns.Add("学号", typeof(string));
            //    displayTable.Columns.Add("到课状态", typeof(string));
            //}
            //foreach (DataRow Row in _dmTable.Rows)
            //{
            //    DataRow displayRow = displayTable.NewRow();
            //    if (Row["XSID"] != DBNull.Value)
            //    {
            //        displayRow["学号"] = Convert.ToString(Row["XSID"]);
            //    }
            //    displayRow["到课状态"] = Convert.ToString(Row["DKZT"]);
            //    switch (Convert.ToString(Row["DKZT"]))
            //    {
                        
            //        case "0":
            //            {
            //                displayRow["到课状态"] = "正常到课";
            //                break;
            //            }
            //        case "1":
            //            {
            //                displayRow["到课状态"] = "迟到";
            //                break;
            //            }
            //        case "2":
            //            {
            //                displayRow["到课状态"] = "早退";
            //                break;
            //            }
            //        case "3":
            //            {
            //                displayRow["到课状态"] = "旷课";
            //                break;
            //            }
            //        case "4":
            //            {
            //                displayRow["到课状态"] = "请假";
            //                break;
            //            }
            //        case "5":
            //            {
            //                displayRow["到课状态"] = "未签到";
            //                break;
            //            }
            //    }
            //    if (Row["XSNAME"] != DBNull.Value)
            //    {
            //        displayRow["姓名"] = Row["XSNAME"].ToString();
            //    }

            //    //resaultRow["到课时间"] = Convert.ToDateTime(Row["DMSJ1"]);\
            //    displayTable.Rows.Add(displayRow);
            //}
            //GridStudentName.DataSource = displayTable;

            //currentLine = GridStudentName.CurrentRow.Index;
        }
        /// <summary>
        /// 刷新饼图的显示
        /// </summary>
        private void refreshChart()
        {
            int sdrs;
            sdrs = CountArriveSudentNumber(_dmTable) + CountLateStudentNumber(_dmTable);
            List<string> xData = new List<string>() { "实到:" + sdrs + "人", "未到" + (_dmTable.Rows.Count - sdrs) + "人" };

            List<int> yData = new List<int>() { sdrs, _dmTable.Rows.Count - sdrs };
            chart1.Series[0].Points.DataBindXY(xData, yData);
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
            dmRows = dmTable.Select("DKZT = '1'");
            return dmRows.Count();
        }

        private void radButton4_Click_1(object sender, EventArgs e)
        {
            ChangeOnedmtableRecord(1, true);
            //刷新label的显示
            if (GridStudentName.SelectedRows.Any() && GridStudentName.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                lbStudentName.Text = (string)GridStudentName.CurrentRow.Cells[0].Value;
                lbDczt.Text = (string)GridStudentName.CurrentRow.Cells[2].Value;
            }
            refreshChart();
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            ChangeOnedmtableRecord(2, false);
            //刷新label的显示
            if (GridStudentName.SelectedRows.Any() && GridStudentName.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                lbStudentName.Text = (string)GridStudentName.CurrentRow.Cells[0].Value;
                lbDczt.Text = (string)GridStudentName.CurrentRow.Cells[2].Value;
            }
            //刷新label的显示
            refreshChart();
        }

        private void radButton8_Click(object sender, EventArgs e)
        {
            ChangeOnedmtableRecord(3, false);
            //刷新label的显示
            if (GridStudentName.SelectedRows.Any() && GridStudentName.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                lbStudentName.Text = (string)GridStudentName.CurrentRow.Cells[0].Value;
                lbDczt.Text = (string)GridStudentName.CurrentRow.Cells[2].Value;
            }
            //刷新label的显示
            refreshChart();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            ChangeOnedmtableRecord(4, false);
            //刷新label的显示
            if (GridStudentName.SelectedRows.Any() && GridStudentName.CurrentRow.Cells[0].Value != DBNull.Value)
            {
                lbStudentName.Text = (string)GridStudentName.CurrentRow.Cells[0].Value;
                lbDczt.Text = (string)GridStudentName.CurrentRow.Cells[2].Value;
            }
            //刷新label的显示
            refreshChart();
        }

        private void radButton9_Click(object sender, EventArgs e)
        {

        }

    }
}
