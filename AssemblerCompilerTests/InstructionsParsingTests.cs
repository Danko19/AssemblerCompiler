using AssemblerCompiler.Commands;
using FluentAssertions;
using NUnit.Framework;

namespace AssemblerCompilerTests
{
    [TestFixture]
    public class InstructionsParsingTests
    {
        [Test]
        public void MovParse()
        {
            var mov = new Mov("mov ax, 19");

            mov.Label.Should().Be(null);
            mov.Operands.Length.Should().Be(2);
            mov.Operands[0].Should().Be("ax");
            mov.Operands[1].Should().Be("19");
        }
    }
}
