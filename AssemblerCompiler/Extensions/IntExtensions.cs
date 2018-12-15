using System.Linq;

namespace AssemblerCompiler.Extensions
{
    public static class IntExtensions
    {
        public static byte[] InReverseByteOrder(this int number, int digits)
        {
            var result = new byte[digits];
            var i = 0;
            while (number > 0)
            {
                result[i++] = (byte)(number % 256);
                number /= 256;
            }

            return result;
        }

        public static byte[] InDirectByteOrder(this int number, int digits)
        {
            return number.InReverseByteOrder(digits).Reverse().ToArray();
        }
    }
}