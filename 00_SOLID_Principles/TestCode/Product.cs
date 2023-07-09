using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TestCode
{

    public enum Size
    {
        Large, Medium, Small
    }
    public enum Color
    {
        Red, Blue, Green
    }
    public class Product
    {
        public string Name;
        public Size Size;
        public Color Color;

        public Product(string name, Size s, Color c)
        {
            this.Name = name;
            this.Size = s;
            this.Color = c;
        }
        public override string ToString()
        {
            return $"{this.Name}-{this.Color} and {this.Size}";
        }
    }


    public class ProductFilter
    {

        // 但是這就不符合open-close principles，因為每當我要建立新的方法時，我就必須要去修改原本class 裡面的內容（新建一個function）
        // Open-Close 應該是要能夠像 extension-method 去擴充功能，只會針對當前的class 做擴充且不動到原先class 裡面的內容
            // 那這樣就可以透過繼承關係實作介面來達到 open-close principles
        public static IEnumerable<Product> FilterColor(Product[] prodcuts,Color c)
        {
            foreach(var p in prodcuts)  
            {
                if (p.Color == c)
                    yield return p;
            }
        }
        public static IEnumerable<Product> FilterSize(Product[] prodcuts, Size s)
        {
            foreach (var p in prodcuts)
            {
                if (p.Size == s)
                    yield return p;
            }
        }
        public static IEnumerable<Product> FilterColorAndSize(Product[] prodcuts, Color c, Size s)
        {
            foreach (var p in prodcuts)
            {
                if (p.Size == s && p.Color == c)
                    yield return p;
            }
        }
    }

    //--------------以下是比較好的寫法------------------------

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
    public interface IFilter<T> 
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    // better寫法
    public class ColorSpecification : ISpecification<Product>
    {

        private Color color;

        public ColorSpecification(Color c)
        {
            this.color = c;
        }

        public bool IsSatisfied(Product p)
        {
            return p.Color == color;
        }
    }
    public class SizeSpecification : ISpecification<Product>
    {

        private Size Size;

        public SizeSpecification(Size s)
        {
            this.Size = s;
        }

        public bool IsSatisfied(Product p)
        {
            return p.Size == Size;
        }
    }
    // 可以實作介面自己同時也加入泛型。
    public class AndSpecification<T> : ISpecification<T>
    {

        private ISpecification<T> first, Second;

        public AndSpecification(ISpecification<T> color ,ISpecification<T> size)
        {
            first = color;
            Second = size;
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && Second.IsSatisfied(t);
        }
    }

    // you can filter by any condition
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> prods,ISpecification<Product> spec)
        {
            foreach(var p in prods)
            {
                if (spec.IsSatisfied(p))
                {
                    yield return p;
                }
            }

        }
    }







}
