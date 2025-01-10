using Deco_Sara.Models;
using Deco_Sara.Services;
using Microsoft.AspNetCore.Mvc;

namespace Deco_Sara.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class OrderController : ControllerBase
        {
            private readonly IOrderService _orderService;

            public OrderController(IOrderService orderService)
            {
                _orderService = orderService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var order = await _orderService.GetAllOrdersAsync();
                return Ok(order);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var order = await _orderService.GetByIdAsync(id);
                if (order == null) return NotFound();
                return Ok(order);
            }

            [HttpPost]
            public async Task<IActionResult> Add(Order order)
            {
                var newOrder = await _orderService.AddAsync(order);
                return CreatedAtAction(nameof(GetById), new { id = newOrder.Order_ID }, newOrder);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateOrder(int id, Order order)
            {
                var updatedOrder = await _orderService.UpdateAsync(id, order);

                if (updatedOrder == null)
                {
                    return NotFound();
                }

                return Ok(updatedOrder);
            }




            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _orderService.DeleteAsync(id);
                if (!result) return NotFound();
                return NoContent();
            }
        }
    
}
