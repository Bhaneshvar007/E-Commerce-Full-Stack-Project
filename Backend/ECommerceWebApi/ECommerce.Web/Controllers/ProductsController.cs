using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        public readonly IDALProducts  _dalProduct;

        public ProductsController(IDALProducts dALProducts )
        {
            this._dalProduct = dALProducts;
        }

        [Route("GetProducts")]
        [HttpGet]
        public IActionResult Index()
        {
            var products = _dalProduct.GetProducts();

            if (products == null || !products.Any())
                return NoContent();

            return Ok(products);
        }


        [Route("GetProductById/{ProductId}")]
        [HttpGet]
        public IActionResult GetProductsById(int ProductId)
        {
            var cetagory = _dalProduct.GetProductsById(ProductId);

            if (cetagory == null)
                return NoContent();

            return Ok(cetagory);
        }


        [HttpPost]
        [Route("InsertProduct")]
        public ResponseModel InsertProduct(ProductModel model)
        {
            return _dalProduct.InsertProducts(model);
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public ResponseModel UpdateProduct(ProductModel model)
        {
            return _dalProduct.UpdateProducts(model);
        }


        [Route("DeleteProduct")]
        [HttpGet]
        public ResponseModel DeleteProduct(int productId)
        {
            return _dalProduct.DeleteProducts(productId);
        }
    }
}
