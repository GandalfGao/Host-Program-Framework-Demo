using WinformAppDemo.Utils.Configs;
using WinformAppDemo.Utils.Exceptions;
using HslCommunication.Profinet.Siemens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformAppDemo.HardwareAccess
{
    /// <summary>
    /// plc链接帮助类
    /// </summary>
    internal static class PlcConnectionHelper
    {
        /// <summary>
        /// 获取plc链接对象
        /// </summary>
        /// <param name="plcEquip"></param>
        /// <returns></returns>
        /// <exception cref="PlcException"></exception>
        public static SiemensS7Net GetPlcConnection(PlcEquip plcEquip)
        {
            // 设置plc对象
            var plc = new SiemensS7Net(plcEquip.Type, plcEquip.Ip);
            // 设置端口号
            if (plcEquip.Port.HasValue)
            {
                plc.Port = plcEquip.Port.Value;
            }
            // 设置槽号
            if (plcEquip.Slot.HasValue)
            {
                plc.Slot = plcEquip.Slot.Value;
            }
            // 设置机架号
            if (plcEquip.Rack.HasValue)
            {
                plc.Rack = plcEquip.Rack.Value;
            }

            // 从短连接切换到长连接, 请结合实际情况使用
            var res = plc.ConnectServer();

            if (!res.IsSuccess)
            {
                throw new PlcException(res.ErrorCode, res.Message);
            }

            return plc;
        }
    }
}
