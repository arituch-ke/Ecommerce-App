using Ecommerce.Server.Entites;
using Ecommerce.Server.Models;
using Ecommerce.Server.Repositories.Interfaces;
using Ecommerce.Server.Services.Interfaces;

namespace Ecommerce.Server.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductListViewModel> GetProductsAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1) {
                throw new ArgumentException("PageNumber and PageSize must be greater than 0");
            }

            var products = await _productRepository.GetAllProductsAsync(pageNumber, pageSize);
            var totalProducts = await _productRepository.GetTotalProductsAsync();

            var productListViewModel = new ProductListViewModel
            {
                Products = products,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalProducts = totalProducts
            };

            return productListViewModel;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            if (productId <= 0) {
                throw new ArgumentException("ProductId is Required");
            }

            var product = await _productRepository.GetProductByIdAsync(productId);

            if (product == null) {
                throw new KeyNotFoundException($"Product with Id {productId} not found");
            }

            return product; 
        }
    }
}
