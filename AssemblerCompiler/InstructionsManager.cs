using System;
using System.Collections.Generic;
using System.Linq;
using AssemblerCompiler.Commands;
using AssemblerCompiler.Directives;

namespace AssemblerCompiler
{
    public static class InstructionsManager
    {
        private static Dictionary<string, Func<string, Instruction>> registeredInstructions
            = new Dictionary<string, Func<string, Instruction>>
            {
                {"add", (line) => new Add(line) },
                {"cmp", (line) => new Cmp(line) },
                {"jmp", (line) => new Jmp(line) },
                {"jnz", (line) => new Jnz(line) },
                {"mov", (line) => new Mov(line) },
                {"pop", (line) => new Pop(line) },
                {"push", (line) => new Push(line) },
                {"sar", (line) => new Sar(line) },
                {"std", (line) => new Std(line) },

                {"model", (line) => new Model(line) },
                {".code", (line) => new Code(line) },
                {".data", (line) => new Data(line) },
                {"end", (line) => new End(line) },
                {"dw", (line) => new Dw(line) }
            };
        
        public static Instruction CreateInstruction(string codeLine)
        {
            var instruction = codeLine.ToLower().Split(' ').First(x => registeredInstructions.ContainsKey(x));
            return registeredInstructions[instruction](codeLine);
        }
    }
}