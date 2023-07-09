using System;  
namespace TestCode
{
    public interface IRenderer
    {
        void RenderCycle(float radius);
    }
    public class VectorRender : IRenderer
    {
        public void RenderCycle(float radius)
        {
            Console.WriteLine($"Drawing a Circle of radius : {radius}");
        }
    }
    public class RasterRender : IRenderer
    {
        public void RenderCycle(float radius)
        {
            Console.WriteLine($"Drawing a Circle with pixels of radius : {radius}");
        }

    }

    // using Abstractions to connect all components
    public abstract class Shape1
    {
        protected IRenderer renderer;
        protected Shape1(IRenderer renderer)
        {
            this.renderer = renderer ?? throw new ArgumentNullException(paramName: nameof(renderer));
        }

        public abstract void Draw();
        public abstract void Resize(float factor);

    }

    public class Circle : Shape1
    {

        private float radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCycle(this.radius);
        }
        public override void Resize(float factor)
        {
            this.radius *= factor;
        }
    }
}
