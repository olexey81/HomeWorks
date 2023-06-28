namespace HW_5_Collections
{
    using System.Collections;

    public interface IMyCollection : IEnumerable
    {
        int Count { get; }
        object[] ToArray();
        void Clear();
    }
}