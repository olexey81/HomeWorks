namespace HW_5_Collections
{
    public interface IMyStack<T> : IMyCollection<T>
    {
        T Peek();
        void Push(T item);
        T Pop();
    }
}