using Common.Repositories;
using ECommerceCampaign.Entity.Models;
using System.Collections.Generic;

namespace ECommerceCampaign.Entity.Repositories
{
    public interface ICampaignRepo : IRepository<Campaign>
    {
        List<Campaign> GetActiveCampaigns();
    }
}
