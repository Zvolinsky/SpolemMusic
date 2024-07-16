using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Server.Services.ProductDataServices;

namespace SpolemMusic.Controllers.ProductDataControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        public TracksService _tracksService;

        public TracksController(TracksService tracksService)
        {
            _tracksService = tracksService;
        }

        [HttpGet("get-tracks")]
        public IActionResult GetTracks()
        {
            var tracks = _tracksService.GetTracks();
            return Ok(tracks);
        }

        [HttpPost("add-track")]
        public IActionResult AddTrack([FromBody] TrackDTO track)
        {
            try
            {
                _tracksService.AddTrack(track);
                return Created(nameof(AddTrack), "Utworzono");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-track/{id}")]
        public IActionResult UpdateTrack([FromBody] TrackDTO track, int id)
        {
            _tracksService.UpdateTrack(track, id);
            return Ok(track);
        }

        [HttpDelete("delete-track/{id}")]
        public IActionResult DeleteTrack(int id)
        {
            try
            {
                _tracksService.DeleteTrack(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
