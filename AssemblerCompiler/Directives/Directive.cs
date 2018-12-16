namespace AssemblerCompiler.Directives
{
    public abstract class Directive : Instruction
    {
        protected Directive(string codeLine) : base(codeLine)
        {
        }

        public override void Execute(Program program)
        {
            Perform(program);
            Done = true;
        }

        protected abstract void Perform(Program program);

        public override InstructionType Type => InstructionType.Directive;
    }
}