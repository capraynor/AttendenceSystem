using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FpHandle = FingerprintHelper.FpOpenUsb(0xFFFFFFFF, 0);
            
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
                        nRet = FingerprintHelper.FpGetImage(FpHandle, 0);
                    } while (nRet != 0 && _ContinueGetImage);
                    //用到的函数不是上传原始图像 而是上传BMP指纹图像到文件
                    if (!File.Exists("finger.bmp"))
                    {
                        FingerprintHelper.FpUpBMPFile(FpHandle, "finger.bmp", 0);
                    }
                    else
                    {
                        File.Delete("finger.bmp");
                        FingerprintHelper.FpUpBMPFile(FpHandle, "finger.bmp", 0);
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
    }
}
