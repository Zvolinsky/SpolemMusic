using System.ComponentModel.DataAnnotations;

namespace SpolemMusic.Data.DTOs
{
    public class ClientDTO
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required byte[] PasswordHash { get; set; }
        
    }
}
