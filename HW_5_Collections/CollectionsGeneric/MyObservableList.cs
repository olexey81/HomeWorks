namespace HW_5_Collections
{
    public class MyObservableList<T> : MyList<T>
    {
        public event Action<T> ItemAdded;
        public event Action<T> ItemRemoved;
        public event Action ListCleared;
        public event Action ListReversed;
        public event Action ListSorted;

        public override void Add(T item)
        {
            base.Add(item);
            ItemAdded?.Invoke(item);
        }
        public override void Insert(int index, T newItem)
        {
            base.Insert(index, newItem);
            ItemAdded.Invoke(newItem);
        }
        public override bool Remove(T item)
        {
            bool result = base.Remove(item);
            if (result)
                ItemRemoved.Invoke(item);
            return result;
        }
        public override void RemoveAt(int indexToRemove)
        {
            base.RemoveAt(indexToRemove);
            ItemRemoved.Invoke(_items[indexToRemove - 1]);
        }
        public override void Clear()
        {
            base.Clear();
            ListCleared?.Invoke();
        }

        public override void Reverse()
        {
            base.Reverse();
            ListReversed.Invoke();
        }

        public override void Sort()
        {
            base.Sort();
            ListSorted.Invoke();
        }
    }
}