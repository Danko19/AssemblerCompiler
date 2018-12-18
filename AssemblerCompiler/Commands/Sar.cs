using System;
using AssemblerCompiler.Extensions;

namespace AssemblerCompiler.Commands
{
    public class Sar : Command
    {
        public Sar(int lineNumber, string codeLine) : base(lineNumber, codeLine)
        {
        }

        public override int OperandsCount => 2;
        protected override int Length => 3;
        protected override void Compile(Program program)
        {
            if (Operands[0].OperandType != OperandType.Register)
                throw new NotSupportedException();
            var w = RegistersManager.GetW(Operands[0].Value);
            var regCode = RegistersManager.GetCode(Operands[0].Value);
            BinaryCode.AddBits(1, 1, 0);
            if (Operands[1].OperandType == OperandType.Direct)
            {
                var dir = int.Parse(Operands[1].Value);
                if (dir == 1)
                {
                    BinaryCode.AddBits(1, 0, 0, 0, w, 1, 1, 1, 1, 1);
                    BinaryCode.AddBits(regCode);
                }
                else
                {
                    BinaryCode.AddBits(0, 0, 0, 0, w, 1, 1, 1, 1, 1);
                    BinaryCode.AddBits(regCode);
                    BinaryCode.AddBytes(dir.InReverseByteOrder(1));
                }
            }
            else if (Operands[1].Value == "cl")
            {
                BinaryCode.AddBits(1, 0, 0, 1, w, 1, 1, 1, 1, 1);
                BinaryCode.AddBits(regCode);
            }
            else throw new NotSupportedException();
        }
    }
}