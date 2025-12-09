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

    internal class CetagoryRepository : ICetagoryRepository
    {
        private readonly IHelper _helper;
        public CetagoryRepository(IHelper helper)
        {
            this._helper = helper;
        }

        public List<CetagoryModel> GetCetagorys(DataTable DT)
        {
            var cetagories = new List<CetagoryModel>();

            if (DT == null || DT.Rows.Count == 0)
                return cetagories;
            try
            {


                foreach (DataRow row in DT.Rows)
                {
                    var pass = row["Password"] != DBNull.Value ? Convert.ToString(row["Password"]) : "";
                    string decPass = _helper.DecryptPassword(pass);

                    CetagoryModel list = new CetagoryModel()
                    {
                        CetagoryId = row["CetagoryId"] != DBNull.Value ? Convert.ToInt32(row["CetagoryId"]) : 0,
                        CetagoryName = row["CetagoryName"] != DBNull.Value ? Convert.ToString(row["CetagoryName"]) : "",
                        Description = row["Description"] != DBNull.Value ? Convert.ToString(row["Description"]) : "",
                        ImageUrl = row["ImageUrl"] != DBNull.Value ? Convert.ToString(row["ImageUrl"]) : "",
                        CreatedBy = row["CreatedBy"] != DBNull.Value ? Convert.ToInt32(row["CreatedBy"]) : 0,
                        CreatedDate = row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.MinValue,
                    };

                    cetagories.Add(list);
                }
            }
            catch (Exception ex)
            {
                _helper.WriteLog($"Error In Cetagory Repository GetCetagorys {ex.ToString()}");
                throw ex;
            }

            return cetagories;
        }

    }
}