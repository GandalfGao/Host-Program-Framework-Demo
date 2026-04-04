using WinformAppDemo.Utils.Configs;
using HslCommunication.Profinet.Siemens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WinformAppDemo.Utils.ConfigReaders
{
    /// <summary>
    /// plc配置读取器
    /// </summary>
    internal static class PlcConfigReader
    {
        /// <summary>
        /// 读取配置文件中的plcConfig节点
        /// </summary>
        /// <param name="plcConfigNode"></param>
        /// <returns></returns>
        public static PlcConfig Read(XmlNode plcConfigNode)
        {
            var plcConfig = new PlcConfig();

            // 获取plc设备配置节点
            var plcEquipNode = plcConfigNode.SelectSingleNode("plcEquip");
            if (plcEquipNode == null)
            {
                throw new ArgumentNullException(nameof(plcEquipNode), "配置错误, plcEquip节点不可以为空！");
            }
            plcConfig.PlcEquip = PlcEquipReader.Read(plcEquipNode);

            // 获取plc地址配置节点
            var plcAddrsNode = plcConfigNode.SelectSingleNode("plcAddrs");
            if (plcAddrsNode == null)
            {
                throw new ArgumentNullException(nameof(plcAddrsNode), "配置错误, addrs节点不可以为空！");
            }
            plcConfig.PlcAddrs = PlcAddrsReader.Read(plcAddrsNode);

            return plcConfig;
        }
    }

    /// <summary>
    /// plc设备配置读取器
    /// </summary>
    internal static class PlcEquipReader
    {
        /// <summary>
        /// 读取配置文件中的plcEquip节点
        /// </summary>
        /// <param name="plcEquipNode"></param>
        /// <returns></returns>
        public static PlcEquip Read(XmlNode plcEquipNode)
        {
            var plcEquip = new PlcEquip();

            // 获取plc设备类型属性
            var typeAttr = plcEquipNode.Attributes["type"];
            if (typeAttr == null)
            {
                throw new ArgumentNullException(nameof(typeAttr), "配置错误, plcEquip节点的type属性不可以为空！");
            }
            if (!int.TryParse(typeAttr.Value, out int plcType))
            {
                throw new ArgumentException($"配置错误, plcEquip节点的type属性值格式不正确！type属性值: {typeAttr.Value}", nameof(typeAttr));
            }
            if (!Enum.IsDefined(typeof(SiemensPLCS), plcType))
            {
                throw new ArgumentOutOfRangeException(nameof(typeAttr), $"配置错误, plcEquip节点的type属性值不在{nameof(SiemensPLCS)}枚举的正常范围内！type属性值: {typeAttr.Value}");
            }
            plcEquip.Type = (SiemensPLCS)plcType;

            // 获取plc设备ip属性
            var ipAttr = plcEquipNode.Attributes["ip"];
            if (ipAttr == null || string.IsNullOrEmpty(ipAttr.Value))
            {
                throw new ArgumentNullException(nameof(ipAttr), "配置错误, plcEquip节点的ip属性不可以为空！");
            }
            plcEquip.Ip = ipAttr.Value;

            // 获取plc设备端口属性
            var portAttr = plcEquipNode.Attributes["port"];
            if (portAttr != null && !string.IsNullOrEmpty(portAttr.Value))
            {
                if (!int.TryParse(portAttr.Value, out int port))
                {
                    throw new ArgumentException($"配置错误, plcEquip节点的port属性值格式不正确！port属性值: {portAttr.Value}", nameof(portAttr));
                }
                plcEquip.Port = port;
            }

            // 获取plc设备槽号属性
            var slotAttr = plcEquipNode.Attributes["slot"];
            if (slotAttr != null && !string.IsNullOrEmpty(slotAttr.Value))
            {
                if (!byte.TryParse(slotAttr.Value, out byte slot))
                {
                    throw new ArgumentException($"配置错误, plcEquip节点的slot属性值格式不正确！slot属性值: {portAttr.Value}", nameof(portAttr));
                }
                plcEquip.Slot = slot;
            }

            // 获取plc设备机架号属性
            var rackAttr = plcEquipNode.Attributes["rack"];
            if (rackAttr != null && !string.IsNullOrEmpty(rackAttr.Value))
            {
                if (!byte.TryParse(rackAttr.Value, out byte rack))
                {
                    throw new ArgumentException($"配置错误, plcEquip节点的rack属性值格式不正确！rack属性值: {rackAttr.Value}", nameof(rackAttr));
                }
                plcEquip.Rack = rack;
            }

            return plcEquip;
        }
    }

    /// <summary>
    /// plc地址配置读取器
    /// </summary>
    internal static class PlcAddrsReader
    {
        /// <summary>
        /// 读取配置文件中的plcAddrs节点, 将plc地址配置转换为字典对象返回, 键为地址名称, 值为地址字符串
        /// </summary>
        /// <param name="plcAddrsNode"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Read(XmlNode plcAddrsNode)
        {
            using (var childNodes = plcAddrsNode.ChildNodes)
            {
                if (childNodes.Count == 0)
                {
                    throw new ArgumentNullException(nameof(plcAddrsNode), "配置错误, plcAddrs节点下的子节点集合不可以为空！");
                }

                var dic = new Dictionary<string, string>();

                for (int i = 0; i < childNodes.Count; i++)
                {
                    var childNode = childNodes[i];
                    if (childNode.NodeType == XmlNodeType.Element)
                    {
                        if (string.IsNullOrEmpty(childNode.InnerText))
                        {
                            throw new ArgumentNullException(childNode.Name, $"配置错误, {childNode.Name}节点的值不可以为空！");
                        }
                        dic.Add(childNode.Name, childNode.InnerText);
                    }
                }

                return dic;
            }
        }
    }
}
