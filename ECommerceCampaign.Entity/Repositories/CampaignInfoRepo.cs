using Common.Repositories;
using ECommerceCampaign.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceCampaign.Entity.Repositories
{
    public class CampaignInfoRepo : Repository<CampaignInfo>, ICampaignInfoRepo
    {
        public CampaignInfoRepo(DbContext context) : base(context)
        {

        }
    }
}
