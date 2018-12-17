using System.Text;

namespace AssemblerCompiler.Extensions
{
    public static class StringExtensions
    {
        public static string Clean(this string lexemm)
        {

            return lexemm
                ?.Replace(" ", "")
                .Replace("\t", "")
                .Replace(":", "");
        }

        public static string NullIfEmpty(this string str)
        {
            return str == string.Empty ? null : str;
        }

        public static byte[] ToBytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}