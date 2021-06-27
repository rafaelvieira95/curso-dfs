using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class CompanyRepository: BaseRepository, ICompanyRepository
    {
        private readonly DataAppContext _context;
        
        public CompanyRepository(DataAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }

        public void Delete(Company company)
        {
            _context.Companies.Remove(company);
        }

        public async Task<Company> FindByIdAsync(int id)
        {
            var companyWithProducts = _context.Companies.Include(company => company.Products).AsNoTracking();
            return await companyWithProducts.FirstOrDefaultAsync(company => company.Id == id);
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            var companyWithProducts = _context.Companies.Include(company => company.Products).AsNoTracking();
            return await companyWithProducts.ToListAsync();
        }
    }
}