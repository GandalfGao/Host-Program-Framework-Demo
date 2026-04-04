using Sunny.UI;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformAppDemo.HardwareAccess;
using WinformAppDemo.Utils.Configs;

namespace WinformAppDemo.HardwareAccess.Scanners
{
    /// <summary>
    /// 扫码枪操作器类
    /// </summary>
    internal class ScannerOperator : IDisposable
    {
        /// <summary>
        /// 串口设备通讯对象字段
        /// </summary>
        private readonly SerialPort serialPort;
        /// <summary>
        /// 条码数据字符串构建器字段
        /// </summary>
        private readonly StringBuilder barcodeStrBuilder;

        public ScannerOperator(SerialPortConfig serialPortConfig)
        {
            serialPort = SerialPortConnectionHelper.GetSerialPortConnection(serialPortConfig);
            serialPort.DataReceived += OnDataReceived;

            // 依据实际扫码枪数据长度, 初始化字符串构建器容量
            barcodeStrBuilder = new StringBuilder(50);
        }

        /// <summary>
        /// 条码数据接收事件
        /// </summary>
        public event Action<string> BarcodeReceived;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 获取扫码枪扫描到的条码数据
            var barcode = serialPort.ReadExisting();
            if (barcode.EndsWith("\r\n"))
            {
                barcode = barcode.TrimEnd(new char[] { '\r', '\n' });
                barcodeStrBuilder.Append(barcode);
                BarcodeReceived?.Invoke(barcodeStrBuilder.ToString());
                // 清空字符串构建器以准备接收下一条码数据
                barcodeStrBuilder.Clear();
            }
            else
            {
                barcodeStrBuilder.Append(barcode);
            }
        }

        public void Dispose()
        {
            serialPort.DataReceived -= OnDataReceived;
            serialPort.Dispose();
        }
    }
}
