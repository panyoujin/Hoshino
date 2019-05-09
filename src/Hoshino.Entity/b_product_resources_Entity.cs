using System;

namespace Hoshino.Entity
{
    public class b_product_resources_Entity
    {
        /// <summary>
        /// 
        /// <summary>
        public int P_Resources_ID { get; set; }

        /// <summary>
        /// 
        /// <summary>
        public int Product_ID { get; set; }

        /// <summary>
        /// 资源名称简体
        /// <summary>
        public string P_Resources_Name_CH { get; set; }

        /// <summary>
        /// 资源名称繁体
        /// <summary>
        public string P_Resources_Name_HK { get; set; }

        /// <summary>
        /// 资源URL，通过后缀判断是视频还是图片
        /// <summary>
        public string P_Resources_URL { get; set; }

        /// <summary>
        /// 资源类型：image 图片 video 视频
        /// <summary>
        public string P_Resources_Type { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// <summary>
        public int P_Resources_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// <summary>
        public int P_Resources_Seq { get; set; }

        /// <summary>
        /// 
        /// <summary>
        public DateTime Create_Time { get; set; }

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
        public DateTime Update_Time { get; set; }

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
