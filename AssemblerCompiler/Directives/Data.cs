namespace AssemblerCompiler.Directives
{
    public class Data : Directive
    {
        public override int OperandsCount => 0;

        public Data(int lineNumber, string codeLine) : base(lineNumber, codeLine)
        {
        }

        protected override void Perform(Program program)
        {
            program.StartSegment(SegmnetType.Data);
        }
    }
}