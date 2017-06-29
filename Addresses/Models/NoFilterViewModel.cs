namespace Addresses.Models
{
    public class NoFilterViewModel
    {
        public NoFilterViewModel(string countryNoFilter, string cityNoFilter, string streetNoFilter,
            string houseNumberNoFilter, string zipCodeNoFilter, string creationDataTimeNoFilter)
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
        public string SelectedHouseNumber { get; set; }
        public string SelectedZipCode { get; set; }
        public string SelectedCreationDateTime { get; set; }
    }
}
