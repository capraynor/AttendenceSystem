using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using RemObjects.DataAbstract;

namespace AttendanceSystemAlpha
{
    public static class FormChooseClassParams
    {
        public static long Jieci = 0;
        public static  Briefcase ChooseClassBriefcase;
        public static string ClassName = "";
        public static DateTime SjSkdate;
        public static DateTime YdSkdate;
        public static DateTime YdXkdate;
        public static DateTime SjXkdate;
        public static bool Flag;
        public static DataTable DmTable;
        public static string TeacherName;
        public static long ClassNumber;
        public static DataTable PropertiesTable;
        public static Briefcase PropertieBriefcase;
    }
}
