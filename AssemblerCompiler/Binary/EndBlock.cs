namespace AssemblerCompiler.Binary
{
    public class EndBlock : Block
    {
        public EndBlock()
        {
            AddRecord(new Record(0x8A).AddBinaryCode(new BinaryCode(0x00)));
        }
    }
}