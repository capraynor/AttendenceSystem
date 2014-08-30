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


    public class FingerFunction
    {
        private const int FP_OK = 0x00;
        protected FP_HANDLE m_hFpDrive;
        
        [DllImport("fplib.dll")]

/***********************************************************************************************************
* 函数名称: FP_HANDLE FpOpenUsb(uint32_t nAddr, uint32_t timeout);
* 函数功能: 打开USB驱动
* 输入参数: 芯片地址
* 输入参数: 等候时间
* 返回参数: 失败为0, 否则为设备句柄
***********************************************************************************************************/
        public extern FP_HANDLE FpOpenUsb(uint32_t nAddr, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpCloseUsb(FP_HANDLE fpHandle);
* 函数功能: 关闭USB驱动
* 输入参数: 设备句柄, FpOpenUsb()或FpOpenUsbEx()的返回值
* 返回参数: 执行结果
***********************************************************************************************************/

        [DllImport("fplib.dll")]
        public extern int FpCloseUsb(FP_HANDLE fpHandle);

/***********************************************************************************************************
* 函数名称: int FpGetImage(FP_HANDLE fpHandle, uint32_t timeout)
* 函数功能: 探测手指，探测到后录入指纹图像存于ImageBuffer
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/

        [DllImport("fplib.dll")]
        public extern int FpGetImage(FP_HANDLE fpHandle, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpGenChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint32_t timeout)
* 函数功能: 将ImageBuffer 中的原始图像生成指纹特征文件存于CharBuffer1 或CharBuffer2
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 特征缓冲区号
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/

        [DllImport("fplib.dll")]
        public extern int FpGenChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpMatch(FP_HANDLE fpHandle, uint16_t *pScore, uint32_t timeout)
* 函数功能: 精确比对CharBuffer1 与CharBuffer2 中的特征文件
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 比对得分
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/

        [DllImport("fplib.dll")]
        public extern int FpMatch(FP_HANDLE fpHandle, ref uint16_t pScore, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpSearch(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nStartPage, uint16_t nPageNum, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout)
* 函数功能: 以CharBuffer1或CharBuffer2中的特征文件搜索指定指纹库
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 特征缓冲区号
* 输入参数: 搜索起始页
* 输入参数: 搜索页数
* 输入参数: 匹配页码
* 输入参数: 比对得分
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/

        [DllImport("fplib.dll")]
        public extern int FpSearch(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nStartPage, uint16_t nPageNum,
            ref uint16_t pPageId, ref uint16_t pScore, uint32_t timeout);


/***********************************************************************************************************
* 函数名称: int FpRegModel(FP_HANDLE fpHandle, uint32_t timeout)
* 函数功能: 将CharBuffer1与CharBuffer2中的特征文件合并生成模板，结果存于CharBuffer1与CharBuffer2
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/

        [DllImport("fplib.dll")]
        public extern int FpRegModel(FP_HANDLE fpHandle, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpStoreChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout)
* 函数功能: 将CharBuffer1或CharBuffer2中的模板文件存到PageId号Flash 数据库位置
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 特征缓冲区号
* 输入参数: 指纹库位置号
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/

        [DllImport("fplib.dll")]
        public extern int FpStoreChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpLoadChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout)
* 函数功能: 将Flash数据库中指定ID号的指纹模板读入到模板缓冲区CharBuffer1或 CharBuffer2
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 特征缓冲区号
* 输入参数: 指纹库位置号
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/

        [DllImport("fplib.dll")]
        public extern int FpLoadChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpValidTempleteNum(FP_HANDLE fpHandle, uint16_t *pNum, uint32_t timeout)
* 函数功能: 读有效模板个数
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 模板个数
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/

        [DllImport("fplib.dll")]
        public extern int FpValidTempleteNum(FP_HANDLE fpHandle, ref uint16_t pNum, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpUpBMPFile(FP_HANDLE fpHandle, const char *pFile, uint32_t timeout)
* 函数功能: 将设备缓冲区中的原始图像转化为BMP图像后上传给上位机并保存为文件
* 输入参数: 设备句柄
* 输入参数: 文件名称
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/

        [DllImport("fplib.dll")]
        public extern int FpUpBMPFile(FP_HANDLE fpHandle, string pFile, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpEmpty(FP_HANDLE fpHandle, uint32_t timeout)
* 函数功能: 删除Flash 数据库中所有指纹模板
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
        public extern int FpEmpty(FP_HANDLE fpHandle, uint32_t timeout);

    }
}
