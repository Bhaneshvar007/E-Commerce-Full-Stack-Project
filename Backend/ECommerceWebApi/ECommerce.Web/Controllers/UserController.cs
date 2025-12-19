using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.DataAcessLayer.Service;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IDalUser _iuser;


        public UserController(IDalUser iuser)
        {
            this._iuser = iuser;
        }

        [Route("GetUser")]
        [HttpGet]
        public IActionResult Index()
        {
            var users = _iuser.GetUsers();

            if (users == null || !users.Any())
                return NoContent();
            return Ok(users);
        }

        [Route("SignUp")]
        [HttpPost]
        public ResponseModel RegistrationUser([FromBody] UserSignupDto umodel)
        {
            return _iuser.AddUser(umodel);
        }

        

        [Route("GetUserById/{UserId}")]
        [HttpGet]
        public IActionResult GetUserById(int UserId)
        {
            var users = _iuser.GetUserById(UserId);

            if (users == null)
                return NoContent();

            return Ok(users);
        }


        [Route("Login")]
        [HttpPost]
        public ResponseModel LoginUser([FromBody] UserLoginDto umodel)
        {
            return _iuser.LoginUser(umodel);
        }


        [Route("LogOut")]
        [HttpGet]
        public ResponseModel LogOut()
        {
            return _iuser.LogoutUser();
        }

        [Route("UpdateUser")]
        [HttpPost]
        public ResponseModel UpdateUser([FromBody] UserModel umodel)
        {
            return _iuser.UpdateUser(umodel);
        }
    }
}
