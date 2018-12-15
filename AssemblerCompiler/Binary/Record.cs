using System.Collections.Generic;
using System.Linq;

namespace AssemblerCompiler.Binary
{
    public class Record
    {
        private readonly List<BinaryCode> content = new List<BinaryCode>();

        public Record(byte id)
        {
            Id = id;
        }

        public byte Id { get; }
        public int Length => content.Sum(x => x.Length) + 1;

        public Record AddBinaryCode(BinaryCode binaryCode)
        {
            content.Add(binaryCode);
            return this;
        }

        public byte[] ToBytes()
        {
            return new byte[] { 1}; //todo
        }

        private byte GetControlByte(IEnumerable<byte> bytes)
        {
            var buffer = 0;
            foreach (var b in bytes)
                buffer += b;
            return (byte) (256 - buffer % 256);
        }
    }
}