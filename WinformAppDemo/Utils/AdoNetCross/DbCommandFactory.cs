using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace WinformAppDemo.Utils.AdoNetCross
{
    /// <summary>
    /// sql指令工厂类
    /// </summary>
    internal static class DbCommandFactory
    {
        /// <summary>
        /// 指令创建
        /// </summary>
        /// <param name="conn">数据库连接对象参数</param>
        /// <param name="dbCmdDefinition">指令定义对象参数</param>
        /// <returns>DbCommand对象</returns>
        public static DbCommand Create(DbConnection conn, DbCommandDefinition dbCmdDefinition)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = dbCmdDefinition.CommandText;
            cmd.CommandType = dbCmdDefinition.CommandType;
            if (dbCmdDefinition.Parameters.Any())
            {
                cmd.Parameters.AddRange(dbCmdDefinition.Parameters);
            }
            return cmd;
        }
    }
}
