namespace HW_5_Collections
{
    public interface IMyLinkedLists : IMyCollection
    {
        object? First { get; }
        object? Last { get; }
        void Add(object data);
        void AddFirst(object data);
        void Insert(int index, object data);
        void Remove(object data);
        void RemoveFirst();
        void RemoveLast();
        bool Contains(object data);
    }
}