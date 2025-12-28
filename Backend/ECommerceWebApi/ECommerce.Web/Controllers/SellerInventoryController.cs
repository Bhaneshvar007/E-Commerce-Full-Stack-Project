using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerInventoryController : Controller
    {
        public readonly IDalSellerInventory _dalSellerInventory;

        public SellerInventoryController(IDalSellerInventory dalSellerInventory)
        {
            this._dalSellerInventory = dalSellerInventory;
        }

        [HttpGet("GetSellerInventory")]
        public IActionResult Index()
        {
            var inventory = _dalSellerInventory.GetSellerInventory();

            if (inventory == null || !inventory.Any())
                return NoContent();

            return Ok(inventory);
        }


        [HttpGet("GetSellerInventoryById/{InventoryId}")]
        public IActionResult GetProductsById(int InventoryId)
        {
            var inventory = _dalSellerInventory.GetSellerInventoryById(InventoryId);

            if (inventory == null)
                return NoContent();

            return Ok(inventory);
        }


        [HttpPost]
        [Route("InsertSellerInventory")]
        public ResponseModel InsertSellerInventory(SellerInventoryModel model)
        {
            return _dalSellerInventory.InsertSellerInventory(model);
        }

        [HttpPost]
        [Route("UpdateSellerInventory")]
        public ResponseModel UpdateSellerInventory(SellerInventoryModel model)
        {
            return _dalSellerInventory.UpdateSellerInventory(model);
        }


        [Route("DeleteSellerInventory")]
        [HttpGet]
        public ResponseModel DeleteSellerInventory(int inventoryId)
        {
            return _dalSellerInventory.DeleteSellerInventory(inventoryId);
        }
    }
}
