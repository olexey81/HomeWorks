using System.Collections;

namespace HW_5_Collections
{
    public class MyBinarySearchTree<T> : IMyBinarySearchTree<T> where T : IComparable<T>
    {
        private Node _root;
        private int _size;

        public Node Root => _root;
        public int Count => _size;

        public void Add(T value)
        {
            _root = InsertNode(_root, value);
            _size++;
        }
        private Node InsertNode(Node current, T value)
        {
            if (current == null)
                return new Node(value);

            if (value.CompareTo(current.Value) <= 0)
                current.Left = InsertNode(current.Left, value);
            else
                current.Right = InsertNode(current.Right, value);

            return current;
        }
        public bool Contains(T value) => SearchNode(_root, value) != null;
        private Node SearchNode(Node current, T value)
        {
            if (current == null || current.Value.CompareTo(value) == 0)
                return current;

            if (value.CompareTo(current.Value) <= 0)
                return SearchNode(current.Left, value);

            else
                return SearchNode(current.Right, value);
        }
        public void Clear()
        {
            _root = null;
            _size = 0;
        }
        public T[] ToArray()
        {
            MyList<T> array = new MyList<T>(_size);
            TreeInOrder(_root, array);

            return array.ToArray();
        }
        private void TreeInOrder(Node current, MyList<T> result)
        {
            if (current != null)
            {
                TreeInOrder(current.Left, result);

                result.Add(current.Value);

                TreeInOrder(current.Right, result);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        //public IEnumerator GetEnumerator()
        //{
        //    var tree = this.ToArray();
        //    for (int i = 0; i < Count; i++)
        //    {
        //        yield return tree[i];
        //    }
        //}
        public IEnumerator<T> GetEnumerator() => new BinaryTreeIterator(this);
        private class BinaryTreeIterator : IEnumerator<T>
        {
            private readonly T[] _tree;
            private int _index;
            public T Current { get; private set; }

            object IEnumerator.Current { get; }

            public BinaryTreeIterator(MyBinarySearchTree<T> tree)
            {
                _tree = tree.ToArray();
                _index = 0;
            }
            public bool MoveNext()
            {
                if (_index < _tree.Length)
                {
                    Current = _tree[_index++];
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _index = 0;
            }

            public void Dispose()
            {
            }
        }
        public class Node
        {
            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }
    }
}