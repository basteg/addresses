namespace Addresses.Models
{
    public class PageViewModel
    {
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
