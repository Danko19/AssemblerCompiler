using AssemblerCompiler.Commands;

namespace AssemblerCompiler
{
    public class Mov : Command
    {
        public Mov(CodeLine codeLine) : base(codeLine)
        {
        }

        protected override byte[] Compile()
        {
            throw new System.NotImplementedException();
        }
    }
}