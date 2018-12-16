using AssemblerCompiler.Binary;
using FluentAssertions;
using NUnit.Framework;

namespace AssemblerCompilerTests
{
    [TestFixture]
    public class BinaryCodeTests
    {
        [Test]
        public void BinaryCodeFiiling()
        {
            var binaryCode = new BinaryCode();
            binaryCode
                .AddBits(0, 1, 1)
                .AddBytes(15)
                .AddBits(1)
                .AddBytes(23);
            binaryCode.ToBytes().Should().BeEquivalentTo(new byte[] { 96, 15, 128, 23 });
        }

    }
}