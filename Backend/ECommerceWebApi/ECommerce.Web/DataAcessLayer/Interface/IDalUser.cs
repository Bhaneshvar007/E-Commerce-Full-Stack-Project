using ECommerce.Common.Models;

namespace ECommerce.Web.DataAcessLayer.Interface
{
    public interface IDalUser
    {
        public List<UserModel> GetUsers();
        public UserModel GetUserById(int id);
        public ResponseModel AddUser(UserModel umodel);
        public ResponseModel LoginUser(UserModel umodel);
        public ResponseModel UpdateUser(UserModel umodel);
    }
}
