using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TeseCode
{
    public class Graph
    {
        // create prop and assign
        public virtual string Name { get; set; } = "Name";
        public string Color;

        private Lazy<List<Graph>> children = new Lazy<List<Graph>>();
        public List<Graph> Children => children.Value;

        private void Print(StringBuilder sb,int depth)
        {
            sb.Append(new String('*', depth))
                .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{this.Color}")
                .AppendLine(Name);

            foreach(var child in Children)
            {
                child.Print(sb,depth+1);
            }

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }


    }
    public class Circle : Graph
    {
        public override string Name => "Circle";

    }
    public class Square : Graph
    {
        public override string Name => "Square";
    }
}
