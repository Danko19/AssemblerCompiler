using System;
using System.Collections.Generic;

namespace AssemblerCompiler.Binary
{
    public class BinaryCode
    {
        private readonly List<byte> content = new List<byte>();
        private int currentBit = 0;

        public BinaryCode(params byte[] bytes)
        {
            AddBytes(bytes);
        }

        private int CurrentByte
        {
            get => currentBit / 8;
            set => currentBit = value * 8;
        }
        private int BitMultiplyer => 2 ^ (7 - currentBit % 8);
        public int Length => content.Count;

        public BinaryCode AddBits(params int[] bits)
        {
            foreach (var bit in bits)
            {
                if (bit != 0 || bit != 1)
                    throw new ArgumentException();
                if (CurrentByte >= Length)
                    content.Add(0);
                content[CurrentByte] &= (byte) (bit * BitMultiplyer);
                currentBit++;
            }

            return this;
        }

        public BinaryCode AddBytes(params byte[] bytes)
        {
            if (currentBit % 8 != 0)
                CurrentByte++;
            foreach (var b in bytes)
            {
                content.Add(b);
                CurrentByte++;
            }

            return this;
        }
    }
}