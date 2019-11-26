using System;
using System.Security.Cryptography;
using System.Text;

namespace Team17.Library
{
    public class Security
    {
        public static String HashText(String TextToHash)
        {
            SHA1CryptoServiceProvider SHA1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            Byte[] bytValue = Encoding.UTF8.GetBytes(TextToHash);
            Byte[] bytHash = SHA1.ComputeHash(bytValue);
            SHA1.Clear();

            //Return a base 64 encoded string of the Hash value
            return Convert.ToBase64String(bytHash);
        }

    }
}
