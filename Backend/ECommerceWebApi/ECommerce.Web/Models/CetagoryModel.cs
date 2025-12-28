using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerce.Web.Models
{
    public class CetagoryModel
    {
        public int CetagoryId { get; set; }
        public string CetagoryName { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ImageUrl { get; set; }
    }
}
