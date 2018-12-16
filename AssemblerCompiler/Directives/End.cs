namespace AssemblerCompiler.Directives
{
    public class End : Directive
    {
        public End(string codeLine) : base(codeLine)
        {
        }

        protected override void Perform(Program program)
        {
            program.EndCurrentSegment();
        }
    }
}