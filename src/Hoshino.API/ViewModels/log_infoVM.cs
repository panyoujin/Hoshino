using System;
using System.ComponentModel.DataAnnotations;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// log_info
    /// </summary>
    public class log_infoVM
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(length:64,ErrorMessage ="长度不能超过64字符")]
        public string chain_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(length:500,ErrorMessage ="长度不能超过500字符")]
        public string content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(length:200,ErrorMessage ="长度不能超过200字符")]
        public string interface_name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? creation_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(length:64,ErrorMessage ="长度不能超过64字符")]
        public string ip { get; set; }

    }
}
