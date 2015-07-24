using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;


namespace Siteyonetim.Framework.Business
{
    public static class Functions
    {
        private static byte[] ByteOrderMark = Encoding.UTF8.GetPreamble();

        public static decimal toDecimalEN(string obj)
        {
            if (!string.IsNullOrEmpty(obj))
                return Decimal.Parse(obj, new System.Globalization.CultureInfo("en-US"));
            else return 0;


        }
        public static decimal toDecimalTR(string obj)
        {
            if (!string.IsNullOrEmpty(obj))
                return Decimal.Parse(obj, new System.Globalization.CultureInfo("tr-TR"));
            else return 0;
        }

        public static string toDecStrTR(string obj)
        {
            if (!string.IsNullOrEmpty(obj))
                return string.Format("{0:0,00}", obj).Replace(",", ".");
            else return "0";

            //return Decimal.Parse(obj, new System.Globalization.CultureInfo("tr-TR")).ToString().Replace(",", ".");
        }
        public static string toIssueDate(DateTime dt)
        {
            //2010-11-23
            return String.Format("{0:yyyy-MM-dd}", dt);
        }
        public static string toIssueTime(DateTime dt)
        {
            //11:54:23
            return String.Format("{0:HH:mm:ss}", dt);
        }




        public static string ConvertEnum(string s)
        {
            string result = string.Empty;
            char[] letters = s.ToCharArray();
            foreach (char c in letters)
                if (c.ToString() != c.ToString().ToLower())
                    result += " " + c.ToString();
                else
                    result += c.ToString();
            return result;
        }


        public static string toString(string obj)
        {
            if (!string.IsNullOrEmpty(obj))
                return obj;
            else return string.Empty;
        }

        public static byte[] ConvertFileToByteArray(string fileName)
        {
            byte[] returnValue = null;

            using (FileStream fr = new FileStream(fileName, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fr))
                {
                    returnValue = br.ReadBytes((int)fr.Length);
                }
            }

            return returnValue;

        }
        private static string Temizle(string veri)
        {

            veri = Regex.Replace(veri, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "");
            veri = Regex.Replace(veri, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", "");
            veri = Regex.Replace(veri, "<(.|\\n)*?>", "");
            veri = Regex.Replace(veri, "admin’--", "");
            veri = Regex.Replace(veri, "’ or 0=0 --", "");
            veri = Regex.Replace(veri, "\" or 0=0 --", "");
            veri = Regex.Replace(veri, "or 0=0 -- ", "");
            veri = Regex.Replace(veri, "’ or 0=0 #", "");
            veri = Regex.Replace(veri, "\" or 0=0 #", "");
            veri = Regex.Replace(veri, "or 0=0 #", "");
            veri = Regex.Replace(veri, "’ or ’x’=’x", "");
            veri = Regex.Replace(veri, "\" or \"x\"=\"x", "");
            veri = Regex.Replace(veri, "' OR ''='", "");


            return veri;

        }

        public static bool isEmail(string emailAddress)
        {

            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"

                        + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"

                        + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"

                        + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"

                        + @"[a-zA-Z]{2,}))$";

            Regex reStrict = new Regex(patternStrict);


            return reStrict.IsMatch(emailAddress);



        }

        public static string EndPointAdres(int INVOICE_CLIENT_ID, int PartnerID)
        {

            string adress = string.Format(Siteyonetim.Framework.Business.GlobalEnum.ServerWCFBaseAddress, INVOICE_CLIENT_ID, PartnerID) + INVOICE_CLIENT_ID.ToString();
            return adress;

        }

        public static string SadeceBasHarfiBuyut(string Yazi)
        {
            if (string.IsNullOrEmpty(Yazi))
            {
                return string.Empty;
            }
            char[] a = Yazi.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public static string CalculateHashWithSHA1(byte[] data)
        {
            var obj = SHA1.Create().ComputeHash(data);
            return Convert.ToBase64String(obj);
        }

        public static byte[] CalculateHashWithSHA256(ref byte[] data)
        {
            return new SHA256Managed().ComputeHash(data);
        }

        public static byte[] CalculateHashWithSHA256(byte[] data)
        {
            return new SHA256Managed().ComputeHash(data);
        }

        public static string ToHex(byte[] data)
        {
            string hex = null;
            foreach (byte x in data)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        public static bool CheckBarcodeWeight(string barcode, ref int checksum)
        {
            char[] weight = "131313131313".ToCharArray();
            char[] barcodearr = barcode.ToCharArray();
            if (barcodearr.Length != 13) throw new ArgumentOutOfRangeException("barcode lenght invalid");
            int totalWeight = 0;
            for (int i = 0; i < weight.Length-1; i++)
            {
                totalWeight += Convert.ToInt32(weight[i].ToString()) * Convert.ToInt32(barcodearr[i].ToString());
            }

            totalWeight = totalWeight % 10;
            checksum = 10 - totalWeight;
            return (checksum == Convert.ToInt32(barcodearr[12].ToString()));

        }

        /// <summary>
        /// Byte Data içinde byteordermark varsa temizler
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] RemoveByteOrderMark(byte[] data)
        {
            bool bomSign = true;
            for (int i = 0; i < ByteOrderMark.Length; i++)
            {
                if (ByteOrderMark[i] != data[i])
                {
                    bomSign = false;
                    break;
                }
            }
            if (!bomSign)
                return data;
            byte[] TempData = new byte[data.Length - ByteOrderMark.Length];
            Array.Copy(data, ByteOrderMark.Length, TempData, 0, data.Length - ByteOrderMark.Length);
            return TempData;
        }
    }
}
