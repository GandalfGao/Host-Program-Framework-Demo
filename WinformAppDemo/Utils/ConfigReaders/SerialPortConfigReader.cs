using WinformAppDemo.Utils.Configs;
using HslCommunication.Profinet.Siemens;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml;

namespace WinformAppDemo.Utils.ConfigReaders
{
    /// <summary>
    /// 串口配置读取器
    /// </summary>
    internal static class SerialPortConfigReader
    {
        /// <summary>
        /// 读取配置文件中的serialPortConfig节点
        /// </summary>
        /// <param name="serialPortConfigNode"></param>
        /// <returns></returns>
        public static SerialPortConfig Read(XmlNode serialPortConfigNode)
        {
            var config = new SerialPortConfig();

            // 获取串口号
            var portNameAttr = serialPortConfigNode.Attributes["portName"];
            if (portNameAttr == null || string.IsNullOrEmpty(portNameAttr.Value))
            {
                throw new ArgumentNullException(nameof(portNameAttr), "配置错误, serialPortConfig节点的portName属性不可以为空！");
            }
            config.PortName = portNameAttr.Value;

            // 获取波特率
            var baudRateAttr = serialPortConfigNode.Attributes["baudRate"];
            if (baudRateAttr == null || string.IsNullOrEmpty(baudRateAttr.Value))
            {
                throw new ArgumentNullException(nameof(baudRateAttr), "配置错误, serialPortConfig节点的baudRate属性不可以为空！");
            }
            if (!int.TryParse(baudRateAttr.Value, out int baudRate))
            {
                throw new ArgumentException($"配置错误, serialPortConfig节点的baudRate属性值格式不正确！baudRate属性值: {baudRateAttr.Value}", nameof(baudRateAttr));
            }
            config.BaudRate = baudRate;

            // 获取校验位
            var parityAttr = serialPortConfigNode.Attributes["parity"];
            if (parityAttr == null || string.IsNullOrEmpty(parityAttr.Value))
            {
                throw new ArgumentNullException(nameof(parityAttr), "配置错误, serialPortConfig节点的parity属性不可以为空！");
            }
            if (!int.TryParse(parityAttr.Value, out int parity))
            {
                throw new ArgumentException($"配置错误, serialPortConfig节点的parity属性值格式不正确！parity属性值: {parityAttr.Value}", nameof(parityAttr));
            }
            if (!Enum.IsDefined(typeof(Parity), parity))
            {
                throw new ArgumentOutOfRangeException(nameof(parityAttr), $"配置错误, serialPortConfig节点的parity属性值不在{nameof(Parity)}枚举的正常范围内！parity属性值: {parityAttr.Value}");
            }
            config.Parity = (Parity)parity;

            // 获取数据位
            var dataBitsAttr = serialPortConfigNode.Attributes["dataBits"];
            if (dataBitsAttr == null || string.IsNullOrEmpty(dataBitsAttr.Value))
            {
                throw new ArgumentNullException(nameof(dataBitsAttr), "配置错误, serialPortConfig节点的dataBits属性不可以为空！");
            }
            if (!int.TryParse(dataBitsAttr.Value, out int dataBits))
            {
                throw new ArgumentException($"配置错误, serialPortConfig节点的dataBits属性值格式不正确！dataBits属性值: {dataBitsAttr.Value}", nameof(dataBitsAttr));
            }
            config.DataBits = dataBits;

            // 获取停止位
            var stopBitsAttr = serialPortConfigNode.Attributes["stopBits"];
            if (stopBitsAttr == null || string.IsNullOrEmpty(stopBitsAttr.Value))
            {
                throw new ArgumentNullException(nameof(stopBitsAttr), "配置错误, serialPortConfig节点的stopBits属性不可以为空！");
            }
            if (!int.TryParse(stopBitsAttr.Value, out int stopBits))
            {
                throw new ArgumentException($"配置错误, serialPortConfig节点的stopBits属性值格式不正确！stopBits属性值: {stopBitsAttr.Value}", nameof(stopBitsAttr));
            }
            if (!Enum.IsDefined(typeof(StopBits), stopBits))
            {
                throw new ArgumentOutOfRangeException(nameof(stopBitsAttr), $"配置错误, serialPortConfig节点的stopBits属性值不在{nameof(StopBits)}枚举的正常范围内！stopBits属性值: {stopBitsAttr.Value}");
            }
            config.StopBits = (StopBits)stopBits;

            return config;
        }
    }
}
