﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendenceSystem_Alp;
using AttendenceSystem_Alp.PC;
using RemObjects.DataAbstract;

namespace AttendenceSystemClientBeta
{
    public static class OfflineHelper
    {
        //static private DataModule _fdaModule;


        /// <summary>
        /// 将list转换成datatable
        /// </summary>
        /// <param name="list">需要转换的list</param>
        /// <param name="tableName">创建出来的table名称</param>
        /// <returns></returns>
        public static DataTable XktableListToDataTable(List<XKTABLE_VIEW1> list, string tableName)
        {
            DataTable dt = new DataTable(tableName);
            foreach (PropertyInfo info in typeof(XKTABLE_VIEW1).GetProperties())
            {
                dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
            }
            foreach (XKTABLE_VIEW1 t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeof(XKTABLE_VIEW1).GetProperties())
                {
                   row[info.Name] = info.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        
        public static DataTable TableListToDataTable<T>(List<T> list, string tableName)
        {
            DataTable result = new DataTable(tableName);
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    //获取类型
                    Type colType = pi.PropertyType;
                    //当类型为Nullable<>时
                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }
                    result.Columns.Add(pi.Name, colType);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
        //public static DataTable TableListToDataTable<T>(List<T> list, string tableName)
        //{
        //    DataTable dt = new DataTable(tableName);
        //    foreach (PropertyInfo info in typeof(T).GetProperties())
        //    {
        //        // dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
        //        dt.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
        //    }
        //    foreach (T t in list)
        //    {
        //        DataRow row = dt.NewRow();
        //        foreach (PropertyInfo info in typeof(T).GetProperties())
        //        {
        //            if (info.GetValue(t, null) == null)
        //            {
        //                row[info.Name] = DBNull.Value;
        //            }
        //            else
        //            {
        //                row[info.Name] = info.GetValue(t, null);
        //            }
        //            //row[info.Name] = info.GetValue(t, null);
        //        }
        //        dt.Rows.Add(row);
        //    }
        //    return dt;
        //}

      
