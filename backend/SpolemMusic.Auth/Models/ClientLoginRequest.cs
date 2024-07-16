using System.ComponentModel.DataAnnotations;

namespace SpolemMusic.Auth.Models
{
    public class ClientLoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
