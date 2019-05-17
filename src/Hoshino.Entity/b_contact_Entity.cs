namespace Hoshino.Entity
{
    public class b_contact_Entity : BaseEntity
    {
        /// <summary>
        /// 
        /// <summary>
        public int Contact_ID { get; set; }

        /// <summary>
        /// 公司名称
        /// <summary>
        public string Company { get; set; }

        /// <summary>
        /// 联系人
        /// <summary>
        public string Contacts { get; set; }

        /// <summary>
        /// 电话
        /// <summary>
        public string Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// <summary>
        public string Email { get; set; }

        /// <summary>
        /// 事项
        /// <summary>
        public string Matter { get; set; }

        /// <summary>
        /// 微信
        /// <summary>
        public string Wechat { get; set; }

        /// <summary>
        /// WhatsApp
        /// <summary>
        public string WhatsApp { get; set; }

        /// <summary>
        /// 0 未处理,1 已处理
        /// <summary>
        public int Contact_Status { get; set; }

        /// <summary>
        /// 处理结果
        /// <summary>
        public string Processing_Result { get; set; }


    }
}
