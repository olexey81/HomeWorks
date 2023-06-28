namespace HW_5_Collections
{
    public interface IMyQueue : IMyCollection
    {
        void Enqueue(object item);
        object Dequeue();
        object Peek();
        bool Contains(object item);

    }
}