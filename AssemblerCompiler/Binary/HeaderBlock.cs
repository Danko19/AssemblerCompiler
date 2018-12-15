using System.Collections.Generic;
using AssemblerCompiler.Extensions;

namespace AssemblerCompiler.Binary
{
    public class HeaderBlock : IBlock
    {
        private readonly List<Record> records = new List<Record>();

        public void AddRecord(Record record)
        {
            records.Add(record);
        }

        public byte[] ToBytes()
        {
            return null; //todo;
        }

        public void Fill(string fileName)
        {
            records.Add(new Record(0x80).AddBinaryCode(AddString(new BinaryCode(), fileName)));
            records.Add(new Record(0x88).AddBinaryCode(AddString(new BinaryCode(0, 0), Constants.CompilerName)));
            records.Add(new Record(0x88).AddBinaryCode(AddString(new BinaryCode(0x40, 0xE9, 0x96, 0x7E, 0x5E, 0x4D), fileName)));
            records.Add(new Record(0x88).AddBinaryCode(new BinaryCode(0x40, 0xE9)));
            records.Add(new Record(0x96).AddBinaryCode(new BinaryCode(0)));
            records.Add(new Record(0x88).AddBinaryCode(new BinaryCode(0x40, 0xA1)));
        }

        private static BinaryCode AddString(BinaryCode binaryCode, string str)
        {
            binaryCode.AddBytes((byte) str.Length);
            binaryCode.AddBytes(str.ToBytes());
            return binaryCode;
        }
    }
}