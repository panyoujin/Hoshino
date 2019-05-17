namespace Hoshino.Entity
{
    public class b_video_resources_Entity : BaseEntity
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


    }
}
