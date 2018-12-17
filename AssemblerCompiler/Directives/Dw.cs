using AssemblerCompiler.Binary;
using AssemblerCompiler.Extensions;

namespace AssemblerCompiler.Directives
{
    public class Dw : Directive
    {
        public override int OperandsCount => 1;

        public Dw(string codeLine) : base(codeLine)
        {
        }

        protected override void Perform(Program program)
        {
            program.Labels[Label] = program.Address;
            program.ObjectFile.SegmentsBlock.DataSegment.AddDefinition(new BinaryCode(int.Parse(Operands[0].Value).InReverseByteOrder(program.ReferenceSize)));
            program.AddDataLength(2);
        }
    }
}