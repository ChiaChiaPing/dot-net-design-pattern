using System;
using System.Text;
using System.Collections.Generic;

namespace TestCode
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();//階層式elementss
        private const int IndentSize = 2;

        public HtmlElement() { }

        public HtmlElement(string name,string text)
        {
            // null coalescing operator 適合做 Defensive programming
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }


        // recursive 的方式去建立 HTML Element DOM Model: 用樹狀結構的方式去呈現Html element 的關係。
        private string ToStringImp(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', IndentSize * indent);

            sb.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text)) {

                
                sb.Append(new string(' ', IndentSize * (indent + 1)));
                sb.AppendLine(Text);
                
            }

            foreach(var e in Elements) // for sub-elements
            {
                sb.Append(e.ToStringImp(indent + 1));
            }

            sb.AppendLine($"{i}</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImp(0);
        }

    }

    
    public class HtmlBuilder
    {

        private readonly string RootName;
        HtmlElement root = new HtmlElement();
        public HtmlBuilder() { }
        public HtmlBuilder(string name)
        {
            RootName = name;
            root.Name = name;
        }

        public void AddChild(string childName,string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }

        public override string ToString()
        {
            return root.ToString();
        }





    }
    


}
