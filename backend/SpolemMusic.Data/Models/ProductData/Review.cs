using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpolemMusic.Data.Models.ProductData
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
        public string? Comment { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
