using System;

namespace test
{
    public class ArrayList<T> where T : IComparable
    {
        private T[] _array;
        private int _max;
        private int _last;

        public ArrayList(int max)
        {
            _max = max;
            _array = new T[_max];
            _last = -1;
        }

        //Bool Search1
        public bool BoolSearch(T item)
        {
            for (int i = 0; i <= _last; i++)
            {
                if (_array[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }
        //Search2
        public int Search(T item)
        {
            for (int i = 0; i <= _last; i++)
            {
                if (_array[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        //BinarySearch3
        public int BinarySearch(T item, int min, int max)
        {
            if (max >= min)
            {
                int middle = min + (max - min) / 2;

                // base
                if (_array[middle].CompareTo(item) == 0)
                    return middle;

                // if the item is in left subarray
                if (_array[middle].CompareTo(item) > 0)
                    BinarySearch(item, min, middle - 1);

                // if the item is in right subarray
                if (_array[middle].CompareTo(item) < 0)
                    BinarySearch(item, middle + 1, max);
            }

            return -1;
        }

        //AddItem4
        public void AddItem(T item)
        {
            if (_last + 1 == _max) return;

            int indexToAdd = _last + 1;

            for (int i = _last; i >= 0; i--)
            {
                if (_array[i].CompareTo(item) > 0)
                {
                    _array[i + 1] = _array[i];
                    indexToAdd = i;
                }
            }

            _array[indexToAdd] = item;
            _last++;
        }

        //AddItemFull5
        public void AddItemFull(T item)
        {
            if (_last + 1 == _max)
            {
                T[] temp = _array;
                _array = new T[_array.Length * 2];
                _max *= 2;

                for (int i = 0; i < temp.Length; i++)
                {
                    _array[i] = temp[i];
                }
            }
            AddItem(item);
        }
        //Replace6
            public void Replace(T k, T item)
            {
                for (int i = 0; i < _array.Length; i++)
                {
                    if (_array[i].Equals(k))
                        _array[i] = item;
                }
            }
        //Duplicate7
        public void Duplicate(T obj, int times)
        {
            int pos = Search(obj);
            for(int i = 0; i < times + 1; i++)
            {
                addItemPos(obj, pos);
            }
        }

        //addItemPos8
        public void addItemPos(T item, int pos)
        {
            if (pos > _last) return;

            if (_last + 1 == _max)
            {
                T[] temp = _array;
                _array = new T[_array.Length * 2];
                _max *= 2;

                for (int i = 0; i < temp.Length; i++)
                {
                    _array[i] = temp[i];
                }
            }

            for (int i = _last; i >= pos; i--)
            {
                _array[i + 1] = _array[i];
            }

            _array[pos] = item; //add the item
            _last++;
        }
        
        //DeleteItem9
        public int DeleteItem(T item)
        {
            int indexToDelete = -10000;

            for (int i = 0; i <= _last; i++)
            {
                if (_array[i].CompareTo(item) == 0)
                {
                    indexToDelete = i;
                    break;
                }
            }

            if (indexToDelete == -10000)
            {
                Console.WriteLine("The item was not found");
                return -10000;
            }

            for (int i = indexToDelete; i <= _last; i++)
            {
                _array[i] = _array[i + 1];
            }

            _last--;
            return indexToDelete;
        }
        //Split 10
        public void Split(int n)
        {
            int number = _array.Length / n;
            int temp = 0;
            T[] newArray = new T[number];
            for (int i = 0; i < number; i++)
            {
                T[] newSubArray = new T[n];
                for (int j = 0, k = temp; j < newSubArray.Length; j++, k++)
                {
                    newSubArray[j] = _array[k];
                }
                temp += newSubArray.Length;
                newArray[i] = newSubArray;
            }
            _array = newArray;
        }
        public void Print()
        {
            for (int i = 0; i <= _last; i++)
            {
                Console.Write(_array[i] + " ");
            }
        }

        public int CurLen()
        {
            return _last + 1;
        }

        public int MaxLen()
        {
            return _max;
        }
        //==============
    }
}