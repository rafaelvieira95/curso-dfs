using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Resources.Product
{
    public  class SaveProductResource
    {
      
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(2048)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [MaxLength(1024)]
        public string Observation { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string ImageUri { get; set; }
    }
}
