using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addresses.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Address> Addresses { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
