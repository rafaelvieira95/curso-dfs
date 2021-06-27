using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Repositories
{
    public interface ICompanyRepository
    {
        public Task AddAsync(Company company);

        public void Update(Company company);

        public void Delete(Company company);

        public Task<Company> FindByIdAsync(int id);

        public Task<IEnumerable<Company>> ListAsync();

    }
}