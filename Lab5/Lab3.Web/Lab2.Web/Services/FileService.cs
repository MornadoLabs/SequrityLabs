using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Lab5.Web.Models;

namespace Lab5.Web.Services
{
    public class FileService
    {
        public const string BaseDirectory = @"C:\Users\mornado\Desktop\Sequrity\";

        public byte[] LoadFile(string fileName)
        {
            return File.ReadAllBytes(BaseDirectory + fileName);
        }

        public void SaveFile(string fileName, byte[] content)
        {
            File.WriteAllBytes(BaseDirectory + fileName, content);
        }

        public void SaveEncriptingResut(EncryptingResultModel encryptingResult, string fileName)
        {
            var file = new FileInfo(BaseDirectory + fileName);
            var fileData = new byte[encryptingResult.IV.Length + encryptingResult.EncryptedData.Length];
            Array.Copy(encryptingResult.IV, 0, fileData, 0, encryptingResult.IV.Length);
            Array.Copy(encryptingResult.EncryptedData, 0, fileData, encryptingResult.IV.Length, encryptingResult.EncryptedData.Length);

            var encodedFilePath = file.FullName.Insert(file.FullName.Length - file.Extension.Length, "_encrypted");
            File.WriteAllBytes(encodedFilePath, fileData);
        }

        public void SaveDecriptingResut(string fileName, byte[] decryptingResult)
        {
            var file = new FileInfo(BaseDirectory + fileName);
            var decryptedFilePath = string.Empty;

            if (file.Name.Contains("_encrypted"))
            {
                decryptedFilePath = file.Directory + "\\" + file.Name.Replace("_encrypted", "_decrypted");
            }
            else
            {
                decryptedFilePath = file.FullName.Insert(file.FullName.Length - file.Extension.Length, "_decrypted");
            }

            File.WriteAllBytes(decryptedFilePath, decryptingResult);
        }
        
        public void SaveFileWithSuffix(string fileName, string suffix, byte[] data)
        {
            var file = new FileInfo(BaseDirectory + fileName);
            var resultFilePath = file.FullName.Insert(file.FullName.Length - file.Extension.Length, suffix);
            File.WriteAllBytes(resultFilePath, data);
        }
    }
}