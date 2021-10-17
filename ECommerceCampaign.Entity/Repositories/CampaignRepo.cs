using Common.Repositories;
using ECommerceCampaign.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceCampaign.Entity.Repositories
{
    public class CampaignRepo : Repository<Campaign>, ICampaignRepo
    {
        public CampaignRepo(DbContext context) :base(context)
        {

        }

        public List<Campaign> GetActiveCampaigns()
        {
            return GetAll().Where(x => x.IsActive == true).ToList();
        }
    }
}
