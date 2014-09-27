using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AttendenceSystem_Alp
{
    public class ProgressHelper
    {
        private static ProgressForm progressForm = null;
        private static Thread thread = thread = new Thread(ShowProgress);
        private static void ShowProgress()
        {
            ProgressForm progressForm = new ProgressForm();
            progressForm.ShowDialog();
        }

        public static void StartProgressThread()
        {
            thread = new Thread(ShowProgress);
            thread.Start();
        }

        public static void  StopProgressThread()
        {
            if (thread.IsAlive)
            {
                thread.Abort();
            }
        }

        public static void SetProgress(int Value)
        {
            Properties.Settings.Default.ProgressValue = Value;
        }

        
    }
}
