using System;
using System.ComponentModel.DataAnnotations;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// b_category
    /// </summary>
    public class b_categoryVM
    {
        /// <summary>
        /// 
        /// </summary>
        public int Category_ID { get; set; }

        /// <summary>
        /// 父级分类 0 第一级
        /// </summary>
        public int? Parent_Category_ID { get; set; }

        /// <summary>
        /// 分类名称简体
        /// </summary>
        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string Category_Name_CH { get; set; }

        /// <summary>
        /// 分类名称繁体
        /// </summary>
        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string Category_Name_HK { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// </summary>
        public int? Category_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// </summary>
        public int Category_Seq { get; set; }

    }
}
