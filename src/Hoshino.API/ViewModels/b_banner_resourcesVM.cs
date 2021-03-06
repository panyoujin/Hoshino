﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// b_banner_resources
    /// </summary>
    public class b_banner_resourcesVM
    {
        /// <summary>
        /// 
        /// </summary>
        public int Banner_ID { get; set; }

        /// <summary>
        /// Banner名称简体
        /// </summary>
        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string Banner_Name_CH { get; set; }

        /// <summary>
        /// Banner名称繁体
        /// </summary>
        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string Banner_Name_HK { get; set; }

        /// <summary>
        /// BannerURL，通过后缀判断是视频还是图片
        /// </summary>
        [MaxLength(length:256,ErrorMessage ="长度不能超过256字符")]
        public string Banner_URL { get; set; }

        /// <summary>
        /// Banner类型：image 图片 video 视频
        /// </summary>
        [MaxLength(length:10,ErrorMessage ="长度不能超过10字符")]
        public string Banner_Type { get; set; }

        /// <summary>
        /// Banner类型： Index 首页
        /// </summary>
        [MaxLength(length:10,ErrorMessage ="长度不能超过10字符")]
        public string Banner_Location { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// </summary>
        public int? Banner_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// </summary>
        public int Banner_Seq { get; set; }

    }
}
