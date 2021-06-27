using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Repositories
{
    public interface IUserRepository
    {

        public Task AddAsync(User user);
        
        void Update(User user);

        void Delete(User user);
        
        public Task<User> FindByIdAsync(int id);

        public Task<User> FirstOrDefaultAsync(string email, string password);

        public Task<IEnumerable<User>> ListAsync();
    }
}