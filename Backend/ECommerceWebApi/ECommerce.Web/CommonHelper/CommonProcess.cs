using ECommerce.Web.Models;
using System.Data.SqlClient;

namespace ECommerce.Web.CommonHelper
{
    public class CommonProcess
    {
        public static UserModel MapUser(SqlDataReader r)
        {
            return new UserModel
            {
                UserId = r["UserId"] == DBNull.Value ? 0 : Convert.ToInt32(r["UserId"]),
                UserName = r["UserName"] == DBNull.Value ? "" : r["UserName"].ToString(),
                Email = r["Email"] == DBNull.Value ? "" : r["Email"].ToString(),
                Password = r["Password"] == DBNull.Value ? "" : Helper.DecryptPassword(r["Password"].ToString()),
                PhoneNumber = r["Number"] == DBNull.Value ? "" : r["Number"].ToString(),
                ImageUrl = r["ImageUrl"] == DBNull.Value ? "" : r["ImageUrl"].ToString(),
                CreatedDate = r["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["CreatedDate"]),
                RoleName = r["RoleName"] == DBNull.Value ? "" : r["RoleName"].ToString()
            };
        }

        public static CetagoryModel MapCetagory(SqlDataReader r)
        {
            return new CetagoryModel
            {
                CetagoryId = r["CetagoryId"] == DBNull.Value ? 0 : Convert.ToInt32(r["CetagoryId"]),
                CetagoryName = r["CetagoryName"] == DBNull.Value ? "" : r["CetagoryName"].ToString(),
                Description = r["Description"] == DBNull.Value ? "" : r["Description"].ToString(),
                CreatedBy = r["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(r["CreatedBy"]),
                CreatedDate = r["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["CreatedDate"]),
                ImageUrl = r["ImageUrl"] == DBNull.Value ? "" : r["ImageUrl"].ToString()
            };
        }

        public static SubCetagoryModel MapSubCetagory(SqlDataReader r)
        {
            return new SubCetagoryModel
            {
                SubCetagoryId = r["SubCetagoryId"] == DBNull.Value ? 0 : Convert.ToInt32(r["SubCetagoryId"]),
                SubCetagoryName = r["SubCetagoryName"] == DBNull.Value ? "" : r["SubCetagoryName"].ToString(),
                CetagoryId = r["CetagoryId"] == DBNull.Value ? 0 : Convert.ToInt32(r["CetagoryId"]),
                CetagoryName = r["CetagoryName"] == DBNull.Value ? "" : r["CetagoryName"].ToString(),
                Description = r["Description"] == DBNull.Value ? "" : r["Description"].ToString(),
                CreatedBy = r["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(r["CreatedBy"]),
                CreatedDate = r["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["CreatedDate"]),
                ImageUrl = r["ImageUrl"] == DBNull.Value ? "" : r["ImageUrl"].ToString()
            };
        }


        public static ProductModel MapProducts(SqlDataReader r)
        {
            return new ProductModel
            {
                ProductId = r["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(r["ProductId"]),
                ProductName = r["ProductName"] == DBNull.Value ? "" : r["ProductName"].ToString(),
                SubCetagoryId = r["SubCetagoryId"] == DBNull.Value ? 0 : Convert.ToInt32(r["SubCetagoryId"]),
                SubCetagoryName = r["SubCetagoryName"] == DBNull.Value ? "" : r["SubCetagoryName"].ToString(),
                Brand = r["Brand"] == DBNull.Value ? "" : r["Brand"].ToString(),
                Description = r["Description"] == DBNull.Value ? "" : r["Description"].ToString(),
                MRP = r["MRP"] == DBNull.Value ? 0 : Convert.ToDecimal(r["MRP"]),
                ImageUrl = r["ImageUrl"] == DBNull.Value ? "" : r["ImageUrl"].ToString(),
                CreatedBy = r["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(r["CreatedBy"]),
                CreatedDate = r["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["CreatedDate"])
            };
        }
        public static SellerInventoryModel MapSellerInventory(SqlDataReader r)
        {
            return new SellerInventoryModel
            {
                InventoryId = r["InventoryId"] == DBNull.Value ? 0 : Convert.ToInt32(r["InventoryId"]),
                SellerId = r["SellerId"] == DBNull.Value ? 0 : Convert.ToInt32(r["SellerId"]),
                SellerName = r["UserName"] == DBNull.Value ? "" : r["UserName"].ToString(),
                ProductId = r["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(r["ProductId"]),
                ProductName = r["ProductName"] == DBNull.Value ? "" : r["ProductName"].ToString(),
                Price = r["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(r["Price"]),
                TotalPrice = r["TotalPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(r["TotalPrice"]),
                Quantity = r["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(r["Quantity"]),
                ModifiedDate = r["ModifiedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["ModifiedDate"]),
                CreatedDate = r["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["CreatedDate"])
            };
        }

    }
}
