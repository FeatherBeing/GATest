using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GATest
{
    public class StringExpression
    {
        private static char[] allowedNums = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private static char[] allowedOps = new char[] { '+', '-', '*', '/' };
        private static Dictionary<char, Func<double, double, double>> mathOperations;
        public readonly string Text;

        static StringExpression()
        {
            mathOperations = new Dictionary<char,Func<double,double,double>>();
            mathOperations.Add('+', new Func<double, double, double>((a, b) => a + b));
            mathOperations.Add('-', new Func<double, double, double>((a, b) => a - b));
            mathOperations.Add('*', new Func<double, double, double>((a, b) => a * b));
            mathOperations.Add('/', new Func<double, double, double>((a, b) => (a != 0 || b != 0) ? a / b : 0));
        }

        public StringExpression(string expression)
        {
            // If all characters in the input string match valid mathematical expression characters then all is fine 
            if(expression.All(a => allowedNums.Concat(allowedOps).Any(b => a == b)))
            {
                Text = GenerateValidExpression(expression);
            }
            else
            {
                // HACK; Generate empty expression
                Text = "0 + 0";
                //throw new Exception(
                //    string.Format("Expression string contained illegal characters: {0}", 
                //        string.Join(", ",
                //            expression.Where(a => !char.IsDigit(a) && !IsOperator(a)
                //            ))));
            }
        }

        private string GenerateValidExpression(string rawExpr)
        {
            var sb = new StringBuilder();
            char prev = '\0';

            foreach (char current in rawExpr)
            {
                if (char.IsDigit(prev))
                {
                    if (allowedOps.Any(op => op == current))
                    {
                        sb.Append(current);
                        prev = current;
                    }
                }
                else if(char.IsDigit(current))
                {
                    sb.Append(current);
                    prev = current;
                }
            }

            return sb.ToString();
        }

        private bool IsOperator(char chr)
        {
            return allowedOps.Any(op => op == chr);
        }

        public double Evaluate()
        {
            var numbers = Text.Where(c => char.IsDigit(c))
                              .Select(n => char.GetNumericValue(n));

            char[] operators = Text.Where(c => IsOperator(c)).ToArray();
            
            int i = 0;
            double sum = numbers.Aggregate((a, b) => mathOperations[operators[i++]](a, b));
            return sum;
        }

        public static StringExpression Random(int exprLength, Random seed)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < exprLength; i++)
            {
                if (i % 2 == 0)
                {
                    // Append Number
                    sb.Append(allowedNums[seed.Next(allowedNums.Length)]);
                }
                else
                {
                    // Append operator
                    sb.Append(allowedOps[seed.Next(allowedOps.Length)]);
                }
            }

            return new StringExpression(sb.ToString());
        }

        public override string ToString()
        {
            return Text.Aggregate(new StringBuilder(), (a, b) => a.Append(b + " ")).ToString();
        }
        public override bool Equals(object obj)
        {
            return Text.Equals(((StringExpression)obj).Text);
        }
    }
}
