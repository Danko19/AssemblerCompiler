using System;
using System.Collections.Generic;

namespace AssemblerCompiler
{
    public static class RegistersManager
    {
        public static bool IsRegister(string regName)
        {
            return regCodes.ContainsKey(regName);
        }

        public static int[] GetCode(string regName)
        {
            var result = new int[3];
            GetRegCodeValue(regName).Code.CopyTo(result, 0);
            return result;
        }

        public static int GetW(string regName)
        {
            return GetRegCodeValue(regName).W;
        }

        private static RegCodeValue GetRegCodeValue(string regName)
        {
            if (!IsRegister(regName))
                throw new ArgumentException();
            return regCodes[regName];
        }

        private static int[][] codes = new[]
        {
            new[] {0, 0, 0},
            new[] {0, 0, 1},
            new[] {0, 1, 0},
            new[] {0, 1, 1},
            new[] {1, 0, 0},
            new[] {1, 0, 1},
            new[] {1, 1, 0},
            new[] {1, 1, 1},
        };

        private static Dictionary<string, RegCodeValue> regCodes = new Dictionary<string, RegCodeValue>
        {
            {"ax", new RegCodeValue(codes[0], 1)},
            {"al", new RegCodeValue(codes[0], 0)},
            {"cx", new RegCodeValue(codes[1], 1)},
            {"cl", new RegCodeValue(codes[1], 0)},
            {"dx", new RegCodeValue(codes[2], 1)},
            {"dl", new RegCodeValue(codes[2], 0)},
            {"bx", new RegCodeValue(codes[3], 1)},
            {"bl", new RegCodeValue(codes[3], 0)},
            {"sp", new RegCodeValue(codes[4], 1)},
            {"ah", new RegCodeValue(codes[4], 0)},
            {"bp", new RegCodeValue(codes[5], 1)},
            {"ch", new RegCodeValue(codes[5], 0)},
            {"si", new RegCodeValue(codes[6], 1)},
            {"dh", new RegCodeValue(codes[6], 0)},
            {"di", new RegCodeValue(codes[7], 1)},
            {"bh", new RegCodeValue(codes[7], 0)},
        };

        private class RegCodeValue
        {
            public RegCodeValue(int[] code, int w)
            {
                Code = code;
                W = w;
            }

            public int[] Code;
            public int W;
        }
    }

}