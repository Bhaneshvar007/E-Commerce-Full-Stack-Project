using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.DB
{
    public interface IAppDbContext
    {
        public DataTable ExecuteQuery(string cQuery);
        public DataTable ExecuteProcedure(string cProcedureName, SqlParameter[] paramenters = null);
    }
}
