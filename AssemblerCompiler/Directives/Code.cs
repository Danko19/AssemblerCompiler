namespace AssemblerCompiler.Directives
{
    public class Code : Directive
    {
        public override int OperandsCount => 0;

        public Code(int lineNumber, string codeLine) : base(lineNumber, codeLine)
        {
        }

        protected override void Perform(Program program)
        {
            program.StartSegment(SegmnetType.Code);
        }
    }
}