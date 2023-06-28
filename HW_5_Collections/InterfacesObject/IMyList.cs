namespace HW_5_Collections
{
    public interface IMyList : IMyCollection
    {
        object this[int index] { get; set; }
        int Capacity { get; set; }
        void Add(object value);
        void Insert(int index, object value);
        void RemoveAt(int index);
        bool Remove(object value);
        int IndexOf(object value);
        void Reverse();
        bool Contains(object value);
    }
}