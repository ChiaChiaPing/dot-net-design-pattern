using System;
using System.Collections.Generic;
using System.Collections;


namespace TestCode
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Parent;
        public Node<T> Left, Right;

        public Node(T value)
        {
            Value = value;
        }

        // build up one node which have left node and right node
        public Node(T value, Node<T> left,Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
            left.Parent = right.Parent = this;

        }
    }

    public class BinaryTree<T>
    {
        private readonly Node<T> root;

        public BinaryTree(Node<T> root)
        {
            this.root = root;
        }

        public IEnumerable<Node<T>> InOrder
        {

            get
            {
                // inner method
                IEnumerable<Node<T>> Traverse(Node<T> Current)
                {
                    yield return Current;

                    if (Current.Left != null)
                    {
                        var LeftList = Traverse(Current.Left);
                        foreach(var left in LeftList)
                        {
                            yield return left;
                        }
                    }
                    //yield return Current;

                    if(Current.Right != null)
                    {
                        var RightList = Traverse(Current.Right);
                        foreach (var right in RightList)
                        {
                            yield return right;
                        }
                    }

                }

                foreach(var node in Traverse(root))
                {
                    yield return node; // two layer of yield return
                }
            }
        }
    }
}
