using ECommerce.Web.Models;

namespace ECommerce.Web.DataAcessLayer.Interface
{
    public interface IDALProducts
    {
        public ProductModel GetProductsById(int id);
        public List<ProductModel> GetProducts();
        public ResponseModel InsertProducts(ProductModel model);
        public ResponseModel UpdateProducts(ProductModel model);
        public ResponseModel DeleteProducts(int id);
    }
}
