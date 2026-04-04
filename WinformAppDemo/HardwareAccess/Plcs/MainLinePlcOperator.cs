using WinformAppDemo.Utils.Configs;
using WinformAppDemo.Utils.Exceptions;
using HslCommunication.Profinet.Siemens;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformAppDemo.HardwareAccess.Plcs
{
    /// <summary>
    /// 主线plc操作器
    /// </summary>
    internal class MainLinePlcOperator : IDisposable
    {
        /// <summary>
        /// 日志对象字段
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger("MainLogger");
        /// <summary>
        /// plc地址配置对象字段
        /// </summary>
        private readonly Dictionary<string, string> plcAddrs;
        /// <summary>
        /// plc对象字段
        /// </summary>
        private readonly SiemensS7Net plc;

        public MainLinePlcOperator(PlcConfig plcConfig)
        {
            plcAddrs = plcConfig.PlcAddrs;
            plc = PlcConnectionHelper.GetPlcConnection(plcConfig.PlcEquip);
        }

        /// <summary>
        /// 启动或停止主线输送
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <exception cref="PlcException"></exception>
        public async Task SetLineStateAsync(bool isStart)
        {
            var res1 = await plc.WriteAsync(plcAddrs["startLineAddr"], isStart);
            if (!res1.IsSuccess)
            {
                throw new PlcException(res1.ErrorCode, res1.Message);
            }

            var res2 = await plc.WriteAsync(plcAddrs["stopLineAddr"], !isStart);
            if (!res2.IsSuccess)
            {
                throw new PlcException(res2.ErrorCode, res2.Message);
            }

            log.InfoFormat("{0}主线输送成功, 启动指令值: {1}, 停止指令值: {2}", (isStart ? "启动" : "停止"), isStart, !isStart);
        }

        /// <summary>
        /// 获取主线输送状态
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PlcException"></exception>
        public async Task<bool> GetLineStateAsync()
        {
            var res1 = await plc.ReadBoolAsync(plcAddrs["startLineAddr"]);
            if (!res1.IsSuccess)
            {
                throw new PlcException(res1.ErrorCode, res1.Message);
            }

            var res2 = await plc.ReadBoolAsync(plcAddrs["stopLineAddr"]);
            if (!res2.IsSuccess)
            {
                throw new PlcException(res2.ErrorCode, res2.Message);
            }

            if (res1.Content != !res2.Content)
            {
                throw new PlcException("PLC主线状态异常！启动和停止地址状态不一致");
            }

            log.InfoFormat("获取主线输送状态成功, 启动地址值: {0}, 停止地址值: {1}", res1.Content, res2.Content);

            return res1.Content;
        }

        public void Dispose()
        {
            // 将长连接模式切换回短连接模式，并关闭连接，释放资源(如果本身就是短连接不需要调用ConnectClose函数)
            plc.ConnectClose();
            plc.Dispose();
        }
    }
}
