using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Web.Services
{
    internal class RandomNumberGenerator : IRandomNumberGenerator
    {
        public RandomNumberGenerator(long a, long c, long m, long x0)
        {
            this.a = a;
            this.c = c;
            this.m = m;
            this.x = x0;
        }

        private long a { get; set; }
        private long c { get; set; }
        private long m { get; set; }
        private long x { get; set; }

        public long GetNextNumber()
        {
            var result = x;
            x = (a * x + c) % m;
            return result;
        }
    }
}
