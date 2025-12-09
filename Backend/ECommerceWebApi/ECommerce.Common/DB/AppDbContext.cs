using ECommerce.Common.DB;
using ECommerce.Common.Helpers;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

public class AppDbContext : IAppDbContext
{
    private readonly IHelper _helper;
    private readonly IConfiguration _config;

    private string ConnStr => _config.GetConnectionString("DefaultConnection");

    public AppDbContext(IHelper helper, IConfiguration config)
    {
        _helper = helper;
        _config = config;
    }

    public DataTable ExecuteQuery(string cQuery)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(ConnStr))
        {
            try
            {
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cQuery, conn))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                _helper.WriteLog("Error While ExecuteQuery: " + ex.ToString());
                throw ex;
            }
        }
        return dt;
    }

    public DataTable ExecuteProcedure(string cProcedureName, SqlParameter[] parameters = null)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(ConnStr))
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 560;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = cProcedureName;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                _helper.WriteLog($"Error While ExecuteProcedure '{cProcedureName}': {ex}");
                throw ex;
            }
        }

        return dt;
    }
}
