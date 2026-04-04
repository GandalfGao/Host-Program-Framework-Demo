using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformAppDemo.Utils.Exceptions
{
    /// <summary>
    /// plc异常类
    /// </summary>
    class PlcException : Exception
    {
        /// <summary>
        /// 异常信息模板字段
        /// </summary>
        private const string exMessageTemplate1 = "plc操作异常！错误信息: {0}";
        /// <summary>
        /// 异常信息模板字段
        /// </summary>
        private const string exMessageTemplate2 = "plc操作异常！错误代码: {0}, 错误信息: {1}";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errMessage">错误信息</param>
        public PlcException(string errMessage) : base(string.Format(exMessageTemplate1, errMessage))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errCode">错误代码</param>
        /// <param name="errMessage">错误信息</param>
        public PlcException(int errCode, string errMessage) : base(string.Format(exMessageTemplate2, errCode, errMessage))
        { }
    }
}
