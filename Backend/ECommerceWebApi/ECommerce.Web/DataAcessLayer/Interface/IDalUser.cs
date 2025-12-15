 using ECommerce.Web.Models;

namespace ECommerce.Web.DataAcessLayer.Interface
{
    public interface IDalUser
    {
        public List<UserModel> GetUsers();
        public UserModel GetUserById(int id);
        public ResponseModel AddUser(UserSignupDto umodel);
        public ResponseModel LoginUser(UserModel umodel);
        public ResponseModel LogoutUser();
        public ResponseModel UpdateUser(UserModel umodel);
    }
}
