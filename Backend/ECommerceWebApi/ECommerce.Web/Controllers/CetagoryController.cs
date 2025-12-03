using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CetagoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
