using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Helpers
{
    public interface IHelper
    {
        public void WriteLog(string message);
        public string EncryptPassword(string plainText);
        public string DecryptPassword(string cipherText);


        public List<Dictionary<string, object>> ConvertToObjectList(DataTable dt);
    }
}
