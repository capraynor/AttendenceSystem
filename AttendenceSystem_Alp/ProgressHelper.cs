using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using AttendenceSystem_Alp.Properties;

namespace AttendenceSystem_Alp
{
    public class ProgressHelper
    {
        private static Thread thread = thread = new Thread(ShowProgress);
        private static void ShowProgress()
        {
            ProgressForm progressForm = new ProgressForm();
            lock (GlobalParams.CloseProgressWindowLocker)
            {
                Settings.Default.CloseProgressForm = false;
            }
            try
            {
                progressForm.ShowDialog();
            }
            catch (Exception)
            {
                
            }
        }

        public static void StartProgressThread()
        {
            thread = new Thread(ShowProgress);
            lock (GlobalParams.CloseProgressWindowLocker)
            {
                Settings.Default.CloseProgressForm = false;
            }
            thread.IsBackground = true;
            thread.Start();
        }

        public static void  StopProgressThread()
        {
            lock (GlobalParams.CloseProgressWindowLocker)
            {
                Settings.Default.CloseProgressForm = true;
            }
        }

        public static void SetProgress(int Value)
        {
            lock (GlobalParams.ProgressValueLocker)
            {
                Settings.Default.ProgressValue = Value;
            }
        }

        
    }
}
