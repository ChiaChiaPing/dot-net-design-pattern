using System;
using System.Text;
using System.Linq;

namespace TestCode
{
    class SOLID_Principles
    {
        public static void SingleResponsibilityPrinciples()
        {
            // Single Responsibility Principles
            var journal = new Jurnal();
            var p = new Persistence();

            journal.AddEntry("qoo");
            journal.AddEntry("kevin");
            Console.WriteLine(journal);
            const string filePath = "/Users/jiajiaping/Desktop/Software_Engineer_Training/NET Framework Design Pattern/9.15_SOLID_Principles/text.txt";
            p.Save(journal, filePath, overwrite: false);
            //Process.Start(filePath);
        }

        public static void OpenClosePrinciples()
        {
            // Open-Closed Pattern
            Product[] prods = {

                new Product("Apple",Size.Medium,Color.Red),
                new Product("Tree",Size.Large,Color.Green),
                new Product("Grass",Size.Small,Color.Green),
                new Product("Kevin",Size.Large,Color.Blue)

            };

            // traditional-way to do extension
            var return_prods = ProductFilter.FilterColor(prods, Color.Green);
            foreach (var p in return_prods)
            {
                System.Console.WriteLine(p);
            }

            // open-close to do extension
            var spec = new ColorSpecification(Color.Green);
            var bf = new BetterFilter();
            System.Console.WriteLine(new StringBuilder("-", 20));
            var return_prod = bf.Filter(prods, spec);
            foreach (var p in return_prod)
            {
                System.Console.WriteLine(p);
            }

            // open-close to do extension
            System.Console.WriteLine(new StringBuilder("-", 20));
            var prod = bf.Filter(prods, new AndSpecification<Product>(
                new ColorSpecification(Color.Blue),
                new SizeSpecification(Size.Large)
                ));
            foreach (var p in prod)
            {
                System.Console.WriteLine(p);
            }
        }


        public static void LiskovSubsitutionPrincoples()
        {

            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine(rc + $" {nameof(Area)}:{Area(rc)}");

            Rectangle sq = new Square();
            sq.Height = 4;
            Console.WriteLine(sq + $" {nameof(Area)}:{Area(sq)}");
        }

        static int Area(Rectangle r) => r.Height * r.Width;

        public static void DependencyInversion()
        {

            var p1 = new Person() { name = "John" };
            var p2 = new Person() { name = "kevin" };
            var p3 = new Person() { name = "Cat" };
            var relation = new Relationships();
            relation.AddParentAndChild(p1, p2);
            relation.AddParentAndChild(p1, p3);
            foreach (var person in relation.FindChildFromName("John"))
            {
                Console.WriteLine($"{person.name} has parent John");
            }
        }



    }




}
