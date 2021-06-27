using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Repositories
{
    public interface IItemRepository
    {
        
        public Task<IEnumerable<Item>> FindByPurchaseIdAsync(int id);

    }
}