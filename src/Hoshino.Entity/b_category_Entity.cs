namespace Hoshino.Entity
{
    public class b_category_Entity : BaseEntity
    {
        /// <summary>
        /// 
        /// <summary>
        public int Category_ID { get; set; }

        /// <summary>
        /// 父级分类 0 第一级
        /// <summary>
        public int? Parent_Category_ID { get; set; }

        /// <summary>
        /// 分类名称简体
        /// <summary>
        public string Category_Name_CH { get; set; }

        /// <summary>
        /// 分类名称繁体
        /// <summary>
        public string Category_Name_HK { get; set; }

        /// <summary>
        /// 1:有效; 0:无效
        /// <summary>
        public int? Category_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// <summary>
        public int Category_Seq { get; set; }


    }
}
