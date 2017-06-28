using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Addresses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using PagedList.Core;
using PagedList;
using System.Globalization;

namespace Addresses.Controllers
{
    public class HomeController : Controller
    {
        private AddressesContext db;

        //const int rowPerPage = 100;

        public HomeController(AddressesContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(string countryFilter, string cityFilter, string streetFilter, 
            string houseNumberFilter, string zipCodeFilter, string creationDataTimeFilter, SortState sortState = SortState.NoSort, int page=1)
        {
            int pageSize = 10;
            IQueryable<Address> addresses = db.Addresses;
            
            if (!String.IsNullOrEmpty(countryFilter))
            {
                addresses = addresses.Where(p => p.Country.StartsWith(countryFilter));
            }
            if (!String.IsNullOrEmpty(cityFilter))
            {
                addresses = addresses.Where(p => p.City.StartsWith(cityFilter));
            }
            if (!String.IsNullOrEmpty(streetFilter))
            {
                addresses = addresses.Where(p => p.Street.StartsWith(streetFilter));
            }
            if (!String.IsNullOrWhiteSpace(houseNumberFilter))
            {
                if (houseNumberFilter.Contains("-"))
                {
                    var range = houseNumberFilter.Split('-');
                    var start = int.Parse(range[0]);
                    var end = int.Parse(range[1]);

                    addresses = addresses.Where(p => p.HouseNumber >= start &&
                                                     p.HouseNumber <= end);
                }
                else
                    addresses = addresses.Where(p => p.ZipCode == int.Parse(houseNumberFilter));
            }
            if (!String.IsNullOrWhiteSpace(zipCodeFilter))
            {
                if (zipCodeFilter.Contains("-"))
                {
                    var range = zipCodeFilter.Split('-');
                    var start = int.Parse(range[0]);
                    var end = int.Parse(range[1]);

                    addresses = addresses.Where(p => p.ZipCode >= start &&
                                                     p.ZipCode <= end);
                }
                else
                    addresses = addresses.Where(p => p.ZipCode == int.Parse(zipCodeFilter));
            }
            if (!string.IsNullOrWhiteSpace(creationDataTimeFilter))
            {
                var dates = creationDataTimeFilter.Split('-');
                var startDate = DateTime.Parse(dates[0], CultureInfo.CurrentCulture);
                var endDate = DateTime.Parse(dates[1], CultureInfo.CurrentCulture);

                addresses = addresses.Where(p => p.CreationDateTime >= startDate &&
                                                 p.CreationDateTime <= endDate);
            }

            ViewData["CountrySort"] = sortState == SortState.CountryAsc ? SortState.CountryDesc : SortState.CountryAsc;
            ViewData["CitySort"] = sortState == SortState.CityAsc ? SortState.CityDesc : SortState.CityAsc;
            ViewData["StreetSort"] = sortState == SortState.StreetAsc ? SortState.StreetDesc : SortState.StreetAsc;
            ViewData["HouseNumberSort"] = sortState == SortState.HouseNumberAsc ? SortState.HouseNumberDesc : SortState.HouseNumberAsc;
            ViewData["ZipCodeSort"] = sortState == SortState.ZipCodeAsc ? SortState.ZipCodeDesc : SortState.ZipCodeAsc;
            ViewData["CreationDateTime"] = sortState == SortState.CreationDateTimeAsc ? SortState.CreationDateTimeDesc : SortState.CreationDateTimeAsc;

            switch (sortState)
            {
                case SortState.CountryAsc:
                    addresses = addresses.OrderBy(s => s.Country);
                    break;
                case SortState.CountryDesc:
                    addresses = addresses.OrderByDescending(s => s.Country);
                    break;
                case SortState.CityAsc:
                    addresses = addresses.OrderBy(s => s.City);
                    break;
                case SortState.CityDesc:
                    addresses = addresses.OrderByDescending(s => s.City);
                    break;
                case SortState.StreetAsc:
                    addresses = addresses.OrderBy(s => s.Street);
                    break;
                case SortState.StreetDesc:
                    addresses = addresses.OrderByDescending(s => s.Street);
                    break;
                case SortState.HouseNumberAsc:
                    addresses = addresses.OrderBy(s => s.HouseNumber);
                    break;
                case SortState.HouseNumberDesc:
                    addresses = addresses.OrderByDescending(s => s.HouseNumber);
                    break;
                case SortState.ZipCodeAsc:
                    addresses = addresses.OrderBy(s => s.ZipCode);
                    break;
                case SortState.ZipCodeDesc:
                    addresses = addresses.OrderByDescending(s => s.ZipCode);
                    break;
                case SortState.CreationDateTimeAsc:
                    addresses = addresses.OrderBy(s => s.CreationDateTime);
                    break;
                case SortState.CreationDateTimeDesc:
                    addresses = addresses.OrderByDescending(s => s.CreationDateTime);
                    break;
                default:
                    addresses = addresses.OrderBy(s => s.Id);
                    break;
            }
            var count = await addresses.CountAsync();
            //var items =  addresses.ToPagedList(page, pageSize);

            var items = await addresses.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            //return View(phones.ToPagedList(pageNumber, pageSize));


            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                FilterViewModel = new FilterViewModel(countryFilter, cityFilter, streetFilter, houseNumberFilter, zipCodeFilter, creationDataTimeFilter),
                SortViewModel = new SortViewModel(sortState),
                Addresses = items,
                NoFilterViewModel=new NoFilterViewModel(null, null, null, null, null, null)
            };
          
            if(viewModel.FilterViewModel.SelectedCountry != null || viewModel.SortViewModel.Current == SortState.CountryAsc
                || viewModel.SortViewModel.Current == SortState.CountryDesc)
                {
                viewModel.FilterViewModel.StyleTextCountry = "color:blue";
            }
            if(viewModel.FilterViewModel.SelectedCity != null || viewModel.SortViewModel.Current == SortState.CityAsc
                || viewModel.SortViewModel.Current == SortState.CityDesc)
                {
                viewModel.FilterViewModel.StyleTextCity = "color:blue";
            }
          if(viewModel.FilterViewModel.SelectedStreet != null || viewModel.SortViewModel.Current == SortState.StreetAsc
                || viewModel.SortViewModel.Current == SortState.StreetDesc)
                {
                viewModel.FilterViewModel.StyleTextStreet = "color:blue";
            }
            if(viewModel.FilterViewModel.SelectedHouseNumber != null || viewModel.SortViewModel.Current == SortState.HouseNumberAsc
                || viewModel.SortViewModel.Current == SortState.HouseNumberDesc)
                {
                viewModel.FilterViewModel.StyleTextHouseNumber = "color:blue";
            }
            if(viewModel.FilterViewModel.SelectedZipCode != null||viewModel.SortViewModel.Current==SortState.ZipCodeAsc
                ||viewModel.SortViewModel.Current==SortState.ZipCodeDesc)
                {
                viewModel.FilterViewModel.StyleTextZipCode = "color:blue";
            }
            if(viewModel.FilterViewModel.SelectedCreationDateTime != null || viewModel.SortViewModel.Current == SortState.CreationDateTimeAsc
                || viewModel.SortViewModel.Current == SortState.CreationDateTimeDesc)
                {
                viewModel.FilterViewModel.StyleTextCreationDateTime = "color:blue";
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            return LocalRedirect(returnUrl);
                }
        
        //{
        //    var data = await db.Addresses.Take(rowPerPage).ToListAsync();
        //    return View(data);
        //}

        //public async Task<IActionResult> Index(int page)
        //{
        //    var data = await db.Addresses.Skip((page - 1) * rowPerPage)
        //                                 .Take(rowPerPage).ToListAsync();
        //    return View(data);
        //}

        
    }
}
