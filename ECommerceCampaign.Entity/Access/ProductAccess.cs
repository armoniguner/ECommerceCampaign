using ECommerceCampaign.Entity.Models;
using ECommerceCampaign.Entity.Repositories;
using ECommerceCampaign.Entity.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceCampaign.Entity.Access
{
    public class ProductAccess
    {
        UnitOfWork uow = new UnitOfWork(new ProductDbContext());
        IProductRepo repo;

        public ProductAccess()
        {
            repo = uow.ProductRepo;
        }
        public List<Product> GetAll()
        {
            return repo.GetAll().ToList();            
        }

        public void SaveProduct(Product product)
        {
            repo.Save(product);
            uow.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            repo.Update(product);
            uow.SaveChanges();
        }

        public Product GetByProductCode(string productCode)
        {
            return repo.GetByProductCode(productCode);
        }
    }
}
