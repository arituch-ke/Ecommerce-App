using Ecommerce.Server.Entites;
using Ecommerce.Server.Models;

namespace Ecommerce.Server.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductListViewModel> GetProductsAsync(int pageNumber, int pageSize);
        Task<Product> GetProductByIdAsync(int productId);
    }
}
