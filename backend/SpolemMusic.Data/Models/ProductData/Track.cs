using SpolemMusic.Data.Models.JoinTables;
using System.ComponentModel.DataAnnotations;
namespace SpolemMusic.Data.Models.ProductData
{
    public class Track
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public int TrackNumber { get; set; }
        public int Length { get; set; }
        public ICollection<ArtistTrack> TrackArtists { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
