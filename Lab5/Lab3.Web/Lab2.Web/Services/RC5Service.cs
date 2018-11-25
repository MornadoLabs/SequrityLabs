using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Web.Helpers;
using Lab5.Web.Models;

namespace Lab5.Web.Services
{
    public class RC5Service
    {
        private static RandomNumberGenerator RandomNumberGenerator = new RandomNumberGenerator();

        private HashService HashService { get; set; } = new HashService();

        public EncryptingResultModel Encrypt(byte[] input, byte[] keyInput, int w, int r, int b)
        {
            var key = GetKey(keyInput, b);
            for (int i = 0; i < keyInput.Length; i++)
            {
                keyInput[i] = 0;
            }

            var helper = new RC5Helper(w, r, key);
            input = GetFullInput(input, helper.BlockSize);            

            var IV = GetInitializeVector(helper.BlockSize);
            var resultData = new byte[input.Length];
            var result = new EncryptingResultModel { IV = EncryptInitializeVector(IV, key, w, r) };
            for (int i = 0; i < input.Length; i += helper.BlockSize)
            {
                var currentBlock = new byte[helper.BlockSize];
                Array.Copy(input, i, currentBlock, 0, helper.BlockSize);

                currentBlock = XOR(IV, currentBlock, helper.W);
                IV = EncryptBlock(currentBlock, helper);

                Array.Copy(IV, 0, resultData, i, helper.BlockSize);
            }
            result.EncryptedData = resultData;

            return result;
        }

        public byte[] Decrypt(byte[] startupInput, byte[] keyInput, int w, int r, int b)
        {
            var key = GetKey(keyInput, b);
            for (int i = 0; i < keyInput.Length; i++)
            {
                keyInput[i] = 0;
            }

            var helper = new RC5Helper(w, r, key);
            var input = GetEncryptingResultModel(startupInput, helper.BlockSize);            
            var result = new byte[input.EncryptedData.Length];
            var IV = DecryptInitializeVector(input.IV, key, w, r);
            for (int i = 0; i < input.EncryptedData.Length; i += helper.BlockSize)
            {
                var currentBlock = new byte[helper.BlockSize];
                Array.Copy(input.EncryptedData, i, currentBlock, 0, helper.BlockSize);

                var decryptedBlock = DecryptBlock(currentBlock, helper);
                decryptedBlock = XOR(IV, decryptedBlock, helper.W);
                Array.Copy(decryptedBlock, 0, result, i, helper.BlockSize);
                
                IV = currentBlock;
            }

            return RemoveAppending(result);
        }

        private byte[] GetInitializeVector(int blockSize)
        {
            switch (blockSize)
            {
                case 4: return BitConverter.GetBytes(RandomNumberGenerator.GetNextNumber()).Take(4).ToArray();
                case 8: return BitConverter.GetBytes(RandomNumberGenerator.GetNextNumber());
                case 16:
                    {
                        var part1 = BitConverter.GetBytes(RandomNumberGenerator.GetNextNumber());
                        var part2 = BitConverter.GetBytes(RandomNumberGenerator.GetNextNumber());

                        return part1.Concat(part2).ToArray();
                    }
                default: throw new Exception("Incorrect block size.");
            }
        }

        private byte[] EncryptInitializeVector(byte[] input, byte[] key, int w, int r)
        {
            var helper = new RC5Helper(w, r, key);

            if (input.Length % helper.BlockSize != 0)
            {
                input = GetFullInput(input, helper.BlockSize);
            }

            var result = new byte[input.Length];
            for (int i = 0; i < input.Length; i += helper.BlockSize)
            {
                var currentBlock = new byte[helper.BlockSize];
                Array.Copy(input, i, currentBlock, 0, helper.BlockSize);
                currentBlock = EncryptBlock(currentBlock, helper);
                Array.Copy(currentBlock, 0, result, i, helper.BlockSize);
            }

            return result;
        }

        private byte[] DecryptInitializeVector(byte[] input, byte[] key, int w, int r)
        {
            var helper = new RC5Helper(w, r, key);            
            var result = new byte[input.Length];

            for (int i = 0; i < input.Length; i += helper.BlockSize)
            {
                var currentBlock = new byte[helper.BlockSize];
                Array.Copy(input, i, currentBlock, 0, helper.BlockSize);
                currentBlock = DecryptBlock(currentBlock, helper);
                Array.Copy(currentBlock, 0, result, i, helper.BlockSize);
            }

            return result;
        }

