using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ECommerce.Persistence.Repositories
{
    public class PurchaseRepository: BaseRepository, IPurchaseRepository
    {
        private readonly DataAppContext _context;
        
        public PurchaseRepository(DataAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Purchase purchase)
        {
            await _context.Purchases.AddAsync(purchase);
            
        }

        public void Update(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
        }

        public void Delete(Purchase purchase)
        {
            _context.Purchases.Remove(purchase);
        }

        public async Task<Purchase> FindByIdAsync(int id)
        {
            var purchasesWithCart = _context.Purchases.Include(p => p.Items).AsNoTracking();

            return await purchasesWithCart.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Purchase>> ListAsync()
        {
            return await _context.Purchases.ToListAsync();
        }
    }
}