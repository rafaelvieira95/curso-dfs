using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services.Communication;

namespace ECommerce.Domain.Services
{
    public interface IUserService
    {
        
        public Task<UserResponse> SaveAsync(User user);
        
        public Task<UserResponse> UpdateAsync(int id, User user);

        public Task<UserResponse> DeleteAsync(int id);
        
        public Task<User> FindByIdAsync(int id);

        public Task<User> FirstOrDefaultAsync(string email, string password);
        
        public Task<IEnumerable<User>> ListAsync();
        
    }
}