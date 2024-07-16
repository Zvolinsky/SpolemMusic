using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpolemMusic.Data.DTOs;
using SpolemMusic.Server.Services;

namespace SpolemMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public ClientsService _clientsService;

        public ClientsController(ClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpGet("get-clients")]
        public IActionResult GetClients()
        {
            var clients = _clientsService.GetClients();
            return Ok(clients);
        }

        [HttpPost("add-client")]
        public IActionResult AddClient([FromBody] ClientDTO client)
        {
            try
            {
                _clientsService.AddClient(client);
                return Created(nameof(AddClient), "Utworzono");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-client/{id}")]
        public IActionResult UpdateClient([FromBody] ClientDTO client, int id)
        {
            _clientsService.UpdateClient(client, id);
            return Ok(client);
        }

        [HttpDelete("delete-client/{id}")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                _clientsService.DeleteClient(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
