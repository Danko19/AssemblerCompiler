using System;
using System.Collections.Generic;
using AssemblerCompiler.Commands;

namespace AssemblerCompiler
{
    public static class InstructionsManager
    {
        private static Dictionary<string, Func<string, Instruction>> registeredInstructions
            = new Dictionary<string, Func<string, Instruction>>
            {
                {"mov", (line) => new Mov(line) }
            };


        public static Instruction CreateInstruction(string codeLine)
        {
            return registeredInstructions[codeLine](codeLine);
        }
    }
}