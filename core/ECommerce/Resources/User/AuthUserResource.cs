using System.ComponentModel.DataAnnotations;

namespace ECommerce.Resources.User
{
    public class AuthUserResource
    {
        [Required]
        [MaxLength(45)]
        public string Email { get; set; }
        
        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; }
    }
}