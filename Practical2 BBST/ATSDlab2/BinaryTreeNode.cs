using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSDlab2
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        public BinaryTreeNode(T data)
        {
            Data = data;
        }
        public T Data 
        { get; 
          set; 
        }

        public BinaryTreeNode<T> Left 
        { 
            get; 
            internal set; 
        }

        public BinaryTreeNode<T> Right 
        { 
        get;  
       internal set; 
        }

        internal void PrintInAscending()
        {
            Left?.PrintInAscending();
            Console.Write(Data + " ");
            Right?.PrintInAscending();
        }

        internal void PrintInDescending()
        {
            Right?.PrintInDescending();
            Console.Write(Data + " ");
            Left?.PrintInDescending();
        }

        internal void PrintPreOrder()
        {
            Console.Write(Data + " ");
            Left?.PrintPreOrder();
            Right?.PrintPreOrder();
        }

        internal void PrintPostOrder()
        {
            Left?.PrintPreOrder();
            Right?.PrintPreOrder();
            Console.Write(Data + " ");
        }
    }
}
