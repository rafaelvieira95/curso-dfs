using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Repositories
{
    public interface IProductRepository
    {
        public Task AddAsync(Product product);

        public void Update(Product product);

        public void Delete(Product product);

        public Task<Product> FindByIdAsync(int id);

        public Task<IEnumerable<Product>> ListAsync();

    }
}