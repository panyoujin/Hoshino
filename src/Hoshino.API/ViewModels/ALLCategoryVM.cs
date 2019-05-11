using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoshino.API.ViewModels
{
    public class ALLCategoryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Name_CN { get; set; }
        public string Name_HK { get; set; }
        public List<ALLCategoryVM> Child { get; set; }
    }
}
