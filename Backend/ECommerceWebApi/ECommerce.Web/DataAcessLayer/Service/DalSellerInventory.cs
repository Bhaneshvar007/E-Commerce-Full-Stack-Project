using Dapper;
using ECommerce.Web.CommonHelper;
using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ECommerce.Web.DataAcessLayer.Service
{
    public class DalSellerInventory : IDalSellerInventory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _connectionString;
        public DalSellerInventory(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._connectionString = Helper.GetConnectionString();
        }


        public List<SellerInventoryModel> GetSellerInventory()
        {
            List<SellerInventoryModel> list = new List<SellerInventoryModel>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetSellerInventoryDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InventoryId", DBNull.Value);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(CommonProcess.MapSellerInventory(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in GetSellerInventory()");
                throw;
            }

            return list;
        }

        public SellerInventoryModel GetSellerInventoryById(int id)
        {
            SellerInventoryModel SellerInventory = null;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetSellerInventoryDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InventoryId", id);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            SellerInventory = CommonProcess.MapSellerInventory(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog($"Error in GetSellerInventoryById | InventoryId: {id} | {ex.Message}");
                throw;
            }

            return SellerInventory;
        }



        public ResponseModel InsertSellerInventory(SellerInventoryModel model)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertSellerInventory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                    cmd.Parameters.AddWithValue("@SellerId", model.SellerId);
                    cmd.Parameters.AddWithValue("@Price", model.Price);
                    cmd.Parameters.AddWithValue("@Quantity", model.Quantity);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                res.Status = true;
                res.Message = "Product Added successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in InsertSellerInventory()");
                res.Status = false;
                res.Message = "Something went wrong!";
            }

            return res;
        }

        public ResponseModel UpdateSellerInventory(SellerInventoryModel model)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateSellerInventory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@InventoryId", model.InventoryId);
                    cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                    //cmd.Parameters.AddWithValue("@SellerId", model.SellerId);
                    cmd.Parameters.AddWithValue("@Price", model.Price);
                    cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                res.Status = true;
                res.Message = "Stock updated successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in UpdateSellerInventory()");
                res.Status = false;
                res.Message = "Something went wrong!";
            }

            return res;
        }



        public ResponseModel DeleteSellerInventory(int id)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE tbl_SellerInventory 
                             SET IsActive = 0 
                             WHERE InventoryId = @InventoryId";

                    con.Execute(query, new { InventoryId = id });
                }

                res.Status = true;
                res.Message = "Data deleted successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in DeleteSellerInventory()");
                res.Status = false;
                res.Message = "Delete failed!";
            }

            return res;
        }

    }
}
