namespace ECommerce.Web.Models
{
    public class SellerInventoryModel
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal? TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int SellerId { get; set; }
        public string? SellerName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }



    }
}
