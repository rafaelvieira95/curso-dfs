using System;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Services.Communication
{
    public class CompanyResponse: BaseResponse
    {
        public Company Company { get; private set; }
        
        public CompanyResponse(string message, bool success, Company company) : base(message, success)
        {
            Company = company;
        }

        public CompanyResponse(Company company) : this(String.Empty, true, company)
        {
            
        }

        public CompanyResponse(string message) : this(message, false, null)
        {
            
        }
        
    }
}