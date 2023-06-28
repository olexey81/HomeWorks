namespace HW_5_Collections
{
    public class MyPriorityQueue<T> : MyQueue<T> where T : IComparable<T>
    {
        public override void Enqueue(T item)
        {
            _items.Add(item);
            int position = Count - 1;

            while (position > 0 && _items[position].CompareTo(_items[position - 1]) > 0)
            {
                _items[position] = _items[position - 1];
                _items[position - 1] = item;
                position--;
            }
        }
    }
}