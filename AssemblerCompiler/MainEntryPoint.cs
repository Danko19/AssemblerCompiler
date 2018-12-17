using System.Linq;

namespace AssemblerCompiler
{
    public class MainEntryPoint
    {
        static void Main(string[] args)
        {
            var program = new Program(/*args.First()*/"new.asm");
            program.Compile();
        }
    }
}