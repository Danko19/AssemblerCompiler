using System.Collections.Generic;
using System.IO;

namespace AssemblerCompiler
{
    public class Program
    {
        private readonly List<Instruction> instructions = new List<Instruction>();
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

        private void InitInstructions()
        {
            foreach (var codeLine in File.ReadLines(fileName))
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
