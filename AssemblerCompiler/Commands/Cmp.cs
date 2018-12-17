using System;
using System.Linq;
using AssemblerCompiler.Extensions;

namespace AssemblerCompiler.Commands
{
    public class Cmp : Command
    {
        public Cmp(string codeLine) : base(codeLine)
        {
        }

        public override int OperandsCount => 2;
        protected override int Length => 3;
        protected override void Compile(Program program)
        {
            if ((Operands[0].Value == "al" || Operands[0].Value == "ax") & Operands[1].OperandType == OperandType.Direct)
            {
                var w = RegistersManager.GetW(Operands[0].Value);
                BinaryCode.AddBits(0, 0, 1, 1, 1, 1, 0, w);
                BinaryCode.AddBytes(int.Parse(Operands[1].Value).InReverseByteOrder(w + 1));
            }
            else if (Operands.All(x => x.OperandType == OperandType.Register))
            {
                var w = Operands.ToW();
                BinaryCode.AddBits(0, 0, 1, 1, 1, 0, 1, w, 1, 1);
                BinaryCode.AddBits(RegistersManager.GetCode(Operands[0].Value));
                BinaryCode.AddBits(RegistersManager.GetCode(Operands[1].Value));
            }
            else throw new NotSupportedException();
        }
    }
}