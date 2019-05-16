using System;
using System.ComponentModel.DataAnnotations;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// b_product_resources
    /// </summary>
    public class b_product_resourcesVM
    {
        /// <summary>
        /// 
        /// </summary>
        public int P_Resources_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Product_ID { get; set; }

        /// <summary>
        /// 资源名称简体
        /// </summary>
        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string P_Resources_Name_CH { get; set; }

        /// <summary>
        /// 资源名称繁体
        /// </summary>
        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string P_Resources_Name_HK { get; set; }

        /// <summary>
        /// 资源URL，通过后缀判断是视频还是图片
        /// </summary>
        [MaxLength(length:256,ErrorMessage ="长度不能超过256字符")]
        public string P_Resources_URL { get; set; }

        /// <summary>
        /// 资源类型：image 图片 video 视频
        /// </summary>
        [MaxLength(length:10,ErrorMessage ="长度不能超过10字符")]
        public string P_Resources_Type { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// </summary>
        public int? P_Resources_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// </summary>
        public int P_Resources_Seq { get; set; }

    }
}
