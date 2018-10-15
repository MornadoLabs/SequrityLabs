using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Web.Services
{
    internal class RandomNumberGenerator
    {
        public RandomNumberGenerator()
        {
            this.a = (long) Math.Pow(7, 5);
            this.c = 17711;
            this.m = (long) Math.Pow(2, 31) - 1;
            this.x = 31;
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