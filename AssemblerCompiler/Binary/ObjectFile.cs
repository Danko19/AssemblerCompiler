using System.IO;

namespace AssemblerCompiler.Binary
{
    public class ObjectFile
    {
        public readonly HeaderBlock HeaderBlock = new HeaderBlock();
        public readonly DescriptionBlock DescriptionBlock = new DescriptionBlock();
        public readonly SegmentsBlock SegmentsBlock = new SegmentsBlock();
        public readonly EndBlock EndBlock = new EndBlock();

        public void ToBytes(BinaryWriter binaryWriter)
        {
            HeaderBlock.ToBytes(binaryWriter);
            DescriptionBlock.ToBytes(binaryWriter);
            SegmentsBlock.ToBytes(binaryWriter);
            EndBlock.ToBytes(binaryWriter);
        }
    }
}