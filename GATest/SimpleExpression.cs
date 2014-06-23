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
                Text = GenerateValidExpression(expression);
            }
            else
            {
                throw new Exception("Expression string contained illegal characters");
            }
        }

        private string GenerateValidExpression(string rawExpr)
        {
            char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] operators = new char[] { '+', '-', '*', '/' };

            var sb = new StringBuilder();
            char prev = '\0';

            foreach (char current in rawExpr)
            {
                if (numbers.Any(num => num != prev))
                {
                    sb.Append(current + " ");
                }
                else if(operators.Any(op => op == current))
                {
                    sb.Append(current + " ");
                }

                prev = current;
            }

            return sb.ToString();
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

        public override bool Equals(object obj)
        {
            return Text.Equals(((SimpleExpression)obj).Text);
        }
    }
}
