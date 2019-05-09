using System;

namespace Hoshino.Entity
{
    public class b_product_Entity
    {
        /// <summary>
        /// 
        /// <summary>
        public int Product_ID { get; set; }

        /// <summary>
        /// 所属分类
        /// <summary>
        public int Category_ID { get; set; }

        /// <summary>
        /// 产品名称简体
        /// <summary>
        public string Product_Name_CH { get; set; }

        /// <summary>
        /// 产品名称繁体
        /// <summary>
        public string Product_Name_HK { get; set; }

        /// <summary>
        /// 1:最新; 0:非最新
        /// <summary>
        public int Product_New { get; set; }

        /// <summary>
        /// 1:热门; 0:非热门
        /// <summary>
        public int Product_Hot { get; set; }

        /// <summary>
        /// 1:推荐; 0:非推荐
        /// <summary>
        public int Product_Recommend { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// <summary>
        public int Product_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// <summary>
        public int Product_Seq { get; set; }

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
