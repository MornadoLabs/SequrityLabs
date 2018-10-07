using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Web.Models
{
    public class RoundInputModel
    {
        public const int WordsCount = 16;
        public const int WordSize = 4;

        public RoundInputModel(byte[] inputBlock)
        {
            _words = new List<uint>();
            for (int i = 0; i < WordsCount; i++)
            {
                var word = new byte[WordSize];
                Array.Copy(inputBlock, i * WordSize, word, 0, WordSize);
                _words.Add(BitConverter.ToUInt32(word, 0));
            }
        }

        private List<uint> _words;
        public uint this[int i] => _words[i];
    }
}