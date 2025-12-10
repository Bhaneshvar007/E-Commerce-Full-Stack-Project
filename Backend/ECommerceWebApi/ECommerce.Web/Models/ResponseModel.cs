using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Web.Models
{
    public class ResponseModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }

        public object Data { get; set; }

    }
}
