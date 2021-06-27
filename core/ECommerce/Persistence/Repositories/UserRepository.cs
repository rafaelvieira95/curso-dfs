using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class UserRepository: BaseRepository, IUserRepository
    {
        private readonly DataAppContext _context;
        
        public UserRepository(DataAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            
            var userWithPurchases =  _context.Users.Include(user => user.Purchases).AsNoTracking();
            return await userWithPurchases.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> FirstOrDefaultAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}