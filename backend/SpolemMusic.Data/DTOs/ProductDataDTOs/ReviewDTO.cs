namespace SpolemMusic.Data.DTOs.ProductDataDTOs
{
    public class ReviewDTO
    {
        public int Rate { get; set; }
        public string? Comment { get; set; }
        public int ProductId { get; set; }
    }
}
