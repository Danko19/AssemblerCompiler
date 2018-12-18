using System;

namespace AssemblerCompiler.Commands
{
    public class Push : Command
    {
        public Push(int lineNumber, string codeLine) : base(lineNumber, codeLine)
        {
        }

        public override int OperandsCount => 1;
        protected override int Length => 1;
        protected override void Compile(Program program)
        {
            if (Operands[0].OperandType != OperandType.Register)
                throw new NotSupportedException();
            BinaryCode.AddBits(0, 1, 0, 1, 0);
            BinaryCode.AddBits(RegistersManager.GetCode(Operands[0].Value));
        }
    }
}