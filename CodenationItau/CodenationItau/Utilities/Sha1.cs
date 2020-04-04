using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace ConsoleApp1.Utilities
{
    public class Sha1
    {
        private SHA1CryptoServiceProvider cryptoTransformSHA1;

        public Sha1()
        {
            cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
        }

        public string Generate(string hash)
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes(hash);
                string report = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer))
                                    .Replace("-", "")
                                    .ToLower();

                return report;
            }
            catch (Exception)
            {}

            return "";
        }
    }
}
