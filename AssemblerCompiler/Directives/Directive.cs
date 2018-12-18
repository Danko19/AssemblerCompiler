using System;

namespace AssemblerCompiler.Directives
{
    public abstract class Directive : Instruction
    {
        protected Directive(int lineNumber, string codeLine) : base(lineNumber, codeLine)
        {
        }

        public override void Execute(Program program)
        {
            try
            {
                if (Label != null)
                    program.Labels[Label] = program.Address;
                Perform(program);
                Done = true;
            }
            catch (Exception e)
            {
                throw new Exception($"Line {LineNumber}: Unsupported using of derective {Mnemonik}");
            }
        }

        protected abstract void Perform(Program program);

        public override InstructionType Type => InstructionType.Directive;
    }
}