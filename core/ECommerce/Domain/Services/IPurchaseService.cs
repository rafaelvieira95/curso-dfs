using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services.Communication;
using ECommerce.Resources;

namespace ECommerce.Domain.Services
{
    public interface IPurchaseService
    {
        public Task<PurchaseResponse> SaveAsync(Purchase purchase);

        public Task<PurchaseResponse> UpdateAsync(int id, Purchase purchase);

        public Task<PurchaseResponse> DeleteAsync(int id);

        public Task<Purchase> FindByIdAsync(int id);

        public Task<IEnumerable<Purchase>> ListAsync();
    }
}