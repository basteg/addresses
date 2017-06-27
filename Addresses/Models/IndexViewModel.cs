using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addresses.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Address> Addresses { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public NoFilterViewModel NoFilterViewModel { get; set; }

         
    }
}
