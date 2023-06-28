using System.Collections;

namespace HW_5_Collections
{
    public class MyQueue : IMyQueue
    {
        private MyList _items;
        public int Count => _items.Count;

        public MyQueue()
        {
            _items = new MyList(0);
        }
        public MyQueue(int capacity)
        {
            _items = new MyList(capacity);
        }

        public void Enqueue(object item) => _items.Add(item);
        public object Dequeue()
        {
            if (Count > 0)
            {
                object dequeue = _items[0];
                _items.RemoveAt(0);
                return dequeue;
            }
            return null;
        }
        public void Clear() => _items.Clear();
        public bool Contains(object item) => _items.Contains(item);
        public object Peek()
        {
            if (Count > 0)
                return _items[0];
            else
                return null;
        }
        public object[] ToArray() => _items.ToArray();

        //public  IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < Count; i++)
        //        yield return _items[i];
        //}
        public IEnumerator GetEnumerator() => _items.GetEnumerator();
    }
}