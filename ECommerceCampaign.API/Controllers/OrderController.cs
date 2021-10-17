using ECommerceCampaign.Business.Business;
using ECommerceCampaign.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCampaign.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderManager orderManager;
        public OrderController()
        {
            orderManager = new OrderManager();
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(orderManager.GetAll());
        }

        [HttpPost]
        public IActionResult SaveOrder(Order order)
        {
            orderManager.SaveOrder(order);
            return Ok();
        }
    }
}
