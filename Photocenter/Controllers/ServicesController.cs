using Microsoft.AspNetCore.Mvc;
using Photocenter.Models.ViewModels;
using Photocenter.Services.Interfaces;

namespace Photocenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicesController : Controller
    {
        IServiceService _serviceService;
        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ServiceViewModel model)
        {
            var response = await _serviceService.CreateService(model);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _serviceService.DeleteService(id);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet("services")]
        public async Task<IActionResult> GetClients()
        {
            var response = await _serviceService.GetServices();
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        //Разобраться с методом
        [HttpGet("service")]
        public async Task<IActionResult> GetClient(int id)
        {
            var response = await _serviceService.GetService(id);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ServiceViewModel model)
        {
            var response = await _serviceService.EditService(id, model);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}

