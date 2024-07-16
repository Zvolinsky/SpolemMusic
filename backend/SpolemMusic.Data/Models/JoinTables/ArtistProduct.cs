using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Data.Models.JoinTables
{
    public class ArtistProduct
    {
        public int ArtistId { get; set; }
        public int ProductId { get; set; }
        public Artist Artist { get; set; }
        public Product Product { get; set; }
    }
}
