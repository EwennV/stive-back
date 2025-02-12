using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StiveBack.Models;
using StiveBack.Ressources;

using StiveBack.Services;

namespace StiveBack.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController: ControllerBase
    {
        private OrderService _orderService;
        private UserService _userService;

        public OrderController(OrderService orderService, UserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            OrderRessource? order = _orderService.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll() 
        {
            List<OrderRessource> orders;

            orders = _orderService.Get();

            return Ok(orders);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(OrderSaveRessource orderSaveRessource)
        {
            var user = _userService.GetUserFromSecurityUserAsync(User);

            if (user == null)
            {
                return BadRequest();
            }

            if (!User.IsInRole("Admin"))
            {
                orderSaveRessource.UserId = user.Id;
            }

            OrderRessource order = _orderService.Add(orderSaveRessource);

            return Ok(order);
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update(int id, [FromBody] OrderSaveRessource orderSaveRessource)
        {
            var user = _userService.GetUserFromSecurityUserAsync(User);

            if (user == null)
            {
                return BadRequest();
            }

            OrderRessource order = _orderService.GetById(id);

            if (order == null || (!User.IsInRole("Admin") && order.UserId != user.Id))
            {
                return NotFound();
            }

            if (!User.IsInRole("Admin"))
            {
                orderSaveRessource.UserId = user.Id;
            }

            order = _orderService.Modify(id, orderSaveRessource);

            return Ok(order);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Remove(int id)
        {
            var user = _userService.GetUserFromSecurityUserAsync(User);

            if (user == null)
            {
                return BadRequest();
            }

            OrderRessource order = _orderService.GetById(id);

            if (order == null || (!User.IsInRole("Admin") && order.UserId != user.Id)) {
                return NotFound();
            }

            _orderService.Delete(id);

            return Ok();
        }
    }
}