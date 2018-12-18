using System;
using AssemblerCompiler.Extensions;

namespace AssemblerCompiler
{
    public abstract class Instruction
    {
        protected readonly int LineNumber;

        protected Instruction(int lineNumber, string codeLine)
        {
            this.LineNumber = lineNumber;
            Parse(codeLine);
        }

        public bool Done { get; set; }
        public string Label { get; private set; }
        public string Mnemonik => GetType().Name;
        public Operand[] Operands { get; private set; }
        public abstract void Execute(Program program);
        public abstract InstructionType Type { get; }
        public abstract int OperandsCount { get; }

        private void Parse(string codeLine)
        {
            try
            {
                var indexOf = codeLine.IndexOf(Mnemonik, StringComparison.OrdinalIgnoreCase);
                Label = codeLine.Substring(0, indexOf).Clean().NullIfEmpty();
                Operands = codeLine.Substring(indexOf + Mnemonik.Length).Clean().Split(',').ToOperands();
                if (Operands.Length != OperandsCount)
                    throw new Exception();
            }
            catch (Exception e)
            {
                throw new Exception($"Line {LineNumber}: Unexpected syntax. { Mnemonik } support only { OperandsCount} operands");
            }
        }
    }
}