using ECommerceCampaign.Business.Business;
using ECommerceCampaign.Entity.Models;
using ECommerceCampaign.Entity.Repositories;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCampaign.API.Tasks
{
    public class CampaignPushJob : IJob
    {
        CampaignManager campaignManager;
        ProductManager productManager;
        OrderManager orderManager;
        public CampaignPushJob()
        {
            campaignManager = new CampaignManager();
            productManager = new ProductManager();
            orderManager = new OrderManager();
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var campaignRepo = new CampaignRepo(new CampaignDbContext());
            //var userList = campaignRepo.GetActiveCampaigns();

            List<Campaign> activeCampaigns = campaignManager.GetActiveCampaigns();
            CampaignInfo campaignInfo = new CampaignInfo();

            foreach (var item in activeCampaigns)
            {
                Product product = productManager.GetByProductCode(item.ProductCode);
                var MinPriceMustBe = Decimal.Round((product.FirstPrice - item.PriceManipulationLimit), 2);
                var PriceWillBe = Decimal.Round((product.Price - item.Ratio), 2);

                if (PriceWillBe < MinPriceMustBe)
                {
                    item.IsActive = false;
                    campaignInfo.IsActive = false;
                    campaignManager.UpdateCampaign(item);
                }
                else
                {
                    campaignInfo.IsActive = true;
                    product.Price = PriceWillBe;
                    productManager.UpdateProduct(product);
                }

                campaignInfo.CampaignId = item.Id;
                campaignInfo.CreatedDate = DateTime.Now;
                campaignInfo.TotalSales = orderManager.SalesOrderCount(item.ProductCode);
                if (campaignInfo.TotalSales != 0)
                    campaignInfo.Turnover = (item.TargetSalesCount - campaignInfo.TotalSales) * 100;
                campaignManager.SaveCampaignInfo(campaignInfo);
                orderManager.UpdateOrderByProductCode(item.ProductCode);
            }
            await Console.Out.WriteLineAsync("Job Push");
        }
    }
}
