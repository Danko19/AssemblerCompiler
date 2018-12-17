using System.Collections.Generic;
using System.IO;

namespace AssemblerCompiler.Binary
{
    public abstract class Block
    {
        protected readonly List<Record> records = new List<Record>();

        public void AddRecord(Record record)
        {
            records.Add(record);
        }

        public void ToBytes(BinaryWriter binaryWriter)
        {
            foreach (var record in records)
                binaryWriter.Write(record.ToBytes());
        }
    }
}