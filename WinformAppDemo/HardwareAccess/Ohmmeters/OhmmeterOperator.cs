using WinformAppDemo.Utils.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace WinformAppDemo.HardwareAccess.Ohmmeters
{
    /// <summary>
    /// 电阻仪操作器
    /// </summary>
    internal class OhmmeterOperator : IDisposable
    {
        /// <summary>
        /// 简单的测量电阻值指令
        /// </summary>
        private const string SimpleMeasureResistanceCommand = "MEASure:RESistance?";

        /// <summary>
        /// 串口设备通讯对象字段
        /// </summary>
        private readonly SerialPort serialPort;

        public OhmmeterOperator(SerialPortConfig serialPortConfig)
        {
            serialPort = SerialPortConnectionHelper.GetSerialPortConnection(serialPortConfig);
        }

        /// <summary>
        /// 测量电阻值的指令
        /// </summary>
        public double SimpleMeasureResistance()
        {
            //发送测量电阻值指令
            serialPort.WriteLine(SimpleMeasureResistanceCommand);
            //获取电阻数值
            var resistanceValStr = serialPort.ReadExisting();
            var resistanceVal = double.Parse(resistanceValStr);

            return resistanceVal;
        }

        public void Dispose()
        {
            serialPort.Dispose();
        }
    }
}
