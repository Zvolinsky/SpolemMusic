using SpolemMusic.Data;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Data.Models.JoinTables;
using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Server.Services.JoinTables
{
    public class ArtistsTracksService
    {
        private AppDBContext _context;

        public ArtistsTracksService(AppDBContext context) { _context = context; }

        public List<ArtistTrack> GetArtistsTracks()
        {
            var artistsTracks = _context.ArtistsTracks.ToList();
            return artistsTracks;
        }

    }
}
