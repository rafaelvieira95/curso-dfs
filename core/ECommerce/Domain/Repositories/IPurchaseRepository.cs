using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        public Task AddAsync(Purchase purchase);

        public void Update(Purchase purchase);

        public void Delete(Purchase purchase);

        public Task<Purchase> FindByIdAsync(int id);

        public Task<IEnumerable<Purchase>> ListAsync();
    }
}