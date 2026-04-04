using WinformAppDemo.Utils.Configs;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformAppDemo.HardwareAccess
{
    /// <summary>
    /// 串口设备链接帮助类
    /// </summary>
    internal static class SerialPortConnectionHelper
    {
        /// <summary>
        /// 获取串口设备通讯对象
        /// </summary>
        /// <param name="serialPortConfig"></param>
        /// <returns></returns>
        public static SerialPort GetSerialPortConnection(SerialPortConfig serialPortConfig)
        {
            SerialPort serialPort = new SerialPort
            {
                PortName = serialPortConfig.PortName,
                BaudRate = serialPortConfig.BaudRate,
                DataBits = serialPortConfig.DataBits,
                Parity = serialPortConfig.Parity,
                StopBits = serialPortConfig.StopBits
            };
            serialPort.Open();
            return serialPort;
        }
    }
}
