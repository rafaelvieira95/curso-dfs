using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services.Communication;

namespace ECommerce.Domain.Services
{
    public interface IItemService
    {
        public Task<IEnumerable<Item>> FindByPurchaseIdAsync(int id);
        
    }
}