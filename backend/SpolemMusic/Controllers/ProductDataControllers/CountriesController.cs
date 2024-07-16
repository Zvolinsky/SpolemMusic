using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Server.Services.ProductDataServices;

namespace SpolemMusic.Controllers.ProductDataControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        public CountriesService _countriesService;

        public CountriesController(CountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet("get-countries")]
        public IActionResult GetCountries()
        {
            var countries = _countriesService.GetCountries();
            return Ok(countries);
        }

        [HttpPost("add-country")]
        public IActionResult AddCountry([FromBody] CountryDTO country)
        {
            try
            {
                _countriesService.AddCountry(country);
                return Created(nameof(AddCountry), "Utworzono");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-country/{id}")]
        public IActionResult UpdateCountry([FromBody] CountryDTO country, int id)
        {
            _countriesService.UpdateCountry(country, id);
            return Ok(country);
        }

        [HttpDelete("delete-country/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            try
            {
                _countriesService.DeleteCountry(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
