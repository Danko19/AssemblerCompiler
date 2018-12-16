using AssemblerCompiler.Extensions;

namespace AssemblerCompiler.Binary
{
    public class DescriptionBlock : Block
    {
        private int segmentNumber = 2;
        public void StartCodeSegment()
        {
            records.Add(new Record(0x96).AddBinaryCode(new BinaryCode().AddString("_TEXT").AddString("CODE")));
        }

        public void StartDataSegment()
        {
            records.Add(new Record(0x96).AddBinaryCode(new BinaryCode().AddString("_DATA").AddString("DATA")));
        }

        public void EndSegment(int size)
        {
            records.Add(new Record(0x98).AddBinaryCode(
                new BinaryCode(0x48)
                    .AddBytes(size.InReverseByteOrder(2))
                    .AddBytes((byte) segmentNumber++, (byte) segmentNumber++, 1)));

        }

        public void SetDgroup()
        {
            records.Add(new Record(0x96).AddBinaryCode(new BinaryCode().AddString("DGROUP")));
            records.Add(new Record(0x9A).AddBinaryCode(new BinaryCode(6, 0xFF, 2)));

        }
    }
}