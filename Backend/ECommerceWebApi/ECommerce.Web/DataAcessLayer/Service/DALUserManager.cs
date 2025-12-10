using ECommerce.Web.Models;
using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.Extensions;
using System.Text.Json;

namespace ECommerce.Web.DataAcessLayer.Service
{
    public class DALUserManager : IDALUserManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        
        public DALUserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserModel User()
        {
            
                return _httpContextAccessor.HttpContext?
                            .Session.GetObject<UserModel>("UserDetails");
            
        }
    }

}
