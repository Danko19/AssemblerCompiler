namespace AssemblerCompiler.Directives
{
    public class Code : Directive
    {
        public override int OperandsCount => 0;

        public Code(string codeLine) : base(codeLine)
        {
        }

        protected override void Perform(Program program)
        {
            program.StartSegment(SegmnetType.Code);
        }
    }
}