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
            List<string> parsed = new List<string>();
            foreach (var a in Regex.Split(expression, @"((?<!\d)-?\d+\.?\d*)|([\+\-\*\/\^])|(\()|(\))"))
            {
                if (!String.IsNullOrWhiteSpace(a))
                    parsed.Add(a);
            }

            Queue<string> output = new Queue<string>();
            Stack<char> operators = new Stack<char>();
            foreach (string token in parsed)
            {
                char ctoken = token[0];
                if (double.TryParse(token, out double number))
                {
                    output.Enqueue(token);
                    continue;
                }
                if (Regex.IsMatch(token, @"[\+\-\*\/\^]"))
                {
                    ctoken = token[0];
                    while (operators.Count > 0 && operators.Peek() != '(' && (GetPrecedence(operators.Peek()) >= GetPrecedence(ctoken)))
                    {
                        output.Enqueue(operators.Pop().ToString());
                    }
                    operators.Push(ctoken);
                    continue;
                }
                if (ctoken == '(')
                {
                    operators.Push(ctoken);
                    continue;
                }
                if (ctoken == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        if (operators.Count == 0)
                            throw new ArithmeticException("Brackets isn't balanced!");
                        output.Enqueue(operators.Pop().ToString());
                    }
                    operators.Pop();
                    continue;
                }
            }
            while (operators.Count > 0)
            {
                if (operators.Peek() == '(' || operators.Peek() == ')')
                    throw new ArithmeticException("Brackets isn't balanced!");
                output.Enqueue(operators.Pop().ToString());
            }
            return output.ToList();
        }

        public static double Calculate(List<string> expression)
        {
            Stack<double> expressions = new Stack<double>();
            var switchDict = new Dictionary<string, Action>()
            {
                { "^" , () => { var b = expressions.Pop();
                                expressions.Push(Math.Pow(expressions.Pop(), b));} },
                { "*" , () => expressions.Push(expressions.Pop() * expressions.Pop())},
                { "/" , () => { var a = expressions.Pop();
                                expressions.Push(expressions.Pop() / a); } },
                { "+" , () => expressions.Push(expressions.Pop() + expressions.Pop())},
                { "-" , () => { var b = expressions.Pop();
                                expressions.Push(expressions.Pop() - b);} },
            };

            for (int i = 0; i < expression.Count; i++)
            {
                if (double.TryParse(expression[i], out double result))
                {
                    expressions.Push(result);
                }
                else
                {
                    switchDict[expression[i]]();
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
