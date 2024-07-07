using Ecommerce.Server.Entites;

namespace Ecommerce.Server.Models
{
    public class ProductListViewModel
    {
        public required IEnumerable<Product> Products { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalProducts { get; set; }
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalProducts, PageSize));
    }
}
