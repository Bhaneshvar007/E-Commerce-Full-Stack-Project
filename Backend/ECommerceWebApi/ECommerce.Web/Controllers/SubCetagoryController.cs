using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCetagoryController : Controller
    {
        public readonly IDalSubCetagory _dalSubCetagory;
        public SubCetagoryController(IDalSubCetagory dalSubCetagory) {
            this._dalSubCetagory = dalSubCetagory;
        }


        [Authorize]
        [Route("GetSubCetagory")]
        [HttpGet]
        public IActionResult Index()
        {
            var subcetagory = _dalSubCetagory.GetSubCetagory();

            if (subcetagory == null || !subcetagory.Any())
                return NoContent();

            return Ok(subcetagory);
        }

        [Authorize]
        [Route("GetSubCetagoryById/{SubCetagoryId}")]
        [HttpGet]
        public IActionResult GetSubCetagoryById(int SubCetagoryId)
        {
            var subcetagory = _dalSubCetagory.GetSubCetagoryById(SubCetagoryId);

            if (subcetagory == null)
                return NoContent();

            return Ok(subcetagory);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("InsertSubCetagory")]
        public ResponseModel InsertSubCetagory(SubCetagoryModel SubcetagoryModel)
        {
            return _dalSubCetagory.InsertSubCetagory(SubcetagoryModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("UpdateSubCetagory")]
        public ResponseModel UpdateSubCetagory(SubCetagoryModel subcetagoryModel)
        {
            return _dalSubCetagory.UpdateSubCetagory(subcetagoryModel);
        }


        [Authorize(Roles = "Admin")]
        [Route("DeleteSubCetagory")]
        [HttpGet]
        public ResponseModel DeleteSUbCetagory(int SubCetagoryId)
        {
            return _dalSubCetagory.DeleteSubCetagory(SubCetagoryId);
        }
    }
}
