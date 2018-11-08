using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Web.Helpers
{
    public class RC5Helper
    {
        public static readonly Dictionary<int, ulong> Pw = new Dictionary<int, ulong>
        {
            { 16, 0xB7E1 },
            { 32, 0xB7E15163 },
            { 64, 0xB7E151628AED2A6B }
        };

        public static readonly Dictionary<int, ulong> Qw = new Dictionary<int, ulong>
        {
            { 16, 0x9E37 },
            { 32, 0x9E3779B9 },
            { 64, 0x9E3779B97F4A7C15 }
        };        

        public RC5Helper(int w, int r, byte[] key)
        {
            W = w % 8 == 0 ? w / 8 : 4;
            R = r;
            B = key.Length;

            var Key = new byte[B];
            Array.Copy(key, 0, Key, 0, B);

            var c = B / W;
            var L = new ulong[c];
            for (int i = B - 1; i >= 0; i--)
            {
                L[i / W] = RotateLeft(L[i / W], 8, W * 8) + Key[i];
            }

            S = new ulong[2 * r + 2];
            S[0] = Pw[w];
            for (int i = 1; i < S.Length; i++)
            {
                S[i] = S[i - 1] + Qw[w];
            }

            var t = 3 * Math.Max(L.Length, S.Length);
            ulong A1 = 0, B1 = 0;
            for (int s = 0, i = 0, j = 0; s < t; s++)
            {
                S[i] = RotateLeft((S[i] + A1 + B1), 3, W * 8);
                A1 = S[i];
                i = (i + 1) % S.Length;

                L[j] = RotateLeft((L[j] + A1 + B1), (int) (A1 + B1), W * 8);
                B1 = L[j];
                j = (j + 1) % L.Length;
            }
        }

        public int W { get; protected set; }
        public int R { get; protected set; }
        public int B { get; protected set; }
        //public byte[] Key { get; protected set; }

        public int BlockSize => 2 * W;
        public ulong[] S { get; protected set; }

        public ulong RotateLeft(ulong val, int offset, int w)
        {
            return (val << offset) | (val >> (w - offset));
        }

        public ulong RotateRight(ulong val, int offset, int w)
        {
            return (val >> offset) | (val << (w - offset));
        }
    }
}