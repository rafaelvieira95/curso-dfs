using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services;
using ECommerce.Extensions;
using ECommerce.Resources.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [EnableCors("ecommerce-policy")]
    [Route("/api/ecommerce/products")]
    [Authorize]
    public class ProductController: ControllerBase
    {

        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _service.ListAsync();
            var resource = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            
            return Ok(resource);
        }

        
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            var product = await _service.FindByIdAsync(id);
            if (product == null) return NoContent();
            var resource = _mapper.Map<Product, ProductResource>(product);
            return Ok(resource);
        }

        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _service.SaveAsync(product);

            if (!result.Success)
                return BadRequest();

            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);

        }
        
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _service.UpdateAsync(id, product);
            

            if (!result.Success)
                return BadRequest();

            var productResource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(productResource);
        }

        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            
            if (!result.Success)
                return NotFound();
            
            var resource = _mapper.Map<Product, ProductResource>(result.Product);
            return Ok(resource);
        }
        
    }
}