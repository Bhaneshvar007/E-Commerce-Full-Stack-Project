using ECommerce.Web.Models;

namespace ECommerce.Web.DataAcessLayer.Interface
{
    public interface IDalSellerInventory
    {
        public List<SellerInventoryModel> GetSellerInventory();
        public SellerInventoryModel GetSellerInventoryById(int id);
        public ResponseModel InsertSellerInventory(SellerInventoryModel model);
        public ResponseModel UpdateSellerInventory(SellerInventoryModel model);
        public ResponseModel DeleteSellerInventory(int id);

    }
}
