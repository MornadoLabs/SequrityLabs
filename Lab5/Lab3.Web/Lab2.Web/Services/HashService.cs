using Lab5.Web.Models;
using Lab5.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5.Web.Services
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
            return ProcessBlock(input, true);
        }

        public byte[] GetHashInBytes(byte[] input)
        {
            input = GetFullInput(input);
            return ProcessBlockInBytes(input, true);
        }

        public string ProcessBlock(byte[] block, bool isFirstBlock = false)
        {
            var roundModels = RoundService.GetRoundModels(block);

            if (isFirstBlock)
                MDBuffer.ResetBuffer();            

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

        public byte[] ProcessBlockInBytes(byte[] block, bool isFirstBlock = false)
        {
            var roundModels = RoundService.GetRoundModels(block);

            if (isFirstBlock)
                MDBuffer.ResetBuffer();

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

            var result = new byte[16];
            Array.Copy(BitConverter.GetBytes(MDBuffer.A), 0, result, 0, 4);
            Array.Copy(BitConverter.GetBytes(MDBuffer.B), 0, result, 4, 4);
            Array.Copy(BitConverter.GetBytes(MDBuffer.C), 0, result, 8, 4);
            Array.Copy(BitConverter.GetBytes(MDBuffer.D), 0, result, 12, 4);

            return result;
        }

        public AppendModel GetAppendModel(long startupSize)
        {
            var inputSize = startupSize * 8;
            var inputSizeAppend = BitConverter.GetBytes(inputSize);

            var appendSize = inputSize % 512 == 448 ? 64 :
                             inputSize % 512 > 448 ? (960 - inputSize % 512) / 8
                                                    : (448 - inputSize % 512) / 8;
            var append = new byte[appendSize];
            append[0] = 0x80;

            return new AppendModel { InputSize = inputSizeAppend, Append = append };
        }

        private byte[] GetFullInput(byte[] startupInput)
        {
            var appends = GetAppendModel(startupInput.LongLength);

            var result = new byte[startupInput.Length + appends.InputSize.Length + appends.Append.Length];
            Array.Copy(startupInput, result, startupInput.Length);
            Array.Copy(appends.Append, 0, result, startupInput.Length, appends.Append.Length);
            Array.Copy(appends.InputSize, 0, result, startupInput.Length + appends.Append.Length, appends.InputSize.Length);

            return result;
        }
        
    }
}