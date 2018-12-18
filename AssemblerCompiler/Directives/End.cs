namespace AssemblerCompiler.Directives
{
    public class End : Directive
    {
        public override int OperandsCount => 0;

        protected override void Perform(Program program)
        {
            program.EndCurrentSegment();
        }

        public End(int lineNumber, string codeLine) : base(lineNumber, codeLine)
        {
        }
    }
}