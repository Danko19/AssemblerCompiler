namespace AssemblerCompiler.Directives
{
    public class Data : Directive
    {
        public override int OperandsCount => 0;

        public Data(string codeLine) : base(codeLine)
        {
        }

        protected override void Perform(Program program)
        {
            program.StartSegment(SegmnetType.Data);
        }
    }
}