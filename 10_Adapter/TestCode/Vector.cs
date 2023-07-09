using System;
using System.Linq;
using System.Text;
using System.Net;


namespace TestCode
{


    public interface IInteger
    {
        int Value { get; }
    }


    public static class Dimensions
    {

        public class One : IInteger
        {
            public int Value => 1;
        }   

        public class Two : IInteger
        {
            public int Value => 2;
        }

        public class Three : IInteger
        {
            public int Value { get { return 3; } } // implement method which is contained in IInteger
        }



    }




    public class Vector<TSelf,T, D>
        where D:IInteger,new()

        // Recursive Generic 針對泛型下where限制型別時，若型別跟該泛型的形式一樣 => recursive generic
        where TSelf:Vector<TSelf,T,D>, new()// Where D:---,new () allow create new Object using D class.
    {
        protected T[] Data;

        public Vector()
        {
            Data = new T[new D().Value]; // 一開始就宣告該向量是幾維的。
        }

        public Vector(params T[] Values)
        {
            var requiredSize = new D().Value;
            Data = new T[requiredSize];
            var providedSize = Values.Length;

            // 你Dimension 若下 2 ，但你帶三個值，則會取前面兩值產生二維向量，不會產生三維向量
            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
            {
                Data[i] = Values[i];
            }
        }

        public static TSelf Create(params T[] values)
        {
            var result = new TSelf();
            var requiredSize = new D().Value;
            result.Data = new T[requiredSize];
            var providedSize = values.Length;

            // 你Dimension 若下 2 ，但你帶三個值，則會取前面兩值產生二維向量，不會產生三維向量
            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
            {
                result.Data[i] = values[i];
            }

            return result;

        }

        public T this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }

        public T X
        {
            get { return Data[0]; }
            set { Data[0] = value; }
           
        }  




    }

    // for generic vector
    public class VectorOfInt<D> : Vector<VectorOfInt<D>,int, D> where D:IInteger,new ()
    {
        public VectorOfInt() { }
        public VectorOfInt(params int[] values) : base(values) { }
            
        

        // 這種 operator 只能定義 Static
        public static VectorOfInt<D> operator +
            (VectorOfInt<D> lhs,VectorOfInt<D> rhs) // 就是該物件能夠support + operator ，且該物件已經佔據 兩個物件的其中一個，也就是只剩一個可以加，加完之後依樣回傳 VectorOfInt 類別的物件
        {
            var result = new VectorOfInt<D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i]; // vector plus
            }

            return result;
        }
    }

    // for generic vector
    public class VectorOfFloat<TSelf,D>
        : Vector<TSelf,float, D>
        where D : IInteger, new()
        where TSelf : Vector<TSelf,float,D>,new()
    {
       
    }

    // for 2-dim integer vector
    public class Vector2i : VectorOfInt<Dimensions.Two>
    {

        public Vector2i() { }

        public Vector2i(params int[] values) : base(values)
        {

        }

    }

    // for 3-dim float vector
    public class Vector3f : VectorOfFloat<Vector3f,Dimensions.Three>
    {

        public override string ToString()
        {
            return $"{string.Join(",", Data)}";
        }


    }




  
}
