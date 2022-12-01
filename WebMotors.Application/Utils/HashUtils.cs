using System.Security.Cryptography;
using System.Text;

namespace WebMotors.Application.Utils
{
    public class HashUtils
    {
        public static string HashPassword(string password)
        {
            string initialSalt = "b147V2";
            string finalSalt = "cw@6492";
            password = initialSalt + password + finalSalt;
            MD5 md5 = MD5.Create();
            byte[] encodedPassword = Encoding.UTF8.GetBytes(password);
            byte[] hashedPassword = md5.ComputeHash(encodedPassword);
            string finalPassword = Convert.ToBase64String(hashedPassword);
            if (finalPassword.Length > 30)
            {
                finalPassword = finalPassword[..30];
            }
            return finalPassword;
        }
    }
}