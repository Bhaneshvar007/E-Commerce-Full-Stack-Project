using ECommerce.Common.Models;
using ECommerce.Web.DataAcessLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CetagoryController : Controller
    {
        public readonly IDalCetagory _dalCetagory;

        public CetagoryController(IDalCetagory dalCetagory)
        {
            this._dalCetagory = dalCetagory;
        }

        [Route("GetCetagory")]
        [HttpGet]
        public IActionResult Index()
        {
            var cetagory = _dalCetagory.GetCetagory();

            if (cetagory == null || !cetagory.Any())
                return NoContent();

            return Ok(cetagory);
        }


        [Route("GetCetagoryById/{CetagoryId}")]
        [HttpGet]
        public IActionResult GetCetagoryById(int CetagoryId)
        {
            var cetagory = _dalCetagory.GetCetagoryById(CetagoryId);

            if (cetagory == null)
                return NoContent();

            return Ok(cetagory);
        }


        [HttpPost]
        [Route("InsertCetagory")]
        public ResponseModel InsertCetagory(CetagoryModel cetagoryModel)
        {
            return _dalCetagory.InsertCetagory(cetagoryModel);
        }

        [HttpPost]
        [Route("UpdateCetagory")]
        public ResponseModel UpdateCetagory(CetagoryModel cetagoryModel)
        {
            return _dalCetagory.UpdateCetagory(cetagoryModel);
        }


        [Route("DeleteCetagory")]
        [HttpGet]
        public ResponseModel DeleteCetagory(int CetagoryId)
        {
            return _dalCetagory.DeleteCetagory(CetagoryId);
        }


    }
}
