namespace Hoshino.Entity
{
    public class b_logo_resources_Entity : BaseEntity
    {
        /// <summary>
        /// 
        /// <summary>
        public int Logo_ID { get; set; }


        public string Logo_Name_CH { get; set; }


        public string Logo_Name_HK { get; set; }


        public string Logo_URL { get; set; }



        /// <summary>
        /// 1:有效; 0:无效
        /// <summary>
        public int Logo_Status { get; set; }

        /// <summary>
        /// 排序：倒序
        /// <summary>
        public int Logo_Seq { get; set; }


    }
}
