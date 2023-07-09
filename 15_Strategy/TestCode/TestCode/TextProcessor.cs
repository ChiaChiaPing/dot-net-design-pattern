using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace TestCode
{
    public enum OutputFormat
    {
        MarkedDown,
        Html
    }

    public interface IListStrategy
    {
        void Start(StringBuilder sb);
        void Add(StringBuilder sb,string item);
        void End(StringBuilder sb);
    }

    public class HtmlStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {
            sb.Append($"<ul>");

        }

        public void End(StringBuilder sb){

            sb.Append($"</ul>");
        }

        public void Add(StringBuilder sb,string item)
        {
            sb.Append($"<li>{item}</li>");
            sb.AppendLine();

        }
    }

    public class MarkerDownStrategy: IListStrategy
    {
        public void Start(StringBuilder sb) { }
        public void End(StringBuilder sb) { }
        public void Add(StringBuilder sb,string item)
        {
            sb.Append($"  * {item} ");
            sb.AppendLine();
        }
    }

    // 外部類別
    public class TextProcessor<LS> where LS: IListStrategy, new()
    {
        private StringBuilder sb = new StringBuilder();

        // 把不同可換的演算法（策略）包裝成一個high level 的類別或是介面
        private IListStrategy strategy = new LS(); 


        public void SetOutputFormat(OutputFormat format)
        {
            switch (format)
            {
                case OutputFormat.Html:
                    this.strategy = new HtmlStrategy();
                    break;
                case OutputFormat.MarkedDown:
                    this.strategy = new MarkerDownStrategy();
                    break;
                default:
                    throw new Exception();
            }

        }

        public void AddItem(IEnumerable<string> items)
        {
            this.strategy.Start(sb);
            foreach (var item in items)
            {
                this.strategy.Add(sb,item);
            }
            this.strategy.End(sb);

        }


        public StringBuilder Clear()
        {
            return sb.Clear();
        }
        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
