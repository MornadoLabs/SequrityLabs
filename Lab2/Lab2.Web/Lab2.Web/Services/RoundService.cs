using Lab2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Web.Services
{
    public class RoundService
    {
        public const int BlockSize = 64;

        public List<RoundInputModel> GetRoundModels(byte[] input)
        {
            var roundsCount = input.Length / BlockSize;
            var roundModels = new List<RoundInputModel>();
            for (int i = 0; i < roundsCount; i++)
            {
                var roundInput = new byte[BlockSize];
                Array.Copy(input, i * BlockSize, roundInput, 0, BlockSize);
                roundModels.Add(new RoundInputModel(roundInput));
            }

            return roundModels;
        }

        public void ApplyRoundFunction(ref uint A, uint B, uint C, uint D, uint X, int i, byte s, int cycleNumber)
        {
            var F = GetRoundFunction(cycleNumber);
            A = B + GetLeftRotate(A + F(B, C, D) + X + GetT(i), s);
        }

        public byte[,] S { get; private set; } = new byte[,]
        {
            { 7, 12, 17, 22 },
            { 5, 9, 14, 20 },
            { 4, 11, 16, 23 },
            { 6, 10, 15, 21 }
        };        

        public int GetRoundIdx(int i, int cycleNumber)
        {
            switch (cycleNumber)
            {
                case 0: return i;
                case 1: return (1 + 5 * i) % 16;
                case 2: return (5 + 3 * i) % 16;
                case 3: return (7 * i) % 16;
                default: throw new Exception("Unknown cycle number.");
            }
        }

        private RoundFunction GetRoundFunction(int i)
        {
            switch (i)
            {
                case 0: return GetF;
                case 1: return GetG;
                case 2: return GetH;
                case 3: return GetI;
                default: throw new Exception("Unknown round function id.");
            }
        }

        private uint GetT(int i)
        {
            return (uint)(Math.Pow(2, 32) * Math.Abs(Math.Sin(i)));
        }

        private uint GetF(uint B, uint C, uint D)
        {
            return (B & C) | (~B & D);
        }

        private uint GetG(uint B, uint C, uint D)
        {
            return (B & D) | (C & ~D);
        }

        private uint GetH(uint B, uint C, uint D)
        {
            return B ^ C ^ D;
        }

        private uint GetI(uint B, uint C, uint D)
        {
            return C ^ (B | ~D);
        }

        private uint GetLeftRotate(uint value, byte s)
        {
            return (value << s) | (value >> (32 - s));
        }

        public delegate uint RoundFunction(uint B, uint C, uint D);
    }
}