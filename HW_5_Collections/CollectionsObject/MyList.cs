namespace HW_5_Collections
{
    using System.Collections;

    public class MyList : IMyList
    {
        private object[] _items;
        private const int _InitCapacity = 4;
        private int _size;

        public int Count => _size;
        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < _size)
                    Console.WriteLine("Error! Capacity cannot be less than elements number");
                else
                {
                    object[] _itemsExtend = new object[value];

                    for (int i = 0; i < _size; i++)
                        _itemsExtend[i] = _items[i];

                    _items = _itemsExtend;
                }
            }
        }
        public object this[int index]
        {
            get
            {
                if (index < Count)
                    return _items[index];
                else
                {
                    Console.WriteLine("Error! Incorrect index");
                    return null;
                }
            }
            set
            {
                if (index < Count)
                    _items[index] = value;
                else
                    Console.WriteLine("Error! Incorrect index");
            }
        }


        public MyList()
        {
            _items = new object[_InitCapacity];
        }
        public MyList(int capacity)
        {
            Capacity = capacity;
            _items = new object[Capacity];
        }

        public void Add(object newItem)
        {
            if (_size < _items.Length)
                AddToEnd(newItem);
            else
            {
                Grow();
                AddToEnd(newItem);
            }
        }

        public int BinarySearch(object item)
        {
            Sort();
            return BinarySearch(item, 0, Count - 1);
        }

        private int BinarySearch(object item, int left, int right)
        {
            if (left <= right)
            {
                int middle = (left + right) / 2;
                int comparisonResult = Comparer<object>.Default.Compare(_items[middle], item);

                if (comparisonResult == 0)
                {
                    return middle;
                }
                else if (comparisonResult > 0)
                {
                    return BinarySearch(item, left, middle - 1);
                }
                else
                {
                    return BinarySearch(item, middle + 1, right);
                }
            }

            return -1;
        }


        public void Insert(int index, object newItem)
        {
            if (index >= _size)
            {
                Console.WriteLine("Error! Index is out of array's size");
                //throw new ArgumentOutOfRangeException(nameof(index));
                return;
            }

            ModArrayToInsert(index);
            _items[index] = newItem;
            _size++;
        }
        public bool Remove(object itemToRemove)
        {
            if (Contains(itemToRemove))
            {
                CompressArray(IndexOf(itemToRemove));
                return true;
            }
            else
                return false;
        }
        public void RemoveAt(int indexToRemove)
        {
            if (indexToRemove >= _size)
            {
                Console.WriteLine("Error! Index is out of array's size");
                return;
            }
            else
                CompressArray(indexToRemove);
        }
        public void Clear()
        {
            _items = new object[_InitCapacity];
            _size = 0;
        }
        public bool Contains(object item)
        {
            if (IndexOf(item) > -1)
                return true;
            return false;
        }
        public int IndexOf(object item)
        {
            int indexItem = -1;

            for (int i = 0; i < _size; i++)
            {
                if (_items[i].Equals(item))
                {
                    indexItem = i;
                    break;
                }
            }

            return indexItem;
        }
        public object[] ToArray()
        {
            object[] array = new object[_size];

            for (int i = 0; i < _size; i++)
                array[i] = _items[i];

            return array;

        }
        public void Reverse()
        {
            object[] reversedItems = new object[Capacity];

            for (int i = 0; i < _size; i++)
                reversedItems[i] = _items[_size - 1 - i];

            _items = reversedItems;
        }

        public void Sort() => MergeSort(_items, 0, Count - 1);
        private void MergeSort(object[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);

                Merge(arr, left, middle, right);
            }
        }
        private void Merge(object[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            object[] leftArr = new object[n1];
            object[] rightArr = new object[n2];

            Array.Copy(arr, left, leftArr, 0, n1);
            Array.Copy(arr, middle + 1, rightArr, 0, n2);

            int i = 0, j = 0;
            int k = left;

            while (i < n1 && j < n2)
            {
                if (Comparer<object>.Default.Compare(leftArr[i], rightArr[j]) <= 0)
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = leftArr[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = rightArr[j];
                j++;
                k++;
            }
        }


        private void AddToEnd(object newItem) => _items[_size++] = newItem;

        private void Grow()
        {
            object[] _itemsExtend = new object[_InitCapacity + _items.Length * 2];

            for (int i = 0; i < _size; i++)
                _itemsExtend[i] = _items[i];

            _items = _itemsExtend;
        }
        private void ModArrayToInsert(int index)
        {
            if (_size == Capacity)
            {
                object[] _itemsMod;
                _itemsMod = new object[Capacity + _InitCapacity];
                for (int i = 0; i < _size; i++)
                {
                    if (i < index)
                        _itemsMod[i] = _items[i];
                    else
                        _itemsMod[i + 1] = _items[i];
                }
                _items = _itemsMod;
            }
            else
                for (int i = _size; i > index; i--)
                    _items[i] = _items[i - 1];
        }
        private void CompressArray(int index)
        {
            for (int i = index; i < _size - 1; i++)
                _items[i] = _items[i + 1];

            _items[_size - 1] = null;
            _size--;
        }

        //public IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < Count; i++)
        //        yield return _items[i];
        //}
        public IEnumerator GetEnumerator() => new ListIterator(this);
        private class ListIterator : IEnumerator
        {
            private readonly MyList _items;
            private int _index;
            public object? Current { get; private set; }

            public ListIterator(MyList items)
            {
                _items = items;
                _index = 0;
            }
            public bool MoveNext()
            {
                if (_index < _items.Count)
                {
                    Current = _items[_index++];
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _index = 0;
            }
        }
    }
}