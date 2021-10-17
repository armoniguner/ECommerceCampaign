using Common.Repositories;
using ECommerceCampaign.Entity.Models;
using System.Collections.Generic;

namespace ECommerceCampaign.Entity.Repositories
{
    public interface IOrderRepo : IRepository<Order>
    {
        public List<Order> GetOrdersByProductCode(string productCode);
        public int SalesOrderCount(string productCode);
        public void UpdateOrderByProductCode(string productCode);
    }
}
