using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addresses.Models
{
    public class NoFilterViewModel
    {
        public NoFilterViewModel(string countryNoFilter, string cityNoFilter, string streetNoFilter,
            int? houseNumberNoFilter, int? zipCodeNoFilter, DateTime? creationDataTimeNoFilter)
        {
            SelectedCountry = countryNoFilter;
            SelectedCity = cityNoFilter;
            SelectedStreet = streetNoFilter;
            SelectedHouseNumber = houseNumberNoFilter;
            SelectedZipCode = zipCodeNoFilter;
            SelectedCreationDateTime = creationDataTimeNoFilter;
        }

        public string SelectedCountry { get; set; }
        public string SelectedCity { get; set; }
        public string SelectedStreet { get; set; }
        public int? SelectedHouseNumber { get; set; }
        public int? SelectedZipCode { get; set; }
        public DateTime? SelectedCreationDateTime { get; set; }
    }

}
