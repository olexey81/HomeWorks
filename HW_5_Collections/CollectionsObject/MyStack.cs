using System.Collections;

namespace HW_5_Collections
{
    public class MyStack : IMyStack
    {
        private MyList _items;
        public int Count => _items.Count;

        public MyStack()
        {
            _items = new MyList(0);
        }
        public MyStack(int capacity)
        {
            _items = new MyList(capacity);
        }
        public void Push(object item) => _items.Add(item);
        public object Pop()
        {
            if (Count > 0)
            {
                object dequeue = _items[Count - 1];
                _items.RemoveAt(Count - 1);
                return dequeue;
            }
            else
                return null;
        }
        public object Peek()
        {
            if (Count > 0)
                return _items[Count - 1];
            else
                return null;
        }
        public void Clear() => _items.Clear();
        public bool Contains(object item) => _items.Contains(item);
        public object[] ToArray() => _items.ToArray();

        //public IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < Count; i++)
        //        yield return _items[i];
        //}
        public IEnumerator GetEnumerator() => new StackIterator(_items);
        private class StackIterator : IEnumerator
        {
            private readonly MyList _items;
            private int _index;
            public object? Current { get; private set; }

            public StackIterator(MyList items)
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
        }
    }
}