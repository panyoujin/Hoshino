using System;

namespace Hoshino.Entity
{
    public class b_category_Entity
    {
        /// <summary>
        /// 
        /// <summary>
        public int Category_ID { get; set; }

        /// <summary>
        /// 父级分类 0 第一级
        /// <summary>
        public int? Parent_Category_ID { get; set; }

        /// <summary>
        /// 分类名称简体
        /// <summary>
        public string Category_Name_CH { get; set; }

        /// <summary>
        /// 分类名称繁体
        /// <summary>
        public string Category_Name_HK { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// <summary>
        public int? Category_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// <summary>
        public int Category_Seq { get; set; }

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
