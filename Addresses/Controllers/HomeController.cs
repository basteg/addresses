using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Addresses.Models;
using Microsoft.EntityFrameworkCore;

namespace Addresses.Controllers
{
    public class HomeController : Controller
    {
        private AddressesContext db;

        const int rowPerPage = 100;
        int currentPage;
        int pagesCount;

        public HomeController(AddressesContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(SortState sortState = SortState.NoSort)
        {
            IQueryable<Address> addresses = db.Addresses.Take(rowPerPage);
            //ViewData["CountrySort"] = sortState == SortState.CountryAsc ? SortState.CountryDesc : SortState.CountryAsc;
            //ViewData["CitySort"] = sortState == SortState.CityAsc ? SortState.CityDesc : SortState.CityAsc;
            //ViewData["StreetSort"] = sortState == SortState.StreetAsc ? SortState.StreetDesc : SortState.StreetAsc;
            //ViewData["HouseNumberSort"] = sortState == SortState.HouseNumberAsc ? SortState.HouseNumberDesc : SortState.HouseNumberAsc;
            //ViewData["ZipCodeSort"] = sortState == SortState.ZipCodeAsc ? SortState.ZipCodeDesc : SortState.ZipCodeAsc;
            //ViewData["CreationDateTime"] = sortState == SortState.CreationDateTimeAsc ? SortState.CreationDateTimeDesc : SortState.CreationDateTimeAsc;

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

            IndexViewModel viewModel = new IndexViewModel
            {
                Addresses = await addresses.AsNoTracking().ToListAsync(),
                SortViewModel = new SortViewModel(sortState)
            };
                    return View(viewModel);
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
