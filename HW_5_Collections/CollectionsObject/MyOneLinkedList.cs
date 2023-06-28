namespace HW_5_Collections
{
    using System.Collections;

    public class MyOneLinkedList : IMyLinkedLists
    {
        protected OneLinkedNode? _first;
        protected OneLinkedNode? _last;
        protected int _size;

        public int Count => _size;
        public virtual object? First => _first?.Data;
        public virtual object? Last => _last?.Data;


        protected virtual OneLinkedNode NewNode(object data) => new OneLinkedNode(data);
        public virtual void Add(object data)
        {
            OneLinkedNode newNode = NewNode(data);

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
        public virtual void AddFirst(object data)
        {
            OneLinkedNode newNode = NewNode(data);

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

        public int BinarySearch(object item)
        {
            Sort();
            int left = 0;
            int right = Count - 1;

            while (left <= right)
            {
                int middle = (right + left) / 2;
                object middleValue = GetNodeValueAt(middle);

                int comparisonResult = Comparer<object>.Default.Compare(middleValue, item);

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
        private object GetNodeValueAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            OneLinkedNode current = _first;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public virtual void Insert(int index, object data)
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

            OneLinkedNode newNode = new OneLinkedNode(data);
            OneLinkedNode current = _first;
            OneLinkedNode previous = null;
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
        public virtual void Remove(object data)
        {
            OneLinkedNode? current = _first;
            OneLinkedNode? previous = null;

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
                OneLinkedNode? current = _first;
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

        public bool Contains(object data)
        {
            OneLinkedNode? current = _first;

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
        protected OneLinkedNode? MergeSort(OneLinkedNode? head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            OneLinkedNode? middle = GetMiddleNode(head);
            OneLinkedNode? nextToMiddle = middle?.Next;
            middle!.Next = null;

            OneLinkedNode? left = MergeSort(head);
            OneLinkedNode? right = MergeSort(nextToMiddle);

            return Merge(left, right);
        }
        private OneLinkedNode? Merge(OneLinkedNode? left, OneLinkedNode? right)
        {
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            OneLinkedNode? result;
            int comparisonResult = Comparer<object>.Default.Compare(left.Data, right.Data);

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
        private OneLinkedNode? GetMiddleNode(OneLinkedNode? head)
        {
            if (head == null)
            {
                return head;
            }

            OneLinkedNode? slowPointer = head;
            OneLinkedNode? fastPointer = head;

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

            OneLinkedNode current = _first;
            while (current.Next != null)
            {
                current = current.Next;
            }

            _last = current;
        }

        public object[] ToArray()
        {
            object[] array = new object[_size];
            OneLinkedNode current = _first;
            int index = 0;

            while (current != null)
            {
                array[index] = current.Data;
                current = current.Next;
                index++;
            }

            return array;
        }

        //public virtual IEnumerator GetEnumerator()
        //{
        //    OneLinkedNode? current = _first;

        //    while (current != null)
        //    {
        //        yield return current.Data;
        //        current = current.Next;
        //    }
        //}

        public virtual IEnumerator GetEnumerator() => new LinkedListIterator(_first);
        private class LinkedListIterator : IEnumerator
        {
            private OneLinkedNode? _currentNode;
            public object? Current { get; private set; }
            public LinkedListIterator(OneLinkedNode? current)
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
        }

        protected class OneLinkedNode
        {
            public object Data { get; }
            public OneLinkedNode? Next { get; set; } = null;

            public OneLinkedNode(object data)
            {
                Data = data;
            }
        }
    }
}