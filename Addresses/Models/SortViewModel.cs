using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Addresses.Models;

namespace Addresses.Models
{
    public class SortViewModel
    {
        public SortState CountrySort { get; set; }
        public SortState CitySort { get; set; }
        public SortState StreetSort { get; set; }
        public SortState HouseNumberSort { get; set; }
        public SortState ZipCodeSort { get; set; }
        public SortState CreationDateTimeSort { get; set; }
        public SortState NoSort { get; set; }
        public SortState Current { get; set; }
        public bool Up { get; set; }


        public SortViewModel(SortState sortState)
        {
            CountrySort = SortState.CountryAsc;
            CitySort = SortState.CityAsc;
            StreetSort = SortState.StreetAsc;
            HouseNumberSort = SortState.HouseNumberAsc;
            ZipCodeSort = SortState.ZipCodeAsc;
            CreationDateTimeSort = SortState.CreationDateTimeAsc;
            Up = true;
            NoSort = SortState.NoSort;

            if (sortState==SortState.CityDesc|| sortState==SortState.CountryDesc|| sortState==SortState.CreationDateTimeDesc|| sortState==SortState.HouseNumberDesc||sortState==SortState.StreetDesc|| sortState==SortState.ZipCodeDesc)
            {
                Up = false;
            }
            switch (sortState)
            {
                case SortState.CityAsc:
                    Current = CitySort = SortState.CityDesc;
                    break;
                case SortState.CityDesc:
                    Current = CitySort = SortState.CityAsc;
                    break;
                case SortState.CountryAsc:
                    Current = CountrySort = SortState.CountryDesc;
                    break;
                case SortState.CountryDesc:
                    Current = CountrySort = SortState.CountryAsc;
                    break;
                case SortState.CreationDateTimeAsc:
                    Current = CreationDateTimeSort = SortState.CreationDateTimeDesc;
                    break;
                case SortState.CreationDateTimeDesc:
                    Current = CreationDateTimeSort = SortState.CreationDateTimeAsc;
                    break;
                case SortState.HouseNumberAsc:
                    Current = HouseNumberSort = SortState.HouseNumberDesc;
                    break;
                case SortState.HouseNumberDesc:
                    Current = HouseNumberSort = SortState.HouseNumberAsc;
                    break;
                case SortState.StreetAsc:
                    Current = StreetSort = SortState.StreetDesc;
                    break;
                case SortState.StreetDesc:
                    Current = StreetSort = SortState.StreetAsc;
                    break;
                case SortState.ZipCodeAsc:
                    Current = ZipCodeSort = SortState.ZipCodeDesc;
                    break;
                case SortState.ZipCodeDesc:
                    Current = ZipCodeSort = SortState.ZipCodeAsc;
                    break;
                default:
                    Current = NoSort = SortState.NoSort;
                    break;
            }
        }
    }
}
