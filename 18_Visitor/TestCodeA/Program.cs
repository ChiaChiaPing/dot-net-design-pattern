using System;
using System.Text;

namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //Classic Visitor Design Pattern(Double Dispatch)
            var e = new AdditionExpression(
                new DoubleExpression(2),
                new AdditionExpression(
                    new DoubleExpression(2),
                    new DoubleExpression(3)
                )
            );
            var ep = new ExpressionPrinter();
            ep.Visit(e);
            Console.WriteLine(ep);
        }
    }
}
