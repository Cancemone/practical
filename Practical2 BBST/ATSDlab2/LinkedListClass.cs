using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class LinkedListClass <T> where T : IComparable
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;

        private int count;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool Empty
        {
            get
            {
                return count == 0;
            }
        }
        public LinkedListNode<T> First
        {
            get
            {
                return head;
            }
        }
        public LinkedListClass()
        {

        }
        public void AddAfter(LinkedListNode<T> node, T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value, node);
            node.Next = newNode;
            count++;
        }
        public void AddSort(T value)
        {
            if (head == null)
            {
                head = tail = new LinkedListNode<T>(value, null);
                count++;
            }
            else
            {
                LinkedListNode<T> current = head;
                while (current != null)
                {
                    if (value.CompareTo(current.Value) >= 0 && value.CompareTo(current.Next.Value) <= 0)
                    {
                        AddAfter(current, value);
                        break;
                    }
                    else if (value.CompareTo(head.Value) <= 0)
                    {
                        LinkedListNode<T> oldHead = head;
                        head = new LinkedListNode<T>(value, oldHead);
                        count++;
                        break;
                    }
                    else if (value.CompareTo(tail.Value) >= 0)
                    {
                        AddAfter(tail, value);
                        break;
                    }
                    current = current.Next;
                }
            }
        }
        public void RemoveAfter(LinkedListNode<T> node)
        {
            LinkedListNode<T> removedNode = node.Next;
            node.Next = removedNode.Next;
            removedNode.Next = null;
            if (removedNode == tail)
            {
                tail = node;
            }
            count--;
        }
        public void Remove(LinkedListNode<T> node)
        {
            if (node.Next != null)
            {
                node.Value = node.Next.Value;
                RemoveAfter(node);
            }
            else
            {
                //delete tail
                if (head == tail)
                {
                    head = tail = null;
                    count--;
                }
                else
                {
                    RemoveAfter(FindPrevNode(node));
                }
            }
        }
        public LinkedListNode<T> FindPrevNode(LinkedListNode<T> node)
        {
            LinkedListNode<T> prevNode = null;
            LinkedListNode<T> currentNode = head;

            while (currentNode != null)
            {
                prevNode = currentNode;
                currentNode = currentNode.Next;
            }

            return prevNode;
        }
        public void ListEqual(LinkedListClass<T> L2)
        {
            LinkedListNode<T> current1 = head;
            LinkedListNode<T> current2 = L2.head;
            if (count.CompareTo(L2.count) == 0)
            {

                while (current1 != null)
                {
                    if (current1.Value.CompareTo(current2.Value) != 0)
                    {
                        Console.WriteLine("Lists are diffrent");
                        break;
                    }
                    current1 = current1.Next;
                    current2 = current2.Next;
                }
                PrintList();
                L2.PrintList();
            }
        }
        public void TheBiggest(LinkedListClass<T> L2, LinkedListClass<T> L3)
        {
            LinkedListNode<T> current1 = head;
            LinkedListNode<T> current2 = L2.head;
            LinkedListNode<T> current3 = L3.head;
            int count1=0,count2=0, count3=0;
            int tmp1, tmp2;
            LinkedListClass<T> max;
            while (current1.Next != null)
            {
                tmp1 = Convert.ToInt32(current1.Value);
                tmp2 = Convert.ToInt32(current1.Next.Value);
                if (tmp2 - tmp1 == 1)
                {
                    count1++;
                }
                else
                {
                    break;
                }
                current1 = current1.Next;
            }
            max = this;
            while (current2.Next != null)
            {
                tmp1 = Convert.ToInt32(current2.Value);
                tmp2 = Convert.ToInt32(current2.Next.Value);
                if (tmp2 - tmp1 == 1)
                {
                    count2++;
                }
                else if(tmp2-tmp1>1)
                {
                    break;
                }
                current2 = current2.Next;
            }
            if (count2 > count1)
            {
                max = L2;
            }
            while (current3.Next != null)
            {
                tmp1 = Convert.ToInt32(current3.Value);
                tmp2 = Convert.ToInt32(current3.Next.Value);
                if (tmp2 - tmp1 == 1)
                {
                    count3++;
                }
                else
                {
                    break;
                }
                current3 = current3.Next;
            }
            if (count3 > count2)
            {
                max = L3;
            }
            max.PrintList();
            
        }
        public void PrintList()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
        public void Add(T value)
        {

            var node = new LinkedListNode<T>(value);
            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }

            tail = node;
            count++;
        }
        public LinkedListNode<T> Search(T value)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Value.CompareTo(value) == 0)
                    return current;
                current = current.Next;
            }
            return null;
        }
    }
}
