namespace AssemblerCompiler.Commands
{
    public abstract class Command : Instruction
    {
        public override InstructionType Type => InstructionType.Command;
        protected byte[] CodeBytes;
        protected Command(string codeLine) 
            : base(codeLine)
        {
        }

        public override void Execute(Program program)
        {
            Compile();
        }

        protected abstract void Compile();
    }
}