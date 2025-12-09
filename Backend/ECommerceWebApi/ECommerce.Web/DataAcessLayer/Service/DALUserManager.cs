using ECommerce.Common.Models;
using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.Extensions;
using System.Text.Json;

namespace ECommerce.Web.DataAcessLayer.Service
{
    public class DALUserManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DALUserManager()
        {
        }

        public DALUserManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserModel User
        {
            get
            {
                return _httpContextAccessor.HttpContext.Session.GetObject<UserModel>("UserDetails");
            }
        }
    }

}
