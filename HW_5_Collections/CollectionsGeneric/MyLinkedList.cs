namespace HW_5_Collections
{
    public class MyLinkedList<T> : MyOneLinkedList<T> where T : IComparable<T>
    {
        protected override OneLinkedNode<T> NewNode(T data) => new LinkedNode<T>(data);

        public override void Add(T data)
        {
            LinkedNode<T> newNode = (LinkedNode<T>)_last;
            base.Add(data);

            if (newNode != null)
                ((LinkedNode<T>)_last).Previous = newNode;
        }
        public override void AddFirst(T data)
        {
            LinkedNode<T> newNode = (LinkedNode<T>)_first;
            base.AddFirst(data);

            if (newNode != null)
                newNode.Previous = (LinkedNode<T>)_first;
        }
        public override void Insert(int index, T data)
        {
            if (index > _size)
                throw new IndexOutOfRangeException();

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

            LinkedNode<T> newNode = new LinkedNode<T>(data);
            LinkedNode<T> current = (LinkedNode<T>)_first;
            LinkedNode<T> previous = null;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previous = current;
                current = (LinkedNode<T>)current.Next;
                currentIndex++;
            }
            current.Previous = newNode;
            newNode.Next = current;
            newNode.Previous = previous;
            previous.Next = newNode;

            _size++;
        }
        public override void Remove(T data)
        {
            if (Count == 0) return;
            if (Count == 1 && _first.Data.Equals(data))
            {
                _first = null;
                _last = null;
                _size--;
                return;
            }
            LinkedNode<T> current = (LinkedNode<T>)_first;
            LinkedNode<T> next = (LinkedNode<T>)current.Next;
            LinkedNode<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (next == null)
                    {
                        previous.Next = null;
                        _last = previous;
                    }
                    else
                    {
                        next.Previous = previous;

                        if (previous == null)
                            _first = next;
                        else
                            previous.Next = next;
                    }

                    _size--;
                    return;
                }

                if (next == null)
                    return;

                previous = current;
                current = next;
                next = (LinkedNode<T>)current.Next;
            }
        }
        public override void RemoveFirst()
        {
            base.RemoveFirst();
            if (_first != null)
                ((LinkedNode<T>)_first).Previous = null;
        }
        public override void RemoveLast()
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
                _last = ((LinkedNode<T>)_last).Previous;
                _last.Next = null;
            }

            _size--;
        }

        public override void Sort()
        {
            _first = MergeSort(_first);
            UpdateNodeLinks();
        }
        private void UpdateNodeLinks()
        {
            if (_first == null)
            {
                _last = null;
                return;
            }

            LinkedNode<T> current = (LinkedNode<T>)_first;
            LinkedNode<T> previous = null;
            LinkedNode<T> next = (LinkedNode<T>)current.Next;

            while (next != null)
            {
                current.Previous = previous;
                previous = current;
                current = next;
                next = (LinkedNode<T>)next.Next;
            }

            current.Previous = previous;
            _last = current;
        }

        private class LinkedNode<T> : OneLinkedNode<T>
        {
            public LinkedNode<T> Previous { get; set; } = null;

            public LinkedNode(T data) : base(data)
            {
            }
        }
    }
}