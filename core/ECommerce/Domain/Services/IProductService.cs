using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services.Communication;

namespace ECommerce.Domain.Services
{
    public interface IProductService
    {
        public Task<ProductResponse> SaveAsync(Product product);

        public Task<ProductResponse> UpdateAsync(int id, Product product);

        public Task<ProductResponse> DeleteAsync(int id);

        public Task<Product> FindByIdAsync(int id);

        public Task<IEnumerable<Product>> ListAsync();

    }
}