using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class LinkedListNode<T>
    {
        //значение в узле списка
        public T Value
        {
            get; set;
        }
        //следующий узел
        public LinkedListNode<T> Next
        {
            get; set;
        }
        //constructor
        public LinkedListNode(T value, LinkedListNode<T> next = null)
        {
            Value = value;
            Next = next;
        }
    }
}
