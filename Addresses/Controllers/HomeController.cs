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

        public async Task<IActionResult> Index(SortState sortOrder = SortState.NoSort)
        {
            IQueryable<Address> addresses = db.Addresses.Take(rowPerPage);
            ViewData["CountrySort"] = sortOrder == SortState.CountryAsc ? SortState.CountryDesc : SortState.CountryAsc;
            ViewData["CitySort"] = sortOrder == SortState.CityAsc ? SortState.CityDesc : SortState.CityAsc;
            ViewData["StreetSort"] = sortOrder == SortState.StreetAsc ? SortState.StreetDesc : SortState.StreetAsc;
            ViewData["HouseNumberSort"] = sortOrder == SortState.HouseNumberAsc ? SortState.HouseNumberDesc : SortState.HouseNumberAsc;
            ViewData["ZipCodeSort"] = sortOrder == SortState.ZipCodeAsc ? SortState.ZipCodeDesc : SortState.ZipCodeAsc;
            ViewData["CreationDateTime"] = sortOrder == SortState.CreationDateTimeAsc ? SortState.CreationDateTimeDesc : SortState.CreationDateTimeAsc;

            switch (sortOrder)
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

                    return View(await addresses.AsNoTracking().ToListAsync());
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
