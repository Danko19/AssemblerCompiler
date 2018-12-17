using AssemblerCompiler.Extensions;

namespace AssemblerCompiler.Binary
{
    public class SegmentsBlock : Block
    {
        private int segmentNumber = 1;

        public readonly Segment DataSegment;
        public readonly Segment CodeSegment;

        public SegmentsBlock()
        {
            AddRecord(new Record(0x88).AddBinaryCode(new BinaryCode(0x40, 0xA2, 0x01)));
            DataSegment = new Segment(this);
            CodeSegment = new Segment(this);
        }

        public byte[] GetNextSegmentNumber()
        {
            return segmentNumber++.InReverseByteOrder(3);
        }

    }
}