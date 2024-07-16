using SpolemMusic.Data.Models.ProductData;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpolemMusic.Data.DTOs
{
    public class ProductDTO
    {
        public required string Name { get; set; }
        public int? FormatId { get; set; }
        public int? GenreId { get; set; }
        public int? Year { get; set; }
        public int? CountryId { get; set; }
        public string? Description { get; set; }
        public int LabelId { get; set; }
        public required string CatalogueNum { get; set; }

        public string? CoverImage { get; set; }

        public string? PreviewMusic { get; set; }

        public required float Price { get; set; }
        public required int CountInStock { get; set; }
    }
}
