namespace ECommerce.Web.Models
{
    public class SubCetagoryModel
    {
        public int SubCetagoryId { get; set; }
        public string SubCetagoryName { get; set; }
        public string Description { get; set; }
        public int CetagoryId { get; set; }
        public string? CetagoryName { get;set; }
        public string? ImageUrl { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
 
    }
}
