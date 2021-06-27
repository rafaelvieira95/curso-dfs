using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services.Communication;

namespace ECommerce.Domain.Services
{
    public interface ICompanyService
    {

        public Task<CompanyResponse> SaveAsync(Company company);

        public Task<CompanyResponse> UpdateAsync(int id, Company company);

        public Task<CompanyResponse> DeleteAsync(int id);
        
        public Task<Company> FindByIdAsync(int id);

        public Task<IEnumerable<Company>> ListAsync();

    }
}