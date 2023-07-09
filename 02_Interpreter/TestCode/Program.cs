using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;


namespace TestCode
{
    class Program
    {
        // Lex is to split the inputstring and view each element as token
        static List<Token> Lex(string input)
        {
            var result = new List<Token>();
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '(':
                        result.Add(new Token(Token.Type.Lparen, input[i].ToString()));
                        break;
                    case ')':
                        result.Add(new Token(Token.Type.Rparen, input[i].ToString()));
                        break;
                    case '+':
                        result.Add(new Token(Token.Type.Plus, input[i].ToString()));
                        break;
                    case '-':
                        result.Add(new Token(Token.Type.Minus, input[i].ToString()));
                        break;
                    default:
                        // append numeric string when there is a number whose digit number > 2
                        var sb = new StringBuilder().Append(input[i]);
                        for (int j = i + 1; j < input.Length; j++)
                        {
                            if (char.IsDigit(input[j]))
                            {
                                // if still point to number, append this numeric value
                                sb.Append(input[j]);
                                i++;
                            }
                            else
                            {
                                result.Add(new Token(Token.Type.Integer, sb.ToString()));
                                break;
                            }
                        }
                        break;
                }
            }

            return result;
        }

        //Parsing
        static IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();
            bool haveLHS = false;
            for(int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                switch (token.type)
                {

                    case Token.Type.Integer:
                        var integer = new Integer(int.Parse(token.Input));
                        if (!haveLHS)
                        {
                            result.Left = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = integer;
                        }
                        break;
                    case Token.Type.Minus:
                        result.type = BinaryOperation.Type.Substraction;
                        break;
                    case Token.Type.Plus:
                        result.type = BinaryOperation.Type.Addition;
                        break;
                    case Token.Type.Lparen:
                        int j = i;
                        for (; j < tokens.Count; ++j)
                        {   
                            if (tokens[j].type == Token.Type.Rparen)
                                break;
                        }
                        var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                        var element = Parse(subexpression);
                        if (!haveLHS)
                        {
                            result.Left = element;
                            haveLHS = true;

                        }
                        else
                        {
                            result.Right = element;
                        }
                        i = j;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
       
            }
            return result;
        }


        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var exp = "(13+4)-(12+1)";
            var tokenList = Lex(exp);
            Console.WriteLine(string.Join(" ",tokenList));

            // use recursive method to calculate whole big expression
            // actually this big expression 's left and right are alo expression, but just subexpression.
            Console.WriteLine(Parse(tokenList).Value);

            var obj = new Exercise();
            Console.WriteLine(obj.Calculate("1+2+3"));
            //Console.WriteLine(obj.Calculate("1+2+xy"));

        }
    }
}
