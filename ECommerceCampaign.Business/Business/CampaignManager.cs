using ECommerceCampaign.Entity.Access;
using ECommerceCampaign.Entity.Models;
using System;
using System.Collections.Generic;

namespace ECommerceCampaign.Business.Business
{
    public class CampaignManager
    {
        private CampaignAccess campaignAccess;
        public CampaignManager()
        {
            campaignAccess = new CampaignAccess();
        }
        public List<Campaign> GetAll()
        {
            return campaignAccess.GetAllCampaign();
        }
        public List<Campaign> GetActiveCampaigns()
        {
            return campaignAccess.GetActiveCampaigns();
        }
        public void UpdateCampaign(Campaign campaign)
        {
            campaignAccess.UpdateCampaign(campaign);
        }
        public void SaveCampaign(Campaign campaign)
        {
            campaign.Ratio = Decimal.Round(Convert.ToDecimal(campaign.PriceManipulationLimit) / Convert.ToDecimal((campaign.Duration - 1)),2);
            campaign.CreatedDate = DateTime.Now;
            campaign.IsActive = true;
            campaignAccess.SaveCampaign(campaign);
        }

        public void SaveCampaignInfo(CampaignInfo campaignInfo)
        {
            campaignAccess.SaveCampaignInfo(campaignInfo);
        }
        
    }
}
