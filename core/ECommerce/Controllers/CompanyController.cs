using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services;
using ECommerce.Extensions;
using ECommerce.Resources.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [EnableCors("ecommerce-policy")]
    [Route("/api/ecommerce/companies")]
    [Authorize]
    public class CompanyController: ControllerBase
    {

        private readonly ICompanyService _service;
        private readonly IMapper _mapper;
        
        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<CompanyResource>> GetAllAsync()
        {
            var companies = await  _service.ListAsync();
            var resource = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
            return resource;
        }

        
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            var company = await _service.FindByIdAsync(id);
            if (company == null) return NoContent();
            var resource = _mapper.Map<Company, CompanyResource>(company);
            return Ok(resource);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCompanyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var company = _mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await _service.SaveAsync(company);

            if (!result.Success)
                return BadRequest();

            var userResource = _mapper.Map<Company, CompanyResource>(result.Company);
            
            return Ok(userResource);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompanyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var company = _mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await _service.UpdateAsync(id, company);

            if (!result.Success)
                return BadRequest();

            var companyResource = _mapper.Map<Company, CompanyResource>(result.Company);

            return Ok(companyResource);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            
            var result = await _service.DeleteAsync(id);

            if (!result.Success)
                return NoContent();

            var resource = _mapper.Map<Company, CompanyResource>(result.Company);
            
            return Ok(resource);
        }
        
    }
}