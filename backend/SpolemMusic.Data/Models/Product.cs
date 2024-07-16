using SpolemMusic.Data.Models.JoinTables;
using SpolemMusic.Data.Models.ProductData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpolemMusic.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public ICollection<ArtistProduct> ProductArtists { get; set; }
        public int? FormatId { get; set; }
        public Format? Format { get; set; }
        public int? GenreId { get; set; }
        public  Genre? Genre { get; set; }
        [Range(1900, 2100)]
        public int? Year { get; set; }
        public int? CountryId { get; set; }
        public  Country? Country { get; set; }
        public string? Description { get; set; }
        public ICollection<Track> Tracklist { get; set; }
        [Required]
        public int LabelId { get; set; }
        public Label Label { get; set; }
        [Required]
        public required string CatalogueNum { get; set; }

        public string? CoverImage { get; set; }

        public string? PreviewMusic { get; set; }

        [Required]
        public required float Price { get; set; }
        [Required]
        public required int CountInStock { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
