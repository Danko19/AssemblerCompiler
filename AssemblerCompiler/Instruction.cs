using System;
using AssemblerCompiler.Extensions;

namespace AssemblerCompiler
{
    public abstract class Instruction
    {
        protected Instruction(string codeLine)
        {
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
            var indexOf = codeLine.IndexOf(Mnemonik, StringComparison.OrdinalIgnoreCase);
            Label = codeLine.Substring(0, indexOf).Clean().NullIfEmpty();
            Operands = codeLine.Substring(indexOf + Mnemonik.Length).Clean().Split(',').ToOperands();
            if (Operands.Length != OperandsCount)
                throw new ArgumentException($"{Mnemonik} support only {OperandsCount} operands");
        }
    }
}