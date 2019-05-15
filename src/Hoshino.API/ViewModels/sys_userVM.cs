using System;
using System.ComponentModel.DataAnnotations;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// sys_user
    /// </summary>
    public class sys_userVM
    {
        /// <summary>
        /// 
        /// </summary>
        public int User_ID { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        [MaxLength(length:100,ErrorMessage ="长度不能超过100字符")]
        public string User_Account { get; set; }

        /// <summary>
        /// 密码 帐号+密码+随机码 MDS
        /// </summary>
        [MaxLength(length:100,ErrorMessage ="长度不能超过100字符")]
        public string Password { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(length:100,ErrorMessage ="长度不能超过100字符")]
        public string User_Name { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// </summary>
        public int? User_Status { get; set; }

    }
}
