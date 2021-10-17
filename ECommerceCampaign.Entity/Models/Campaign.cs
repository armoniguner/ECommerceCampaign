using System;

#nullable disable

namespace ECommerceCampaign.Entity.Models
{
    public partial class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public decimal Ratio { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
