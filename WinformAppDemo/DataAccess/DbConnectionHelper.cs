using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformAppDemo.DataAccess
{
    /// <summary>
    /// 数据库链接帮助类
    /// </summary>
    internal static class DbConnectionHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        /// <summary>
        /// 获取SqlConnection对象
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            var conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }
    }
}