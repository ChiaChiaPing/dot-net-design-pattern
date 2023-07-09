using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;


// this is VectorObject to convert to the RasterObject
namespace TestCode
{
    public class Point
    {
        public int X, Y;
        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }

        protected bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        // 與上方overloading但object class 涵蓋範圍最大 ，所以當帶值時 若有一個物件他是 point object, 都優先呼叫下方方法
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((Point) obj);


        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 396) ^ Y;
            }
           
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point s,Point e)
        {
            Start = s ?? throw new ArgumentException($"{nameof(Start)} can'tt be null");
            End = e ?? throw new ArgumentException($"{nameof(End)} can'tt be null");
        }

        protected bool Equals(Line other)
        {
            return Equals(Start,other.Start) && Equals(End,other.End);
        }

        // 與上方overloading但object class 涵蓋範圍最大 ，所以當帶值時 若有一個物件他是 point object, 都優先呼叫下方方法
        public override bool Equals(object obj)
        {   
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((Line)obj);


        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (Start != null ? Start.GetHashCode():0)*397 ^ (End != null ? End.GetHashCode() : 0) * 397;
            }   

        }   

    }

    public class VectorObject : Collection<Line>
    {
    }

    public class Rectangle : VectorObject // if we create a object from Rectangle, it will be a collecttions which contain Line Object
    {
        public Rectangle(int x,int y,int width,int height)
        {
            this.Add(new Line(new Point(x, y),new Point(x+width,y)));
            this.Add(new Line(new Point(x, y), new Point(x , y+height)));
            this.Add(new Line(new Point(x+width, y), new Point(x + width, y+height)));
            this.Add(new Line(new Point(x, y+height), new Point(x + width, y+height)));
        }
    }



    public class LineToPointAdapter : IEnumerable<Point>
    {
        private static int count;


        // this dicitonary store cache using HashCode which is viewed sa Point
        static Dictionary<int, List<Point>> cache = new Dictionary<int, List<Point>>();



        public LineToPointAdapter(Line line)
        {

            var has = line.GetHashCode();
            if (cache.ContainsKey(has)) return; // 可以運用於建構子的中斷

            // Line Notation Log            
            Console.Write($"{++count} Generating points for line [{line.Start.X},{line.Start.Y}]-[{line.End.X},{line.End.Y}] : ");
            var points = new List<Point>();


            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int top = Math.Min(line.Start.Y, line.End.Y);

            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;


            // Each Line will met one of two situation below, because it is rectangle

            // vertical line
            if (dx == 0)
            {
                for(int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point(top, y));
                }
            }
            // Horizonttal Line
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point(left, x));
                }
            }
            // 會 疊加 所有的線的 points, 代表 store 從第一條線道最後一條線所有產生的 points$
            cache.Add(has, points);




        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return cache.Values.SelectMany(x => x).GetEnumerator();
        }   
    }


    
}
