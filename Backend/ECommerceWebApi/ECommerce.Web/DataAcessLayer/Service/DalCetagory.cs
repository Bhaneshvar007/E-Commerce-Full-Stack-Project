using Dapper;
using ECommerce.Web.CommonHelper;
using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.Extensions;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ECommerce.Web.DataAcessLayer.Service
{
    public class DalCetagory : IDalCetagory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _connectionString;



        public DalCetagory(IHttpContextAccessor httpContextAccessor, IDALUserManager dALUserManager)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._connectionString = Helper.GetConnectionString();
        }


        public List<CetagoryModel> GetCetagory()
        {
            List<CetagoryModel> categories = new List<CetagoryModel>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetCetagoryDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CetagoryId", DBNull.Value); // all categories
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(CommonProcess.MapCetagory(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in GetCetagory()");
                throw;
            }

            return categories;
        }

        public CetagoryModel GetCetagoryById(int id)
        {
            CetagoryModel category = null;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetCetagoryDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CetagoryId", id);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category = CommonProcess.MapCetagory(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog($"Error in GetCetagoryById | CetagoryId: {id} | {ex.Message}");
                throw;
            }

            return category;
        }



        public ResponseModel InsertCetagory(CetagoryModel model)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertUpadateCetagory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CetagoryName", model.CetagoryName);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                    cmd.Parameters.AddWithValue("@ImageUrl", model.ImageUrl);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                res.Status = true;
                res.Message = "Category created successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in InsertCetagory()");
                res.Status = false;
                res.Message = "Something went wrong!";
            }

            return res;
        }

        public ResponseModel UpdateCetagory(CetagoryModel model)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertUpadateCetagory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CetagoryId", model.CetagoryId);
                    cmd.Parameters.AddWithValue("@CetagoryName", model.CetagoryName);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                    cmd.Parameters.AddWithValue("@ImageUrl", model.ImageUrl);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                res.Status = true;
                res.Message = "Category updated successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in UpdateCetagory()");
                res.Status = false;
                res.Message = "Update failed!";
            }

            return res;
        }



        public ResponseModel DeleteCetagory(int id)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE tbl_Cetagory 
                             SET IsActive = 0 
                             WHERE CetagoryId = @CetagoryId";

                    con.Execute(query, new { CetagoryId = id });
                }

                res.Status = true;
                res.Message = "Data deleted successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in DeleteCetagory()");
                res.Status = false;
                res.Message = "Delete failed!";
            }

            return res;
        }




    }
}
