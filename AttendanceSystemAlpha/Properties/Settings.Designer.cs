﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18449
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AttendanceSystemAlpha.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UserId {
            get {
                return ((string)(this["UserId"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Password {
            get {
                return ((string)(this["Password"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool StorePassword {
            get {
                return ((bool)(this["StorePassword"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("AttendanceSystem")]
        public string Domain {
            get {
                return ((string)(this["Domain"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("PC")]
        public string Schema {
            get {
                return ((string)(this["Schema"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:7099/bin/")]
        public string ServerUrl {
            get {
                return ((string)(this["ServerUrl"]));
            }
            set {
                this["ServerUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\\\Resources\\\\Properties.daBriefcase")]
        public string PropertiesBriefcaseFolder {
            get {
                return ((string)(this["PropertiesBriefcaseFolder"]));
            }
            set {
                this["PropertiesBriefcaseFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\\\Resources\\\\OfflineData\\\\{0}")]
        public string OfflineFolder {
            get {
                return ((string)(this["OfflineFolder"]));
            }
            set {
                this["OfflineFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BRIEF_CASE_TEACHER_PASSWD")]
        public string PropertiesBriefcasePasswd {
            get {
                return ((string)(this["PropertiesBriefcasePasswd"]));
            }
            set {
                this["PropertiesBriefcasePasswd"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BRIEF_CASE_TEACHER_NAME")]
        public string PropertiesBriefCaseTeacherName {
            get {
                return ((string)(this["PropertiesBriefCaseTeacherName"]));
            }
            set {
                this["PropertiesBriefCaseTeacherName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BRIEF_CASE_LAST_CHECKIN")]
        public string PropertiesLastCheckin {
            get {
                return ((string)(this["PropertiesLastCheckin"]));
            }
            set {
                this["PropertiesLastCheckin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BRIEF_CASE_TOTAL_NUMBER")]
        public string PropertiesTotalStudentNumber {
            get {
                return ((string)(this["PropertiesTotalStudentNumber"]));
            }
            set {
                this["PropertiesTotalStudentNumber"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SaveOfflinePasswd {
            get {
                return ((bool)(this["SaveOfflinePasswd"]));
            }
            set {
                this["SaveOfflinePasswd"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DownloadPasswd {
            get {
                return ((string)(this["DownloadPasswd"]));
            }
            set {
                this["DownloadPasswd"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CurrentDownloadPasswd {
            get {
                return ((string)(this["CurrentDownloadPasswd"]));
            }
            set {
                this["CurrentDownloadPasswd"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int OperationProgess {
            get {
                return ((int)(this["OperationProgess"]));
            }
            set {
                this["OperationProgess"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool BriefcaseIsBusy {
            get {
                return ((bool)(this["BriefcaseIsBusy"]));
            }
            set {
                this["BriefcaseIsBusy"] = value;
            }
        }
    }
}
