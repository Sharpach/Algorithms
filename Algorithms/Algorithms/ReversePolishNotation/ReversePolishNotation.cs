using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Algorithms
{
    public class ReversePolishNotation
    {
        public static List<string> Parse(string expression)
        {
            var parsedTokens = new List<string>();
            foreach (var parsedToken in Regex.Split(expression, @"((?<!\d)-?\d+\.?\d*)|([\+\-\*\/\^])|(\()|(\))")
                                             .Where(token => !String.IsNullOrWhiteSpace(token)))
            {
                    parsedTokens.Add(parsedToken);
            }

            var output = new Queue<string>();
            var operators = new Stack<char>();
            foreach (string token in parsedTokens)
            {
                char op = token[0]; //not "operator" because it's already clamed by C# //also token[0] is best way to convert string to char
                if (double.TryParse(token, out double number))
                {
                    output.Enqueue(token);
                    continue;
                }
                if (Regex.IsMatch(token, @"[\+\-\*\/\^]"))
                {
                    while (operators.Count > 0 && operators.Peek() != '(' && (GetPrecedence(operators.Peek()) >= GetPrecedence(op)))
                    {
                        output.Enqueue(operators.Pop().ToString());
                    }
                    operators.Push(op);
                    continue;
                }
                if (op == '(')
                {
                    operators.Push(op);
                    continue;
                }
                if (op == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        if (operators.Count == 0)
                            throw new ArithmeticException("Brackets aren't balanced!");
                        output.Enqueue(operators.Pop().ToString());
                    }
                    operators.Pop();
                    continue;
                }
            }
            while (operators.Count > 0)
            {
                if (operators.Peek() == '(' || operators.Peek() == ')')
                    throw new ArithmeticException("Brackets aren't balanced!");
                output.Enqueue(operators.Pop().ToString());
            }
            return output.ToList();
        }

        public static double Calculate(List<string> expression)
        {
            var expressions = new Stack<double>();
            var switchDict = new Dictionary<string, Action>()
            {
                { "^" , () => {
                        var b = expressions.Pop();
                        expressions.Push(Math.Pow(expressions.Pop(), b));
                    }
                },

                { "*" , () => 
                        expressions.Push(expressions.Pop() * expressions.Pop())
                },

                { "/" , () => {
                        var a = expressions.Pop();
                        expressions.Push(expressions.Pop() / a);
                    }
                },

                { "+" , () => 
                        expressions.Push(expressions.Pop() + expressions.Pop())
                },

                { "-" , () => {
                        var b = expressions.Pop();
                        expressions.Push(expressions.Pop() - b);
                    }
                },
            };

            foreach (string value in expression)
            {
                if (double.TryParse(value, out double result))
                {
                    expressions.Push(result);
                }
                else
                {
                    switchDict[value]();
                }
            }
            return expressions.Pop();
        }

        static int GetPrecedence(char op)
        {
            if (op == '+' || op == '-')
                return 0;
            if (op == '*' || op == '/')
                return 1;
            if (op == '^')
                return 2;
            throw new ArithmeticException($"{op} is not a valid operator!");
        }
    }
}
