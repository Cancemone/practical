using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSDlab2
{
    public class BinaryTree<T> where T : IComparable<T>, IComparable
    {
        public BinaryTreeNode<T> Root;

        public BinaryTree() { }

        public BinaryTree(BinaryTreeNode<T> node)
        {
            Root = node;
        }
        //It prints keys of a BBST in 2 lines:
    //-	Sorted in ascending order(first line)
    //-	Sorted in descending order(second line)

        public void PrintSorted()
        {
            Console.WriteLine("Sorted in ascending order (inOrder traversal) :");
            PrintInAscending();

            Console.WriteLine("\nSorted in descending order :");
            PrintInDescending();
            Console.WriteLine();
        }
        private void PrintInAscending()
        {
            Root?.PrintInAscending();
        }

        private void PrintInDescending()
        {
            Root?.PrintInDescending();
        }

        public void PrintPreOrder()
        {
            Root?.PrintPreOrder();
            Console.WriteLine();
        }

        private void PrintPostOrder()
        {
            Root?.PrintPostOrder();
        }
        //1.	Given a recursive function (= a definition of a recursive algorithm).
        public int F(int n)
        {
            if (n == 0)
            {
                return 3;
            }
            else if(n>0)
            {
                return 4 * F(n - 1) + 2 * F(n / 2) + 7;
            }
            else
            {
                return 0;
            }
        }
        //2. Write a recursive algorithm int Prod( int a, int b) that calculates and returns a×b;
        static int product(int x, int y)
        {
            // if x is less than
            // y swap the numbers
            if (x < y)
                return product(y, x);

            // iteratively calculate
            // y times sum of x
            else if (y != 0)
                return (x + product(x, y - 1));

            // if any of the two numbers is
            // zero return zero
            else
                return 0;
        }
        //3.Write a recursive algorithm  int Sum() that calculates and returns 
        //the sum of integer items of a linked list
        int Sum(LinkedListNode<int> head)
        {
            if (head != null)
                return head.Value + Sum(head.Next);
            else
                return 0;
        }
        //4.Write a recursive algorithm  void printList() 
        //that prints integer items of a linked list.
        static void printList(LinkedListNode<T> head)
        {
            if (head == null)
                return;

            // If head is not null, print current node
            // and recur for remaining list
            Console.Write(head.Value + " ");

            printList(head.Next);
        }
        //5.	Write a recursive algorithm  void printListReverse() 
        //that prints integer items of a linked list in reverse order.
        void printReverse(LinkedListNode<T> head)
        {
            if (head == null) return;

            // print list of head node
            printReverse(head.Next);

            // After everything else is printed
            Console.Write(head.Value + " ");
        }

        //6,7 Realised in BinaryTreeNode.cs

        //8. It finds the sum of keys in right son nodes in a BBST.
        public int SumKeys(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            return (root.Data + SumKeys(root.Right));
        }
        //10. It returns true if two BBSTs are equal( if tree shapes and corresponding keys are the same). 
        //Otherwise it returns false.
        public bool sameData(BinaryTree<T> BinaryTree)
        {
            return this.ToList().SequenceEqual(BinaryTree.ToList());
        }
        //11.	Write an algorithm  function void BST_List(linkedList *L)  
        //that copies data from a binary search tree T into a linked list L which is sorted in ascending order.
        private void ToList(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }
            list.Add(node.Data);
            if (node.Left != null)
            {
                ToList(node.Left, list);
            }

            if (node.Right != null)
            {
                ToList(node.Right, list);
            }
        }
        void makeEmpty() 
        {
            Root = null;
        }
        //13.	Write an algorithm int size() for the class BST that returns the number 
        //of data items (= nodes) in a BST.
        private int Size(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return (Size(node.Left) + 1 + Size(node.Right));
            }
        }

        //14. It returns true if the calling object is a balanced binary search tree, otherwise false.
        public bool IsBalanced()
        {
            return BalanceFactor(Root) < 2 && BalanceFactor(Root) > -2;
        }
        private int BalanceFactor(BinaryTreeNode<T> current)
        {
            int l = GetHeight(current.Left);
            int r = GetHeight(current.Right);
            int balanceFactor = l - r;
            return balanceFactor;
        }
        //It count the number of left son nodes in a BBST.
        public int CounNodeLeft()
        {
            return CountNodeLeft(Root);
        }
        private int CountNodeLeft(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.Left == null)
            {
                return CountNodeLeft(root.Right);
            }
            else
            {
                return CountNodeLeft(root.Left) + CountNodeLeft(root.Right) + 1;
            }
        }

        //add node in BST, using only recursion.
        private BinaryTreeNode<T> RecursiveInsert(BinaryTreeNode<T> current, BinaryTreeNode<T> n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            if (n.Data.CompareTo(current.Data) < 0)
            {
                current.Left = RecursiveInsert(current.Left, n);
                current = BalanceBinaryTree(current);
            }
            else if (n.Data.CompareTo(current.Data) > 0)
            {
                current.Right = RecursiveInsert(current.Right, n);
                current = BalanceBinaryTree(current);
            }
            return current;
        }

        //searches node in BST, using only recursion.
        public void Search(T data)
        {
            if (Search(data, Root).Data.Equals(data))
            {
                Console.WriteLine($"{data} was found!");
            }
            else
            {
                Console.WriteLine("Nothing found!");
            }
        }
        private BinaryTreeNode<T> Search(T data, BinaryTreeNode<T> current)
        {
            if (data.CompareTo(current.Data) < 0)
            {
                if (data.Equals(current.Data))
                {
                    return current;
                }
                return Search(data, current.Left);

            }
            if (data.Equals(current.Data))
            {
                return current;
            }

            return Search(data, current.Right);
        }

        //deletes node in BST, using only recursion.
        public void Delete(T data)
        {
            Root = Delete(Root, data);
        }
        private BinaryTreeNode<T> Delete(BinaryTreeNode<T> current, T data)
        {
            BinaryTreeNode<T> parent;
            if (current == null)
            {
                return null;
            }
            if (data.CompareTo(current.Data) < 0)
            {
                current.Left = Delete(current.Left, data);
                if (BalanceFactor(current) == -2)
                {
                    if (BalanceFactor(current.Right) <= 0)
                    {
                        current = RotateRR(current);
                    }
                    else
                    {
                        current = RotateRL(current);
                    }
                }
            }
            else if (data.CompareTo(current.Data) > 0)
            {
                current.Right = Delete(current.Right, data);
                if (BalanceFactor(current) == 2)
                {
                    if (BalanceFactor(current.Left) >= 0)
                    {
                        current = RotateLL(current);
                    }
                    else
                    {
                        current = RotateLR(current);
                    }
                }
            }
            else
            {
                if (current.Right != null)
                {
                    parent = current.Right;
                    while (parent.Left != null)
                    {
                        parent = parent.Left;
                    }
                    current.Data = parent.Data;
                    current.Right = Delete(current.Right, parent.Data);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else { current = RotateLR(current); }
                    }
                }
                else
                {
                    return current.Left;
                }
            }
            return current;
        }

        //It deletes all even keys from a BBST. (Result is also a BBST)
        public BinaryTree<T> DeleteEven()
        {
            var BinaryTree = new BinaryTree<T>();
            var result = ToList().Where(x => Convert.ToInt32(x) % 2 != 0);
            foreach (var item in result)
            {
                BinaryTree.Add(item);
            }

            return BinaryTree;
        }

        //It returns the tree key which is the nearest to the Valuemid = (keymin + keymax) / 2.
        public T FindMiddle()
        {
            var num = (Convert.ToInt32(ToList().OrderBy(x => x).Last()) +
                      Convert.ToInt32(ToList().OrderBy(x => x).First())) / 2;
            var result = ToList().OrderBy(item => Math.Abs(num - Convert.ToInt32(item))).First();
            return result;
        }
        //It returns the second largest key of a BBST without deleting it.
        public BinaryTreeNode<T> GetSecondLargest(BinaryTreeNode<T> node)
        {

            if (node.Right == null && node.Left != null)
            {
                return GetLargest(node.Left);
            }

            if (node.Right != null &&
                node.Right.Left == null &&
                node.Right.Right == null)
            {
                return node;
            }

            return GetSecondLargest(node.Right);
        }

        public T GetSecondLargest()
        {
            return GetSecondLargest(Root).Data;
        }
        private BinaryTreeNode<T> GetLargest(BinaryTreeNode<T> node)
        {
            if (node.Right != null)
            {
                return GetLargest(node.Right);
            }
            return node;
        }
        //It creates and returns a copy of a given BBST.
        public BinaryTree<T> CopyBinaryTree()
        {
            BinaryTree<T> BinaryTree = new BinaryTree<T>(this.CopyBinaryTree(Root));
            return BinaryTree;
        }
        private BinaryTreeNode<T> CopyBinaryTree(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return null;
            }
            else
            {
                var tmp = new BinaryTreeNode<T>(root.Data);
                tmp.Left = CopyBinaryTree(root.Left);
                tmp.Right = CopyBinaryTree(root.Right);
                return tmp;
            }
        }
        //It inserts al keys of BBST2 into a BBST1. Result is BBST1 which is balanced.
        public void InsertBinaryTree(BinaryTree<T> BinaryTree)
        {
            var list = BinaryTree.ToList();
            foreach (var item in list)
            {
                this.Add(item);
            }
        }
        
        public void Add(T data)
        {
            BinaryTreeNode<T> newItem = new BinaryTreeNode<T>(data);
            Root = Root == null ? newItem : RecursiveInsert(Root, newItem);
        }
        
        private BinaryTreeNode<T> BalanceBinaryTree(BinaryTreeNode<T> current)
        {
            int balanceFactor = BalanceFactor(current);
            if (balanceFactor > 1)
            {
                if (BalanceFactor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (balanceFactor < -1)
            {
                if (BalanceFactor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        
        //It determines if all keys of BBST2 are contained in BBST1. If so it returns true, otherwise false.
        public bool Contains(BinaryTree<T> BinaryTree)
        {
            return this.ToList().Except(BinaryTree.ToList()).Any();
        }
        //It creates and returns a new BBST which is symmetrical to the original one.
        public BinaryTree<T> MakeSymmetricalBinaryTree()
        {
            var BinaryTree = new BinaryTree<T>(MakeSymmetricalBinaryTree(Root));
            return BinaryTree;
        }

        private BinaryTreeNode<T> MakeSymmetricalBinaryTree(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return null;
            }

            BinaryTreeNode<T> mirror = new BinaryTreeNode<T>(root.Data);
            mirror.Right = MakeSymmetricalBinaryTree(root.Left);
            mirror.Left = MakeSymmetricalBinaryTree(root.Right);
            return mirror;
        }
        //It returns the key of the father node for the node with the argument key, 
        //if the argument key belongs to the calling tree object, otherwise it returns -10000.
        public T FatherNode(T data)
        {
            return FatherNode(Root, Search(data, Root)).Data;
        }
        private BinaryTreeNode<T> FatherNode(BinaryTreeNode<T> node, BinaryTreeNode<T> father)
        {
            if (father.Equals(Root) || node == null)
            {
                throw new Exception();
            }
            else
            {
                if (node.Left == father || node.Right == father)
                    return node;
                else
                {
                    if (node.Data.CompareTo(father.Data) < 0)
                    {
                        return FatherNode(node.Right, father);
                    }
                    else
                    {
                        return FatherNode(node.Left, father);
                    }
                }
            }
        }
        //It returns the lowest common ancestor of the two nodes containing the argument keys. 
        //For the above example, A.CommonAncestor(17, 40) returns 25.  
        public T CommonAncestor(T x, T y)
        {
            return CommonAncestor(Root, x, y).Data;
        }
        private BinaryTreeNode<T> CommonAncestor(BinaryTreeNode<T> node, T x, T y)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Data.Equals(x) || node.Data.Equals(y))
            {
                return node;
            }

            BinaryTreeNode<T> leftAncestor = CommonAncestor(node.Left, x, y);
            BinaryTreeNode<T> rightAncestor = CommonAncestor(node.Right, x, y);

            if (leftAncestor != null && rightAncestor != null)
            {
                return node;
            }

            return leftAncestor ?? rightAncestor;
        }
        

        private int Max(int l, int r)
        {
            return l > r ? l : r;
        }
        private int GetHeight(BinaryTreeNode<T> current)
        {
            int height = 0;
            if (current != null)
            {
                int l = GetHeight(current.Left);
                int r = GetHeight(current.Right);
                int m = Max(l, r);
                height = m + 1;
            }
            return height;
        }
        
        private BinaryTreeNode<T> RotateRR(BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;

        }
        private BinaryTreeNode<T> RotateLL(BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private BinaryTreeNode<T> RotateLR(BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private BinaryTreeNode<T> RotateRL(BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }
       

        public bool IsEmpty()
        {
            return Root == null;
        }

        public int Size()
        {
            return Size(Root);
        }
                

        public List<T> ToList()
        {
            var list = new List<T>();
            ToList(Root, list);
            return list;
        }
    }
}
