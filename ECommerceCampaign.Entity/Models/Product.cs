#nullable disable

namespace ECommerceCampaign.Entity.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public decimal FirstPrice { get; set; }
    }
}
