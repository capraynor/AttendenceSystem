using System;
using System.IO;
using System.Runtime.InteropServices;
using FP_HANDLE = System.IntPtr;
using int8_t = System.Char;  
using int16_t=System.Int16;
using int32_t=System.Int32;
using uint8_t=System.Byte;
using uint16_t=System.UInt16;
using uint32_t=System.UInt32;
using INT=System.Int32;
using UINT = System.UInt32;


namespace HDFingerPrintHelper
{


    public class HDFingerprintHelper
    {
        private const int FP_OK = 0x00;
        protected FP_HANDLE m_hFpDrive;
        
        [DllImport("fplib.dll")]
        public static extern FP_HANDLE FpOpenUsb(uint32_t nAddr, uint32_t timeout); // naddr = 0xFFFFFFFF



        [DllImport("fplib.dll")]
        public static extern int FpCloseUsb(FP_HANDLE fpHandle);



        [DllImport("fplib.dll")]
        public static extern int FpGetImage(FP_HANDLE fpHandle, uint32_t timeout);



        [DllImport("fplib.dll")]
        public static extern int FpGenChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint32_t timeout);



        [DllImport("fplib.dll")]
        public static extern int FpMatch(FP_HANDLE fpHandle, ref uint16_t pScore, uint32_t timeout);



        [DllImport("fplib.dll")]
        public static extern int FpSearch(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nStartPage, uint16_t nPageNum,
            ref uint16_t pPageId, ref uint16_t pScore, uint32_t timeout);




        [DllImport("fplib.dll")]
        public static extern int FpRegModel(FP_HANDLE fpHandle, uint32_t timeout);



