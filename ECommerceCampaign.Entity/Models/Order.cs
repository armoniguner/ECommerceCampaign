using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerceCampaign.Entity.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public bool IsReaded { get; set; }
    }
}
