using Ecommerce.Server.Entites;

namespace Ecommerce.Server.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(int pageNumber, int pageSize);
        Task<Product> GetProductByIdAsync(int productId);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
        Task<int> GetTotalProductsAsync();
    }
}
