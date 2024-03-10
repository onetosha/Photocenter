using Microsoft.AspNetCore.Mvc;
using Photocenter.Models.ViewModels;
using Photocenter.Services.Implementations;
using Photocenter.Services.Interfaces;

namespace Photocenter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        IOrderService _orderService;
        public OrdersController(IOrderService orderService) 
        {
            _orderService = orderService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] OrderViewModel model)
        {
            var response = await _orderService.CreateOrder(model);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _orderService.DeleteOrder(id);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet("orders")]
        public async Task<IActionResult> GetClients()
        {
            var response = await _orderService.GetOrders();
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        //Разобраться с методом
        [HttpGet("order")]
        public async Task<IActionResult> GetClient(int id)
        {
            var response = await _orderService.GetOrder(id);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(int id, [FromBody] OrderViewModel model)
        {
            var response = await _orderService.EditOrder(id, model);
            if (response.StatusCode == Models.Enums.StatusCode.OK)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
