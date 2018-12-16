namespace AssemblerCompiler.Directives
{
    public class Data : Directive
    {
        public Data(string codeLine) : base(codeLine)
        {
        }

        protected override void Perform(Program program)
        {
            program.StartSegment(SegmnetType.Data);
        }
    }
}