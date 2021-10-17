using Common.Repositories;
using ECommerceCampaign.Entity.Models;

namespace ECommerceCampaign.Entity.Repositories
{
    public interface IProductRepo : IRepository<Product>
    {
        Product GetByProductCode(string productCode);
    }
}
