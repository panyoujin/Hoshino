using System;

namespace Hoshino.Entity
{
    public class sys_user_Entity : BaseEntity
    {
        /// <summary>
        /// 
        /// <summary>
        public int User_ID { get; set; }

        /// <summary>
        /// 帐号
        /// <summary>
        public string User_Account { get; set; }

        /// <summary>
        /// 密码 帐号+密码+随机码 MDS
        /// <summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户名
        /// <summary>
        public string User_Name { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// <summary>
        public int? User_Status { get; set; }


    }
}
