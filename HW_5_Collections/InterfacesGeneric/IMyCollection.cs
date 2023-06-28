namespace HW_5_Collections
{
    public interface IMyCollection<T> : IEnumerable<T>
    {
        int Count { get; }
        T[] ToArray();
        void Clear();
        bool Contains(T value);
    }
}