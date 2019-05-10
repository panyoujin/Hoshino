using System;

namespace Hoshino.Entity
{
    public class b_video_resources_Entity
    {
        /// <summary>
        /// 
        /// <summary>
        public int Video_ID { get; set; }

        /// <summary>
        /// Video名称简体
        /// <summary>
        public string Video_Name_CH { get; set; }

        /// <summary>
        /// Video名称繁体
        /// <summary>
        public string Video_Name_HK { get; set; }

        /// <summary>
        /// Video URL
        /// <summary>
        public string Video_URL { get; set; }

        /// <summary>
        /// Video 位置： Index 首页
        /// <summary>
        public string Video_Location { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// <summary>
        public int? Video_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// <summary>
        public int Video_Seq { get; set; }

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
