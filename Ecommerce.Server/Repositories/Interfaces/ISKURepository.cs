using Ecommerce.Server.Entites;

namespace Ecommerce.Server.Repositories.Interfaces
{
    public interface ISKURepository
    {
        Task<IEnumerable<SKU>> GetSKUs();
        Task<SKU> GetSKUById(int id);
        Task AddSKU(SKU sku);
        Task UpdateSKU(SKU sku);
        Task DeleteSKU(int id);
    }
}
