namespace Hoshino.Entity
{
    public class b_rel_product_Entity : BaseEntity
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
        public int? P_Relevant_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// <summary>
        public int P_Relevant_Seq { get; set; }


    }
}
