using Common.Repositories;
using ECommerceCampaign.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceCampaign.Entity.Repositories
{
    public class OrderRepo : Repository<Order>, IOrderRepo
    {
        public OrderRepo(DbContext context) : base(context)
        {

        }

        public List<Order> GetOrdersByProductCode(string productCode)
        {
            return GetAll().Where(x => x.ProductCode == productCode).ToList();
        }

        public int SalesOrderCount(string productCode)
        {
            return GetAll().Where(x => x.IsReaded == false && x.ProductCode == productCode).ToList().Sum(x => x.Quantity);
        }

        public void UpdateOrderByProductCode(string productCode)
        {
            List<Order> order = GetAll().Where(x => x.ProductCode == productCode && x.IsReaded == false).ToList();
            order.ForEach(x => x.IsReaded = true);
            order.ForEach(x => Update(x));
        }
    }
}
