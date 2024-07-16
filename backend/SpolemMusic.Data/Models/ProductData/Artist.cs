using SpolemMusic.Data.Models.JoinTables;
using System.ComponentModel.DataAnnotations;

namespace SpolemMusic.Data.Models.ProductData
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }
        public ICollection<ArtistTrack> ArtistTracks { get; set; }
        public ICollection<ArtistProduct> ArtistProducts { get; set; }
    }
}
