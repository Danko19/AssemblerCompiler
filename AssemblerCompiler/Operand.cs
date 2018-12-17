namespace AssemblerCompiler
{
    public class Operand
    {
        public readonly string Value;
        public OperandType OperandType { get; private set; }

        public Operand(string value)
        {
            Value = value;
            Define();
        }

        private void Define()
        {
            if (RegistersManager.IsRegister(Value))
                OperandType = OperandType.Register;
            else if (int.TryParse(Value, out _))
                OperandType = OperandType.Direct;
            else OperandType = OperandType.Memory;
        }


    }
}