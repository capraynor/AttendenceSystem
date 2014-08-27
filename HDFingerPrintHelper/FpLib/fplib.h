#ifndef __FPDRIVE_H__
#define __FPDRIVE_H__

#ifdef __cplusplus
extern "C" {
#endif

#define FP_OK                    0x00
#define FP_COMM_ERR              0x01
#define FP_NO_FINGER             0x02
#define FP_GET_IMG_ERR           0x03
#define FP_FP_TOO_DRY            0x04
#define FP_FP_TOO_WET            0x05
#define FP_FP_DISORDER           0x06
#define FP_LITTLE_FEATURE        0x07
#define FP_NOT_MATCH             0x08
#define FP_NOT_SEARCHED          0x09
#define FP_MERGE_ERR             0x0a
#define FP_ADDRESS_OVER          0x0b
#define FP_READ_ERR              0x0c
#define FP_UP_TEMP_ERR           0x0d
#define FP_RECV_ERR              0x0e
#define FP_UP_IMG_ERR            0x0f
#define FP_DEL_TEMP_ERR          0x10
#define FP_CLEAR_TEMP_ERR        0x11
#define FP_SLEEP_ERR             0x12
#define FP_INVALID_PASSWORD      0x13
#define FP_RESET_ERR             0x14
#define FP_INVALID_IMAGE         0x15
#define FP_HANGOVER_UNREMOVE     0X17
#define FP_PARAM_ERR             0x7E
#define FP_RIGHT_ERR             0x7F
#define FP_POWER_LOW             0x80
#define FP_ERROR_OPEN            0x0102
#define FP_ERROR_RIGHT           0x0103
#define FP_ERROR_ADDRESS         0x0108
#define FP_ERROR_ACK             0x0301
#define FP_ERROR_ENCODE          0x0302
#define FP_ERROR_BUFFER          0x0303
#define FP_ERROR_OPENFILE        0x0304  
#define FP_ERROR_FILEOPEN        0x0304
#define FP_ERROR_MALLOC          0x0305
#define FP_ERROR_HANDLE          0x0306    
#define FP_ERROR_FILEREAD        0x0307
#define FP_ERROR_FILEWRITE       0x0308
#define FP_ERROR_ISOCHAR         0x0309

#define ISO_V20                  2
#define ISO_V30                  3

#define FINGER_UNKNOWN           0
#define FINGER_RIGHT_THUMB       1
#define FINGER_RIGHT_INDEX       2
#define FINGER_RIGHT_MIDDLE      3
#define FINGER_RIGHT_RING        4
#define FINGER_RIGHT_LITTLE      5
#define FINGER_LEFT_THUMB        6
#define FINGER_LEFT_INDEX        7
#define FINGER_LEFT_MIDDLE       8
#define FINGER_LEFT_RING         9
#define FINGER_LEFT_LITTLE       10

typedef void* FP_HANDLE;
typedef char  int8_t;
typedef short int16_t;
typedef long  int32_t;
typedef unsigned char  uint8_t;
typedef unsigned short uint16_t;
typedef unsigned long  uint32_t;


/***********************************************************************************************************
* 函数名称: uint32_t FpGetVersion(void)
* 函数功能: 获取开发包版本
* 输入参数: 无
* 返回参数: 版本号【如110表示版本号1.1.0，而1010则表示版本号10.1.0】
***********************************************************************************************************/
uint32_t WINAPI FpGetVersion(void);

/***********************************************************************************************************
* 函数名称: FP_HANDLE FpOpenUsb(uint32_t nAddr, uint32_t timeout);
* 函数功能: 打开USB驱动
* 输入参数: 芯片地址
* 输入参数: 等候时间
* 返回参数: 失败为0, 否则为设备句柄
***********************************************************************************************************/
FP_HANDLE WINAPI FpOpenUsb(uint32_t addr, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpCloseUsb(FP_HANDLE fpHandle);
* 函数功能: 关闭USB驱动
* 输入参数: 设备句柄, FpOpenUsb()或FpOpenUsbEx()的返回值
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpCloseUsb(FP_HANDLE fpHandle);

/***********************************************************************************************************
* 函数名称: int FpGetVerId(FP_HANDLE fpHandle, uint16_t *pVerId);
* 函数功能: 读取设备的版本号
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 版本号地址, 输出版本号如0x2011表示2.0.11
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpGetVerId(FP_HANDLE fpHandle, uint16_t *pVerId);

/***********************************************************************************************************
* 函数名称: int FpLastError();
* 函数功能: 读最后错误代码,
* 返回参数: FpOpenUsb()或 FpOpenUsbEx()或FpOpenAudio()的错误结果
***********************************************************************************************************/
int WINAPI FpLastError(void);

/***********************************************************************************************************
* 函数名称: int FpGetImage(FP_HANDLE fpHandle, uint32_t timeout)
* 函数功能: 探测手指，探测到后录入指纹图像存于ImageBuffer
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpGetImage(FP_HANDLE fpHandle, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpGenChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint32_t timeout)
* 函数功能: 将ImageBuffer 中的原始图像生成指纹特征文件存于CharBuffer1 或CharBuffer2
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 特征缓冲区号
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpGenChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpMatch(FP_HANDLE fpHandle, uint16_t *pScore, uint32_t timeout)
* 函数功能: 精确比对CharBuffer1 与CharBuffer2 中的特征文件
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 比对得分
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpMatch(FP_HANDLE fpHandle, uint16_t *pScore, uint32_t timeout);

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
int WINAPI FpSearch(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nStartPage, uint16_t nPageNum, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpRegModel(FP_HANDLE fpHandle, uint32_t timeout)
* 函数功能: 将CharBuffer1与CharBuffer2中的特征文件合并生成模板，结果存于CharBuffer1与CharBuffer2
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpRegModel(FP_HANDLE fpHandle, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpStoreChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout)
* 函数功能: 将CharBuffer1或CharBuffer2中的模板文件存到PageId号Flash 数据库位置
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 特征缓冲区号
* 输入参数: 指纹库位置号
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpStoreChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpLoadChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout)
* 函数功能: 将Flash数据库中指定ID号的指纹模板读入到模板缓冲区CharBuffer1或 CharBuffer2
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 特征缓冲区号
* 输入参数: 指纹库位置号
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpLoadChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpUpChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* 函数功能: 将特征缓冲区中的特征文件上传给上位机
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 特征缓冲区号
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小
* 输入参数: 实际大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpUpChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpUpCharFile(FP_HANDLE fpHandle, uint8_t nBufferId, const char *pFile, uint32_t timeout)
* 函数功能: 将设备缓冲区中的指纹模板上传给上位机并保存为文件
* 输入参数: 设备句柄
* 输入参数: 特征缓冲区号
* 输入参数: 文件名称
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpUpCharFile(FP_HANDLE fpHandle, uint8_t nBufferId, const char *pFile, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpUpCharISO30(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t nVer, uint8_t nFinger, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* 函数功能: 将设备缓冲区中的指纹模板上传给上位机并转为ISO30模板
* 输入参数: 设备句柄
* 输入参数: 特征缓冲区号
* 输入参数: 版本号
* 输入参数: 手指位置
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小
* 输出参数: 实际大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpUpCharISO(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t nVer, uint8_t nFinger, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int LIBFP_CALL FpUpCharFileISO30(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t nFinger, uint8_t nVer, const char *pFile, uint32_t timeout)
* 函数功能: 将设备缓冲区中的指纹模板上传给上位机并保存为ISO30模板文件
* 输入参数: 设备句柄
* 输入参数: 特征缓冲区号
* 输入参数: 版本号
* 输入参数: 手指位置
* 输入参数: 文件名称
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpUpCharFileISO(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t nVer, uint8_t nFinger, const char *pFile, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpDownChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t *pBuf, int nBufSize, uint32_t timeout)
* 函数功能: 上位机下载特征文件到模块的一个特征缓冲区
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 特征缓冲区号
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpDownChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpDownCharFile(FP_HANDLE fpHandle, uint8_t nBufferId, const char *pFile, uint32_t timeout)
* 函数功能: 从上位机下载指纹模板文件到设备缓冲区
* 输入参数: 设备句柄
* 输入参数: 特征缓冲区号
* 输入参数: 文件名称
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpDownCharFile(FP_HANDLE fpHandle, uint8_t nBufferId, const char *pFile, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpUpImage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* 函数功能: 将图像缓冲区中的数据上传给上位机
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小
* 输入参数: 实际大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpUpImage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpUpBMP(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* 函数功能: 将图像缓冲区中的数据转换为BMP上传给上位机
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小
* 输入参数: 实际大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpUpBMP(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpUpBMPFile(FP_HANDLE fpHandle, const char *pFile, uint32_t timeout)
* 函数功能: 将设备缓冲区中的原始图像转化为BMP图像后上传给上位机并保存为文件
* 输入参数: 设备句柄
* 输入参数: 文件名称
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpUpBMPFile(FP_HANDLE fpHandle, const char *pFile, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpDownImage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout)
* 函数功能: 将图像缓冲区中的数据下载到设备
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpDownImage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpDownBMP(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout)
* 函数功能: 下载BMP图像到设备缓冲区
* 输入参数: 设备句柄
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpDownBMP(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpDownBMPFile(FP_HANDLE fpHandle, const char *pFile, uint32_t timeout)
* 函数功能: 下载BMP图像文件到设备缓冲区
* 输入参数: 设备句柄
* 输入参数: BMP图像文件名
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpDownBMPFile(FP_HANDLE fpHandle, const char *pFile, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpDeletChar(FP_HANDLE fpHandle, uint16_t nStartPage, uint16_t nPageNum, uint32_t timeout)
* 函数功能: 删除Flash数据库中指定ID号开始的N个指纹模板
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 特征缓冲区号
* 输入参数: 搜索起始页
* 输入参数: 搜索页数
* 输入参数: 匹配页码
* 输入参数: 比对得分
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpDeletChar(FP_HANDLE fpHandle, uint16_t nStartPage, uint16_t nPageNum, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpEmpty(FP_HANDLE fpHandle, uint32_t timeout)
* 函数功能: 删除Flash 数据库中所有指纹模板
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpEmpty(FP_HANDLE fpHandle, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpWriteReg(FP_HANDLE fpHandle, uint8_t nReg, uint8_t nValue, uint32_t timeout)
* 函数功能: 写模块寄存器
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 寄存器地址
* 输入参数: 寄存器数值
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpWriteReg(FP_HANDLE fpHandle, uint8_t nReg, uint8_t nValue, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpReadSysParam(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* 函数功能: 读取模块的基本参数,固定16字节
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小
* 输入参数: 实际大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpReadSysParam(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpEnroll(FP_HANDLE fpHandle, uint16_t *pPageId, uint32_t timeout)
* 函数功能: 采集一次指纹注册模板，在指纹库中搜索空位并存储，返回存储ID
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 存储页码
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpEnroll(FP_HANDLE fpHandle, uint16_t *pPageId, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpIdentify(FP_HANDLE fpHandle, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout)
* 函数功能: 自动采集指纹，在指纹库中搜索目标模板并返回搜索结果
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 存储页码
* 输入参数: 比对得分
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpIdentify(FP_HANDLE fpHandle, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpSetPwd(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout)
* 函数功能: 设置模块握手口令
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 密码缓冲区地址
* 输入参数: 密码缓冲区大小,要求为4
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpSetPwd(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpVfyPwd(FP_HANDLE fpHandle, uint8_t *pBuf, uint8_t nBufSize, uint32_t timeout)
* 函数功能: 验证模块握手口令
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 密码缓冲区地址
* 输入参数: 密码缓冲区大小,要求为4
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpVfyPwd(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpGetRandom(FP_HANDLE fpHandle, uint32_t *pRandom, uint32_t timeout)
* 函数功能: 令芯片生成一个随机数并返回给上位机
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 随机数地址
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpGetRandom(FP_HANDLE fpHandle, uint32_t *pRandom, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpSetChipAddr(FP_HANDLE fpHandle, uint32_t nChip, uint32_t timeout)
* 函数功能: 设置芯片地址
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 新芯片地址
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpSetChipAddr(FP_HANDLE fpHandle, uint32_t nChip, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpReadInfPage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* 函数功能: 写32字节数据到Flash用户区
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小
* 输入参数: 实际大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpReadInfPage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpWriteNotepad(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, uint32_t timeout)
* 函数功能: 写32字节数据到Flash用户区
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 用户区页码
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpWriteNotepad(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpReadNotepad(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* 函数功能: 从FLASH用户区读取32字节数据
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 用户区页码
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小
* 输入参数: 实际大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpReadNotepad(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpHighSpeedSearch(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nStartPage, uint16_t nPageNum, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout)
* 函数功能: 以CharBuffer1或CharBuffer2中的特征文件高速搜索指定指纹库
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 特征缓冲区号
* 输入参数: 搜索起始页
* 输入参数: 搜索页数
* 输入参数: 匹配页码
* 输入参数: 比对得分
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpHighSpeedSearch(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nStartPage, uint16_t nPageNum, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpGenChar(FP_HANDLE fpHandle, uint8_t nBinType, uint32_t timeout)
* 函数功能: 对图像缓冲区中的指纹图像进行处理并生成细化指纹图像
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 细化类型
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpGenBinImage(FP_HANDLE fpHandle, uint8_t nBinType, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpValidTempleteNum(FP_HANDLE fpHandle, uint16_t *pNum, uint32_t timeout)
* 函数功能: 读有效模板个数
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 模板个数
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpValidTempleteNum(FP_HANDLE fpHandle, uint16_t *pNum, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpReadIndexTable(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* 函数功能: 读取录入模版的索引表
* 输入参数: 设备句柄
* 输入参数: 索引表页码, 0-3分别对应模板索引0-1023
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小, 32字节，其中每位代表一个模板，1表示已录入，0表示未录入
* 输入参数: 实际大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpReadIndexTable(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpGetChipSN(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* 函数功能: 读设备序列号
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输入参数: 缓冲区地址
* 输入参数: 缓冲区大小,要求为8
* 输入参数: 实际大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpGetChipSN(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpGetImageSize(FP_HANDLE fpHandle, uint16_t *pWidth, uint16_t *pHigh, uint32_t *pBmpSize, uint32_t timeout)
* 函数功能: 获取图像大小
* 输入参数: 设备句柄, FpOpenUsb()的返回值
* 输出参数: 图像宽度
* 输出参数: 图像高度
* 输出参数: 位图大小
* 输入参数: 等候时间
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpGetImageSize(FP_HANDLE fpHandle, uint16_t *pWidth, uint16_t *pHigh, uint32_t *pBmpSize, uint32_t timeout);

/***********************************************************************************************************
* 函数名称: int FpImgToBMP(const uint8_t *pImg, int nImgSize, uint16_t nWidth, uint16_t nHigh， uint8_t *pBmp, int nBmpSize, int *pBytesReturned)
* 函数功能: 根据图像数据创建BMP
* 输入参数: 数据缓冲区地址
* 输入参数: 数据缓冲区大小
* 输入参数: 图像宽度
* 输入参数: 图像高度
* 输入参数: 位图缓冲区地址
* 输入参数: 位图缓冲区大小
* 输入参数: 实际大小
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpImgToBMP(const uint8_t *pImg, int nImgSize, uint16_t nWidth, uint16_t nHigh, uint8_t *pBmp, int nBmpSize, int *pBytesReturned);

/***********************************************************************************************************
* 函数名称: int FpMakeBMP(const uint8_t *pFile, uint8_t *pBuf, int nSize, uint16_t nWidth, uint16_t nHigh);
* 函数功能: 根据图像数据创建BMP
* 输入参数: 文件名缓冲区地址
* 输入参数: 图像缓冲区地址
* 输入参数: 图像缓冲区大小
* 输入参数: 图像宽度
* 输入参数: 图像高度
* 返回参数: 执行结果
***********************************************************************************************************/
int WINAPI FpMakeBMP(const char *pFile, uint8_t *pBuf, int nSize, uint16_t nWidth, uint16_t nHigh);

#ifdef __cplusplus
}
#endif

#endif
