using System;
using System.ComponentModel.DataAnnotations;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// b_appointment_consultation
    /// </summary>
    public class b_appointment_consultationVM
    {
        /// <summary>
        /// 
        /// </summary>
        public int AC_ID { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [MaxLength(length:256,ErrorMessage ="长度不能超过256字符")]
        public string Company { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [MaxLength(length:50,ErrorMessage ="长度不能超过50字符")]
        public string Contacts { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [MaxLength(length:20,ErrorMessage ="长度不能超过20字符")]
        public string Phone { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [MaxLength(length:256,ErrorMessage ="长度不能超过256字符")]
        public string Email { get; set; }

        /// <summary>
        /// 事项
        /// </summary>
        [MaxLength(length:256,ErrorMessage ="长度不能超过256字符")]
        public string Matter { get; set; }

        /// <summary>
        /// 资料
        /// </summary>
        [MaxLength(length:256,ErrorMessage ="长度不能超过256字符")]
        public string Material { get; set; }

        /// <summary>
        /// 0 未处理,1 已处理
        /// </summary>
        public int AC_Status { get; set; }

        /// <summary>
        /// 处理结果
        /// </summary>
        [MaxLength(length:256,ErrorMessage ="长度不能超过256字符")]
        public string Processing_Result { get; set; }

    }
}
