using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    public class SimpleExpression
    {
        private char[] allowedChars = new char[] { ' ', '+', '-', '*', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public readonly string Text;

        public SimpleExpression(string expression)
        {
            // If all characters in the input string match valid mathematical expression characters then all is fine
            if(expression.All(a => allowedChars.Any(b => a == b))) 
            {
                var sb = new StringBuilder();

                foreach (char item in expression)
                {
                    sb.Append(item + " ");
                }

                Text = sb.ToString();
            }
            else
            {
                throw new Exception("Expression string contained illegal characters");
            }
        }

        private int EvaluateTerms(int term, char op, int term2)
        {
            switch (op)
            {
                case '+':
                    return term + term2;
                case '-':
                    return term - term2;
                case '*':
                    return term * term2;
                case '/':
                    return term / term2;
                default:
                    return -1;
            }
        }

        public int Evaluate()
        {
            var numbers = Text.Where(c => char.IsDigit(c))
                              .Select(n => (int)char.GetNumericValue(n));

            char[] operators = Text.Where(
                                    c => c == '+' ||
                                         c == '-' ||
                                         c == '*' ||
                                         c == '/')
                                         .ToArray();
            int i = 0;
            int sum = numbers.Aggregate((a, b) => EvaluateTerms(a, operators[i++], b));

            return sum;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
