using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCode
{

    public interface IElement
    {
        int Value { get; }
    }

    public class Integer : IElement
    {

        public int Value { get; }

        public Integer(int value)
        {
            this.Value = value;
        }
    }

    public class BinaryOperation : IElement
    {
        public enum Type
        {
            Addition,Substraction
        }

        public Type type;
        public IElement Left, Right;

        public int Value
        {
            get
            {
                switch (type)
                {
                    case Type.Addition:
                        return Left.Value + Right.Value;
                    case Type.Substraction:
                        return Left.Value - Right.Value;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }



    }


	public class Token
	{

		public enum Type
		{
			Integer, Plus, Minus, Rparen, Lparen
		}

		public Type type;
		public string Input;

        public Token(Type type, string input)
		{
			this.type = type;
			this.Input = input ?? throw new ArgumentNullException(nameof(input));
		}

        public override string ToString()
		{
			return $"{Input}";

		}
	}

    public class Exercise
    {

        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            int sum = 0;
            for(int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i]))
                {
                    sum += int.Parse(expression[i].ToString());

                    int j = i + 1;
                    if (char.IsDigit(expression[j]))
                        return 0;

                }
                if (expression[i]=='+')
                {
                    sum += int.Parse(expression[i + 1].ToString());
                    i++;
                    
                }else if (expression[i] == '-')
                {
                    sum -= int.Parse(expression[i + 1].ToString());
                    i++;

                }

            }

            return sum;
        }



    }



}