        private byte[] GetKey(byte[] keyInput, int b)
        {
            var keyHash = HashService.GetHashInBytes(keyInput);

            if (b < 16)
            {
                var result = new byte[8];
                Array.Copy(keyHash, 0, result, 0, result.Length);
                return result;
            }
            else if (b < 32)
            {
                return keyHash;
            }
            else
            {
                var addingHash = HashService.GetHashInBytes(keyHash);
                var result = new byte[32];
                Array.Copy(keyHash, 0, result, 0, keyHash.Length);
                Array.Copy(addingHash, 0, result, keyHash.Length, addingHash.Length);
                return result;
            }
        }

        private byte[] GetFullInput(byte[] input, int blockSize)
        {
            var fullInputSize = (input.Length / blockSize + 1) * blockSize;
            var appendSize = fullInputSize - input.Length;
            var append = new byte[appendSize];
            for (int i = 0; i < appendSize; i++)
            {
                append[i] = (byte) appendSize;
            }

            var fullInput = new byte[fullInputSize];
            Array.Copy(input, 0, fullInput, 0, input.Length);
            Array.Copy(append, 0, fullInput, input.Length, append.Length);

            return fullInput;
        }

        private byte[] EncryptBlock(byte[] block, RC5Helper helper)
        {
            var A = GetBlockPart(block, true, helper.W);
            var B = GetBlockPart(block, false, helper.W);

            A += helper.S[0];
            B += helper.S[1];

            for (int i = 1; i <= helper.R; i++)
            {
                A = helper.RotateLeft((A ^ B), (int)B, helper.W * 8) + helper.S[2 * i];
                B = helper.RotateLeft((B ^ A), (int)A, helper.W * 8) + helper.S[2 * i + 1];
            }

            var result = new byte[2 * helper.W];
            var partA = BitConverter.GetBytes(A);
            var partB = BitConverter.GetBytes(B);

            Array.Copy(partA, 0, result, 0, helper.W);
            Array.Copy(partB, 0, result, helper.W, helper.W);

            return result;
        }

        private byte[] DecryptBlock(byte[] block, RC5Helper helper)
        {
            var A = GetBlockPart(block, true, helper.W);
            var B = GetBlockPart(block, false, helper.W);


            for (int i = helper.R; i > 0; i--)
            {
                B = helper.RotateRight(B - helper.S[2 * i + 1], (int)A, helper.W * 8) ^ A;
                A = helper.RotateRight(A - helper.S[2 * i], (int)B, helper.W * 8) ^ B;
            }

            A -= helper.S[0];
            B -= helper.S[1];

            var result = new byte[2 * helper.W];
            var partA = BitConverter.GetBytes(A);
            var partB = BitConverter.GetBytes(B);

            Array.Copy(partA, 0, result, 0, helper.W);
            Array.Copy(partB, 0, result, helper.W, helper.W);

            return result;
        }

        private ulong GetBlockPart(byte[] block, bool isFirst, int w)
        {
            if (w < 8)
            {
                var tmp = new byte[8];
                Array.Copy(block, isFirst ? 0 : w, tmp, 0, w);
                return BitConverter.ToUInt64(tmp, 0);
            }
            else
            {
                return BitConverter.ToUInt64(block, isFirst ? 0 : w);
            }
        }

        private byte[] XOR(byte[] arr1, byte[] arr2, int w)
        {
            var A1 = GetBlockPart(arr1, true, w);
            var B1 = GetBlockPart(arr1, false, w);
            var A2 = GetBlockPart(arr2, true, w);
            var B2 = GetBlockPart(arr2, false, w);

            return BitConverter.GetBytes(A1 ^ A2).Concat(BitConverter.GetBytes(B1 ^ B2)).ToArray();
        }

        private EncryptingResultModel GetEncryptingResultModel(byte[] input, int blockSize)
        {
            var result = new EncryptingResultModel();
            result.IV = new byte[blockSize];
            result.EncryptedData = new byte[input.Length - blockSize];
            Array.Copy(input, 0, result.IV, 0, blockSize);
            Array.Copy(input, blockSize, result.EncryptedData, 0, result.EncryptedData.Length);
            return result;
        }

        private byte[] RemoveAppending(byte[] data)
        {
            var result = new byte[data.Length - data[data.Length - 1]];
            Array.Copy(data, 0, result, 0, result.Length);
            return result;
        }
    }
}