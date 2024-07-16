using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Server.Services.ProductDataServices;

namespace SpolemMusic.Controllers.ProductDataControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        public FormatsService _formatsService;

        public FormatsController(FormatsService formatsService)
        {
            _formatsService = formatsService;
        }

        [HttpGet("get-formats")]
        public IActionResult GetFormats()
        {
            var formats = _formatsService.GetFormats();
            return Ok(formats);
        }

        [HttpPost("add-format")]
        public IActionResult AddFormat([FromBody] FormatDTO format)
        {
            try
            {
                _formatsService.AddFormat(format);
                return Created(nameof(AddFormat), "Utworzono");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-format/{id}")]
        public IActionResult UpdateFormat([FromBody] FormatDTO format, int id)
        {
            _formatsService.UpdateFormat(format, id);
            return Ok(format);
        }

        [HttpDelete("delete-format/{id}")]
        public IActionResult DeleteFormat(int id)
        {
            try
            {
                _formatsService.DeleteFormat(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
