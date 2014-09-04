using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HDFingerPrintHelper;
using System.Runtime.InteropServices;
using FP_HANDLE = System.IntPtr;
using int8_t = System.Char;
using int16_t = System.Int16;
using int32_t = System.Int32;
using uint8_t = System.Byte;
using uint16_t = System.UInt16;
using uint32_t = System.UInt32;
using INT = System.Int32;
using UINT = System.UInt32;



namespace FormTestProject
{
    public partial class Form1 : Form
    {
        FP_HANDLE FpHandle;

        private delegate void UiProcessFunction(object param);
        private volatile Boolean _ContinueGetImage = true;
        private int nRet = 0;
        private string FingerStrTest = "";
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FpHandle = HDFingerprintHelper.FpOpenUsb(0xFFFFFFFF, 0);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FpHandle.ToInt32() == 0)
            {
                MessageBox.Show("指纹仪初始化失败");
            }
            else
            {
                Thread thread = new Thread(GetImage );
                thread.IsBackground = true;
                thread.Start();

                // todo get Image Thread
            }
        }

        private void GetImage()
        {
            while (_ContinueGetImage)
            {
                if (FpHandle != IntPtr.Zero)
                {
                    do
                    {
                        nRet = HDFingerprintHelper.FpGetImage(FpHandle, 0);
                    } while (nRet != 0 && _ContinueGetImage);
                    //用到的函数不是上传原始图像 而是上传BMP指纹图像到文件
                    if (!File.Exists("finger.bmp"))
                    {
                        HDFingerprintHelper.FpUpBMPFile(FpHandle, "finger.bmp", 0);
                    }
                    else
                    {
                        File.Delete("finger.bmp");
                        HDFingerprintHelper.FpUpBMPFile(FpHandle, "finger.bmp", 0);
                    }
                    
                    if (File.Exists("finger.bmp"))
                    {
                        this.Invoke(new UiProcessFunction(UpdateImage), new object[] { "finger.bmp" });
                    }
                }
            }
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(this.ChangeText);
        //后台线程，不加此声明的话会导致程序关闭错误
            thread.IsBackground = true;
         //开启主线程
        thread.Start();
        }

        private void ChangeText()
        {
            int i = 0;
            while (true)
            {
                string arg = "Count : " + i.ToString();
                //注意此处的参数传递的方法
                this.Invoke(new UiProcessFunction(UpdateLabel), new object[] { arg });
                this.label1.Text = "Count : " + i.ToString();
                Thread.Sleep(500);
                i++;
            }
             // UpdateLabel(i++.ToString()); todo: crash 不能线程间访问
        }

        private void UpdateLabel(Object param)
        {
            this.label1.Text = (string) param;
        }

        private void UpdateImage(Object Path)
        {
            FileStream fs = new FileStream((string)Path , FileMode.Open , FileAccess.Read , FileShare.Read);
            BinaryReader br = new BinaryReader(fs);
            MemoryStream ms = new MemoryStream(br.ReadBytes((int)fs.Length));
            this.pictureBox1.Image = Image.FromStream(ms);
            fs.Close();
            
            //文件流 字节流 内存流 关闭文件流 释放文件 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread getFingerStrThread = new Thread(CaptureFingerString);
            getFingerStrThread.IsBackground = true;
            getFingerStrThread.Start();
        }

        private void CaptureFingerString()
        {
            string fingerStr = "";
            HDFingerprintHelper.Enroll_1st("finger.bmp", FpHandle);
            Invoke(new UiProcessFunction(UpdateImage), new object[] {"finger.bmp"});
            SetControlPropertyThreadSafe(pictureBox1 , "Image" , null);
            SetControlPropertyThreadSafe(pictureBox1, "Image", Image.FromFile("finger.bmp"));
            Invoke(new UiProcessFunction(UpdateLabel), new object[] { "请移开手指" });
            HDFingerprintHelper.LiftUrFinger(FpHandle);
            Invoke(new UiProcessFunction(UpdateLabel), new object[] { "继续按手指" });
            
            HDFingerprintHelper.Enroll_2nd("finger.bmp", FpHandle);
            SetControlPropertyThreadSafe(pictureBox1, "Image", Image.FromFile("finger.bmp"));
            HDFingerprintHelper.GenerateString(FpHandle, ref fingerStr);
            Invoke(new UiProcessFunction(UpdateLabel), new object[] { fingerStr });
            FingerStrTest = fingerStr;
        }

        private void VerifyFingerPrint()
        {
            uint16_t fingerID = 0;
            uint16_t score = 0;
            int stat = 0;

            while (true)
            {
                stat = HDFingerprintHelper.StartVerify(FpHandle, "finger.bmp", ref fingerID, ref score);
                Invoke(new UiProcessFunction(UpdateLabel), new object[] { "指纹编号"+fingerID.ToString() + " 得分 " + score.ToString() + " 状态码 " + stat.ToString() });
            }
            
        }

        private void UploadFingerPrintString()
        {
            
            int stat =  HDFingerprintHelper.Download1Fingerprint(FpHandle, FingerStrTest, 1);

        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            UploadFingerPrintString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread verifyThread = new Thread(VerifyFingerPrint);
            verifyThread.IsBackground = true;
            verifyThread.Start();
            MessageBox.Show("test");
        }
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }
    }
}
