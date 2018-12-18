namespace AssemblerCompiler.Commands
{
    public class Std : Command
    {
        protected override int Length => 1;

        public Std(int lineNumber, string codeLine) : base(lineNumber, codeLine)
        {
        }

        public override int OperandsCount => 0;
        protected override void Compile(Program program)
        {
            BinaryCode.AddBytes(0xFD);
        }
    }
}