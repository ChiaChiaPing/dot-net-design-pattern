using System;
using System.Text;
using System.Linq;
using System.Net;


namespace TestCode
{
    public class Exercise
    {
        public Exercise()
        {
        }
    }


    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethod
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Height * rc.Width;
        }




    }


    public class Square
    {
        public int Side;
    }

   

    public class SquareToRectangleAdapter : IRectangle
    {

        public int Width { get; }
        public int Height { get; }


        public SquareToRectangleAdapter(Square square)
        {
            Width = Height = square.Side;
            Console.WriteLine(this.Area());
        }




    }


}
