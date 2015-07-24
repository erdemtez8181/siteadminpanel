using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Security.Cryptography.Xml;

namespace Siteyonetim.Framework.Business
{

    public static class CryptoHelper
    {

        #region General Function

        public const int A78HeaderSize = 128;

        public static string ComputeDigest(byte[] bytes)
        {
            return Stringify(new SHA1CryptoServiceProvider().ComputeHash(bytes));
        }

        public static string ComputeDigest(FileInfo fileInfo)
        {
            FileStream stream = null;
            try
            {
                stream = File.OpenRead(fileInfo.FullName);
                if (fileInfo.Extension.ToLower() == ".a78")
                    stream.Seek(A78HeaderSize, SeekOrigin.Begin);
                return Stringify(new SHA1CryptoServiceProvider().ComputeHash(stream));
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
        public static string HashString(string Value)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Value);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }


        private static string Stringify(byte[] bytes)
        {
            if (bytes.Length != 16)
            {

                //String.Format(
                //    CultureInfo.InvariantCulture,
                //    "Wrong MD5 checksum size : {0} bytes",
                //    bytes.Length


            }
            StringBuilder result = new StringBuilder();
            foreach (byte b in bytes)
                result.AppendFormat("{0:x2}", b);
            return result.ToString();
        }

        public static string CalculateMD5Hash(byte[] DataBytes)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] hash = md5.ComputeHash(DataBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }


        public static RSACryptoServiceProvider SigningKey = null;

        public static RSACryptoServiceProvider GetSigningKey()
        {

            return SigningKey;

        }

        #endregion

      
        public static byte[] GetDigest(byte[] hash)
        {
            string digStr = Convert.ToBase64String(hash);
            byte[] DigestVaL = new byte[digStr.Length];
            for (int i = 0; i < digStr.Length; i++)
                DigestVaL[i] = (byte)(digStr[i]);
            return DigestVaL;
        }
        public static string GetDigestString(byte[] hash)
        {
            return Convert.ToBase64String(hash);

        }

        public static string textToBase64(string sAscii)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(sAscii);
            return System.Convert.ToBase64String(bytes, 0, bytes.Length);
        }
        public static string base64ToText(string sbase64)
        {
            byte[] bytes = System.Convert.FromBase64String(sbase64);
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetString(bytes, 0, bytes.Length);
        }

        private static readonly MD5 Md5 = MD5.Create();
        public static string GetMd5Sum(string inputString)
        {
            byte[] input = Encoding.UTF8.GetBytes(inputString);
            byte[] result = Md5.ComputeHash(input);
            return Convert.ToBase64String(result);
        }






    }



}




