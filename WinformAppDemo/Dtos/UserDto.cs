using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformAppDemo.Dtos
{
    /// <summary>
    /// 用户Dto类, 用在界面层与业务逻辑层之间的数据传输
    /// </summary>
    internal class UserDto
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
        public DateTime Birthday { get; set; }
    }
}
