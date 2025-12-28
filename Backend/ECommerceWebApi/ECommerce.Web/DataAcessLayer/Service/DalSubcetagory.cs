using Dapper;
using ECommerce.Web.CommonHelper;
using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.Models;
using System.Data;
using System.Data.SqlClient;

namespace ECommerce.Web.DataAcessLayer.Service
{
    public class DalSubcetagory : IDalSubCetagory
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IDALUserManager _userManager;
        private readonly string _connectionString;
        public DalSubcetagory(IHttpContextAccessor contextAccessor, IDALUserManager userManager)
        {
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _connectionString = Helper.GetConnectionString();
        }

        public List<SubCetagoryModel> GetSubCetagory()
        {
            var list = new List<SubCetagoryModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetSubCetagoryDetails", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubCetegoryId", null);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(CommonProcess.MapSubCetagory(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in GetSubCetagory()");
                throw;
            }

            return list;
        }



        public SubCetagoryModel GetSubCetagoryById(int id)
        {
            SubCetagoryModel subcetagoryModel = null;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetSubCetagoryDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubCetegoryId", id);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            subcetagoryModel = CommonProcess.MapSubCetagory(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog($"Error in GetSubCetagoryById | SubCetagoryId: {id} | {ex.Message}");
                throw;
            }

            return subcetagoryModel;
        }



        public ResponseModel InsertSubCetagory(SubCetagoryModel model)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertUpdateSubCetagory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SubCetagoryName", model.SubCetagoryName);
                    cmd.Parameters.AddWithValue("@CetagoryId", model.CetagoryId);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                    cmd.Parameters.AddWithValue("@ImageUrl", model.ImageUrl);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                res.Status = true;
                res.Message = "SubCategory created successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in InsertSubCetagory()");
                res.Status = false;
                res.Message = "Something went wrong!";
            }

            return res;
        }

        public ResponseModel UpdateSubCetagory(SubCetagoryModel model)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertUpdateSubCetagory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SubCetagoryId", model.SubCetagoryId);
                    cmd.Parameters.AddWithValue("@SubCetagoryName", model.SubCetagoryName);
                    cmd.Parameters.AddWithValue("@CetagoryId", model.CetagoryId);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                    cmd.Parameters.AddWithValue("@ImageUrl", model.ImageUrl);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                res.Status = true;
                res.Message = "SubCategory update successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in UpdateSubCetagory()");
                res.Status = false;
                res.Message = "Something went wrong!";
            }

            return res;
        }


        public ResponseModel DeleteSubCetagory(int id)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE tbl_SubCetagory 
                             SET IsActive = 0 
                             WHERE SubCetagoryId = @SubCetagoryId";

                    con.Execute(query, new { SubCetagoryId = id });
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
