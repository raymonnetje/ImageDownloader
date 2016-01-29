using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDownloader
{
    public class Crypt
    {
        Key codes = new Key();
        AesCryptoServiceProvider aes;
        byte[] key;
        byte[] IV;

        public Crypt()
        {
            aes = new AesCryptoServiceProvider();
            key = StringToByteArray(codes.getKey());
            IV = StringToByteArray(codes.getIV());
        }

        public String EncryptString(String inputString)
        {
            byte[] encryptedString;

            ICryptoTransform encryptor = aes.CreateEncryptor(key, IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(inputString);
                    }
                    encryptedString = msEncrypt.ToArray();
                }
            }
    
            return ByteArrayToString(encryptedString);
        }

        public String DecryptString(string inputHash)
        {
            String decryptedString = "";

            byte[] input = StringToByteArray(inputHash);

            ICryptoTransform decryptor = aes.CreateDecryptor(key, IV);

            using (MemoryStream msDecrypt = new MemoryStream(input))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        decryptedString = srDecrypt.ReadToEnd();
                    }
                }
            }
            return decryptedString;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }


        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
