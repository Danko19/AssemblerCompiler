using System;

namespace AssemblerCompiler.Directives
{
    public class Model : Directive
    {
        public override int OperandsCount => 1;

        public Model(string codeLine) : base(codeLine)
        {
        }

        protected override void Perform(Program program)
        {
            if (Operands.Length != 1)
                throw new ArgumentException();
            if (Operands[0].Value != "small")
                throw new ArgumentException();
            program.ReferenceSize = 2;
            program.LabelSize = 1;
        }
    }
}