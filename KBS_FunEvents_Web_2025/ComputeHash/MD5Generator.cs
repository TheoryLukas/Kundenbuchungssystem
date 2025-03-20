using System.Text;
using XSystem.Security.Cryptography;

namespace KBS_FunEvents_Web_2025.ComputeHash
{
    public class MD5Generator
    {
        public static string getMD5Hash(string password)
        {
            StringBuilder sb = new StringBuilder();
            var md5provider = new MD5CryptoServiceProvider();

            //computing MD5 hash
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(password));
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
