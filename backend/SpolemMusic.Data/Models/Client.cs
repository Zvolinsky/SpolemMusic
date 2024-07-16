using System.ComponentModel.DataAnnotations;

namespace SpolemMusic.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Address { get; set; }
        [Required]
        public required string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        [Required]
        public required byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        
        public string? VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires {  get; set; }
    }
}
