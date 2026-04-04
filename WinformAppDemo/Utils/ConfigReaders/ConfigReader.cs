using WinformAppDemo.Utils.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WinformAppDemo.Utils.ConfigReaders
{
    /// <summary>
    /// 配置文件读取器
    /// </summary>
    internal static class ConfigReader
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        public static Config Read()
        {
            try
            {
                const string file = "Config.xml";
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(file);

                //获取config根节点
                var configNode = xmlDoc.DocumentElement;

                if (configNode == null)
                {
                    throw new ArgumentNullException(nameof(configNode), "配置错误, 根节点config不可以为空！");
                }

                var config = new Config();
                var configType = config.GetType();

                using (var plcConfigNodes = configNode.SelectNodes("plcConfig"))
                {
                    if (plcConfigNodes.Count == 0)
                    {
                        throw new ArgumentNullException(nameof(plcConfigNodes), "配置错误, plcConfig节点集合不可以为空！");
                    }

                    for (int i = 0; i < plcConfigNodes.Count; i++)
                    {
                        var plcConfigNode = plcConfigNodes[i];
                        var nameAttr = plcConfigNode.Attributes["name"];
                        if (string.IsNullOrEmpty(nameAttr.Value))
                        {
                            throw new ArgumentNullException(nameof(nameAttr), "配置错误, plcConfig节点的name属性不可以为空！");
                        }
                        configType.GetProperty(nameAttr.Value)?.SetValue(config, PlcConfigReader.Read(plcConfigNode));
                    }
                }

                using (var serialPortConfigs = configNode.SelectNodes("serialPortConfig"))
                {
                    if (serialPortConfigs.Count == 0)
                    {
                        throw new ArgumentNullException(nameof(serialPortConfigs), "配置错误, serialPortConfig节点集合不可以为空！");
                    }

                    for (int i = 0; i < serialPortConfigs.Count; i++)
                    {
                        var serialConfigNode = serialPortConfigs[i];
                        var nameAttr = serialConfigNode.Attributes["name"];
                        if (string.IsNullOrEmpty(nameAttr.Value))
                        {
                            throw new ArgumentNullException(nameof(nameAttr), "配置错误, serialPortConfig节点的name属性不可以为空！");
                        }
                        configType.GetProperty(nameAttr.Value)?.SetValue(config, SerialPortConfigReader.Read(serialConfigNode));
                    }
                }

                return config;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
