using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ECommerce.Web.CommonHelper
{
    public static class Helper
    {
        private static IConfiguration _config;   
        private static readonly string key = "A1B2C3D4E5F6G7H8I9J0K1L2M3N4O5P6";
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("1234567890123456");

         public static void Init(IConfiguration configuration)
        {
            _config = configuration;
        }

        private static string Path => _config?["AppSettings:ErrorLogPath"] ?? "C:\\Logs";

        public static void WriteLog(string message)
        {
            try
            {
                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);

                string fileName = "Error_Log_" + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt";
                string fullPath = System.IO.Path.Combine(Path, fileName);

                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine($"{DateTime.Now:dd-MMM-yyyy HH:mm:ss}\t{message}");
                }
            }
            catch
            {
                throw;
            }
        }

        public static string EncryptPassword(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                using (var ms = new MemoryStream())
                {
                    using (var encryptor = aes.CreateEncryptor())
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var writer = new StreamWriter(cs))
                    {
                        writer.Write(plainText);
                    }  
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }


        public static string DecryptPassword(string cipherText)
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

        public static List<Dictionary<string, object>> ConvertToObjectList(DataTable dt)
        {
            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in dt.Rows)
            {
                var obj = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                    obj[col.ColumnName] = row[col];
                list.Add(obj);
            }

            return list;
        }
    }
}
