using System;
using System.Linq;

namespace AssemblerCompiler
{
    public class CodeLine
    {
        public CodeLine(string codeLine)
        {
            Parse(codeLine);
        }

        public string Label { get; set; }
        public string Mnemonik { get; set; }
        public string Operand_1 { get; set; }
        public string Operand_2 { get; set; }
        
        private void Parse(string line)
        {
            var split = line.Replace("  ", " ").Trim('\t', '\n', '\r').Split(':');
            if (split.Length > 2)
                throw new InvalidOperationException("Invalid syntax");
            if (split.Length == 2)
                Label = split.First();
            split = split.Last().Split(' ');
            Mnemonik = split.First();
        }
    }
}