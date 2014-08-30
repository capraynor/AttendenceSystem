using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AxZKFPEngXControl;
namespace FingerprintHelper
{
    
    public static class FingerHelper
    {
        /// <summary>
        /// Convert File to Byte[]
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        private static byte[] FileContent(string fileName)
        {
            var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {
                var buffur = new byte[fs.Length];
                fs.Read(buffur, 0, (int)fs.Length);

                return buffur;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                //关闭资源
                fs.Close();
            }
        }


        public class RegStatistics
        {
            public int TimesNeeded = 3;//还需要按压的次数 共三次
            public int ErrorCode = 0;//错误代码 0：好的指纹特征 1：特征点不够 2：其他原因导致不能验证
            
        }
        /// <summary>
        /// 初始化指纹设备 关闭程序时需要停止指纹设备
        /// </summary>
        /// <param name="fingerPrinter">指纹设备（如：AxZKFPEngX1）</param>
        public static void InitFingerPrintDevice(AxZKFPEngX fingerPrinter)//初始化指纹设备
        {
            try
            {
                MessageBox.Show(fingerPrinter.InitEngine() == 0 ? "初始化成功" : "初始化失败");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 停止指纹设备
        /// </summary>
        /// <param name="fingerPrinter">指纹设备（如：AxZKFPEngX1）</param>
        public static void StopFingerPrintDevice(AxZKFPEngX fingerPrinter) //停止指纹设备
        {
            try
            {
                fingerPrinter.EndEngine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 用于处理OnFeatureInfoEvent事件
        /// 登记结束后发生onEnroll事件
        /// 抛出：指纹仪未初始化 异常
        /// </summary>
        /// <param name="e">AxZKFPEngXControl中的IZKFPEngXEvents_OnFeatureInfoEvent事件</param>
        /// <param name="fingerPrintDevice">指纹设备（如：AxZKFPEngX1）</param>
        /// <returns>本次采集指纹的质量</returns>
        public static RegStatistics GetRegStat(IZKFPEngXEvents_OnFeatureInfoEvent e ,AxZKFPEngX fingerPrintDevice)
        {
            if (fingerPrintDevice == null) throw new ArgumentNullException("fingerPrintDevice");
            var stat = new RegStatistics {ErrorCode = e.aQuality};
            try
            {
                if (!fingerPrintDevice.IsRegister) return stat;
                stat.TimesNeeded = fingerPrintDevice.EnrollIndex - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            return stat;
        }
        /// <summary>
        /// 用于处理IZKFPEngXEvents_OnImageReceivedEvent事件
        /// 抛出：指纹仪未初始化 异常
        /// </summary>
        /// <param name="e">IZKFPEngXEvents_OnImageReceivedEvent事件</param>
        /// <param name="fingerprintDevice">指纹设备（如：AxZKFPEngX1）</param>
        /// <returns>一个System.Image</returns>
        public static Image GetFingerprintImage(IZKFPEngXEvents_OnImageReceivedEvent e,
            AxZKFPEngX fingerprintDevice)
        {

            if (fingerprintDevice == null) throw new ArgumentNullException("fingerprintDevice");
            if (!e.aImageValid) return null;
#pragma warning disable 642
            if (File.Exists("temp.bmp")) ;
#pragma warning restore 642
            {
                File.Delete("temp.bmp");
            }
            try
            {
                fingerprintDevice.SaveBitmap("temp.bmp");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
#pragma warning disable 642
            
#pragma warning restore 642
            {
                var file = FileContent("temp.bmp");
                var ms = new MemoryStream(file) {Position = 0};
                File.Delete("temp.bmp");
                return Image.FromStream(ms);
            }
        }
        /// <summary>
        /// 用于处理OnEnrollEvent事件
        /// 抛出：指纹仪未初始化 异常
        /// </summary>
        /// <param name="e"></param>
        /// <param name="fingerprintDevice">指纹设备（如：AxZKFPEngX1）</param>
        /// <returns></returns>
        
        public static string GetFingerstring(IZKFPEngXEvents_OnEnrollEvent e,
            AxZKFPEngX fingerprintDevice)
        {
            if (fingerprintDevice == null) throw new ArgumentNullException("fingerprintDevice");
            var atemplate = e.aTemplate;
            
            string fingerPrintString;
            try
            {
                fingerPrintString = fingerprintDevice.EncodeTemplate1(atemplate);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
            return fingerPrintString;

        }
        /// <summary>
        /// 开始采集指纹 一共需要采集三次才能触发 OnEnroll事件
        /// </summary>
        /// <param name="fingerPrintDevice">指纹设备（如：AxZKFPEngX1）</param>
        public static void StartCapture(AxZKFPEngX fingerPrintDevice)
        {
            try
            {
                fingerPrintDevice.BeginEnroll();
            }
            catch (Exception e )
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

//*******指纹验证部分***************//
        /// <summary>
        /// 创建一个高速缓冲区 用于1：N识别指纹
        /// </summary>
        /// <param name="fingerPrintDevice">指纹设备（如：AxZKFPEngX1）</param>
        /// <returns>返回高速缓冲区的编号 此编号需要记录下来，用于添加指纹模板和后期的验证</returns>
        public static int CreateFastBufDatabase(AxZKFPEngX fingerPrintDevice)
        {
            try
            {
                var fpcHandle = fingerPrintDevice.CreateFPCacheDB();
                return fpcHandle;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }
        /// <summary>
        /// 向指定高速缓冲区中添加指纹模板
        /// </summary>
        /// <param name="strFingerPrint">指纹字符串</param>
        /// <param name="fingerPrintDevice">指纹设备</param>
        /// <param name="fpcHandle">高速缓冲存储区的号码</param>
        /// <param name="fingerPrintId">验证成功时将返回的ID 作为指纹的唯一标识</param>
        /// <returns></returns>
        public static bool AddFingerprintTemplate(string strFingerPrint, AxZKFPEngX fingerPrintDevice, int fpcHandle,
            int fingerPrintId)
        {
            if(String.IsNullOrWhiteSpace(strFingerPrint))
            return false;
            MessageBox.Show(strFingerPrint);
            try
            {
                var fRegTemplete = fingerPrintDevice.DecodeTemplate1(strFingerPrint);
                fingerPrintDevice.AddRegTemplateToFPCacheDB(fpcHandle, fingerPrintId, fRegTemplete);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 用于处理OnCapture事件，将采集到的指纹模板和高速缓冲区比对
        /// </summary>
        /// <param name="fingerPrintDevice">指纹设备（如：AxZKFPEngX1）</param>
        /// <param name="fpcHandle">高速缓冲区域的ID</param>
        /// <param name="e">IZKFPEngXEvents_OnCaptureEvent事件 一般为e</param>
        /// <param name="similarity">相似度 【引用传值！】</param>
        /// <param name="identificationIndex">认证顺序号码【引用传值！】</param>
        /// <returns>最相似模板的 ID</returns>
        public static int VeryfyAFingerPrint(AxZKFPEngX fingerPrintDevice, int fpcHandle,IZKFPEngXEvents_OnCaptureEvent e,ref  int similarity,ref int identificationIndex)
        {
            int resault;
            try
            {
                resault = fingerPrintDevice.IdentificationInFPCacheDB(fpcHandle, e.aTemplate, ref similarity, ref identificationIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return resault;

        }
    }
}
