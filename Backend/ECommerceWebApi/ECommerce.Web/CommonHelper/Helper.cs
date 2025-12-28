using ECommerce.Web.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ECommerce.Web.CommonHelper
{
    public static class Helper
    {
        private static IConfiguration _config;
        private static readonly string key = "A1B2C3D4E5F6G7H8I9J0K1L2M3N4O5P6";
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("1234567890123456");

        private static string _connectionString;


        public static void Init(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        private static string Path => _config?["AppSettings:ErrorLogPath"] ?? "C:\\Logs";


        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new Exception("Connection string not initialized. Call Helper.Init() first.");

            return _connectionString;
        }


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

        public static string GenerateToken(UserModel user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleName ?? "Customer")
            };

            var securityKey = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256
            );
            var token = new JwtSecurityToken(
                issuer: _config?["Jwt:Issuer"],
                audience: _config?["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
