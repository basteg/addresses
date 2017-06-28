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

            string textStyle = "color:black";
            StyleTextCountry = textStyle;
            StyleTextCity = textStyle;
            StyleTextStreet = textStyle;
            StyleTextHouseNumber = textStyle;
            StyleTextZipCode = textStyle;
            StyleTextCreationDateTime = textStyle;
            

        }

        public string SelectedCountry{get;set;}
        public string SelectedCity { get; set; }
        public string SelectedStreet { get; set; }
        public int? SelectedHouseNumber { get; set; }
        public int? SelectedZipCode { get; set; }
        public DateTime? SelectedCreationDateTime { get; set; }

        public string StyleTextCountry { get; set; }
        public string StyleTextCity { get; set; }
        public string StyleTextStreet { get; set; }
        public string StyleTextHouseNumber { get; set; }
        public string StyleTextZipCode { get; set; }
        public string StyleTextCreationDateTime { get; set; }

    }
}
