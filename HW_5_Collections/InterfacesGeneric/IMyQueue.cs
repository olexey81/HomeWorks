namespace HW_5_Collections
{
    public interface IMyQueue<T> : IMyCollection<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}