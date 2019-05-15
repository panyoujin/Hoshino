using System;
using System.ComponentModel.DataAnnotations;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// b_video_resources
    /// </summary>
    public class b_video_resourcesVM
    {
        /// <summary>
        /// 
        /// </summary>
        public int Video_ID { get; set; }

        /// <summary>
        /// Video名称简体
        /// </summary>
        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string Video_Name_CH { get; set; }

        /// <summary>
        /// Video名称繁体
        /// </summary>
        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string Video_Name_HK { get; set; }

        /// <summary>
        /// Video URL
        /// </summary>
        [MaxLength(length:256,ErrorMessage ="长度不能超过256字符")]
        public string Video_URL { get; set; }

        /// <summary>
        /// Video 位置： Index 首页
        /// </summary>
        [MaxLength(length:10,ErrorMessage ="长度不能超过10字符")]
        public string Video_Location { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// </summary>
        public int? Video_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// </summary>
        public int Video_Seq { get; set; }

    }
}
