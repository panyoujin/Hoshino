using System;

namespace Hoshino.Entity
{
    public class b_product_attribute_template_Entity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int P_Attribute_ID { get; set; }

        /// <summary>
        /// 属性名称简体
        /// </summary>
        public string P_Attribute_Name_CH { get; set; }

        /// <summary>
        /// 属性名称繁体
        /// </summary>
        public string P_Attribute_Name_HK { get; set; }

        /// <summary>
        /// 属性值简体
        /// </summary>
        public string P_Attribute_Value_CH { get; set; }

        /// <summary>
        /// 属性值繁体
        /// </summary>
        public string P_Attribute_Value_HK { get; set; }

        /// <summary>
        /// 排序：顺序
        /// </summary>
        public int P_Attribute_Seq { get; set; }


    }
}
