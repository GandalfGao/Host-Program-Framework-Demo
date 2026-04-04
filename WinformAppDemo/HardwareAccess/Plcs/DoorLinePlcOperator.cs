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
    /// 辅线plc操作器
    /// </summary>
    internal class DoorLinePlcOperator : IDisposable
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

        public DoorLinePlcOperator(PlcConfig plcConfig)
        {
            plcAddrs = plcConfig.PlcAddrs;
            plc = PlcConnectionHelper.GetPlcConnection(plcConfig.PlcEquip);
        }

        /// <summary>
        /// 复位辅线的报警状态
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PlcException"></exception>
        public async Task ResetAlarmAsync()
        {
            var res = await plc.WriteAsync(plcAddrs["resetAlarmAddr"], true);
            if (!res.IsSuccess)
            {
                throw new PlcException(res.ErrorCode, res.Message);
            }

            log.Info("复位辅线报警状态成功");
        }

        /// <summary>
        /// 是否处于自动模式
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PlcException"></exception>
        public async Task<bool> IsAutoModeAsync()
        {
            var res = await plc.ReadBoolAsync(plcAddrs["autoModeAddr"]);
            if (!res.IsSuccess)
            {
                throw new PlcException(res.ErrorCode, res.Message);
            }

            log.Info($"读取辅线自动模式状态成功，状态值: {res.Content}");

            return res.Content;
        }

        public void Dispose()
        {
            // 将长连接模式切换回短连接模式，并关闭连接，释放资源(如果本身就是短连接不需要调用ConnectClose函数)
            plc.ConnectClose();
            plc.Dispose();
        }
    }
}
