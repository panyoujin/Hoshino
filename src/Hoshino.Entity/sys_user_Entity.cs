using System;

namespace Hoshino.Entity
{
    public class sys_user_Entity
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

        /// <summary>
        /// 
        /// <summary>
        public DateTime? Create_Time { get; set; }

        /// <summary>
        /// 用户ID
        /// <summary>
        public string Create_UserId { get; set; }

        /// <summary>
        /// 用户名称：操作时的用户名
        /// <summary>
        public string Create_User { get; set; }

        /// <summary>
        /// 
        /// <summary>
        public DateTime? Update_Time { get; set; }

        /// <summary>
        /// 用户ID
        /// <summary>
        public string Update_UserId { get; set; }

        /// <summary>
        /// 用户名称：操作时的用户名
        /// <summary>
        public string Update_User { get; set; }

    }
}
