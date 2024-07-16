using SpolemMusic.Data;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Data.Models.ProductData;

namespace SpolemMusic.Server.Services.ProductDataServices
{
    public class CountriesService
    {
        private AppDBContext _context;

        public CountriesService(AppDBContext context) { _context = context; }

        public List<Country> GetCountries()
        {
            var countries = _context.Countries.ToList();
            return countries;
        }

        public Country AddCountry(CountryDTO country)
        {
            var _country = new Country()
            {
                Name = country.Name,
            };
            _context.Countries.Add(_country);
            _context.SaveChanges();

            return _country;
        }

        public void UpdateCountry(CountryDTO country, int id)
        {
            var _country = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (_country != null)
            {
                _country.Name = country.Name;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Nie znaleziono");
            }
        }

        public void DeleteCountry(int id)
        {
            var _country = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (_country != null)
            {
                _context.Countries.Remove(_country);
            }
            else
            {
                throw new Exception("Nie znaleziono");
            };
        }
    }
}
