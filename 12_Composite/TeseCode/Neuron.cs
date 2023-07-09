using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using MoreLinq;

namespace TeseCode
{

    public class Neuron : IEnumerable<Neuron>
    {
        public float value;
        public List<Neuron> In, Out;


        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class NeuronLayer : Collection<Neuron>
    {



    }

    public static class ExtenstionMethods
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if (ReferenceEquals(self, other)) return;
            foreach (var from in self)
                foreach (var to in other)
                {
                    from.Out.Add(to);
                    to.In.Add(from);
                }
        }
    }


}
