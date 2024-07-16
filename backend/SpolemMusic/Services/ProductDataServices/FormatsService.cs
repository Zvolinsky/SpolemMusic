using SpolemMusic.Data;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Server.Services.ProductDataServices
{
    public class FormatsService
    {
        private AppDBContext _context;

        public FormatsService(AppDBContext context) { _context = context; }

        public List<Format> GetFormats()
        {
            var formats = _context.Formats.ToList();
            return formats;
        }

        public Format AddFormat(FormatDTO format)
        {
            var _format = new Format()
            {
                Name = format.Name,
            };
            _context.Formats.Add(_format);
            _context.SaveChanges();

            return _format;
        }

        public void UpdateFormat(FormatDTO format, int id)
        {
            var _format = _context.Formats.FirstOrDefault(c => c.Id == id);
            if (_format != null)
            {
                _format.Name = format.Name;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }

        public void DeleteFormat(int id)
        {
            var _format = _context.Formats.FirstOrDefault(c => c.Id == id);
            if (_format != null)
            {
                _context.Formats.Remove(_format);
            }
            else
            {
                throw new Exception("Nie znaleziono");
            };
        }
    }
}
