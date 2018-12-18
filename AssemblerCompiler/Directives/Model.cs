using System;

namespace AssemblerCompiler.Directives
{
    public class Model : Directive
    {
        public override int OperandsCount => 1;

        protected override void Perform(Program program)
        {
            if (Operands.Length != 1)
                throw new ArgumentException();
            if (Operands[0].Value != "small")
                throw new ArgumentException();
            program.ReferenceSize = 2;
            program.LabelSize = 1;
        }

        public Model(int lineNumber, string codeLine) : base(lineNumber, codeLine)
        {
        }
    }
}