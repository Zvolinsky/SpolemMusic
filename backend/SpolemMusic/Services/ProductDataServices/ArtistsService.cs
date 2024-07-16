using SpolemMusic.Data;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Server.Services.ProductDataServices
{
    public class ArtistsService
    {
        private AppDBContext _context;

        public ArtistsService(AppDBContext context) { _context = context; }

        public List<Artist> GetArtists()
        {
            var artists = _context.Artists.ToList();
            return artists;
        }

        public Artist AddArtist(ArtistDTO artist)
        {
            var _artist = new Artist()
            {
                Name = artist.Name,
            };
            _context.Artists.Add(_artist);
            _context.SaveChanges();

            return _artist;
        }

        public void UpdateArtist(ArtistDTO artist, int id)
        {
            var _artist = _context.Artists.FirstOrDefault(c => c.Id == id);
            if (_artist != null)
            {
                _artist.Name = artist.Name;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }

        public void DeleteArtist(int id)
        {
            var _artist = _context.Artists.FirstOrDefault(c => c.Id == id);
            if (_artist != null)
            {
                _context.Artists.Remove(_artist);
            }
            else
            {
                throw new Exception("Nie znaleziono");
            };
        }
    }
}
