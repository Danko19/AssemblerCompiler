using System;
using System.Collections.Generic;

namespace AssemblerCompiler
{
    public static class InstructionsManager
    {
        private static Dictionary<string, Func<CodeLine, IInstruction>> registeredInstructions
            = new Dictionary<string, Func<CodeLine, IInstruction>>
            {
                {"mov", (line) => new Mov(line) }

            };


        public static IInstruction CreateInstruction(CodeLine codeLine)
        {
            return registeredInstructions[codeLine.Mnemonik](codeLine);
        }
    }
}