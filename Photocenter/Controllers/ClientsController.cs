using Microsoft.AspNetCore.Mvc;
using Photocenter.Models.Entities;
using Photocenter.Models.ViewModels;
using Photocenter.Services.Interfaces;

namespace Photocenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ClientViewModel model)
        {
            var response = await _clientService.CreateClient(model);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _clientService.DeleteClient(id);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet("clients")]
        public async Task<IActionResult> GetClients()
        {
            var response = await _clientService.GetClients();
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        //Разобраться с методом
        [HttpGet("client")]
        public async Task<IActionResult> GetClient(int id)
        {
            var response = await _clientService.GetClient(id);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(int id, [FromBody] ClientViewModel model)
        {
            var response = await _clientService.EditClient(id, model);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
