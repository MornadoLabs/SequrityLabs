using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using Lab5.Web.Models;
using System.IO;

namespace Lab5.Web.Services
{
    public class RSAService
    {
        public const string PublicKeyFile = "PublicKey";
        public const string PrivateKeyFile = "PrivateKey";
        public const int DefaultKeySize = 1024;

        private const int EncryptBlockSize = 64;
        private const int DecryptBlockSize = 128;

        private RSACryptoServiceProvider Provider { get; set; } = new RSACryptoServiceProvider(DefaultKeySize);
        private FileService FileService { get; set; } = new FileService();
        
        public KeysModel GenerateKeys(int keySize)
        {
            Provider = new RSACryptoServiceProvider(keySize);

            var publicKey = Provider.ExportCspBlob(false);
            var privateKey = Provider.ExportCspBlob(true);

            return new KeysModel { PublicKey = publicKey, PrivateKey = privateKey };
        }

        public byte[] Encrypt(byte[] input)
        {
            var publicKey = FileService.LoadFile(PublicKeyFile);
            Provider.ImportCspBlob(publicKey);

            var encryptedData = new MemoryStream();

            for (int i = 0; i < input.Length; i += EncryptBlockSize)
            {
                var buffer = new byte[i + EncryptBlockSize > input.Length ? input.Length - i : EncryptBlockSize];
                Array.Copy(input, i, buffer, 0, buffer.Length);
                buffer = Provider.Encrypt(buffer, false);
                encryptedData.Write(buffer, 0, buffer.Length);
            }            

            return encryptedData.ToArray();
        }

        public byte[] Decrypt(byte[] input)
        {
            var privateKey = FileService.LoadFile(PrivateKeyFile);
            Provider.ImportCspBlob(privateKey);

            var decryptedData = new MemoryStream();

            for (int i = 0; i < input.Length; i += DecryptBlockSize)
            {
                var buffer = new byte[i + DecryptBlockSize > input.Length ? input.Length - i : DecryptBlockSize];
                Array.Copy(input, i, buffer, 0, buffer.Length);
                buffer = Provider.Decrypt(buffer, false);
                decryptedData.Write(buffer, 0, buffer.Length);
            }

            return decryptedData.ToArray();
        }        
    }
}