using System.ComponentModel.DataAnnotations;

namespace SpolemMusic.Data.Models.ProductData
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
