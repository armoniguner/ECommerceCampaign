using ECommerceCampaign.Business.Business;
using ECommerceCampaign.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCampaign.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private CampaignManager campaignManager;
        public CampaignController()
        {
            campaignManager = new CampaignManager();
        }

        [HttpGet]
        public IActionResult GetCampaigns()
        {
            return Ok(campaignManager.GetAll());
        }

        [HttpPost]
        public IActionResult SaveCampaign(Campaign product)
        {
            campaignManager.SaveCampaign(product);
            return Ok();
        }
    }
}
