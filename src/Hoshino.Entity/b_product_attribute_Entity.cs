using System;

namespace Hoshino.Entity
{
    public class b_product_attribute_Entity
    {
        /// <summary>
        /// 
        /// <summary>
        public int P_Attribute_ID { get; set; }

        /// <summary>
        /// 
        /// <summary>
        public int Product_ID { get; set; }

        /// <summary>
        /// 属性名称简体
        /// <summary>
        public string P_Attribute_Name_CH { get; set; }

        /// <summary>
        /// 属性名称繁体
        /// <summary>
        public string P_Attribute_Name_HK { get; set; }

        /// <summary>
        /// 属性值简体
        /// <summary>
        public string P_Attribute_Value_CH { get; set; }

        /// <summary>
        /// 属性值繁体
        /// <summary>
        public string P_Attribute_Value_EN { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// <summary>
        public int P_Attribute_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// <summary>
        public int P_Attribute_Seq { get; set; }

        /// <summary>
        /// 
        /// <summary>
        public DateTime Create_Time { get; set; }

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
        public DateTime Update_Time { get; set; }

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
