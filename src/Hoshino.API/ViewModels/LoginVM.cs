using System;

namespace Hoshino.API.ViewModels
{
    public class LoginVM
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string User_Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerificationCode { get; set; }

        public string token {get;set;}

    }
}
