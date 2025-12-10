using ECommerce.Web.Models;
using System.Data.SqlClient;

namespace ECommerce.Web.CommonHelper
{
    public class CommonProcess
    {
        public static UserModel MapUser(SqlDataReader reader)
        {
            return new UserModel
            {
                UserId = Convert.ToInt32(reader["UserId"]),
                UserName = reader["UserName"].ToString(),
                Email = reader["Email"].ToString(),
                Password = Helper.DecryptPassword(reader["Password"].ToString()), 
                PhoneNumber = reader["Number"].ToString(),
                ImageUrl = reader["ImageUrl"].ToString(),
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                RoleName = reader["RoleName"].ToString(),
            };
        }


        public static CetagoryModel MapCetagory(SqlDataReader reader)
        {
            return new CetagoryModel
            {
                CetagoryId = Convert.ToInt32(reader["CetagoryId"]),
                CetagoryName = reader["CetagoryName"].ToString(),
                Description = reader["Description"].ToString(),
                CreatedBy = Convert.ToInt32(reader["CreatedBy"]),
                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                ImageUrl = reader["ImageUrl"].ToString()
            };
        }

    }
}
