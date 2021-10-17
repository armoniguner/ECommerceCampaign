using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerceCampaign.Entity.Models
{
    public partial class CampaignInfo
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public bool IsActive { get; set; }
        public int TotalSales { get; set; }
        public decimal Turnover { get; set; }
        public decimal AverageItemPrice { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
