using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Data.DTOs;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Server.Services.ProductDataServices;

namespace SpolemMusic.Controllers.ProductDataControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        public ArtistsService _artistsService;

        public ArtistsController(ArtistsService artistsService)
        {
            _artistsService = artistsService;
        }

        [HttpGet("get-artists")]
        public IActionResult GetArtists()
        {
            var artists = _artistsService.GetArtists();
            return Ok(artists);
        }

        [HttpPost("add-artist")]
        public IActionResult AddArtist([FromBody] ArtistDTO artist)
        {
            try
            {
                _artistsService.AddArtist(artist);
                return Created(nameof(AddArtist), "Utworzono");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-artist/{id}")]
        public IActionResult UpdateArtist([FromBody] ArtistDTO artist, int id)
        {
            _artistsService.UpdateArtist(artist, id);
            return Ok(artist);
        }

        [HttpDelete("delete-artist/{id}")]
        public IActionResult DeleteArtist(int id)
        {
            try
            {
                _artistsService.DeleteArtist(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