        [DllImport("fplib.dll")]
        public static extern int FpStoreChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout);



        [DllImport("fplib.dll")]
        public static extern int FpLoadChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout);



        [DllImport("fplib.dll")]
        public static extern int FpValidTempleteNum(FP_HANDLE fpHandle, ref uint16_t pNum, uint32_t timeout);



        [DllImport("fplib.dll")]
        public static extern int FpUpBMPFile(FP_HANDLE fpHandle, string pFile, uint32_t timeout);

        [DllImport("fplib.dll")]
        public static extern int FpEmpty(FP_HANDLE fpHandle, uint32_t timeout);

        [DllImport("fplib.dll")]
        public static extern int FpUpChar(FP_HANDLE fpHandle, uint8_t nBufferId, byte[] pBuf, int nBufSize,
            ref int pBytesReturned, uint32_t timeout);

        [DllImport("fplib.dll")]
        public static extern int FpDownChar(FP_HANDLE fpHandlePtr, uint8_t nBufferId, byte[] pBuf, int nBufSize,
            uint32_t timeout);




        
        
        //下面是自定义函数区段
        /// <summary>
        /// 第二次指纹登记
        /// </summary>
        /// <param name="Filename">指纹图像保存位置 （BMP）</param>
        /// <param name="fpHandlePtr">指纹设备句柄 FpOpenusb的返回值</param>
        /// <param name="timeout">最长等待时间 默认为永远不超时</param>
        /// <returns>状态码 请参照状态码表 </returns>
        public static int Enroll_1st(string Filename , FP_HANDLE fpHandlePtr , uint timeout = 0)
        {
            int stat = 0;
            do
            {
                stat = FpGetImage(fpHandlePtr, timeout);
            } while (stat != 0 && stat == 2);
            if (stat != 0) return stat;

            try
            {
                if (File.Exists(Filename))
                {
                    File.Delete(Filename);
                }
                stat =  FpUpBMPFile(fpHandlePtr, Filename, timeout);
                if (stat != 0) return stat;
            }
            catch (Exception)
            {
                
            }
            FpGenChar(fpHandlePtr, 1, timeout);
            return stat;
        }
        /// <summary>
        /// 第二次指纹登记
        /// </summary>
        /// <param name="Filename">指纹图像保存位置 （BMP）</param>
        /// <param name="fpHandlePtr">指纹设备句柄</param>
        /// <param name="timeout">超时 默认为永远不超时</param>
        /// <returns>状态码 请参照状态码表 </returns>
        public static int Enroll_2nd(string Filename, FP_HANDLE fpHandlePtr, uint timeout = 0)
        {
            int stat = 0;
            do
            {
                stat = FpGetImage(fpHandlePtr, timeout);
            } while (stat != 0 && stat  == 2);
            if (stat != 0) return stat;
            try
            {
                if (File.Exists(Filename))
                {
                    File.Delete(Filename);
                }
                stat = FpUpBMPFile(fpHandlePtr, Filename, timeout);
                if (stat != 0) return stat;
            }
            catch (Exception)
            {

            }
            FpGenChar(fpHandlePtr, 2, timeout);
            return stat;
        }
        /// <summary>
        /// 获得指纹字符串
        /// </summary>
        /// <param name="fpHandlePtr">指纹仪设备的句柄</param>
        /// <param name="fpString">指纹字符串【引用】</param>
        /// <param name="timeout">等待时间 默认为0</param>
        /// <returns>状态码 具体请参考状态码说明文件</returns>
        public static int GenerateString(FP_HANDLE fpHandlePtr, ref string fpString, uint timeout = 0)
        {
            int stat = 0;
            int fingerRawLength = 0;
            stat = FpRegModel(fpHandlePtr, timeout);
            if (stat != 0) return stat; // 调用指纹库
            byte[] fingerRawBytes = new byte[512];
            stat =  FpUpChar(fpHandlePtr, 1, fingerRawBytes, 512, ref fingerRawLength, timeout);
            if (stat != 0) return stat; // 调用指纹库
            //byte[] newBytes = new byte[fingerRawLength];
            //Array.Copy(fingerRawBytes , 0 , newBytes , 0 , fingerRawLength );
            //fingerRawBytes = newBytes; // todo : 截取出已经下载的那部分
            string fingerBase64String = Convert.ToBase64String(fingerRawBytes);
            fpString = fingerBase64String;
            return stat;
        }
        /// <summary>
        /// 该函数会阻塞线程 用来提醒用户将手指离开指纹仪并避免出现错误 
        /// </summary>
        /// <param name="fpHandlePtr"> 指纹仪句柄</param>
        /// <param name="timeout">等待时间</param>
        public static void  LiftUrFinger(FP_HANDLE fpHandlePtr , uint timeout = 0)
        {
            int stat = 0;
            do
            {
                stat = FpGetImage(fpHandlePtr, timeout);
            } while (stat == 0);
        }

        //指纹验证部分
        public static int  Download1Fingerprint(FP_HANDLE fpHandlePtr, string FingerprintString,uint16_t id , uint timeout = 0)
        {
            int stat = 0;
            byte[] fingerPrintRawData = Convert.FromBase64String(FingerprintString);
            stat =  FpDownChar(fpHandlePtr, 1, fingerPrintRawData, 512, timeout);
            if (stat != 0) return stat;
            stat =  FpStoreChar(fpHandlePtr, 1, id, timeout);
            return stat;
        }

        public static int StartVerify(FP_HANDLE fpHandlePtr, string filename, ref uint16_t FingerId,ref ushort score, uint32_t timeout = 0)
        {
            uint16_t  FingerprintNumbers = 0; // 指纹仪中的总数
            int stat = 0;
            do
            {
                stat = FpGetImage(fpHandlePtr, timeout);
            } while (stat != 0 && stat == 2);
            if (stat != 0) return stat;
            stat =  FpValidTempleteNum(fpHandlePtr, ref FingerprintNumbers, timeout); // 获取总数
            if (stat != 0) return stat;
            
           // stat = FpUpBMPFile(fpHandlePtr, filename, timeout); // 上传图片
            if (stat != 0) return stat; 
            stat = FpGenChar(fpHandlePtr, 1, timeout);
            if (stat != 0) return stat;
            stat = FpSearch(fpHandlePtr, 1, 0, Convert.ToUInt16(FingerprintNumbers), ref FingerId, ref  score, timeout);
            //if (stat != 0 && stat != 9) return stat; // 错误码9：没有搜索到指纹
            //else
            //{
            //    return 0;
            //}
            return stat;
        }
        
    }
}
