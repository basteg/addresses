using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addresses.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(string countryFilter, string cityFilter, string streetFilter,
            int? houseNumberFilter, int? zipCodeFilter, DateTime? creationDataTimeFilter)
        {
            SelectedCountry = countryFilter;
            SelectedCity = cityFilter;
            SelectedStreet = streetFilter;
            SelectedHouseNumber = houseNumberFilter;
            SelectedZipCode = zipCodeFilter;
            SelectedCreationDateTime = creationDataTimeFilter;
        }

        public string SelectedCountry{get;set;}
        public string SelectedCity { get; set; }
        public string SelectedStreet { get; set; }
        public int? SelectedHouseNumber { get; set; }
        public int? SelectedZipCode { get; set; }
        public DateTime? SelectedCreationDateTime { get; set; }
    }
}
