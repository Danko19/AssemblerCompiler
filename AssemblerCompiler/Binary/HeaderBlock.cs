namespace AssemblerCompiler.Binary
{
    public class HeaderBlock : Block
    {
        public void Fill(string fileName)
        {
            records.Add(new Record(0x80).AddBinaryCode(new BinaryCode().AddString(fileName)));
            records.Add(new Record(0x88).AddBinaryCode(new BinaryCode(0, 0).AddString(Constants.CompilerName)));
            records.Add(new Record(0x88).AddBinaryCode(new BinaryCode(0x40, 0xE9, 0x96, 0x7E, 0x5E, 0x4D).AddString(fileName)));
            records.Add(new Record(0x88).AddBinaryCode(new BinaryCode(0x40, 0xE9)));
            records.Add(new Record(0x96).AddBinaryCode(new BinaryCode(0)));
            records.Add(new Record(0x88).AddBinaryCode(new BinaryCode(0x40, 0xA1)));
        }
    }
}