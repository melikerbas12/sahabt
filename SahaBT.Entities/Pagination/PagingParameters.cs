using System.ComponentModel.DataAnnotations;

namespace SahaBT.Service.Utilities.Pagination
{
    public class PagingParameters
    {
        public int maxPageSize = 50;
        [Required(ErrorMessage = "{0} boş geçilemez")]
        public int PageNumber { get; set; } = 1;
        public int _pageSize = 10;
        [Required(ErrorMessage = "{0} boş geçilemez")]
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
