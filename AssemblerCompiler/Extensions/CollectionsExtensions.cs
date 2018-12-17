using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace AssemblerCompiler.Extensions
{
    public static class CollectionsExtensions
    {
        public static Operand[] ToOperands(this IEnumerable<string> collection)
        {
            return collection.Where(x => x != string.Empty).Select(x => new Operand(x)).ToArray();
        }

        public static int ToW(this IEnumerable<Operand> operands)
        {
            return operands.Where(x => x.OperandType == OperandType.Register).Max(x => RegistersManager.GetW(x.Value));
        }
    }
}
