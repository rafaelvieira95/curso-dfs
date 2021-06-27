using AutoMapper;
using ECommerce.Domain.Models;
using ECommerce.Resources.Company;
using ECommerce.Resources.Item;
using ECommerce.Resources.Product;
using ECommerce.Resources.Purchase;
using ECommerce.Resources.User;

namespace ECommerce.Mapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveCompanyResource, Company>();
            CreateMap<SavePurchaseResource, Purchase>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveItemResource, Item>();
            CreateMap<AuthUserResource, User>();
        }
    }
}