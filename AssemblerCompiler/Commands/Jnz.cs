using System;
using AssemblerCompiler.Extensions;

namespace AssemblerCompiler.Commands
{
    public class Jnz : Command
    {
        public Jnz(int lineNumber, string codeLine) : base(lineNumber, codeLine)
        {
        }

        public override int OperandsCount => 1;
        protected override int Length => 2;
        protected override void Compile(Program program)
        {
            if (Operands[0].OperandType != OperandType.Memory)
                throw new ArgumentException();
            BinaryCode.AddBytes(0x75);
            BinaryCode.AddBytes((program.Labels[Operands[0].Value] - Address).InReverseByteOrder(program.LabelSize));
        }
    }
}