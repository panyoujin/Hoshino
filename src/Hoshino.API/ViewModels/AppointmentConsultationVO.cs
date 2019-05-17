using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class AppointmentConsultationVO
    {
        /// <summary>
        /// 
        /// </summary>
        public int AC_ID { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contacts { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 事项
        /// </summary>
        public string Matter { get; set; }

        /// <summary>
        /// 资料
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// 0 未处理,1 已处理
        /// </summary>
        public int AC_Status { get; set; }

        /// <summary>
        /// 处理结果
        /// </summary>
        public string Processing_Result { get; set; }
    }
}
