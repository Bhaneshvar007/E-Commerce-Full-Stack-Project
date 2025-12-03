using ECommerce.Common.Helpers;
using ECommerce.Common.Models;
using ECommerce.Common.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Repository.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly IHelper _helper;
        public UserRepository(IHelper helper)
        {
            this._helper = helper;
        }
        public List<UserModel> GetUsers(DataTable DT)
        {
            List<UserModel> users = new List<UserModel>();

            if (DT == null || DT.Rows.Count == 0)
                return users;
            try
            {


                foreach (DataRow row in DT.Rows)
                {
                    var pass = row["Password"] != DBNull.Value ? Convert.ToString(row["Password"]) : "";
                    string decPass = _helper.DecryptPassword(pass);

                    UserModel user = new UserModel()
                    {
                        UserId = row["UserId"] != DBNull.Value ? Convert.ToInt32(row["UserId"]) : 0,
                        UserName = row["UserName"] != DBNull.Value ? Convert.ToString(row["UserName"]) : "",
                        Email = row["Email"] != DBNull.Value ? Convert.ToString(row["Email"]) : "",
                        Password = decPass,
                        PhoneNumber = row["Number"] != DBNull.Value ? Convert.ToString(row["Number"]) : "",
                        //RoleId = row["RoleId"] != DBNull.Value ? Convert.ToInt32(row["RoleId"]) : 0,
                        //roleModel = new RoleModel() { RoleName = row["RoleName"] != DBNull.Value ? Convert.ToString(row["RoleName"]) : "" },
                        ImageUrl = row["ImageUrl"] != DBNull.Value ? Convert.ToString(row["ImageUrl"]) : "",
                        CreatedBy = row["CreatedBy"] != DBNull.Value ? Convert.ToInt32(row["CreatedBy"]) : 0,
                        CreatedDate = row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.MinValue,
                        UpdatedBy = row["ModifiedBy"] != DBNull.Value ? Convert.ToInt32(row["ModifiedBy"]) : 0,
                        UpdatedDate = row["ModifiedDate"] != DBNull.Value ? Convert.ToDateTime(row["ModifiedDate"]) : DateTime.MinValue,
                        DeletedBy = row.Table.Columns.Contains("DeletedBy") && row["DeletedBy"] != DBNull.Value
                                    ? Convert.ToInt32(row["DeletedBy"]) : 0
                    };

                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                _helper.WriteLog($"Error In UserRepository GetUsers {ex.ToString()}");
            }

            return users;
        }



    }
}
