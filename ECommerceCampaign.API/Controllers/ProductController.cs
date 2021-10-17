using ECommerceCampaign.Business.Business;
using ECommerceCampaign.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCampaign.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductManager productManager;
        public ProductController()
        {
            productManager = new ProductManager();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productManager.GetAll());
        }

        [HttpPost]
        public IActionResult SaveProduct(Product product)
        {
            productManager.SaveProduct(product);
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            productManager.UpdateProduct(product);
            return Ok();
        }
    }
}
