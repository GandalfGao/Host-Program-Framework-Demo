using System;
using System.Data;
using System.Data.Common;

namespace WinformAppDemo.Utils.AdoNetCross
{
    /// <summary>
    /// 数据库操作器类
    /// </summary>
    public class DbOperator
    {
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        private readonly DbConnection conn;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="conn">数据库连接对象参数</param>
        public DbOperator(DbConnection conn)
        {
            this.conn = conn;
        }

        /// <summary>
        /// 查询数据表
        /// </summary>
        /// <param name="commandDefinition">数据指令定义类对象</param>
        /// <returns></returns>
        public DataTable Select(DbCommandDefinition commandDefinition)
        {
            try
            {
                var dataTable = new DataTable();

                //校验
                if (string.IsNullOrEmpty(commandDefinition.CommandText))
                {
                    throw new ArgumentNullException(nameof(commandDefinition.CommandText), "sql指令字符串不可以为空！");
                }
                //创建sql指令对象
                using (var cmd = DbCommandFactory.Create(conn, commandDefinition))
                //创建reader对象
                using (var reader = cmd.ExecuteReader())
                {
                    //获取DataColumn数组
                    var dataColumns = GetDataColumns(reader);
                    //添加到DataTable中
                    dataTable.Columns.AddRange(dataColumns);
                    //读取数据
                    while (reader.Read())
                    {
                        var dataRow = dataTable.NewRow();
                        //遍历DataColumn数组
                        foreach (var dataColumn in dataColumns)
                        {
                            dataRow[dataColumn] = reader[dataColumn.ColumnName];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取DataColumn数组
        /// </summary>
        /// <param name="reader">数据读取器对象</param>
        /// <returns></returns>
        private DataColumn[] GetDataColumns(DbDataReader reader)
        {
            //获取字段总数
            int fieldsCount = reader.FieldCount;
            //设置列数组
            var dataColumns = new DataColumn[fieldsCount];
            //遍历
            for (int i = 0; i < fieldsCount; i++)
            {
                //获取字段名称
                var columnName = reader.GetName(i);
                //获取字段数据类型
                var columnType = reader.GetFieldType(i);
                //设置列对象
                var dataColumn = new DataColumn(columnName, columnType);
                //添加到数组
                dataColumns[i] = dataColumn;
            }
            return dataColumns;
        }

        /// <summary>
        /// 编辑数据表(包含“增、删、改”操作)
        /// </summary>
        /// <param name="commandDefinition">数据指令定义类对象</param>
        /// <returns></returns>
        public int Edit(DbCommandDefinition commandDefinition)
        {
            try
            {
                //校验
                if (string.IsNullOrEmpty(commandDefinition.CommandText))
                {
                    throw new ArgumentNullException(nameof(commandDefinition.CommandText), "sql指令字符串不可以为空！");
                }

                //创建sql指令对象
                using (var cmd = DbCommandFactory.Create(conn, commandDefinition))
                { 
                    //返回影响的行数
                    int rowsCount = cmd.ExecuteNonQuery();
                    return rowsCount;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}