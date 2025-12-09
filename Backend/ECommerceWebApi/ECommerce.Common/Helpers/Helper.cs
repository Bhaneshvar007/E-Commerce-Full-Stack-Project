using ECommerce.Common.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Helpers
{
    public class Helper : IHelper
    {
        private readonly IConfiguration _config;
        private string key = "A1B2C3D4E5F6G7H8I9J0K1L2M3N4O5P6";
        private readonly byte[] iv = Encoding.UTF8.GetBytes("1234567890123456");

        
        public Helper(IConfiguration config)
        {
            _config = config;
        }
        private string path => _config["AppSettings:ErrorLogPath"];

        public void WriteLog(string message)
        {
 
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            
            string fileName = "Error_Log_" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt";
            string fullPath = Path.Combine(path, fileName);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(DateTime.Now.ToString("dd-MMM-yyyy") + "\t" + message);
            }
        }



        public string EncryptPassword(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv; 

                using (var encryptor = aes.CreateEncryptor())
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                using (var writer = new StreamWriter(cs))
                {
                    writer.Write(plainText);
                    writer.Close();   
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

 
        public string DecryptPassword(string cipherText)
        {
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;  

                using (var decryptor = aes.CreateDecryptor())
                using (var ms = new MemoryStream(buffer))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd();
                }
            }
        }



        public List<Dictionary<string, object>> ConvertToObjectList(DataTable dt)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in dt.Rows)
            {
                var obj = new Dictionary<string, object>();

                foreach (DataColumn col in dt.Columns)
                {
                    obj[col.ColumnName] = row[col];
                }

                list.Add(obj);
            }

            return list;
        }

       


    }
}
