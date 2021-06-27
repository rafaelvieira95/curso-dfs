using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models;
using ECommerce.Domain.Services;
using ECommerce.Resources.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [EnableCors("ecommerce-policy")]
    [Route("/api/ecommerce/items")]
    [Authorize]
    public class ItemController: ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var items = await _itemService.FindByPurchaseIdAsync(id);
            var resource = _mapper.Map<IEnumerable<Item>, IEnumerable<ItemResource>>(items);
            return Ok(resource);
        }

    }
}