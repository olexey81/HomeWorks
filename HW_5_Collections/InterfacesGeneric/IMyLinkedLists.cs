namespace HW_5_Collections
{
    public interface IMyLinkedLists<T> : IMyCollection<T>
    {
        T First { get; }
        T Last { get; }
        void Add(T data);
        void AddFirst(T data);
        void Insert(int index, T data);
        void Remove(T data);
        void RemoveFirst();
        void RemoveLast();
    }
}