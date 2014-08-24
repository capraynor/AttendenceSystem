namespace AttendenceSystem_Alp
{
    class GlobalParams
    {
        public static string SqlitePath = "H:\\working\\软件学院实验室\\C#\\AttendenceSystem\\AttendenceSystem\\bin\\RollCallSystem.db";
        public static string RelativityUrl = "172.20.0.112:7099/bin";
        public static long Jsid = 0;
        public static string KKNO = "-1";
        public static string SKNO = "-1";
        public static string KKNAME = "";
        public static bool IsLogged = false;
        public static string jsname = "";
        public static string CurrentPasswd = "";
        public static string CurrentOfflineDataFile = ".\\Resources\\OfflineData\\{0}";
        public static string OfflineDataFolder = ".\\Resources\\OfflineData\\";
        public static string PropertiesTableName = "PropertiesTable";
        public static string PropertiesBriefcaseName = ".\\Resources\\Properties";
        public static string ResourcesFolder = ".\\Resources";
        public static string CurrentSKDATE = "";
        public static string PropertiesLastModified = "BRIEF_CASE_DATA_LAST_MODIFIED";
        public static string PropertiesTeacherName = "BRIEF_CASE_TEACHER_NAME";
        public static string PropertiesLessonName = "BRIEF_CASE_LESSON_NAME";
        public static string PropertiesClassName = "BRIEF_CASE_CLASS_NAME";
        public static string PropertiesPasswd = "BRIEF_CASE_TEACHER_PASSWD";
        public static string PropertiesTeacherID = "BRIEF_CASE_TEACHER_ID";
        public static string PropertiesLastCheckin = "BRIEF_CASE_LAST_CHECKIN"; //最后一次签到上课编号(skno)
        public static string PropertiesTotalStudentNumber = "BRIEF_CASE_TOTAL_NUMBER";
        public static string DidNotSigned = "未签到";
        public static string Signed = "已签到";
        public static string NotSubmitYet = "未提交";
        public static string Submitted = "已提交";
    }
}
