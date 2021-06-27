using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Resources.User
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        [Required]
        [MaxLength(45)]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Number of document invalid!.")]
        public string Cpf { get; set; }
    } 
}