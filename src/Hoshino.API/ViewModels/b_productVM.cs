using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// b_product
    /// </summary>
    public class b_productVM
    {
        /// <summary>
        /// 
        /// </summary>
        public int Product_ID { get; set; }

        /// <summary>
        /// 所属分类
        /// </summary>
        public int Category_ID { get; set; }

        /// <summary>
        /// 产品名称简体
        /// </summary>
        [MaxLength(length: 50, ErrorMessage = "长度不能超过50字符")]
        public string Product_Name_CH { get; set; }

        /// <summary>
        /// 产品名称繁体
        /// </summary>
        [MaxLength(length: 50, ErrorMessage = "长度不能超过50字符")]
        public string Product_Name_HK { get; set; }

        /// <summary>
        /// 1:最新; 0:非最新
        /// </summary>
        public int? Product_New { get; set; }

        /// <summary>
        /// 1:热门; 0:非热门
        /// </summary>
        public int? Product_Hot { get; set; }

        /// <summary>
        /// 1:推荐; 0:非推荐
        /// </summary>
        public int? Product_Recommend { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// </summary>
        public int? Product_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// </summary>
        public int Product_Seq { get; set; }
        /// <summary>
        /// 属性列表
        /// </summary>
        public List<b_product_attributeVM> product_attributeList { set; get; }
        /// <summary>
        /// 附件列表
        /// </summary>
        public List<b_product_resourcesVM> product_resourcesList { set; get; }
        /// <summary>
        /// 关联产品列表
        /// </summary>
        public List<b_productVM> rel_productList { set; get; }

    }
}
