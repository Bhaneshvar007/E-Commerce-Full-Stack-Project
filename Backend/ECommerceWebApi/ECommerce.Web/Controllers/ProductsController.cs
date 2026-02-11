using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [Route("GetProducts")]
        [HttpGet]
        public IActionResult Index()
        {
            var products = _dalProduct.GetProducts();

            if (products == null || !products.Any())
                return NoContent();

            return Ok(products);
        }

        [Authorize]
        [Route("GetProductById/{ProductId}")]
        [HttpGet]
        public IActionResult GetProductsById(int ProductId)
        {
            var cetagory = _dalProduct.GetProductsById(ProductId);

            if (cetagory == null)
                return NoContent();

            return Ok(cetagory);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("InsertProduct")]
        public ResponseModel InsertProduct(ProductModel model)
        {
            return _dalProduct.InsertProducts(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("UpdateProduct")]
        public ResponseModel UpdateProduct(ProductModel model)
        {
            return _dalProduct.UpdateProducts(model);
        }


        [Authorize(Roles = "Admin")]
        [Route("DeleteProduct")]
        [HttpGet]
        public ResponseModel DeleteProduct(int productId)
        {
            return _dalProduct.DeleteProducts(productId);
        }
    }
}
