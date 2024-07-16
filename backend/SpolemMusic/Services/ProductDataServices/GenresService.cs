using SpolemMusic.Data;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Server.Services.ProductDataServices
{
    public class GenresService
    {
        private AppDBContext _context;

        public GenresService(AppDBContext context) { _context = context; }

        public List<Genre> GetGenres()
        {
            var genres = _context.Genres.ToList();
            return genres;
        }

        public Genre AddGenre(GenreDTO genre)
        {
            var _genre = new Genre()
            {
                Name = genre.Name,
            };
            _context.Genres.Add(_genre);
            _context.SaveChanges();

            return _genre;
        }

        public void UpdateGenre(GenreDTO genre, int id)
        {
            var _genre = _context.Genres.FirstOrDefault(c => c.Id == id);
            if (_genre != null)
            {
                _genre.Name = genre.Name;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }

        public void DeleteGenre(int id)
        {
            var _genre = _context.Genres.FirstOrDefault(c => c.Id == id);
            if (_genre != null)
            {
                _context.Genres.Remove(_genre);
            }
            else
            {
                throw new Exception("Nie znaleziono");
            };
        }
    }
}
