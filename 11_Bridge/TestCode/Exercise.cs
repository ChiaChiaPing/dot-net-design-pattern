using System;

namespace TestCode
{
    public interface IRenderer1
    {
        string WhatToRenderAs { get; set; }

    }

    public class VectorRenderer : IRenderer1
    {
        public string WhatToRenderAs { get; set; }
        public override string ToString() => $"Drawing {this.WhatToRenderAs} as lines";
    }

    public class RasterRenderer : IRenderer1
    {
        public string WhatToRenderAs { get; set; }
        public override string ToString() => $"Drawing {this.WhatToRenderAs} as Pixels";
    }


    public abstract class Shape
    {
 
        public IRenderer1 render;
        protected Shape(IRenderer1 render)
        {
            this.render = render;
        }
        
    }

    public class Triangle : Shape
    {

        public Triangle(IRenderer1 render):base(render)
        {
            render.WhatToRenderAs = "Triangle";

        }
        public override string ToString()
        {
            return render.ToString();
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer1 render) : base(render)
        {
            render.WhatToRenderAs = "Square";

        }
        public override string ToString()
        {
            return render.ToString();
        }
    }

   
}