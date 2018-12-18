using System;
using System.Linq;
using AssemblerCompiler.Binary;
using AssemblerCompiler.Extensions;

namespace AssemblerCompiler.Commands
{
    public class Mov : Command
    {
        public override int OperandsCount => 2;
        protected override int Length => 3;

        public Mov(int lineNumber, string codeLine) 
            : base(lineNumber, codeLine)
        {
        }
        
        protected override void Compile(Program program)
        {
            if (Operands[0].OperandType == OperandType.Direct)
                throw new ArgumentException();

            var w = Operands.ToW();

            if (Operands.Count(x => x.Value == "al" || x.Value == "ax") == 1)
            {
                var d = Operands[0].OperandType == OperandType.Memory ? 1 : 0;
                BinaryCode.AddBits(1, 0, 1, 0, 0, 0, d, w);
                var inMemoryOperand = Operands.First(x => x.OperandType == OperandType.Memory);
                var reference = program.Labels[inMemoryOperand.Value];
                BinaryCode.AddBytes(reference.InReverseByteOrder(program.ReferenceSize));
                program.ObjectFile.SegmentsBlock.CodeSegment.AddReference(
                    new BinaryCode(0xC4)
                        .AddBytes((Address - program.DataSize + 1 - reference).InReverseByteOrder(1))
                        .AddBytes(0x14, 0x01, 0x02));
            }
            else if (Operands[0].OperandType == OperandType.Register)
            {
                if (Operands[1].OperandType == OperandType.Direct)
                {
                    BinaryCode.AddBits(1, 0, 1, 1, w);
                    BinaryCode.AddBits(RegistersManager.GetCode(Operands[0].Value));
                    BinaryCode.AddBytes(int.Parse(Operands[1].Value).InReverseByteOrder(w + 1));
                }
                else if (Operands[1].OperandType == OperandType.Register)
                {
                    BinaryCode.AddBits(1, 0, 0, 0, 1, 0, 1, w, 1, 1);
                    BinaryCode.AddBits(RegistersManager.GetCode(Operands[0].Value));
                    BinaryCode.AddBits(RegistersManager.GetCode(Operands[1].Value));

                }
            }
            else throw new NotSupportedException();
        }
    }
}