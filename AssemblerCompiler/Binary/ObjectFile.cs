namespace AssemblerCompiler.Binary
{
    public class ObjectFile
    {
        public readonly HeaderBlock HeaderBlock = new HeaderBlock();
        public readonly DescriptionBlock DescriptionBlock = new DescriptionBlock();
    }
}