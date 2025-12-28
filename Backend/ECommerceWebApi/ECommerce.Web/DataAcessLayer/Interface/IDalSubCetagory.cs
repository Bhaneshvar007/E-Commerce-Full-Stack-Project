using ECommerce.Web.Models;

namespace ECommerce.Web.DataAcessLayer.Interface
{
    public interface IDalSubCetagory
    {
        List<SubCetagoryModel> GetSubCetagory();
        SubCetagoryModel GetSubCetagoryById(int id);
        ResponseModel InsertSubCetagory(SubCetagoryModel model);
        ResponseModel UpdateSubCetagory(SubCetagoryModel model);
        ResponseModel DeleteSubCetagory(int id);
    }
}
