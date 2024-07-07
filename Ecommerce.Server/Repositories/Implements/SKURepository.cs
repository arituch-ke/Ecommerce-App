using Ecommerce.Server.Entites;
using Ecommerce.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Server.Repositories.Implements
{
    public class SKURepository : ISKURepository
    {
        private readonly ApplicationDbContext _context;
        public SKURepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SKU>> GetSKUs()
        {
            return await _context.SKUs.ToListAsync();
        }

        public async Task<SKU> GetSKUById(int id)
        {
            return await _context.SKUs.FindAsync(id);
        }

        public async Task AddSKU(SKU sku)
        {
            await _context.SKUs.AddAsync(sku);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSKU(SKU sku)
        {
            _context.SKUs.Update(sku);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSKU(int id)
        {
            var sku = await _context.SKUs.FindAsync(id);
            if (sku != null)
            {
                _context.SKUs.Remove(sku);
                await _context.SaveChangesAsync();
            }
        }
    }
}
