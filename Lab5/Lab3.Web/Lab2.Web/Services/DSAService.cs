using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using Lab5.Web.Models;

namespace Lab5.Web.Services
{
    public class DSAService
    {
        public const string PublicKeyFile = "PublicKey";
        public const string PrivateKeyFile = "PrivateKey";

        private DSACryptoServiceProvider Provider { get; set; } = new DSACryptoServiceProvider();
        private FileService FileService { get; set; } = new FileService();

        public KeysModel GenerateKeys()
        {
            Provider = new DSACryptoServiceProvider();

            var publicKey = Provider.ExportCspBlob(false);
            var privateKey = Provider.ExportCspBlob(true);

            return new KeysModel { PublicKey = publicKey, PrivateKey = privateKey };
        }

        public byte[] SignData(byte[] input)
        {
            var privateKey = FileService.LoadFile(PrivateKeyFile);
            Provider.ImportCspBlob(privateKey);

            return Provider.SignData(input);
        }

        public bool CheckSign(byte[] input, byte[] sign)
        {
            var publicKey = FileService.LoadFile(PublicKeyFile);
            Provider.ImportCspBlob(publicKey);

            return Provider.VerifyData(input, sign);
        }
    }
}