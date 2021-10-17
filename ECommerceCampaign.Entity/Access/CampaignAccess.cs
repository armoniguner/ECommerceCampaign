using ECommerceCampaign.Entity.Models;
using ECommerceCampaign.Entity.Repositories;
using ECommerceCampaign.Entity.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceCampaign.Entity.Access
{
    public class CampaignAccess
    {
        UnitOfWork uow = new UnitOfWork(new CampaignDbContext());
        ICampaignRepo repo;
        ICampaignInfoRepo repoInfo;
        public CampaignAccess()
        {
            repo = uow.CampaignRepo;
            repoInfo = uow.CampaignInfoRepo;
        }

        #region Campaign
        public List<Campaign> GetAllCampaign()
        {
            return repo.GetAll().ToList();            
        }

        public int SaveCampaign(Campaign campaign)
        {
            repo.Save(campaign);
            uow.SaveChanges();
            return campaign.Id;
        }

        public List<Campaign> GetActiveCampaigns()
        {
            return repo.GetActiveCampaigns();
        }

        public void UpdateCampaign(Campaign campaign)
        {
            repo.Update(campaign);
            uow.SaveChanges();
        }
        #endregion Campaign

        #region CampaignInfo
        public int SaveCampaignInfo(CampaignInfo campaignInfo)
        {
            repoInfo.Save(campaignInfo);
            uow.SaveChanges();
            return campaignInfo.Id;
        }
        #endregion CampaignInfo
    }
}
