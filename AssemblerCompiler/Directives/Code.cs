namespace AssemblerCompiler.Directives
{
    public class Code : Directive
    {
        public Code(string codeLine) : base(codeLine)
        {
        }

        protected override void Perform(Program program)
        {
            program.StartSegment(SegmnetType.Code);
        }
    }
}