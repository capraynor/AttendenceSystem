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
* ��������: uint32_t FpGetVersion(void)
* ��������: ��ȡ�������汾
* �������: ��
* ���ز���: �汾�š���110��ʾ�汾��1.1.0����1010���ʾ�汾��10.1.0��
***********************************************************************************************************/
uint32_t WINAPI FpGetVersion(void);

/***********************************************************************************************************
* ��������: FP_HANDLE FpOpenUsb(uint32_t nAddr, uint32_t timeout);
* ��������: ��USB����
* �������: оƬ��ַ
* �������: �Ⱥ�ʱ��
* ���ز���: ʧ��Ϊ0, ����Ϊ�豸���
***********************************************************************************************************/
FP_HANDLE WINAPI FpOpenUsb(uint32_t addr, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpCloseUsb(FP_HANDLE fpHandle);
* ��������: �ر�USB����
* �������: �豸���, FpOpenUsb()��FpOpenUsbEx()�ķ���ֵ
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpCloseUsb(FP_HANDLE fpHandle);

/***********************************************************************************************************
* ��������: int FpGetVerId(FP_HANDLE fpHandle, uint16_t *pVerId);
* ��������: ��ȡ�豸�İ汾��
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: �汾�ŵ�ַ, ����汾����0x2011��ʾ2.0.11
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpGetVerId(FP_HANDLE fpHandle, uint16_t *pVerId);

/***********************************************************************************************************
* ��������: int FpLastError();
* ��������: �����������,
* ���ز���: FpOpenUsb()�� FpOpenUsbEx()��FpOpenAudio()�Ĵ�����
***********************************************************************************************************/
int WINAPI FpLastError(void);

/***********************************************************************************************************
* ��������: int FpGetImage(FP_HANDLE fpHandle, uint32_t timeout)
* ��������: ̽����ָ��̽�⵽��¼��ָ��ͼ�����ImageBuffer
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpGetImage(FP_HANDLE fpHandle, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpGenChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint32_t timeout)
* ��������: ��ImageBuffer �е�ԭʼͼ������ָ�������ļ�����CharBuffer1 ��CharBuffer2
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ������������
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpGenChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpMatch(FP_HANDLE fpHandle, uint16_t *pScore, uint32_t timeout)
* ��������: ��ȷ�ȶ�CharBuffer1 ��CharBuffer2 �е������ļ�
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: �ȶԵ÷�
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpMatch(FP_HANDLE fpHandle, uint16_t *pScore, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpSearch(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nStartPage, uint16_t nPageNum, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout)
* ��������: ��CharBuffer1��CharBuffer2�е������ļ�����ָ��ָ�ƿ�
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ������������
* �������: ������ʼҳ
* �������: ����ҳ��
* �������: ƥ��ҳ��
* �������: �ȶԵ÷�
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpSearch(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nStartPage, uint16_t nPageNum, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpRegModel(FP_HANDLE fpHandle, uint32_t timeout)
* ��������: ��CharBuffer1��CharBuffer2�е������ļ��ϲ�����ģ�壬�������CharBuffer1��CharBuffer2
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpRegModel(FP_HANDLE fpHandle, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpStoreChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout)
* ��������: ��CharBuffer1��CharBuffer2�е�ģ���ļ��浽PageId��Flash ���ݿ�λ��
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ������������
* �������: ָ�ƿ�λ�ú�
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpStoreChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpLoadChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout)
* ��������: ��Flash���ݿ���ָ��ID�ŵ�ָ��ģ����뵽ģ�建����CharBuffer1�� CharBuffer2
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ������������
* �������: ָ�ƿ�λ�ú�
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpLoadChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nPageId, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpUpChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* ��������: �������������е������ļ��ϴ�����λ��
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ������������
* �������: ��������ַ
* �������: ��������С
* �������: ʵ�ʴ�С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpUpChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpUpCharFile(FP_HANDLE fpHandle, uint8_t nBufferId, const char *pFile, uint32_t timeout)
* ��������: ���豸�������е�ָ��ģ���ϴ�����λ��������Ϊ�ļ�
* �������: �豸���
* �������: ������������
* �������: �ļ�����
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpUpCharFile(FP_HANDLE fpHandle, uint8_t nBufferId, const char *pFile, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpUpCharISO30(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t nVer, uint8_t nFinger, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* ��������: ���豸�������е�ָ��ģ���ϴ�����λ����תΪISO30ģ��
* �������: �豸���
* �������: ������������
* �������: �汾��
* �������: ��ָλ��
* �������: ��������ַ
* �������: ��������С
* �������: ʵ�ʴ�С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpUpCharISO(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t nVer, uint8_t nFinger, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* ��������: int LIBFP_CALL FpUpCharFileISO30(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t nFinger, uint8_t nVer, const char *pFile, uint32_t timeout)
* ��������: ���豸�������е�ָ��ģ���ϴ�����λ��������ΪISO30ģ���ļ�
* �������: �豸���
* �������: ������������
* �������: �汾��
* �������: ��ָλ��
* �������: �ļ�����
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpUpCharFileISO(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t nVer, uint8_t nFinger, const char *pFile, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpDownChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t *pBuf, int nBufSize, uint32_t timeout)
* ��������: ��λ�����������ļ���ģ���һ������������
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ������������
* �������: ��������ַ
* �������: ��������С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpDownChar(FP_HANDLE fpHandle, uint8_t nBufferId, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpDownCharFile(FP_HANDLE fpHandle, uint8_t nBufferId, const char *pFile, uint32_t timeout)
* ��������: ����λ������ָ��ģ���ļ����豸������
* �������: �豸���
* �������: ������������
* �������: �ļ�����
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpDownCharFile(FP_HANDLE fpHandle, uint8_t nBufferId, const char *pFile, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpUpImage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* ��������: ��ͼ�񻺳����е������ϴ�����λ��
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ��������ַ
* �������: ��������С
* �������: ʵ�ʴ�С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpUpImage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpUpBMP(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* ��������: ��ͼ�񻺳����е�����ת��ΪBMP�ϴ�����λ��
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ��������ַ
* �������: ��������С
* �������: ʵ�ʴ�С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpUpBMP(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpUpBMPFile(FP_HANDLE fpHandle, const char *pFile, uint32_t timeout)
* ��������: ���豸�������е�ԭʼͼ��ת��ΪBMPͼ����ϴ�����λ��������Ϊ�ļ�
* �������: �豸���
* �������: �ļ�����
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpUpBMPFile(FP_HANDLE fpHandle, const char *pFile, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpDownImage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout)
* ��������: ��ͼ�񻺳����е��������ص��豸
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ��������ַ
* �������: ��������С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpDownImage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpDownBMP(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout)
* ��������: ����BMPͼ���豸������
* �������: �豸���
* �������: ��������ַ
* �������: ��������С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpDownBMP(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpDownBMPFile(FP_HANDLE fpHandle, const char *pFile, uint32_t timeout)
* ��������: ����BMPͼ���ļ����豸������
* �������: �豸���
* �������: BMPͼ���ļ���
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpDownBMPFile(FP_HANDLE fpHandle, const char *pFile, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpDeletChar(FP_HANDLE fpHandle, uint16_t nStartPage, uint16_t nPageNum, uint32_t timeout)
* ��������: ɾ��Flash���ݿ���ָ��ID�ſ�ʼ��N��ָ��ģ��
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ������������
* �������: ������ʼҳ
* �������: ����ҳ��
* �������: ƥ��ҳ��
* �������: �ȶԵ÷�
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpDeletChar(FP_HANDLE fpHandle, uint16_t nStartPage, uint16_t nPageNum, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpEmpty(FP_HANDLE fpHandle, uint32_t timeout)
* ��������: ɾ��Flash ���ݿ�������ָ��ģ��
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpEmpty(FP_HANDLE fpHandle, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpWriteReg(FP_HANDLE fpHandle, uint8_t nReg, uint8_t nValue, uint32_t timeout)
* ��������: дģ��Ĵ���
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: �Ĵ�����ַ
* �������: �Ĵ�����ֵ
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpWriteReg(FP_HANDLE fpHandle, uint8_t nReg, uint8_t nValue, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpReadSysParam(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* ��������: ��ȡģ��Ļ�������,�̶�16�ֽ�
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ��������ַ
* �������: ��������С
* �������: ʵ�ʴ�С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpReadSysParam(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpEnroll(FP_HANDLE fpHandle, uint16_t *pPageId, uint32_t timeout)
* ��������: �ɼ�һ��ָ��ע��ģ�壬��ָ�ƿ���������λ���洢�����ش洢ID
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: �洢ҳ��
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpEnroll(FP_HANDLE fpHandle, uint16_t *pPageId, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpIdentify(FP_HANDLE fpHandle, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout)
* ��������: �Զ��ɼ�ָ�ƣ���ָ�ƿ�������Ŀ��ģ�岢�����������
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: �洢ҳ��
* �������: �ȶԵ÷�
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpIdentify(FP_HANDLE fpHandle, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpSetPwd(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout)
* ��������: ����ģ�����ֿ���
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ���뻺������ַ
* �������: ���뻺������С,Ҫ��Ϊ4
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpSetPwd(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpVfyPwd(FP_HANDLE fpHandle, uint8_t *pBuf, uint8_t nBufSize, uint32_t timeout)
* ��������: ��֤ģ�����ֿ���
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ���뻺������ַ
* �������: ���뻺������С,Ҫ��Ϊ4
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpVfyPwd(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpGetRandom(FP_HANDLE fpHandle, uint32_t *pRandom, uint32_t timeout)
* ��������: ��оƬ����һ������������ظ���λ��
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: �������ַ
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpGetRandom(FP_HANDLE fpHandle, uint32_t *pRandom, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpSetChipAddr(FP_HANDLE fpHandle, uint32_t nChip, uint32_t timeout)
* ��������: ����оƬ��ַ
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ��оƬ��ַ
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpSetChipAddr(FP_HANDLE fpHandle, uint32_t nChip, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpReadInfPage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* ��������: д32�ֽ����ݵ�Flash�û���
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ��������ַ
* �������: ��������С
* �������: ʵ�ʴ�С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpReadInfPage(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpWriteNotepad(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, uint32_t timeout)
* ��������: д32�ֽ����ݵ�Flash�û���
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: �û���ҳ��
* �������: ��������ַ
* �������: ��������С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpWriteNotepad(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpReadNotepad(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* ��������: ��FLASH�û�����ȡ32�ֽ�����
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: �û���ҳ��
* �������: ��������ַ
* �������: ��������С
* �������: ʵ�ʴ�С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpReadNotepad(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpHighSpeedSearch(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nStartPage, uint16_t nPageNum, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout)
* ��������: ��CharBuffer1��CharBuffer2�е������ļ���������ָ��ָ�ƿ�
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ������������
* �������: ������ʼҳ
* �������: ����ҳ��
* �������: ƥ��ҳ��
* �������: �ȶԵ÷�
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpHighSpeedSearch(FP_HANDLE fpHandle, uint8_t nBufferId, uint16_t nStartPage, uint16_t nPageNum, uint16_t *pPageId, uint16_t *pScore, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpGenChar(FP_HANDLE fpHandle, uint8_t nBinType, uint32_t timeout)
* ��������: ��ͼ�񻺳����е�ָ��ͼ����д�������ϸ��ָ��ͼ��
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ϸ������
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpGenBinImage(FP_HANDLE fpHandle, uint8_t nBinType, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpValidTempleteNum(FP_HANDLE fpHandle, uint16_t *pNum, uint32_t timeout)
* ��������: ����Чģ�����
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ģ�����
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpValidTempleteNum(FP_HANDLE fpHandle, uint16_t *pNum, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpReadIndexTable(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* ��������: ��ȡ¼��ģ���������
* �������: �豸���
* �������: ������ҳ��, 0-3�ֱ��Ӧģ������0-1023
* �������: ��������ַ
* �������: ��������С, 32�ֽڣ�����ÿλ����һ��ģ�壬1��ʾ��¼�룬0��ʾδ¼��
* �������: ʵ�ʴ�С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpReadIndexTable(FP_HANDLE fpHandle, uint8_t nPageId, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpGetChipSN(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout)
* ��������: ���豸���к�
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ��������ַ
* �������: ��������С,Ҫ��Ϊ8
* �������: ʵ�ʴ�С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpGetChipSN(FP_HANDLE fpHandle, uint8_t *pBuf, int nBufSize, int *pBytesReturned, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpGetImageSize(FP_HANDLE fpHandle, uint16_t *pWidth, uint16_t *pHigh, uint32_t *pBmpSize, uint32_t timeout)
* ��������: ��ȡͼ���С
* �������: �豸���, FpOpenUsb()�ķ���ֵ
* �������: ͼ����
* �������: ͼ��߶�
* �������: λͼ��С
* �������: �Ⱥ�ʱ��
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpGetImageSize(FP_HANDLE fpHandle, uint16_t *pWidth, uint16_t *pHigh, uint32_t *pBmpSize, uint32_t timeout);

/***********************************************************************************************************
* ��������: int FpImgToBMP(const uint8_t *pImg, int nImgSize, uint16_t nWidth, uint16_t nHigh�� uint8_t *pBmp, int nBmpSize, int *pBytesReturned)
* ��������: ����ͼ�����ݴ���BMP
* �������: ���ݻ�������ַ
* �������: ���ݻ�������С
* �������: ͼ����
* �������: ͼ��߶�
* �������: λͼ��������ַ
* �������: λͼ��������С
* �������: ʵ�ʴ�С
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpImgToBMP(const uint8_t *pImg, int nImgSize, uint16_t nWidth, uint16_t nHigh, uint8_t *pBmp, int nBmpSize, int *pBytesReturned);

/***********************************************************************************************************
* ��������: int FpMakeBMP(const uint8_t *pFile, uint8_t *pBuf, int nSize, uint16_t nWidth, uint16_t nHigh);
* ��������: ����ͼ�����ݴ���BMP
* �������: �ļ�����������ַ
* �������: ͼ�񻺳�����ַ
* �������: ͼ�񻺳�����С
* �������: ͼ����
* �������: ͼ��߶�
* ���ز���: ִ�н��
***********************************************************************************************************/
int WINAPI FpMakeBMP(const char *pFile, uint8_t *pBuf, int nSize, uint16_t nWidth, uint16_t nHigh);

#ifdef __cplusplus
}
#endif

#endif
