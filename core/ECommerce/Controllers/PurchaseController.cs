using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services;
using ECommerce.Extensions;
using ECommerce.Resources.Purchase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{   
    [EnableCors("ecommerce-policy")]
    [Route("/api/ecommerce/purchases")]
    [Authorize]
    public class PurchaseController: ControllerBase
    {

        private readonly IPurchaseService _purchaseService;
        private readonly IMapper _mapper;
      

        public PurchaseController(IPurchaseService purchaseService, IMapper mapper)
        {
            _purchaseService = purchaseService;
            _mapper = mapper;
          
        }
        
        
        [HttpGet]
        public async Task<IEnumerable<PurchaseResource>> GetAllAsync()
        {
            var purchases = await _purchaseService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseResource>>(purchases);
            return resource;
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var purchase = await _purchaseService.FindByIdAsync(id);
            if (purchase == null) return NoContent();

            var resource = _mapper.Map<Purchase, PurchaseResource>(purchase);

            return Ok(resource);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePurchaseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            Console.Write(resource.Items);
            var purchase = _mapper.Map<SavePurchaseResource, Purchase>(resource);

            var result = await _purchaseService.SaveAsync(purchase);

            if (!result.Success)
                return BadRequest();
            
            var purchaseResource = _mapper.Map<Purchase, PurchaseResource>(result.Purchase);
            return Ok(purchaseResource);

        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePurchaseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var purchase = _mapper.Map<SavePurchaseResource, Purchase>(resource);
            var result = await _purchaseService.UpdateAsync(id, purchase);

            if (!result.Success)
                return BadRequest();

            var purchaseResource = _mapper.Map<Purchase, PurchaseResource>(result.Purchase);
            return Ok(purchaseResource);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _purchaseService.DeleteAsync(id);

            if (!result.Success)
                return NoContent();

            var resource = _mapper.Map<Purchase, PurchaseResource>(result.Purchase);
            return Ok(resource);
        }

    }
}