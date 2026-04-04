using HslCommunication.Profinet.Siemens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WinformAppDemo.Utils.Configs
{
    /// <summary>
    /// plc配置类
    /// </summary>
    internal class PlcConfig
    {
        /// <summary>
        /// plc设备配置属性
        /// </summary>
        public PlcEquip PlcEquip { get; set; }

        /// <summary>
        /// plc地址配置属性, 键为地址名称, 值为地址字符串
        /// </summary>
        public Dictionary<string, string> PlcAddrs { get; set; }
    }

    /// <summary>
    /// plc设备配置类
    /// </summary>
    internal class PlcEquip
    {
        /// <summary>
        /// plc设备类型, 设备类型的数值由开发者自行定义, 也可以与使用的第三方工具包中的plc类型枚举对应的数值一致(例如SiemensS7Net中的SiemensPLCS枚举的数值或S7netplus中的CpuType枚举的数值等)
        /// </summary>
        public SiemensPLCS Type { get; set; }

        /// <summary>
        /// plc的ip地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 端口号, 可选项, 如果不设置则使用第三方工具包中的默认端口号
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// 槽号, 可选项, 如果不设置则使用第三方工具包中的默认槽号
        /// </summary>
        public byte? Slot { get; set; }

        /// <summary>
        /// 机架号, 可选项, 如果不设置则使用第三方工具包中的默认机架号
        /// </summary>
        public byte? Rack { get; set; }
    }
}
