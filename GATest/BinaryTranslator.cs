using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    static class BinaryTranslator
    {
        private static Dictionary<char, string> translationTable;

        static BinaryTranslator()
        {
            translationTable = new Dictionary<char, string>() 
            { 
                { '0', "0000" },
                { '1', "0001" },
                { '2', "0010" },
                { '3', "0011" },
                { '4', "0100" },
                { '5', "0101" },
                { '6', "0110" },
                { '7', "0111" },
                { '8', "1000" },
                { '9', "1001" },
                { '+', "1010" },
                { '-', "1011" },
                { '*', "1100" },
                { '/', "1101" }
            };
        }

        public static string ToBinaryString(Chromosome chromosome)
        {
            var sb = new StringBuilder();

            foreach (char item in chromosome.Sequence.Text)
            {
                if (translationTable.ContainsKey(item))
                {
                    sb.Append(translationTable[item]);
                }
            }

            return sb.ToString();
        }

        public static Chromosome ToChrosomosome(string binaryStr)
        {
            if (binaryStr.Length % 4 != 0)
            {
                // If input string is not a multiple of 4 then input string is invalid
                throw new ArgumentException("Binary string either too short or too long");
            }

            var sb = new StringBuilder();

            for (int i = 0; i < binaryStr.Length; i += 4)
            {
                string subStr = binaryStr.Substring(i, 4);
                sb.Append(translationTable.FirstOrDefault(entry => entry.Value.Equals(subStr)).Key);
            }

            return new Chromosome(0, sb.ToString());
        }
    }
}
