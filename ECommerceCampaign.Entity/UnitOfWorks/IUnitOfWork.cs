using ECommerceCampaign.Entity.Repositories;
using System;

namespace ECommerceCampaign.Entity.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        ICampaignRepo CampaignRepo { get; }
        ICampaignInfoRepo CampaignInfoRepo { get; }
        IProductRepo ProductRepo { get; }
        IOrderRepo OrderRepo { get; }
        int SaveChanges();
    }
}
