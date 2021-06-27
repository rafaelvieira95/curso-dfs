using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using ECommerce.Domain.Services.Communication;

namespace ECommerce.Services
{
    public class CompanyService: ICompanyService
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly IUnityOfWork _unityOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUnityOfWork unityOfWork)
        {
            _companyRepository = companyRepository;
            _unityOfWork = unityOfWork;
        }
        
        public async Task<CompanyResponse> SaveAsync(Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                await _unityOfWork.CompleteAsync();

                return new CompanyResponse(company);
            }
            catch (Exception e)
            {
                return new CompanyResponse($"An error occurred {e.Message}");
            }
        }

        
        public async Task<CompanyResponse> UpdateAsync(int id, Company company)
        {
            try
            {
                var _company = await _companyRepository.FindByIdAsync(id);

                if (company == null) return new CompanyResponse($"this company doesn't exists by id {id}");

                _company.FantasyName = company.FantasyName;
                _company.CorporateName = company.CorporateName;
                _company.Cnpj = company.Cnpj;
                _company.Products = company.Products;

                 _companyRepository.Update(_company);
                 await _unityOfWork.CompleteAsync();
                 return new CompanyResponse(_company);
            }
            catch (Exception e)
            {
                return new CompanyResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<CompanyResponse> DeleteAsync(int id)
        {
            try
            {
                var company = await _companyRepository.FindByIdAsync(id);
                if (company == null) return new CompanyResponse($"this company doesn't exists by id {id}");
                
                _companyRepository.Delete(company);
                await _unityOfWork.CompleteAsync();
                return new CompanyResponse(company);
            }
            catch (Exception e)
            {
                return new CompanyResponse($"An error occurred {e.Message}");
            }
        }

        public async Task<Company> FindByIdAsync(int id)
        {
            return await _companyRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _companyRepository.ListAsync();
        }
    }
}