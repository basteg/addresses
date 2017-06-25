﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addresses.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Address> Addresses { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int ZipCode { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
