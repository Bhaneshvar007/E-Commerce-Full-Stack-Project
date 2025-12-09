using ECommerce.Common.DB;
using ECommerce.Common.Helpers;
using ECommerce.Common.Models;
using ECommerce.Common.Repository.Interface;
using ECommerce.Web.DataAcessLayer.Interface;
using System.Data;
using System.Data.SqlClient;

namespace ECommerce.Web.DataAcessLayer.Service
{
    public class DalCetagory : IDalCetagory
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ICetagoryRepository _cetagoryRepository;
        private readonly IHelper _helper;


        public DalCetagory(IAppDbContext appDbContext, ICetagoryRepository cetagoryRepository,IHelper helper)
        {
            this._appDbContext = appDbContext;
            this._cetagoryRepository = cetagoryRepository;
            this._helper = helper;
        }


        public List<CetagoryModel> GetCetagory()
        {
            List<CetagoryModel> cetagories = new List<CetagoryModel>();
            SqlParameter[] Params = {
                new SqlParameter("@CetagoryId",null)
            };

            DataTable DT = _appDbContext.ExecuteProcedure("sp_GetCetagoryDetails", Params);
            cetagories = _cetagoryRepository.GetCetagorys(DT);
            return cetagories;
        }

        public CetagoryModel GetCetagoryById(int id)
        {
            CetagoryModel cetagories = new CetagoryModel();
            SqlParameter[] Params = {
                new SqlParameter("@CetagoryId",id)
            };

            DataTable DT = _appDbContext.ExecuteProcedure("sp_GetCetagoryDetails", Params);
            cetagories = _cetagoryRepository.GetCetagorys(DT).FirstOrDefault();
            return cetagories;
        }

        public ResponseModel InsertCetagory(CetagoryModel model)
        {
            ResponseModel ResModel = new ResponseModel();

            try
            {
                SqlParameter[] Params = {
                                    new SqlParameter("@CetagoryName", model.CetagoryName),
                                    new SqlParameter("@Description", model.Description),
                                    new SqlParameter("@CreatedBy", 0),
                                    new SqlParameter("@ImageUrl", model.ImageUrl),
                                };

                var res = _appDbContext.ExecuteProcedure("sp_InsertUpadateCetagory", Params);

                ResModel.Status = true;
                ResModel.Message = "Cetagory created successfully!";

            }
            catch (Exception ex)
            {
                ResModel.Status = false;
                ResModel.Message = "Error: " + ex.Message;
            }

            return ResModel;
        }


        public ResponseModel UpdateCetagory(CetagoryModel model)
        {
            ResponseModel ResModel = new ResponseModel();
            DALUserManager ObjUserManeger = new DALUserManager();

            try
            {
                SqlParameter[] Params = {
                                    new SqlParameter("@CetagoryId", model.CetagoryId),
                                    new SqlParameter("@CetagoryName", model.CetagoryName),
                                    new SqlParameter("@Description", model.Description),
                                    new SqlParameter("@CreatedBy", ObjUserManeger.User.UserId),
                                    new SqlParameter("@ImageUrl", model.ImageUrl),
                                };

                var res = _appDbContext.ExecuteProcedure("sp_InsertUpadateCetagory", Params);

                ResModel.Status = true;
                ResModel.Message = "Cetagory updated successfully!";

            }
            catch (Exception ex)
            {
                ResModel.Status = false;
                ResModel.Message = "Error: " + ex.Message;
            }

            return ResModel;
        }


        public ResponseModel DeleteCetagory(int id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                _appDbContext.ExecuteQuery($"update tbl_Cetagory set IsActive = 0 where CetagoryId = {id}");
                responseModel.Status = true;
                responseModel.Message = "Record deleted sucessfully";
            }
            catch(Exception ex)
            {
                responseModel.Status = false;
                responseModel.Message =   ex.Message ;   
                ;
            }

            return responseModel;   
             
        }


    }
}
