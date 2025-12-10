using ECommerce.Web.Models;

namespace ECommerce.Web.DataAcessLayer.Interface
{
    public interface IDalCetagory
    {
        public List<CetagoryModel> GetCetagory();
        public CetagoryModel GetCetagoryById(int id);
        public ResponseModel InsertCetagory(CetagoryModel model);
        public ResponseModel UpdateCetagory(CetagoryModel model);
        public ResponseModel DeleteCetagory(int id);
    }
}
