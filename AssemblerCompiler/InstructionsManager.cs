using System;
using System.Collections.Generic;
using System.Linq;
using AssemblerCompiler.Commands;
using AssemblerCompiler.Directives;

namespace AssemblerCompiler
{
    public static class InstructionsManager
    {
        private static Dictionary<string, Func<int, string, Instruction>> registeredInstructions
            = new Dictionary<string, Func<int, string, Instruction>>
            {
                {"add", (lineNumber, line) => new Add(lineNumber, line) },
                {"cmp", (lineNumber, line) => new Cmp(lineNumber, line) },
                {"jmp", (lineNumber, line) => new Jmp(lineNumber, line) },
                {"jnz", (lineNumber, line) => new Jnz(lineNumber, line) },
                {"mov", (lineNumber, line) => new Mov(lineNumber, line) },
                {"pop", (lineNumber, line) => new Pop(lineNumber, line) },
                {"push", (lineNumber, line) => new Push(lineNumber, line) },
                {"sar", (lineNumber, line) => new Sar(lineNumber, line) },
                {"std", (lineNumber, line) => new Std(lineNumber, line) },

                {"model", (lineNumber, line) => new Model(lineNumber, line) },
                {".code", (lineNumber, line) => new Code(lineNumber, line) },
                {".data", (lineNumber, line) => new Data(lineNumber, line) },
                {"end", (lineNumber, line) => new End(lineNumber, line) },
                {"dw", (lineNumber, line) => new Dw(lineNumber, line) }
            };
        
        public static Instruction CreateInstruction(int number, string codeLine)
        {
            var instruction = codeLine.ToLower().Split(' ').First(x => registeredInstructions.ContainsKey(x));
            return registeredInstructions[instruction](number, codeLine);
        }
    }
}