using ECommerce.Common.DB;
using ECommerce.Common.Models;
using System.Data.SqlClient;

namespace ECommerce.Web.DataAcessLayer.Service
{
    public class DalCetagory
    {
        private readonly IAppDbContext _appDbContext;
        public DalCetagory(IAppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
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
    }
}
