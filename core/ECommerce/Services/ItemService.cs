using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using ECommerce.Domain.Services.Communication;

namespace ECommerce.Services
{
    public class ItemService: IItemService
    {

        private readonly IItemRepository _itemRepository;
  

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
            
        }
        
        
        public async Task<IEnumerable<Item>> FindByPurchaseIdAsync(int id)
        {
            return await _itemRepository.FindByPurchaseIdAsync(id);
        }
        
    }
}