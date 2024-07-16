using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Server.Services.ProductDataServices;

namespace SpolemMusic.Controllers.ProductDataControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public GenresService _genresService;

        public GenresController(GenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet("get-genres")]
        public IActionResult GetGenres()
        {
            var genres = _genresService.GetGenres();
            return Ok(genres);
        }

        [HttpPost("add-genre")]
        public IActionResult AddGenre([FromBody] GenreDTO genre)
        {
            try
            {
                _genresService.AddGenre(genre);
                return Created(nameof(AddGenre), "Utworzono");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-genre/{id}")]
        public IActionResult UpdateGenre([FromBody] GenreDTO genre, int id)
        {
            _genresService.UpdateGenre(genre, id);
            return Ok(genre);
        }

        [HttpDelete("delete-genre/{id}")]
        public IActionResult DeleteGenre(int id)
        {
            try
            {
                _genresService.DeleteGenre(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
