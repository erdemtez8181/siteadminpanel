using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.Management;
using System.IO;

namespace Siteyonetim.Framework.Business
{
    public class LicenceHelper
    {
        public LicenceHelper()
        {
        }
        private string _Erorr;
        public string Erorr
        {
            get { return _Erorr; }
        }
        //Public Key ile şifrelenmiş metin dosyası key file'da bulunur. 
        //Privatekey ile Decript eder, Decrypt sonucu VKN+Donanım bilgileri ile eşleştirilir
        //Eşleşme sonucu lisansın geçerliliğini belirler.
        public bool CheckLicence(string KeyFile, string PrivateKeyFile, string VKN)
        {
            try
            {
                string KeyFileString = string.Empty;
                string privateKeyFileString = string.Empty;


                //Key dosyasının varlığını kontrol et ve yükle 
                if (File.Exists(KeyFile))
                {
                    StreamReader streamReader = new StreamReader(KeyFile, true);
                    KeyFileString = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                else return false;

                //Private Key dosyasının varlığını kontrol et ve yükle 
                int bitStrength = 0;
                if (File.Exists(PrivateKeyFile))
                {
                    StreamReader streamReader = new StreamReader(PrivateKeyFile, true);
                    privateKeyFileString = streamReader.ReadToEnd();
                    streamReader.Close();

                    string bitStrengthString = privateKeyFileString.Substring(0, privateKeyFileString.IndexOf("</BitStrength>") + 14);
                    privateKeyFileString = privateKeyFileString.Replace(bitStrengthString, "");
                    bitStrength = Convert.ToInt32(bitStrengthString.Replace("<BitStrength>", "").Replace("</BitStrength>", ""));
                }
                else return false;


                string DecryptedString = DecryptString(KeyFileString, bitStrength, privateKeyFileString);


                string KeyString = VKN; //+ "*" + HardWareInfo();

                if (DecryptedString.Equals(KeyString)) return true;
                else return false;
            }
            catch (Exception ex)
            {
                this._Erorr = ex.Message;
                return false;
            }

        }


        //Donanım bilgilerini alır
        public string HardWareInfo()
        {
            string _HardWareInfo = string.Empty;

            //Anakart Seri numarası
            ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            foreach (ManagementObject getserial in MOS.Get())
            {
                _HardWareInfo = getserial["SerialNumber"].ToString() + "#";
                break;
            }

            //Code for retrieving Processor's Identity
            MOS = new ManagementObjectSearcher("Select * From Win32_processor");
            foreach (ManagementObject getPID in MOS.Get())
            {
                _HardWareInfo += getPID["ProcessorID"].ToString() + "?";
                break;
            }
            //Harddisk Seri numarası
            MOS = new ManagementObjectSearcher("Select * From Win32_DiskDrive");
            foreach (ManagementObject getPID in MOS.Get())
            {
                _HardWareInfo += getPID["SerialNumber"].ToString() + "$";
                break;
            }

            return _HardWareInfo;
        }



        public string DecryptString(string inputString, int dwKeySize, string xmlString)
        {
            // TODO: Add Proper Exception Handlers
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
            rsaCryptoServiceProvider.FromXmlString(xmlString);
            int base64BlockSize = ((dwKeySize / 8) % 3 != 0) ? (((dwKeySize / 8) / 3) * 4) + 4 : ((dwKeySize / 8) / 3) * 4;
            int iterations = inputString.Length / base64BlockSize;
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < iterations; i++)
            {
                byte[] encryptedBytes = Convert.FromBase64String(inputString.Substring(base64BlockSize * i, base64BlockSize));
                // Be aware the RSACryptoServiceProvider reverses the order of encrypted bytes after encryption and before decryption.
                // If you do not require compatibility with Microsoft Cryptographic API (CAPI) and/or other vendors.
                // Comment out the next line and the corresponding one in the EncryptString function.
                Array.Reverse(encryptedBytes);
                arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedBytes, true));
            }
            return Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
        }

        public string EncryptString(string inputString, int dwKeySize, string xmlString)
        {
            // TODO: Add Proper Exception Handlers
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
            rsaCryptoServiceProvider.FromXmlString(xmlString);
            int keySize = dwKeySize / 8;
            byte[] bytes = Encoding.UTF32.GetBytes(inputString);
            // The hash function in use by the .NET RSACryptoServiceProvider here is SHA1
            // int maxLength = ( keySize ) - 2 - ( 2 * SHA1.Create().ComputeHash( rawBytes ).Length );
            int maxLength = keySize - 42;
            int dataLength = bytes.Length;
            int iterations = dataLength / maxLength;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= iterations; i++)
            {
                byte[] tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
                // Be aware the RSACryptoServiceProvider reverses the order of encrypted bytes after encryption and before decryption.
                // If you do not require compatibility with Microsoft Cryptographic API (CAPI) and/or other vendors.
                // Comment out the next line and the corresponding one in the DecryptString function.
                Array.Reverse(encryptedBytes);
                // Why convert to base 64?
                // Because it is the largest power-of-two base printable using only ASCII characters
                stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
            }
            return stringBuilder.ToString();
        }

    }
}
