using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSDlab2
{
    class Program
    {

        static void Main(string[] args)
        {
            var tree1 = new BinaryTree<int>();
            tree1.Add(5);
            tree1.Add(6);
            tree1.Add(7);
            tree1.Add(9);
            tree1.Add(2);
            tree1.Add(1);
            tree1.Add(3);

            var tree2 = new BinaryTree<int>();
            tree2.Add(-9);
            tree2.Add(7);
            tree2.Add(-33);
            tree2.Add(22);
            tree2.Add(11);
            tree2.Add(-77);
            tree2.Add(-111);

            tree1.PrintSorted();
            Console.WriteLine("---------------------");
            Console.Write("Count of left sons : ");
            Console.WriteLine(tree1.CounNodeLeft());
            Console.WriteLine("---------------------");
            Console.Write("Sum of keys right son nodes: ");
            Console.WriteLine(tree1.SumKeys(tree1.Root));
            Console.WriteLine("---------------------");
            Console.Write("Delete even numbers: ");
            tree1.CopyBinaryTree().DeleteEven().PrintPreOrder();
            Console.WriteLine("---------------------");

        }
    }
    }
