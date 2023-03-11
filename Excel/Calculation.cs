using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel
{
    public enum Operator
    {
        Add = '+',
        Subtract = '-',
        Multiply = '*',
        Divide = '/',
        OpenParenthesis = '(',
        CloseParenthesis = ')'
    }

    public enum Priority
    {
        Low,
        High
    }

    public interface IOperator
    {
        Priority priority { get; }
        Func<double, double, double> func { get; }
        char digit { get; }
    }

    public class AddOperator : IOperator
    {
        public Priority priority => Priority.Low;
        public Func<double, double, double> func => (a, b) => a + b;
        public char digit => '+';
    }
    public class SubtractOperator : IOperator
    {
        public Priority priority => Priority.Low;
        public Func<double, double, double> func => (a, b) => a - b;
        public char digit => '-';
    }
    public class MultiplyOperator : IOperator
    {
        public Priority priority => Priority.High;
        public Func<double, double, double> func => (a, b) => a * b;
        public char digit => '*';
    }
    public class DivieOperator : IOperator
    {
        public Priority priority => Priority.High;
        public Func<double, double, double> func => (a, b) =>
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException ex)
            {
                throw new DivideByZeroException(ex.Message);
            }
        };
        public char digit => '/';
    }

    public abstract class Parenthesis
    {
        abstract public void Do(Stack<double> _operands, Stack<Operator> _operators);
    }

    public class OpenParenthesis : Parenthesis
    {
        public override void Do(Stack<double> _operands, Stack<Operator> _operators)
        {
            _operators.Push(Operator.OpenParenthesis);
        }
    }

    public class CloseParenthesis : Parenthesis
    {
        public override void Do(Stack<double> _operands, Stack<Operator> _operators)
        {
            while (_operators.Peek() != Operator.OpenParenthesis)
            {
                Calculation.Calculate(_operands, _operators);
            }
            _operators.Pop();
        }
    }

    public class Calculation
    {
        public List<Parenthesis> paranthesis = new List<Parenthesis>() { new OpenParenthesis(), new CloseParenthesis() };


        public static Dictionary<Operator, IOperator> Operation = new Dictionary<Operator, IOperator>
        {
            { Operator.Add, new AddOperator() },
            { Operator.Subtract, new SubtractOperator() },
            { Operator.Multiply, new MultiplyOperator() },
            { Operator.Divide, new DivieOperator() }
        };

        public static Dictionary<string, int> ParenthesisValue = new Dictionary<string, int>
        {
            { "(", 0 },
            { ")", 1 }
        };

        public Stack<double> _operands = new Stack<double>();
        public Stack<Operator> _operators = new Stack<Operator>();

        public double Evaluate(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("?");
            input = input.Replace(" ", "");

            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    int a = ParenthesisValue[input[i].ToString()];
                    paranthesis[a].Do(_operands, _operators);
                }
                catch (Exception ex)
                {
                    if (!IsOperator(input[i]))
                    {
                        Operator op = GetOperator(input[i]);

                        while (_operators.Count > 0 && _operators.Peek() != Operator.OpenParenthesis && (int)Operation[op].priority <= (int)Operation[_operators.Peek()].priority)
                        {
                            Calculate(_operands, _operators);
                        }

                        _operators.Push(op);
                    }
                    else
                    {
                        string operand = input[i].ToString();

                        for (int j = i + 1; j < input.Length && IsOperator(input[j]); j++)
                        {
                            operand += input[j];
                            i = j;
                        }

                        _operands.Push(double.Parse(operand));
                    }
                }
            }

            while (_operators.Count > 0)
            {
                Calculate(_operands, _operators);
            }

            return _operands.Pop();
        }

        public static void Calculate(Stack<double> _operands, Stack<Operator> _operators)
        {
            double right = _operands.Pop();
            double left = _operands.Pop();
            Operator op = _operators.Pop();

            var result = Operation[op].func(left, right);

            _operands.Push(result);
        }



        private bool IsOperator(char c)
        {
            return Enum.TryParse<Operator>(c.ToString(), out _);
        }

        private Operator GetOperator(char c)
        {
            return Operation.First(x => x.Value.digit == c).Key;
        }
    }
}
