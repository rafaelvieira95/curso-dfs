using System.ComponentModel.DataAnnotations;

namespace ECommerce.Resources.Company
{
    public  class SaveCompanyResource
    {
        
        [Required]
        [MaxLength(45)]
        public string FantasyName { get; set; }
        [Required]
        [MaxLength(45)]
        public string CorporateName { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{14}$",ErrorMessage = "Number of document invalid!.")]
        public string Cnpj { get; set; }
    }
}