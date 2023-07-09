using System;
using System.Text;
using System.Linq;
using System.Net;
using Autofac;

namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IRenderer vr = new VectorRender();
            var circle = new Circle(vr, 2);
            circle.Draw();



            var cb = new ContainerBuilder();
            cb.RegisterType<VectorRender>().As<IRenderer>().SingleInstance();
            cb.Register((c, p) => new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0)));
            using (var c = cb.Build())
            {
                var cir = c.Resolve<Circle>(new PositionalParameter(0, 5.0f));
                cir.Draw();
                cir.Resize(3);
                cir.Draw();
            }


            // Exerccise
            Console.WriteLine(new Square(new RasterRenderer()).ToString());
            Console.WriteLine(new Square(new VectorRenderer()).ToString());
            Console.WriteLine(new Triangle(new RasterRenderer()).ToString());
            Console.WriteLine(new Triangle(new VectorRenderer()).ToString());

        }       
    }
}
