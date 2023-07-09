using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));
            var tree = new BinaryTree<int>(root);
            var result = tree.InOrder;
            var seq = string.Join(',', result.Select(x => x.Value));
            Console.WriteLine("InOrder Traversing : " +  seq);

           
                
        }
    }

}
