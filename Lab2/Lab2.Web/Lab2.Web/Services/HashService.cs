using Lab2.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Web.Services
{
    public class HashService
    {
        private const int CycleCount = 4;
        private const int RoundStepsCount = 16;

        public HashService()
        {
            MDBuffer = new MDBufferRepository();
            RoundService = new RoundService();
        }

        private MDBufferRepository MDBuffer { get; set; }     
        private RoundService RoundService { get; set; }

        public string GetHash(byte[] input)
        {
            input = GetFullInput(input);
            var roundModels = RoundService.GetRoundModels(input);

            foreach (var roundModel in roundModels)
            {
                var startupBuffer = MDBuffer.Clone();

                for (int cycleNumber = 0; cycleNumber < CycleCount; cycleNumber++)
                {
                    for (int i = 0; i < RoundStepsCount; i++)
                    {
                        var a = MDBuffer[0, i % 4];
                        var b = MDBuffer[1, i % 4];
                        var c = MDBuffer[2, i % 4];
                        var d = MDBuffer[3, i % 4];

                        var idx = RoundService.GetRoundIdx(i, cycleNumber);

                        RoundService.ApplyRoundFunction(
                            ref a, b, c, d, 
                            roundModel[idx], 
                            (i + 1) + 16 * cycleNumber, 
                            RoundService.S[cycleNumber, i % 4], 
                            cycleNumber);

                        MDBuffer[i % 4] = a;
                    }
                }

                MDBuffer = MDBuffer + startupBuffer;

            }

            return MDBuffer.ToString();
        }

        private byte[] GetFullInput(byte[] startupInput)
        {
            var inputSize = startupInput.LongLength * 8;
            var inputSizeAppend = BitConverter.GetBytes(inputSize);

            var appendSize = inputSize % 512 == 448 ? 64 : 
                             inputSize % 512 > 448  ? (960 - inputSize % 512) / 8 
                                                    : (448 - inputSize % 512) / 8;
            var append = new byte[appendSize];
            append[0] = 0x80;

            var result = new byte[startupInput.Length + inputSizeAppend.Length + append.Length];
            Array.Copy(startupInput, result, startupInput.Length);
            Array.Copy(append, 0, result, startupInput.Length, append.Length);
            Array.Copy(inputSizeAppend, 0, result, startupInput.Length + append.Length, inputSizeAppend.Length);

            return result;
        }
        
    }
}