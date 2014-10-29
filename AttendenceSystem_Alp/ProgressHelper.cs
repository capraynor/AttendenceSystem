using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace AttendenceSystem_Alp
{
    public class ProgressHelper
    {
        private static Thread thread = thread = new Thread(ShowProgress);
        private static void ShowProgress()
        {
            ProgressForm progressForm = new ProgressForm();
            Properties.Settings.Default.CloseProgressForm = false;
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
            Properties.Settings.Default.CloseProgressForm = false;
            thread.IsBackground = true;
            thread.Start();
        }

        public static void  StopProgressThread()
        {
            Properties.Settings.Default.CloseProgressForm = true;
        }

        public static void SetProgress(int Value)
        {
            Properties.Settings.Default.ProgressValue = Value;
        }

        
    }
}
