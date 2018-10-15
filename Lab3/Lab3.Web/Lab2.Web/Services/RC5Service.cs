using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab3.Web.Helpers;

namespace Lab3.Web.Services
{
    public class RC5Service
    {
        private static RandomNumberGenerator RandomNumberGenerator = new RandomNumberGenerator();

        private HashService HashService { get; set; } = new HashService();

        public byte[] Encrypt(byte[] input, byte[] keyInput, int w, int r, int b)
        {
            var key = GetKey(keyInput, b);
            for (int i = 0; i < keyInput.Length; i++)
            {
                keyInput[i] = 0;
            }

            var helper = new RC5Helper(w, r, key);

            if (input.Length % helper.BlockSize != 0)
            {
                input = GetFullInput(input, helper.BlockSize);
            }

            var IV = EncryptInitializeVector(BitConverter.GetBytes(RandomNumberGenerator.GetNextNumber()), key, w, r);
            var result = new byte[input.Length];
            for (int i = 0; i < input.Length; i += helper.BlockSize)
            {
                var currentBlock = new byte[helper.BlockSize];
                Array.Copy(input, i, currentBlock, 0, helper.BlockSize);

                currentBlock = XOR(IV, currentBlock);
                IV = EncryptBlock(currentBlock, helper);

                Array.Copy(IV, 0, result, i, helper.BlockSize);
            }

            return result;
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

            for (int i = 1; i < helper.R; i++)
            {
                A = helper.RotateLeft((A ^ B), (int)B, helper.W * 8) + helper.S[2 * i];
                B = helper.RotateLeft((B ^ A), (int)A, helper.W * 8) + helper.S[2 * i + 1];
            }

            var result = new byte[2 * helper.W];
            var partA = BitConverter.GetBytes(A);
            var partB = BitConverter.GetBytes(B);

            Array.Copy(partA, 0, result, 0, helper.W);
            Array.Copy(partB, helper.W, result, 0, helper.W);

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

        private byte[] XOR(byte[] arr1, byte[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new ArgumentException("Incorrect arrays length.");
            }

            var result = new byte[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = (byte) (arr1[i] ^ arr2[i]);
            }

            return result;
        }
    }
}