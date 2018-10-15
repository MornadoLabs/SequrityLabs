using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Lab3.Web.Services
{
    public class FileService
    {
        public const string BaseFilesPath = @"D:\Sequrity2Input\";
        public const long FileSizeLimit = 1073741824; // 1 GB
        public const int BlockSize = 64;
        public const int RoundSize = 268435456; // 256 Mb

        private HashService HashService { get; set; } = new HashService();

        public string GetFileHash(string fileName)
        {
            var fileInfo = new FileInfo(BaseFilesPath + fileName);

            if (fileInfo.Length < FileSizeLimit)
                return HashService.GetHash(File.ReadAllBytes(BaseFilesPath + fileName));

            var roundsCount = fileInfo.Length / RoundSize;
            if (fileInfo.Length % RoundSize != 0)
            {
                roundsCount++;
            }

            var appends = HashService.GetAppendModel(fileInfo.Length);
            var result = string.Empty;
            byte[] roundsBuffer;

            using (var stream = File.OpenRead(fileInfo.FullName))
            {
                for (int i = 0; i < roundsCount; i++)
                {
                    if (i != roundsCount - 1)
                    {
                        roundsBuffer = new byte[RoundSize];
                        var blocksCount = RoundSize / BlockSize;

                        stream.Read(roundsBuffer, 0, RoundSize);

                        for (int j = 0; j < blocksCount; j++)
                        {
                            var buffer = new byte[BlockSize];
                            Array.Copy(roundsBuffer, j * BlockSize, buffer, 0, BlockSize);
                            result = HashService.ProcessBlock(buffer, i == 0);
                        }                        
                    }
                    else
                    {
                        var lastRoundSize = fileInfo.Length - i * RoundSize;
                        var lastRoundsBuffer = new byte[lastRoundSize];
                        var blocksCount = lastRoundSize / BlockSize;
                        if (lastRoundSize % BlockSize != 0)
                        {
                            blocksCount++;
                        }

                        stream.Read(lastRoundsBuffer, 0, Convert.ToInt32(lastRoundSize));

                        for (int j = 0; j < blocksCount; j++)
                        {
                            if (j != blocksCount - 1)
                            {
                                var buffer = new byte[BlockSize];
                                Array.Copy(lastRoundsBuffer, j * BlockSize, buffer, 0, BlockSize);
                                result = HashService.ProcessBlock(buffer);
                            }
                            else
                            {
                                var lastBlockSize = lastRoundSize - j * BlockSize;
                                var buffer = new byte[lastBlockSize + appends.Append.Length + appends.InputSize.Length];

                                Array.Copy(lastRoundsBuffer, j * BlockSize, buffer, 0, lastBlockSize);
                                Array.Copy(appends.Append, 0, buffer, lastBlockSize, appends.Append.Length);
                                Array.Copy(appends.InputSize, 0, buffer, lastBlockSize + appends.Append.Length, appends.InputSize.Length);

                                result = HashService.ProcessBlock(buffer);                                
                            }
                        }
                    }
                }

                //var buffer = new byte[BlockSize];
                //stream.Read(buffer, 0, BlockSize);

                //result = HashService.ProcessBlock(buffer, true);

                //for (int i = 1; i < blocksCount; i++)
                //{
                //    stream.Read(buffer, 0, BlockSize);
                //    result = HashService.ProcessBlock(buffer);
                //}

                //var lastBlockOffset = blocksCount * BlockSize;
                //var lastBlockSize = Convert.ToInt32(fileInfo.Length - lastBlockOffset);
                //stream.Read(buffer, 0, lastBlockSize);
                //Array.Copy(appends.Append, 0, buffer, lastBlockSize, appends.Append.Length);
                //Array.Copy(appends.InputSize, 0, buffer, lastBlockSize + appends.Append.Length, appends.InputSize.Length);

                //result = HashService.ProcessBlock(buffer);
            }

            return result;
        }
    }
}