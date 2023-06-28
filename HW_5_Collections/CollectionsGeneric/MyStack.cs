using System.Collections;

namespace HW_5_Collections
{
    public class MyStack<T> : IMyStack<T>
    {
        private MyList<T> _items;
        public int Count => _items.Count;

        public MyStack()
        {
            _items = new MyList<T>(0);
        }
        public MyStack(int capacity)
        {
            _items = new MyList<T>(capacity);
        }
        public void Push(T item) => _items.Add(item);
        public T Pop()
        {
            if (Count > 0)
            {
                T dequeue = _items[Count - 1];
                _items.RemoveAt(Count - 1);
                return dequeue;
            }
            else
                throw new InvalidOperationException();
        }
        public T Peek()
        {
            if (Count > 0)
                return _items[Count - 1];
            else
                throw new InvalidOperationException();
        }
        public void Clear() => _items.Clear();
        public bool Contains(T item) => _items.Contains(item);
        public T[] ToArray() => _items.ToArray();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //public IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < Count; i++)
        //        yield return _items[i];
        //}
        public IEnumerator<T> GetEnumerator() => new StackIterator<T>(_items);
        private class StackIterator<T> : IEnumerator<T>
        {
            private readonly MyList<T> _items;
            private int _index;
            public T Current { get; private set; }
            object IEnumerator.Current => Current;

            public StackIterator(MyList<T> items)
            {
                _items = items;
                _index = items.Count - 1;
            }
            public bool MoveNext()
            {
                if (_index >= 0)
                {
                    Current = _items[_index--];
                    return true;
                }
                return false;
            }
            public void Reset()
            {
                _index = 0;
            }
            public void Dispose()
            {
            }
        }
    }
}