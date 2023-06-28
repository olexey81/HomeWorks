namespace HW_5_Collections
{
    public interface IMyList<T> : IMyCollection<T>
    {
        T this[int index] { get; set; }
        int Capacity { get; set; }
        void Add(T value);
        void Insert(int index, T value);
        void RemoveAt(int index);
        bool Remove(T value);
        int IndexOf(T value);
        void Reverse();
    }
}