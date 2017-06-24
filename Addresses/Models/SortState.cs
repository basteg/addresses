using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addresses.Models
{
    public enum SortState
    {
        CountryAsc,
        CountryDesc,
        CityAsc,
        CityDesc,
        StreetAsc,
        StreetDesc,
        HouseNumberAsc,
        HouseNumberDesc,
        ZipCodeAsc,
        ZipCodeDesc,
        CreationDateTimeAsc,
        CreationDateTimeDesc,
        NoSort
    }
}
