using Deco_Sara.Models;
using Deco_Sara.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

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
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            var (orders, totalCount) = await _orderService.GetAllOrdersAsync(page, pageSize);

            var response = new
            {
                data = orders.Select(v => new
                {
                    v.Order_ID,
                    v.Order_deadlinedate,
                    v.Order_allowance,
                    v.Order_allowance_status,
                    v.Order_date,
                    v.Order_payment_status,
                    v.Order_status,
                    v.Order_description,
                    v.TotalCost,
                    
                    Customer = new
                    {
                       v.user.Address,
                       v.user.Name,
                       v.user.Email,
                       v.user.LastUpdatedTime,
                       v.User_ID
                        , // Add any other customer properties you need
                    },
                    OrderItems = v.Orderitems.Select(oi => new
                    {
                        oi.Order_ID,
                        oi.Product_ID,
                        oi.quantity
                    }),
                }),

                totalItems = totalCount,
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                currentPage = page
            };

            return Ok(response);
        }


        [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var order = await _orderService.GetByIdAsync(id);
                if (order == null) return NotFound();
                return Ok(order);
            }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Orderrequest request)
        {
            if (request == null || request.orderitems?.Count == 0 || request.order == null)
                return BadRequest("Invalid order data");

            var orderId = await _orderService.AddAsync(request.User_ID, request.orderitems, request.order);
            return Ok(new { OrderId = orderId, Message = "Order created successfully" });
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
        [HttpGet("orders/{customerId}")]
        public async Task<IActionResult> GetAllOrdersForCustomer(int customerId)
        {
            var orders = await _orderService.GetAllOrdersForCustomerAsync(customerId);
            return Ok(orders);
        }

        [HttpGet("orderscount/{customerId}")]
        public async Task<IActionResult> GetOrdersCount(int customerId)
        {
            var pendingCount = await _orderService.GetPendingOrdersCountAsync(customerId);
            var newCount = await _orderService.GetNewOrdersCountAsync(customerId);
            var completedCount = await _orderService.GetCompletedOrdersCountAsync(customerId);

            var result = new
            {
                Pending = pendingCount,
                New = newCount,
                Completed = completedCount
            };

            return Ok(result);
        }

        [HttpGet("orderscount")]
        public async Task<IActionResult> GetAllOrdersCount()
        {
            var pendingCount = await _orderService.GetPendingOrdersCountAsync();
            var newCount = await _orderService.GetNewOrdersCountAsync();
            var completedCount = await _orderService.GetCompletedOrdersCountAsync();

            var result = new
            {
                Pending = pendingCount,
                New = newCount,
                Completed = completedCount
            };

            return Ok(result);
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
