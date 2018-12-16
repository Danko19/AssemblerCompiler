using System;

namespace AssemblerCompiler.Directives
{
    public class Model : Directive
    {
        public Model(string codeLine) : base(codeLine)
        {
        }

        protected override void Perform(Program program)
        {
            if (Operands.Length != 1)
                throw new ArgumentException();
            if (Operands[0] != "small")
                throw new ArgumentException();
            program.ReferenceSize = 2;
        }
    }
}