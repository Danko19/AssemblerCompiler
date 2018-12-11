using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AssemblerCompiler
{
    public class Program
    {
        private readonly List<IInstruction> instructions = new List<IInstruction>();
        private readonly string fileName;

        public Program(string fileName)
        {
            this.fileName = fileName;
        }

        public void Compile()
        {
            InitInstructions();
            while (!Run()) {}
        }

        private IEnumerable<CodeLine> ParseLines()
        {
            return File.ReadLines(fileName).Select(codeLine => new CodeLine(codeLine));
        }

        private void InitInstructions()
        {
            foreach (var codeLine in ParseLines())
                instructions.Add(InstructionsManager.CreateInstruction(codeLine));
        }

        private bool Run()
        {
            var compiled = true;
            foreach (var instruction in instructions)
            {
                instruction.Execute(this);
                if (!instruction.Done)
                    compiled = false;
            }

            return compiled;
        }
    }
}
