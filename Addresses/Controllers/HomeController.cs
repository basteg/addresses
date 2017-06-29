using Addresses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Addresses.Controllers
{
    public class HomeController : Controller
    {
        const int pageSize = 100;

        private AddressesContext db;

        public HomeController(AddressesContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(string countryFilter, string cityFilter, string streetFilter,
            string houseNumberFilter, string zipCodeFilter, string creationDataTimeFilter, int? page, SortState sortState = SortState.NoSort)
        {
            var addresses = ApplyFilters(countryFilter, cityFilter, streetFilter,
                                         houseNumberFilter, zipCodeFilter, creationDataTimeFilter);

            ViewData["CountrySort"] = sortState == SortState.CountryAsc ? SortState.CountryDesc : SortState.CountryAsc;
            ViewData["CitySort"] = sortState == SortState.CityAsc ? SortState.CityDesc : SortState.CityAsc;
            ViewData["StreetSort"] = sortState == SortState.StreetAsc ? SortState.StreetDesc : SortState.StreetAsc;
            ViewData["HouseNumberSort"] = sortState == SortState.HouseNumberAsc ? SortState.HouseNumberDesc : SortState.HouseNumberAsc;
            ViewData["ZipCodeSort"] = sortState == SortState.ZipCodeAsc ? SortState.ZipCodeDesc : SortState.ZipCodeAsc;
            ViewData["CreationDateTime"] = sortState == SortState.CreationDateTimeAsc ? SortState.CreationDateTimeDesc : SortState.CreationDateTimeAsc;

            addresses = ApplySort(addresses, sortState);

            var viewModel = await CreateViewModel(addresses, page,
                    new FilterViewModel(countryFilter, cityFilter, streetFilter,
                                        houseNumberFilter, zipCodeFilter, creationDataTimeFilter),
                    sortState);
                
             ApplyAllotment(viewModel);
                
            return View(viewModel);
        }

        private async Task<IndexViewModel> CreateViewModel(IQueryable<Address> addresses, int? page, 
                                                     FilterViewModel filter, SortState sortState)
        {
            int pageIndex = page ?? 1;
            var count = await addresses.CountAsync();

            var addressesForPage = await addresses.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            var items = new StaticPagedList<Address>(addressesForPage, pageIndex, pageSize, count);

            var viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, pageIndex, pageSize),
                FilterViewModel = filter,
                SortViewModel = new SortViewModel(sortState),
                Addresses = items,
                NoFilterViewModel = new NoFilterViewModel(null, null, null, null, null, null)
            };

            return viewModel;
        }

        private void ApplyAllotment(IndexViewModel viewModel)
        {
            if (viewModel.FilterViewModel.SelectedCountry != null || viewModel.SortViewModel.Current == SortState.CountryAsc
                || viewModel.SortViewModel.Current == SortState.CountryDesc)
            {
                viewModel.FilterViewModel.StyleTextCountry = "color:blue";
            }
            if (viewModel.FilterViewModel.SelectedCity != null || viewModel.SortViewModel.Current == SortState.CityAsc
                || viewModel.SortViewModel.Current == SortState.CityDesc)
            {
                viewModel.FilterViewModel.StyleTextCity = "color:blue";
            }
            if (viewModel.FilterViewModel.SelectedStreet != null || viewModel.SortViewModel.Current == SortState.StreetAsc
                  || viewModel.SortViewModel.Current == SortState.StreetDesc)
            {
                viewModel.FilterViewModel.StyleTextStreet = "color:blue";
            }
            if (viewModel.FilterViewModel.SelectedHouseNumber != null || viewModel.SortViewModel.Current == SortState.HouseNumberAsc
                || viewModel.SortViewModel.Current == SortState.HouseNumberDesc)
            {
                viewModel.FilterViewModel.StyleTextHouseNumber = "color:blue";
            }
            if (viewModel.FilterViewModel.SelectedZipCode != null || viewModel.SortViewModel.Current == SortState.ZipCodeAsc
                || viewModel.SortViewModel.Current == SortState.ZipCodeDesc)
            {
                viewModel.FilterViewModel.StyleTextZipCode = "color:blue";
            }
            if (viewModel.FilterViewModel.SelectedCreationDateTime != null || viewModel.SortViewModel.Current == SortState.CreationDateTimeAsc
                || viewModel.SortViewModel.Current == SortState.CreationDateTimeDesc)
            {
                viewModel.FilterViewModel.StyleTextCreationDateTime = "color:blue";
            }
        }

        private IQueryable<Address> ApplySort(IQueryable<Address> addresses, SortState sortState)
        {
            IQueryable<Address> sortedAssresses;

            switch (sortState)
            {
                case SortState.CountryAsc:
                    sortedAssresses = addresses.OrderBy(s => s.Country);
                    break;
                case SortState.CountryDesc:
                    sortedAssresses = addresses.OrderByDescending(s => s.Country);
                    break;
                case SortState.CityAsc:
                    sortedAssresses = addresses.OrderBy(s => s.City);
                    break;
                case SortState.CityDesc:
                    sortedAssresses = addresses.OrderByDescending(s => s.City);
                    break;
                case SortState.StreetAsc:
                    sortedAssresses = addresses.OrderBy(s => s.Street);
                    break;
                case SortState.StreetDesc:
                    sortedAssresses = addresses.OrderByDescending(s => s.Street);
                    break;
                case SortState.HouseNumberAsc:
                    sortedAssresses = addresses.OrderBy(s => s.HouseNumber);
                    break;
                case SortState.HouseNumberDesc:
                    sortedAssresses = addresses.OrderByDescending(s => s.HouseNumber);
                    break;
                case SortState.ZipCodeAsc:
                    sortedAssresses = addresses.OrderBy(s => s.ZipCode);
                    break;
                case SortState.ZipCodeDesc:
                    sortedAssresses = addresses.OrderByDescending(s => s.ZipCode);
                    break;
                case SortState.CreationDateTimeAsc:
                    sortedAssresses = addresses.OrderBy(s => s.CreationDateTime);
                    break;
                case SortState.CreationDateTimeDesc:
                    sortedAssresses = addresses.OrderByDescending(s => s.CreationDateTime);
                    break;
                default:
                    sortedAssresses = addresses.OrderBy(s => s.Id);
                    break;
            }

            return sortedAssresses;
        }
        
        IQueryable<Address> ApplyFilters(string countryFilter, string cityFilter, string streetFilter,
               string houseNumberFilter, string zipCodeFilter, string creationDataTimeFilter)
        {
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

            return addresses;
        }


        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return LocalRedirect(returnUrl);
        }
    }
}
