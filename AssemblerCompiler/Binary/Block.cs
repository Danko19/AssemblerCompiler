using System.Collections.Generic;

namespace AssemblerCompiler.Binary
{
    public abstract class Block
    {
        protected readonly List<Record> records = new List<Record>();

        public void AddRecord(Record record)
        {
            records.Add(record);
        }

        public byte[] ToBytes()
        {
            var result = new List<byte>();
            foreach (var record in records)
            {
                result.AddRange(record.ToBytes());
            }

            return result.ToArray();
        }
    }
}