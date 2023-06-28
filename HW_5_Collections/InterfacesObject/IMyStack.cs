namespace HW_5_Collections
{
    public interface IMyStack : IMyCollection
    {
        object Peek();
        void Push(object item);
        object Pop();
        bool Contains(object item);
    }
}