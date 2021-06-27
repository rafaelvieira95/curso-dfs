using System.Collections.Generic;
using ECommerce.Domain.Models;
using ECommerce.Resources.Product;

namespace ECommerce.Resources.Company
{
    public class CompanyResource
    {
        public int Id { get; set; }
        public string FantasyName { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public IList<ProductResource> Products { get; set; }
    }
}