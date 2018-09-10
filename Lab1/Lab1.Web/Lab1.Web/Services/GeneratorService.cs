using Lab1.Web.Helpers;
using Lab1.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace Lab1.Web.Services
{
    public class GeneratorService
    {
        public const string path = @"D:\RandomSequence.txt";
        public static GeneratingResultModel GenerateSequence(InputModel input)
        {
            var generator = new RandomSequenceGenerator(input.A, input.C, input.M, input.X0);
            var result = new List<long>();

            File.WriteAllText(path, string.Empty);
            using (var fileStream = File.OpenWrite(path))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.AutoFlush = true;
                    while (!generator.IsEnded)
                    {
                        var sequencePart = generator.GetNextSequencePart();
                        result.Add(sequencePart[0]);
                        var fileLine = new StringBuilder();
                        sequencePart.ForEach(num => fileLine.Append(num).Append(" "));
                        writer.WriteLine(fileLine.ToString());
                    }
                }
            }

            return new GeneratingResultModel { TuchPoints = result, Period = generator.Period };
        }
    }
}