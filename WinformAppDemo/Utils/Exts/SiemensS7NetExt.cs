using HslCommunication;
using HslCommunication.Profinet.Siemens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformAppDemo.Utils.Exts
{
    internal static class SiemensS7NetExt
    {
        /// <summary>
        /// 读取plc存储的日期数据
        /// </summary>
        /// <param name="plc"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static OperateResult<DateTime> ReadDateTime(this SiemensS7Net plc, string address)
        {
            var dataRes = plc.Read(address, 12);

            if (dataRes.IsSuccess)
            {
                var data = dataRes.Content;

                // 1. 读取年份
                ushort year = (ushort)(data[0] << 8 | (data[1]));

                // 2. 读取月份、日期、时间（单字节，无字节序问题）
                byte month = data[2];
                byte day = data[3];
                byte hour = data[5];
                byte minute = data[6];
                byte second = data[7];

                // 3. 读取纳秒
                uint nanoseconds = (uint)
                (
                    data[8] << 24 |
                    (data[9] << 16) |
                    (data[10] << 8) |
                    (data[11])
                );

                // 4. 转换为毫秒
                int milliseconds = (int)(nanoseconds / 1_000_000);

                var dt = new DateTime(year, month, day, hour, minute, second, milliseconds);

                return OperateResult.CreateSuccessResult(dt);
            }

            return OperateResult.CreateFailedResult<DateTime>(dataRes);
        }
    }
}
