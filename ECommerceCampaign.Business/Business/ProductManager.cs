using ECommerceCampaign.Entity.Access;
using ECommerceCampaign.Entity.Models;
using System;
using System.Collections.Generic;

namespace ECommerceCampaign.Business.Business
{
    public class ProductManager
    {
        private ProductAccess productAccess;
        public ProductManager()
        {
            productAccess = new ProductAccess();
        }
        public List<Product> GetAll()
        {
            return productAccess.GetAll();
        }
        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
                product.FirstPrice = product.Price;
            productAccess.SaveProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            productAccess.UpdateProduct(product);
        }

        public Product GetByProductCode(string productCode)
        {
            return productAccess.GetByProductCode(productCode);
        }

        public void CalcPrice(string productCode, decimal ratio)
        {
            Product product = productAccess.GetByProductCode(productCode);
            product.Price = Decimal.Round((product.Price - ratio), 2);

            UpdateProduct(product);
        }
    }
}
