using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Console.Helpers
{
    internal static class FileWriter
    {
        public static void WritePartOfSequenceToFile(string path, List<long> data)
        {
            File.AppendAllLines(path, data.Select(d => d.ToString()));
        }
    }
}
