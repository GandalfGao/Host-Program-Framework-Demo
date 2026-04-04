using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformAppDemo.DataAccess.Entities
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    internal class UserEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年纪
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set;  }


    }
}
