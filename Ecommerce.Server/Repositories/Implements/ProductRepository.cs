using Ecommerce.Server.Entites;
using Ecommerce.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Server.Repositories.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(int pageNumber, int pageSize)
        {
            return await _context.Products
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products
                                 .Include(p => p.SKUs)
                                 .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetTotalProductsAsync()
        {
            return await _context.Products.CountAsync();
        }
    }
}
