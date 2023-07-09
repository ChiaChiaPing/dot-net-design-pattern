using System;
using System.Collections.Generic;
using System.Text;

namespace TeseCode
{
    class Program
    {
        public static void Main(string[] args)
        {
            var drawing = new Graph { Name = "My Drawing" };
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new Graph() { Name = "Group"};
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });
            var group1 = new Graph { Name = "Group1" };
            group1.Children.Add(new Circle { Color = "Red" });
            group1.Children.Add(new Square { Color = "Red" });
            group.Children.Add(group1);



            drawing.Children.Add(group);


            Console.WriteLine(drawing);
            Console.WriteLine(group);

            // Neural Network
            /*
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();
            neuron1.ConnectTo(neuron2);

            var Layer1 = new NeuronLayer();
            var Layer2 = new NeuronLayer();

            neuron1.ConnectTo(Layer1);
            neuron2.ConnectTo(Layer2);*/



            // sum-exercise
            var s1 = new SingleValue() { Value=12};
            var m1 = new ManyValues();
            m1.Add(22);
            m1.Add(33);

            var list = new List<IValueContainer>();
            list.Add(s1);
            list.Add(m1);
            Console.WriteLine(list.Sum());




        }
    }

   
}
