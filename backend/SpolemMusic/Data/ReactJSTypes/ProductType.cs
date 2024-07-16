using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Data.ReactJSTypes
{
    public class ProductType
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public List<string>? Artists { get; set; }
        public string? Format { get; set; }
        public required string Genre { get; set; }
        public int? Year { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public List<TrackType> Tracklist { get; set; }
        public string Label { get; set; }
        public required string CatalogueNum { get; set; }
        public string? CoverImage { get; set; }
        public string? PreviewMusic { get; set; }
        public required float Price { get; set; }
        public required int CountInStock { get; set; }
        public List<ReviewType>? Reviews { get; set; }


    }
}
