namespace AssemblerCompiler.Commands
{
    public abstract class Command : IInstruction
    {
        private readonly CodeLine codeLine;

        protected Command(CodeLine codeLine)
        {
            this.codeLine = codeLine;
        }

        protected string Name => this.GetType().Name;
        protected string Label => codeLine.Label;
        protected string Operand_1 => codeLine.Operand_1;
        protected string Operand_2 => codeLine.Operand_2;
        public InstructionType Type => InstructionType.Command;
        public bool Done { get; set; }

        protected abstract byte[] Compile();
        public void Execute(Program program)
        {
            Compile(); //todo 
            throw new System.NotImplementedException();
        }
    }
}