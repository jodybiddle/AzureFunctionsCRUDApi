using AzureFunctionsCRUDApi.Entities;
using AzureFunctionsCRUDApi.Interfaces;

namespace AzureFunctionsCRUDApi.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
    }
}