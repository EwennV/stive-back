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

            if (User.IsInRole("Admin")) {
                orders = _orderService.Get();
            } else
            {
                orders = _orderService.GetByUser(User);
            }

            return Ok();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(OrderSaveRessource orderSaveRessource)
        {
            var user = _userService.GetUserFromSecurityUserAsync(User);

            return Ok(new {user = user});
        }
    }
}