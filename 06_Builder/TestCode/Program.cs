using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "Hello");
            builder.AddChild("li", "World");
            Console.WriteLine(builder.ToString());

            // fluent inherited builder
            var a = Person.New;
            a.Called("Kevin").WorkAs("Engineer");
            Console.WriteLine(a.Build);

            // Faceted Builder，由小 Builder 攜手完成大 Builder;
            MemberBuilder mb = new MemberBuilder();
            mb.Works.At("Micron")
                    .AsA("Engineer");

            mb.Info.Call("Kevin")
                    .In("Taichung")
                    .Live("South District");

            Member m1 = mb;
            Console.WriteLine(m1+"\n");


            // Exercise
            var cb = new CodeBuilder("Person").AddFields("Name", "string").AddFields("Age", "int");
            Console.WriteLine(cb);


        }
    }

    public class CodeBuilder
    {
        StringBuilder sb = new StringBuilder();


        public CodeBuilder() { }
        public CodeBuilder(string className)
        {
            sb.AppendLine(string.Format("public class {0}",className));
            sb.AppendLine("{");

        }

        public CodeBuilder AddFields(string filedName,string fieldType)
        {

            this.sb.AppendLine(string.Format("  public {0} {1}", fieldType, filedName));
            return this;
        }

        public override string ToString()
        {
            sb.AppendLine("}");
            return this.sb.ToString();
        }



    }
}
