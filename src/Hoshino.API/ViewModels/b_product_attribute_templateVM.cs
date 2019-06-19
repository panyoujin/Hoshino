﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// b_product_attribute_template
    /// </summary>
    public class b_product_attribute_templateVM
    {
        /// <summary>
        /// 
        /// </summary>
        public int P_Attribute_ID { get; set; }

        /// <summary>
        /// 属性名称简体
        /// </summary>
        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string P_Attribute_Name_CH { get; set; }

        /// <summary>
        /// 属性名称繁体
        /// </summary>
        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string P_Attribute_Name_HK { get; set; }

        /// <summary>
        /// 属性值简体
        /// </summary>
        [MaxLength(length:256,ErrorMessage ="长度不能超过256字符")]
        public string P_Attribute_Value_CH { get; set; }

        /// <summary>
        /// 属性值繁体
        /// </summary>
        [MaxLength(length:256,ErrorMessage ="长度不能超过256字符")]
        public string P_Attribute_Value_HK { get; set; }

        /// <summary>
        /// 排序：顺序
        /// </summary>
        public int P_Attribute_Seq { get; set; }

    }
}
