using System;
using System.Text;
using System.Net;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using MoreLinq;
using System.Collections.Generic;



namespace TestCode
{
    class Program
    {

        private static readonly List<VectorObject> vectorObjects =
           new List<VectorObject>
           {
                new Rectangle(3,3,6,10),
                new Rectangle(1,1,10,10)
           };

        public static void DrawPoint(Point p)
        {
            Console.Write(".");
        }


        private static void Draw()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    // will create new Adapter for each line
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                    Console.WriteLine();

                }
            }
        }



        static void Main(string[] args)
        {
            //Draw();



            // Generic Value Adapter, ：可以去創建int 或是 float 的 n 維度 Vectors
            var v1 = new Vector2i(1,2);
            v1[0] = 0;

            var v2 = new Vector2i(3, 2);
            var result = v1 + v2;

            var u = Vector3f.Create(3.5f, 2.2f, 1);
            Console.WriteLine(result);
            Console.WriteLine(u);

            // Exercise
            var Rectangle = new SquareToRectangleAdapter(new Square() { Side = 6 });


        }
    }
}
