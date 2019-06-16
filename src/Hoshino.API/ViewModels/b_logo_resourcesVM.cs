using System;
using System.ComponentModel.DataAnnotations;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// b_banner_resources
    /// </summary>
    public class b_logo_resourcesVM
    {
        /// <summary>
        /// 
        /// </summary>
        public int Logo_ID { get; set; }


        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string Logo_Name_CH { get; set; }

        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string Logo_Name_HK { get; set; }


        [MaxLength(length:256,ErrorMessage ="长度不能超过256字符")]
        public string Logo_URL { get; set; }


        /// <summary>
        /// 排序：倒序
        /// </summary>
        public int Logo_Seq { get; set; }

    }
}
