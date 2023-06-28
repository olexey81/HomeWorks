namespace HW_5_Collections
{
    using System.Collections;

    public class MyOneLinkedList<T> : IMyLinkedLists<T>
    {
        protected OneLinkedNode<T> _first;
        protected OneLinkedNode<T> _last;
        protected int _size;

        public int Count => _size;
        public virtual T First => _first.Data;
        public virtual T Last => _last.Data;

        protected virtual OneLinkedNode<T> NewNode(T data) => new OneLinkedNode<T>(data);

        public virtual void Add(T data)
        {
            OneLinkedNode<T> newNode = NewNode(data);

            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                _last.Next = newNode;
                _last = newNode;
            }

            _size++;
        }
        public virtual void AddFirst(T data)
        {
            OneLinkedNode<T> newNode = NewNode(data);

            if (_first == null)
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Next = _first;
                _first = newNode;
            }

            _size++;
        }
        public int BinarySearch(T item, Func<T, T, int> comparison)
        {
            Sort();
            int left = 0;
            int right = Count - 1;

            while (left <= right)
            {
                int middle = (right + left) / 2;
                T middleValue = GetNodeValueAt(middle);

                int comparisonResult = comparison(middleValue, item);

                if (comparisonResult == 0)
                {
                    return middle;
                }
                else if (comparisonResult > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return -1;
        }
        private T GetNodeValueAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            OneLinkedNode<T> current = _first;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public virtual void Insert(int index, T data)
        {
            if (index > _size)
                Console.WriteLine("Error! Incorrect index");

            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            if (index == _size)
            {
                Add(data);
                return;
            }

            OneLinkedNode<T> newNode = new OneLinkedNode<T>(data);
            OneLinkedNode<T> current = _first;
            OneLinkedNode<T> previous = null;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previous = current;
                current = current.Next;
                currentIndex++;
            }

            newNode.Next = current;
            previous.Next = newNode;

            _size++;
        }
        public virtual void Remove(T data)
        {
            OneLinkedNode<T> current = _first;
            OneLinkedNode<T>? previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current == _last)
                            _last = previous;
                    }
                    else
                    {
                        _first = current.Next;
                        if (_first == null)
                            _last = null;
                    }

                    _size--;
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        public virtual void RemoveFirst()
        {
            if (_first == null)
                return;

            _first = _first.Next;
            _size--;

            if (_first == null)
                _last = null;
        }
        public virtual void RemoveLast()
        {
            if (_last == null)
                return;

            if (_first == _last)
            {
                _first = null;
                _last = null;
            }
            else
            {
                OneLinkedNode<T> current = _first;
                while (current?.Next != _last)
                {
                    current = current?.Next;
                }
                current.Next = null;
                _last = current;
            }
            _size--;
        }
        public void Clear()
        {
            _first = null;
            _last = null;
            _size = 0;
        }

        public bool Contains(T data)
        {
            OneLinkedNode<T> current = _first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public virtual void Sort()
        {
            _first = MergeSort(_first);
            UpdateLastNode();
        }
        protected OneLinkedNode<T> MergeSort(OneLinkedNode<T> head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            OneLinkedNode<T> middle = GetMiddleNode(head);
            OneLinkedNode<T>? nextToMiddle = middle?.Next;
            middle!.Next = null;

            OneLinkedNode<T>? left = MergeSort(head);
            OneLinkedNode<T> right = MergeSort(nextToMiddle);

            return Merge(left, right);
        }
        private OneLinkedNode<T> Merge(OneLinkedNode<T> left, OneLinkedNode<T> right)
        {
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            OneLinkedNode<T> result;
            int comparisonResult = Comparer<T>.Default.Compare((T)Convert.ChangeType(left.Data, typeof(T)), (T)Convert.ChangeType(right.Data, typeof(T)));

            if (comparisonResult <= 0)
            {
                result = left;
                result.Next = Merge(left.Next, right);
            }
            else
            {
                result = right;
                result.Next = Merge(left, right.Next);
            }

            return result;
        }
        private OneLinkedNode<T> GetMiddleNode(OneLinkedNode<T> head)
        {
            if (head == null)
            {
                return head;
            }

            OneLinkedNode<T> slowPointer = head;
            OneLinkedNode<T> fastPointer = head;

            while (fastPointer?.Next != null && fastPointer.Next.Next != null)
            {
                slowPointer = slowPointer?.Next;
                fastPointer = fastPointer.Next.Next;
            }

            return slowPointer;
        }
        private void UpdateLastNode()
        {
            if (_first == null)
            {
                _last = null;
                return;
            }

            OneLinkedNode<T> current = _first;
            while (current.Next != null)
            {
                current = current.Next;
            }

            _last = current;
        }

        public T[] ToArray()
        {
            T[] array = new T[_size];
            OneLinkedNode<T> current = _first;
            int index = 0;

            while (current != null)
            {
                array[index] = current.Data;
                current = current.Next;
                index++;
            }

            return array;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //public virtual IEnumerator GetEnumerator()
        //{
        //    OneLinkedNode? current = _first;

        //    while (current != null)
        //    {
        //        yield return current.Data;
        //        current = current.Next;
        //    }
        //}

        public virtual IEnumerator<T> GetEnumerator() => new LinkedListIterator<T>(_first);

        private class LinkedListIterator<T> : IEnumerator<T>
        {
            private OneLinkedNode<T> _currentNode;
            public T Current { get; private set; }

            object IEnumerator.Current => Current;

            public LinkedListIterator(OneLinkedNode<T> current)
            {
                _currentNode = current;
            }

            public bool MoveNext()
            {
                if (_currentNode == null)
                    return false;

                Current = _currentNode.Data;
                _currentNode = _currentNode.Next;
                return true;
            }
            public void Reset()
            {
                _currentNode = null;
            }

            public void Dispose()
            {
            }
        }

        protected class OneLinkedNode<T>
        {
            public T Data { get; }
            public OneLinkedNode<T> Next { get; set; } = null;

            public OneLinkedNode(T data)
            {
                Data = data;
            }
        }
    }
}