using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addresses.Models
{
    public class PageViewModel
    {
        //public int PageNumber { get; set; }
        //public int TotalPages { get; set; }

        //public PageViewModel(int count, int pageNumber, int pageSize)
        //{
        //    PageNumber = pageNumber;
        //    TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        //}

        //public bool HasPreviousPage
        //{
        //    get
        //    {
        //        return (PageNumber > 1);
        //    }
        //}

        //public bool HasNextPage
        //{
        //    get
        //    {
        //        return (PageNumber < TotalPages);
        //    }
        //}
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            PageCount = count;
        }
    }
}
