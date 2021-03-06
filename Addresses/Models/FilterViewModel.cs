﻿namespace Addresses.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(string countryFilter, string cityFilter, string streetFilter,
            string houseNumberFilter, string zipCodeFilter, string creationDataTimeFilter)
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
        public string SelectedHouseNumber { get; set; }
        public string SelectedZipCode { get; set; }
        public string SelectedCreationDateTime { get; set; }

        public string StyleTextCountry { get; set; }
        public string StyleTextCity { get; set; }
        public string StyleTextStreet { get; set; }
        public string StyleTextHouseNumber { get; set; }
        public string StyleTextZipCode { get; set; }
        public string StyleTextCreationDateTime { get; set; }
    }
}
