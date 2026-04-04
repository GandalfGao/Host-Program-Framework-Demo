using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace WinformAppDemo.Utils.AdoNetCross
{
    /// <summary>
    /// 数据指令定义类
    /// </summary>
    public class DbCommandDefinition
    {
        public DbCommandDefinition()
        {
            
        }

        /// <summary>
        /// sql指令字符串
        /// </summary>
        public string CommandText { get; set; } = string.Empty;

        /// <summary>
        /// sql指令类型
        /// </summary>
        public CommandType CommandType { get; set; } = CommandType.Text;

        /// <summary>
        /// sql指令参数
        /// </summary>
        public DbParameter[] Parameters { get; set; } = Array.Empty<DbParameter>();
    }
}
