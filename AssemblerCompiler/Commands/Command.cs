using System;
using System.Linq;
using AssemblerCompiler.Binary;

namespace AssemblerCompiler.Commands
{
    public abstract class Command : Instruction
    {
        public override InstructionType Type => InstructionType.Command;
        protected int Address { get; private set; }
        protected abstract int Length { get; }
        protected BinaryCode BinaryCode = new BinaryCode();

        public override void Execute(Program program)
        {
            try
            {
                if (program.RunNumber == 1)
                {
                    Address = program.Address;
                    program.AddCodeLength(Length);
                    if (Label != null)
                        program.Labels[Label] = Address;
                    program.ObjectFile.SegmentsBlock.CodeSegment.AddDefinition(BinaryCode);
                }
                if (!InMemoryOperandsReady(program))
                    return;
                Compile(program);
                FillBinaryCode();
                Done = true;
            }
            catch (Exception e)
            {
                throw new Exception($"Line {LineNumber}: Unsupported call of command {Mnemonik}");
            }
        }

        private bool InMemoryOperandsReady(Program program)
        {
            var operandInMemory = Operands.FirstOrDefault(x => x.OperandType == OperandType.Memory);

            if (operandInMemory != null && !program.Labels.ContainsKey(operandInMemory.Value))
            {
                if (program.RunNumber > 1)
                    throw new ArgumentException();
                return false;
            }

            return true;
        }

        private void FillBinaryCode()
        {
            while (BinaryCode.Length < Length)
                BinaryCode.AddBytes(0x90);
        }

        protected abstract void Compile(Program program);

        protected Command(int lineNumber, string codeLine) : base(lineNumber, codeLine)
        {
        }
    }
}