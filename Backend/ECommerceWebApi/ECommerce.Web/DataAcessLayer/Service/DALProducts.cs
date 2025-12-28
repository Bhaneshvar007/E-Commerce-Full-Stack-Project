using Dapper;
using ECommerce.Web.CommonHelper;
using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.Models;
using System.Data;
using System.Data.SqlClient;

namespace ECommerce.Web.DataAcessLayer.Service
{
    public class DALProducts : IDALProducts
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _connectionString;



        public DALProducts(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._connectionString = Helper.GetConnectionString();
        }

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> products = new List<ProductModel>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetProductsDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", DBNull.Value);  
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(CommonProcess.MapProducts(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in GetProducts()");
                throw;
            }

            return products;
        }

        public ProductModel GetProductsById(int id)
        {
            ProductModel product = null;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetProductsDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = CommonProcess.MapProducts(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog($"Error in GetProductsById | ProductId: {id} | {ex.Message}");
                throw;
            }

            return product;
        }



        public ResponseModel InsertProducts(ProductModel model)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertUpdateProducts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductName", model.ProductName);
                    cmd.Parameters.AddWithValue("@SubCetagoryId", model.SubCetagoryId);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@Brand", model.Brand);
                    cmd.Parameters.AddWithValue("@MRP", model.MRP);
                    cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                    cmd.Parameters.AddWithValue("@ImageUrl", model.ImageUrl);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                res.Status = true;
                res.Message = "Product created successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in InsertProduct()");
                res.Status = false;
                res.Message = "Something went wrong!";
            }

            return res;
        }

        public ResponseModel UpdateProducts(ProductModel model)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertUpdateProducts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                    cmd.Parameters.AddWithValue("@ProductName", model.ProductName);
                    cmd.Parameters.AddWithValue("@SubCetagoryId", model.SubCetagoryId);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@Brand", model.Brand);
                    cmd.Parameters.AddWithValue("@MRP", model.MRP);
                    cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                    cmd.Parameters.AddWithValue("@ImageUrl", model.ImageUrl);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                res.Status = true;
                res.Message = "Product updated successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in UpdateProduct()");
                res.Status = false;
                res.Message = "Something went wrong!";
            }

            return res;
        }



        public ResponseModel DeleteProducts(int id)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE tbl_Products 
                             SET IsActive = 0 
                             WHERE ProductId = @ProductsId";

                    con.Execute(query, new { ProductsId = id });
                }

                res.Status = true;
                res.Message = "Data deleted successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in DeleteProducts()");
                res.Status = false;
                res.Message = "Delete failed!";
            }

            return res;
        }


    }
}

