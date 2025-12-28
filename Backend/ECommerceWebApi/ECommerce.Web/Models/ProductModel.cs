namespace ECommerce.Web.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal MRP { get; set; }
       
        public string? ImageUrl { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int SubCetagoryId { get; set; }
        public string? SubCetagoryName { get; set; }

    }
}
