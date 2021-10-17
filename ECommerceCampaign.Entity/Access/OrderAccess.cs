using ECommerceCampaign.Entity.Models;
using ECommerceCampaign.Entity.Repositories;
using ECommerceCampaign.Entity.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceCampaign.Entity.Access
{
    public class OrderAccess
    {
        UnitOfWork uow = new UnitOfWork(new OrderDbContext());
        IOrderRepo repo;

        public OrderAccess()
        {
            repo = uow.OrderRepo;
        }
        public List<Order> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public void SaveOrder(Order order)
        {
            repo.Save(order);
            uow.SaveChanges();
        }
        public void UpdateOrder(Order order)
        {
            repo.Update(order);
            uow.SaveChanges();
        }

        public List<Order> GetOrdersByProductCode(string productCode)
        {
            return repo.GetOrdersByProductCode(productCode);
        }

        public int SalesOrderCount(string productCode)
        {
            return repo.SalesOrderCount(productCode);
        }

        public void UpdateOrderByProductCode(string productCode)
        {
            repo.UpdateOrderByProductCode(productCode);
            uow.SaveChanges();
        }
    }
}
