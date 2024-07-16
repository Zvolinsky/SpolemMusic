using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Data.Models.JoinTables
{
    public class ArtistTrack
    {
        public int ArtistId { get; set; }
        public int TrackId { get; set; }
        public Artist Artist { get; set; }
        public Track Track { get; set; }
    }
}
