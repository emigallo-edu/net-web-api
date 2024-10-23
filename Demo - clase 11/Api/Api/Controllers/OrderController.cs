using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using System.Diagnostics;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Debug.WriteLine("Hello");
            List<Order> orders = await this._orderRepository.GetAllAsync();
            return Ok(orders);
        }
    }
}