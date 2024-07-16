using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Data.DTOs.ProductDataDTOs;
using SpolemMusic.Server.Services.ProductDataServices;

namespace SpolemMusic.Controllers.ProductDataControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        public LabelsService _labelsService;

        public LabelsController(LabelsService labelsService)
        {
            _labelsService = labelsService;
        }

        [HttpGet("get-labels")]
        public IActionResult GetLabels()
        {
            var labels = _labelsService.GetLabels();
            return Ok(labels);
        }

        [HttpPost("add-label")]
        public IActionResult AddLabel([FromBody] LabelDTO label)
        {
            try
            {
                _labelsService.AddLabel(label);
                return Created(nameof(AddLabel), "Utworzono");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-label/{id}")]
        public IActionResult UpdateLabel([FromBody] LabelDTO label, int id)
        {
            _labelsService.UpdateLabel(label, id);
            return Ok(label);
        }

        [HttpDelete("delete-label/{id}")]
        public IActionResult DeleteLabel(int id)
        {
            try
            {
                _labelsService.DeleteLabel(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
