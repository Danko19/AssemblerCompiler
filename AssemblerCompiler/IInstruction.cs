using System;
using AssemblerCompiler.Extensions;

namespace AssemblerCompiler
{
    public abstract class Instruction
    {
        public Instruction(string codeLine)
        {
            Parse(codeLine);
        }

        public bool Done { get; private set; }
        public string Label { get; private set; }
        public string Mnemonik => GetType().Name;
        public string[] Operands { get; private set; }
        public abstract void Execute(Program program);
        public abstract InstructionType Type { get; }

        protected void Parse(string codeLine)
        {
            var indexOf = codeLine.IndexOf(Mnemonik, StringComparison.OrdinalIgnoreCase);
            Label = codeLine.Substring(0, indexOf).Clean().NullIfEmpty();
            Operands = codeLine.Substring(indexOf + Mnemonik.Length).Clean().Split(',');
        }
    }
}