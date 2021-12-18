using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace authentication {
    internal class AesEncrypt {

        public static string DecryptString( string cipherText , byte [ ] key , byte [ ] iv ) {
            Aes encryptor = Aes.Create( );
            encryptor.Mode = CipherMode.CBC;
            encryptor.Key = key;
            encryptor.IV = iv;
            MemoryStream memoryStream = new MemoryStream( );
            ICryptoTransform aesDecryptor = encryptor.CreateDecryptor( );
            CryptoStream cryptoStream = new CryptoStream( memoryStream , aesDecryptor , CryptoStreamMode.Write );
            string plainText = String.Empty;

            try {
                byte [ ] cipherBytes = Convert.FromBase64String( cipherText );
                cryptoStream.Write( cipherBytes , 0 , cipherBytes.Length );
                cryptoStream.FlushFinalBlock( );
                byte [ ] plainBytes = memoryStream.ToArray( );
                plainText = Encoding.ASCII.GetString( plainBytes , 0 , plainBytes.Length );
            } finally {
                memoryStream.Close( );
                cryptoStream.Close( );
            }
            return plainText;
        }

        public static string EncryptString( string plainText , byte [ ] key , byte [ ] iv ) {
            Aes encryptor = Aes.Create( );
            encryptor.Mode = CipherMode.CBC;
            encryptor.Key = key;
            encryptor.IV = iv;
            MemoryStream memoryStream = new MemoryStream( );
            ICryptoTransform aesEncryptor = encryptor.CreateEncryptor( );
            CryptoStream cryptoStream = new CryptoStream( memoryStream , aesEncryptor , CryptoStreamMode.Write );
            byte [ ] plainBytes = Encoding.ASCII.GetBytes( plainText );
            cryptoStream.Write( plainBytes , 0 , plainBytes.Length );
            cryptoStream.FlushFinalBlock( );
            byte [ ] cipherBytes = memoryStream.ToArray( );
            memoryStream.Close( );
            cryptoStream.Close( );
            string cipherText = Convert.ToBase64String( cipherBytes , 0 , cipherBytes.Length );
            return cipherText;
        }

        private static string Base64Encode( string plainText ) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes( plainText );
            return System.Convert.ToBase64String( plainTextBytes );
        }
    }
}