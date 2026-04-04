using HslCommunication.Profinet.Siemens;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WinformAppDemo.Utils.Configs
{
    /// <summary>
    /// 配置类
    /// </summary>
    internal class Config
    {
        /// <summary>
        /// 主线plc配置属性
        /// </summary>
        public PlcConfig MainLinePlcConfig { get; set; }

        /// <summary>
        /// 辅线Plc配置属性
        /// </summary>
        public PlcConfig DoorLinePlcConfig { get; set; }

        /// <summary>
        /// 电阻仪串口配置属性
        /// </summary>
        public SerialPortConfig OhmmeterSpConfig { get; set; }

        /// <summary>
        /// 扫码枪串口配置属性
        /// </summary>
        public SerialPortConfig ScannerSpConfig { get; set;  }
    }
}
