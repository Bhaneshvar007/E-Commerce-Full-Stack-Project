using ECommerce.Common.DB;
using ECommerce.Common.Helpers;
using ECommerce.Common.Models;
using ECommerce.Common.Repository.Interface;
using ECommerce.Common.Repository.Service;
using ECommerce.Web.DataAcessLayer.Interface;using System.Data;
using System.Data.SqlClient;

namespace ECommerce.Web.DataAcessLayer.Service
{
    public class DalUser : IDalUser
    {

        private readonly IUserRepository _userRepository;
        private readonly IAppDbContext _appDbContext;
        private readonly IHelper _helper;

        public DalUser(IUserRepository userRepository, IAppDbContext appDbContext, IHelper helper)
        {
            this._userRepository = userRepository;
            this._appDbContext = appDbContext;
            this._helper = helper;
        }
        public List<UserModel> GetUsers()
        {
            List<UserModel> userModel = new List<UserModel>();
            SqlParameter[] Params = {
                new SqlParameter("@UserId",null)
            };

            DataTable DT = _appDbContext.ExecuteProcedure("sp_GetUserDetails", Params);
            userModel = _userRepository.GetUsers(DT);
            return userModel;
        }

        public UserModel GetUserById(int id)
        {
            UserModel userModel = new UserModel();
            SqlParameter[] Params = {
                new SqlParameter("@UserId",id)
            };

            DataTable DT = _appDbContext.ExecuteProcedure("sp_GetUserDetails", Params);
            userModel = _userRepository.GetUsers(DT).FirstOrDefault();
            return userModel;
        }



        public ResponseModel AddUser(UserModel umodel)
        {
            ResponseModel ResModel = new ResponseModel();

            string EncryptedPassword = _helper.EncryptPassword(umodel.Password);

            try
            {
                SqlParameter[] Params = {
                                    new SqlParameter("@UserName", umodel.UserName),
                                    new SqlParameter("@Email", umodel.Email),
                                    new SqlParameter("@Number", umodel.PhoneNumber),
                                    new SqlParameter("@Password",EncryptedPassword),
                                    new SqlParameter("@RoleId", umodel.RoleId),
                                    new SqlParameter("@CreatedBy", umodel.CreatedBy),
                                    new SqlParameter("@ImageUrl", umodel.ImageUrl),
                                };

                var res = _appDbContext.ExecuteProcedure("sp_InsertUpadateUser", Params);

                ResModel.Status = true;
                ResModel.Message = "User created successfully!";

            }
            catch (Exception ex)
            {
                ResModel.Status = false;
                ResModel.Message = "Error: " + ex.Message;
            }

            return ResModel;
        }



        public ResponseModel LoginUser(UserModel umodel)
        {
            ResponseModel ResModel = new ResponseModel();
            string EncryptedPassword = _helper.EncryptPassword(umodel.Password);

            try
            {
                SqlParameter[] Params = {
                                    new SqlParameter("@Email", umodel.Email),
                                    new SqlParameter("@RoleId", umodel.RoleId),
                                    new SqlParameter("@Password", EncryptedPassword),
                                };

                var dt = _appDbContext.ExecuteProcedure("sp_LoginUser", Params);


                if (dt.Rows.Count == 0)
                {
                    ResModel.Status = false;
                    ResModel.Message = "Invalid email or password!";
                    return ResModel;
                }
                else
                {
                    var convertedData = _helper.ConvertToObjectList(dt);
                    ResModel.Status = true;
                    ResModel.Message = "Login successfully!";
                    ResModel.Data = convertedData;
                }


            }
            catch (Exception ex)
            {
                ResModel.Status = false;
                ResModel.Message = "Error: " + ex.Message;
            }

            return ResModel;
        }



        public ResponseModel UpdateUser(UserModel umodel)
        {
            ResponseModel ResModel = new ResponseModel();
            string EncryptedPassword = _helper.EncryptPassword(umodel.Password);

            try
            {
                SqlParameter[] Params = {
                                    new SqlParameter("@UserId", umodel.UserId),
                                    new SqlParameter("@UserName", umodel.UserName),
                                    new SqlParameter("@Email", umodel.Email),
                                    new SqlParameter("@Number", umodel.PhoneNumber),
                                    new SqlParameter("@Password", EncryptedPassword),
                                    new SqlParameter("@RoleId", umodel.RoleId),
                                    new SqlParameter("@CreatedBy", umodel.CreatedBy),
                                    new SqlParameter("@ImageUrl", umodel.ImageUrl),
                                };

                var res = _appDbContext.ExecuteProcedure("sp_InsertUpadateUser", Params);

                ResModel.Status = true;
                ResModel.Message = "User updated successfully!";

            }
            catch (Exception ex)
            {
                ResModel.Status = false;
                ResModel.Message = "Error: " + ex.Message;
            }

            return ResModel;
        }

    }
}
