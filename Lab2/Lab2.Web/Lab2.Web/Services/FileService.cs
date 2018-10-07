using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Lab2.Web.Services
{
    public class FileService
    {
        public const string BaseFilesPath = @"D:\Sequrity2Input\";

        public byte[] LoadFile(string fileName)
        {
            return File.ReadAllBytes(BaseFilesPath + fileName);
        }
    }
}