using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Web.Services
{
    public class RandomSequenceGenerator : IRandomSequenceGenerator
    {
        public const int PartSize = 200000;

        public RandomSequenceGenerator(long a, long c, long m, long x0)
        {
            this.Generator = new RandomNumberGenerator(a, c, m, x0);
            this.x0 = x0;
            this.Period = 0;
            this.IsEnded = false;
            this.IsStart = true;
            this.FirstElements = new List<long>();
        }
        
        private RandomNumberGenerator Generator { get; set; }
        private bool IsStart { get; set; }
        private List<long> FirstElements { get; set; }
        private long prevNumb { get; set; }

        public long x0 { get; protected set; }
        public long Period { get; protected set; }
        public bool IsEnded { get; protected set; }

        public List<long> GetNextSequencePart()
        {
            if (IsEnded)
            {
                return null;
            }
            if (IsStart)
            {
                FirstElements = new List<long> { x0 };
            }

            var result = new List<long>();

            for (int i = 0; i < PartSize; i++)
            {
                var nextNumber = Generator.GetNextNumber();
                result.Add(nextNumber);

                if (IsStart && i < 2)
                {
                    FirstElements.Add(nextNumber);
                }

                if (nextNumber == x0 && (!IsStart || IsStart && result.Count > 1) || FirstElements.Contains(nextNumber) && (!IsStart || IsStart && i > 1) || nextNumber == prevNumb)
                {
                    IsEnded = true;
                    Period += i;
                    return result;
                }

                prevNumb = nextNumber;
            }

            Period += PartSize;

            if (IsStart)
            {
                IsStart = false;
            }

            return result;
        }
    }
}
