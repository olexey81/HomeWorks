namespace HW_5_Collections
{
    public interface IMyBinarySearchTree : IMyCollection
    {
        MyBinarySearchTree.Node Root { get; }
        void Add(int value);
        bool Contains(int value);
    }
}