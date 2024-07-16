using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Server.Services.JoinTables;

namespace SpolemMusic.Controllers.JoinTables
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsTracksController : ControllerBase
    {
        public ArtistsTracksService _aristsTracksService;

        public ArtistsTracksController(ArtistsTracksService artistsTracksService)
        {
            _aristsTracksService = artistsTracksService;
        }

        [HttpGet("get-artists-tracks")]
        public IActionResult GetArtistsTracks()
        {
            var artistsTracks = _aristsTracksService.GetArtistsTracks();
            return Ok(artistsTracks);
        }
    }
}
