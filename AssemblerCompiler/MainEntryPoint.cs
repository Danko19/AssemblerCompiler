namespace AssemblerCompiler
{
    public class MainEntryPoint
    {
        static void Main(string[] args)
        {
            var program = new Program("abc");
            program.Compile();
        }
    }
}