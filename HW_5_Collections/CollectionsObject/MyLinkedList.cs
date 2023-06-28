namespace HW_5_Collections
{
    public class MyLinkedList : MyOneLinkedList, IMyLinkedLists
    {
        protected override OneLinkedNode NewNode(object data) => new LinkedNode(data);

        public override void Add(object data)
        {
            LinkedNode? newNode = (LinkedNode)_last;
            base.Add(data);

            if (newNode != null)
                ((LinkedNode)_last).Previous = newNode;
        }
        public override void AddFirst(object data)
        {
            LinkedNode? newNode = (LinkedNode)_first;
            base.AddFirst(data);

            if (newNode != null)
                newNode.Previous = (LinkedNode)_first;
        }

        public override void Insert(int index, object data)
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

            LinkedNode newNode = new LinkedNode(data);
            LinkedNode current = (LinkedNode)_first;
            LinkedNode previous = null;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previous = current;
                current = (LinkedNode?)current.Next;
                currentIndex++;
            }
            current.Previous = newNode;
            newNode.Next = current;
            newNode.Previous = previous;
            previous.Next = newNode;

            _size++;
        }
        public override void Remove(object data)
        {
            if (Count == 0) return;
            if (Count == 1 && _first.Data.Equals(data))
            {
                _first = null;
                _last = null;
                _size--;
                return;
            }
            LinkedNode? current = (LinkedNode?)_first;
            LinkedNode? next = (LinkedNode?)current.Next;
            LinkedNode? previous = null;

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
                next = (LinkedNode?)current.Next;
            }
        }
        public override void RemoveFirst()
        {
            base.RemoveFirst();
            if (_first != null)
                ((LinkedNode)_first).Previous = null;
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
                _last = ((LinkedNode)_last).Previous;
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

            LinkedNode current = (LinkedNode)_first;
            LinkedNode previous = null;
            LinkedNode next = (LinkedNode)current.Next;

            while (next != null)
            {
                current.Previous = previous;
                previous = current;
                current = next;
                next = (LinkedNode)next.Next;
            }

            current.Previous = previous;
            _last = current;
        }

        private class LinkedNode : OneLinkedNode
        {
            public LinkedNode? Previous { get; set; } = null;

            public LinkedNode(object data) : base(data)
            {
            }
        }
    }
}