using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WeiXinBenDiTestComponents
{
    public class CryptoHelper
    {
        public static string SHA1(params object[] args)
        {
            Array.Sort(args);
            string temp = String.Join("", args);
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(temp));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        public static string Md5(string source)
        {
            byte[] buffer = MD5.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(source));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in buffer)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string Base64Encode(string source)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            try
            {
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return source;
            }
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns></returns>
        public static string Base64Decode(string result)
        {
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                return Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return result;
            }
        }
    }
}
