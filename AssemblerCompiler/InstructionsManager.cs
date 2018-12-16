using System;
using System.Collections.Generic;
using AssemblerCompiler.Commands;
using AssemblerCompiler.Directives;

namespace AssemblerCompiler
{
    public static class InstructionsManager
    {
        private static Dictionary<string, Func<string, Instruction>> registeredInstructions
            = new Dictionary<string, Func<string, Instruction>>
            {
                {"mov", (line) => new Mov(line) },

                {"model", (line) => new Model(line) },
                {".code", (line) => new Code(line) },
                {".data", (line) => new Data(line) },
                {"end", (line) => new End(line) }
            };


        public static Instruction CreateInstruction(string codeLine)
        {
            return registeredInstructions[codeLine](codeLine);
        }
    }
}