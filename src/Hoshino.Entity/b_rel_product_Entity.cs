using System;

namespace Hoshino.Entity
{
    public class b_rel_product_Entity
    {
        /// <summary>
        /// 
        /// <summary>
        public int P_Relevant_ID { get; set; }

        /// <summary>
        /// 
        /// <summary>
        public int Source_Product_ID { get; set; }

        /// <summary>
        /// 
        /// <summary>
        public int Rel_Product_ID { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// <summary>
        public int P_Relevant_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// <summary>
        public int P_Relevant_Seq { get; set; }

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
