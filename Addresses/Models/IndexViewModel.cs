using System.Collections.Generic;

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
