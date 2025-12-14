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
    public class DalUser : IDalUser
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _connectionString;

        public DalUser(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
            _connectionString = Helper.GetConnectionString();



        }
        public List<UserModel> GetUsers()
        {
            List<UserModel> users = new List<UserModel>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetUserDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(CommonProcess.MapUser(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + "Error in GetUsers()");
                throw;
            }

            return users;
        }

        public UserModel GetUserById(int id)
        {
            UserModel user = null;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetUserDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", id);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = CommonProcess.MapUser(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog($"Error in GetUserById | UserId: {id} and Exception : {ex.Message}");
                throw;
            }

            return user;
        }

        public ResponseModel AddUser(UserModel umodel)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                string encryptedPwd = Helper.EncryptPassword(umodel.Password);

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertUpadateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", umodel.UserName);
                    cmd.Parameters.AddWithValue("@Email", umodel.Email);
                    cmd.Parameters.AddWithValue("@Number", umodel.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Password", encryptedPwd);
                    cmd.Parameters.AddWithValue("@RoleName", umodel.RoleName);
                    cmd.Parameters.AddWithValue("@CreatedBy", umodel.CreatedBy);
                    cmd.Parameters.AddWithValue("@ImageUrl", umodel.ImageUrl);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                res.Status = true;
                res.Message = "User created successfully";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + " Error in AddUser");
                res.Status = false;
                res.Message = "Something went wrong!";
            }

            return res;
        }

        public ResponseModel LoginUser(UserModel umodel)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                string encryptedPwd = Helper.EncryptPassword(umodel.Password);

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_LoginUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", umodel.Email);
                    cmd.Parameters.AddWithValue("@Password", encryptedPwd);
                    cmd.Parameters.AddWithValue("@RoleName", umodel.RoleName);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            res.Status = false;
                            res.Message = "Invalid Email or Password";
                            return res;
                        }

                        UserModel user = CommonProcess.MapUser(reader);


                        _httpContextAccessor.HttpContext.Session
                            .SetObject("UserDetails", user);

                        res.Status = true;
                        res.Message = "Login successfully";
                        res.Data = user;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + "Error in LoginUser");
                res.Status = false;
                res.Message = "Login failed!";
            }

            return res;
        }

        public ResponseModel LogoutUser()
        {
            ResponseModel res = new ResponseModel();

            try
            {
                _httpContextAccessor.HttpContext.Session.Clear();
                _httpContextAccessor.HttpContext.Session.Remove("UserDetails");

                res.Status = true;
                res.Message = "Logout successful!";
            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Message = "Error: " + ex.Message;
            }

            return res;
        }

        public ResponseModel UpdateUser(UserModel umodel)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                string encryptedPwd = Helper.EncryptPassword(umodel.Password);

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertUpadateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", umodel.UserId);
                    cmd.Parameters.AddWithValue("@UserName", umodel.UserName);
                    cmd.Parameters.AddWithValue("@Email", umodel.Email);
                    cmd.Parameters.AddWithValue("@Number", umodel.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Password", encryptedPwd);
                    cmd.Parameters.AddWithValue("@RoleName", umodel.RoleName);
                    cmd.Parameters.AddWithValue("@CreatedBy", umodel.CreatedBy);
                    cmd.Parameters.AddWithValue("@ImageUrl", umodel.ImageUrl);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                res.Status = true;
                res.Message = "User updated successfully";
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.Message + "Error in UpdateUser");
                res.Status = false;
                res.Message = "Update failed!";
            }

            return res;
        }


        public ResponseModel DeleteUser(int userId)
        {
            ResponseModel res = new ResponseModel();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE tbl_User 
                             SET IsActive = 0 
                             WHERE UserId = @UserId";

                    con.Execute(query, new { UserId = userId });
                }

                res.Status = true;
                res.Message = "User deleted successfully!";
            }
            catch (Exception ex)
            {
                Helper.WriteLog($"Error in DeleteUser | UserId: {userId} | {ex.Message}");
                res.Status = false;
                res.Message = "Delete failed!";
            }

            return res;
        }

    }
}
