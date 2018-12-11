namespace AssemblerCompiler
{
    public interface IInstruction
    {
        InstructionType Type { get; }
        bool Done { get; set; }
        void Execute(Program program);
    }
}