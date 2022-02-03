using System.ComponentModel.DataAnnotations;

namespace SahaBT.Shared.Pagination
{
    public class PagingParameters
    {
        public int maxPageSize = 50;

        public int PageNumber { get; set; } = 1;

        public int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
