using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoshino.API.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ALLCategoryVM
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name_CN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name_HK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ALLCategoryVM> Child { get; set; }
    }
}
