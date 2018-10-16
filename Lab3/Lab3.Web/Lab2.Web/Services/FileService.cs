using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Lab3.Web.Models;

namespace Lab3.Web.Services
{
    public class FileService
    {
        public const string BaseDirectory = @"D:\Sequrity3\";

        public byte[] LoadFile(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        public void SaveEncriptingResut(EncryptingResultModel encryptingResult, FileInfo file)
        {
            var fileData = new byte[encryptingResult.IV.Length + encryptingResult.EncryptedData.Length];
            Array.Copy(encryptingResult.IV, 0, fileData, 0, encryptingResult.IV.Length);
            Array.Copy(encryptingResult.EncryptedData, 0, fileData, encryptingResult.IV.Length, encryptingResult.EncryptedData.Length);

            var encodedFilePath = file.FullName.Insert(file.FullName.Length - file.Extension.Length, "_encrypted");
            File.WriteAllBytes(encodedFilePath, fileData);
        }
    }
}