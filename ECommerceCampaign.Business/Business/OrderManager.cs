using ECommerceCampaign.Entity.Access;
using ECommerceCampaign.Entity.Models;
using System.Collections.Generic;

namespace ECommerceCampaign.Business.Business
{
    public class OrderManager
    {
        private OrderAccess orderAccess;
        public OrderManager()
        {
            orderAccess = new OrderAccess();
        }
        public List<Order> GetAll()
        {
            return orderAccess.GetAll();
        }
        public void SaveOrder(Order order)
        {
            order.IsReaded = false;
            orderAccess.SaveOrder(order);
        }
        public void UpdateOrder(Order order)
        {
            orderAccess.UpdateOrder(order);
        }
        public List<Order> GetOrdersByProductCode(string productCode)
        {
            return orderAccess.GetOrdersByProductCode(productCode);
        }

        public int SalesOrderCount(string productCode)
        {
            return orderAccess.SalesOrderCount(productCode);
        }

        public void UpdateOrderByProductCode(string productCode)
        {
            orderAccess.UpdateOrderByProductCode(productCode);
        }
    }
}
