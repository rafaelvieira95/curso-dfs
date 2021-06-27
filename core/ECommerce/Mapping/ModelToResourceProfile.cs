using AutoMapper;
using ECommerce.Domain.Models;
using ECommerce.Resources;
using ECommerce.Resources.Company;
using ECommerce.Resources.Item;
using ECommerce.Resources.Product;
using ECommerce.Resources.Purchase;
using ECommerce.Resources.User;

namespace ECommerce.Mapping
{
    public class ModelToResourceProfile: Profile
    {

        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<Company, CompanyResource>();
            CreateMap<Purchase, PurchaseResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<Item, ItemResource>();
        }
    }
}