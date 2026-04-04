using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformAppDemo.DataAccess;
using WinformAppDemo.DataAccess.Entities;
using WinformAppDemo.Utils.AdoNetCross;

namespace WinformAppDemo.DataAccess.Repositories
{
    /// <summary>
    /// 用户表数据访问类
    /// </summary>
    internal class UserRepository
    {
        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserEntity> GetUsers()
        {
            try
            {
                const string sql = "SELECT * FROM [dbo].[users]";
                List<UserEntity> users = new List<UserEntity>();

                using (var conn = DbConnectionHelper.GetSqlConnection())
                {
                    var dbOperator = new DbOperator(conn);
                    var dataTable = dbOperator.Select(new DbCommandDefinition()
                    { 
                        CommandText = sql,
                    });

                    foreach (DataRow row in dataTable.Rows)
                    {
                        var user = new UserEntity()
                        { 
                            Id = Convert.ToInt32(row["id"]),
                            Name = Convert.ToString(row["name"]),
                            Age = Convert.ToInt32(row["age"]),
                            Birthday = Convert.ToDateTime(row["birthday"]),
                            Email = Convert.ToString(row["email"]),
                        };
                        users.Add(user);
                    }
                }
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // 其他数据访问方法，如添加用户、更新用户、删除用户等
    }
}
