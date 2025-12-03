using ECommerce.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Repository.Interface
{
    public interface ICetagoryRepository
    {
        public List<CetagoryModel> GetCetagorys(DataTable DT);
    }
}
