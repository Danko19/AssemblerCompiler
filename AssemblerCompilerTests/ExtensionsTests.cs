using System.Collections.Generic;
using AssemblerCompiler.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace AssemblerCompilerTests
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void IntToBytesInReverseOrder(int number, int digits, byte[] result)
        {
            number.InReverseByteOrder(digits).Should().BeEquivalentTo(result);
        }

        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(57, 3, new byte[] { 57, 0, 0 });
            yield return new TestCaseData(57, 2, new byte[] { 57, 0 });
            yield return new TestCaseData(1317, 2, new byte[] { 37, 5 });
        }
    }
}