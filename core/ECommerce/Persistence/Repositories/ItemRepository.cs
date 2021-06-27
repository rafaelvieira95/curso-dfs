using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class ItemRepository: BaseRepository , IItemRepository
    {
        private readonly DataAppContext _context;
        
        public ItemRepository(DataAppContext context) : base(context)
        {
            _context = context;
        }
        
        
        public async Task<IEnumerable<Item>> FindByPurchaseIdAsync(int id)
        {
            var itemsByPurchase = _context.Items.Include(p => p.Product).AsNoTracking();
            var items = await itemsByPurchase.ToListAsync();
            return items.FindAll(p => p.PurchaseId == id);
        }

   
    }
}