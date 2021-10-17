using Common.Repositories;
using ECommerceCampaign.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ECommerceCampaign.Entity.Repositories
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        public ProductRepo(DbContext context) : base(context)
        {

        }

        public Product GetByProductCode(string productCode)
        {
            return GetAll().Where(x => x.ProductCode == productCode).FirstOrDefault();
        }
    }
}
