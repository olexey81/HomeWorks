using System.Collections;

namespace HW_5_Collections
{
    public class MyBinarySearchTree : IMyBinarySearchTree
    {
        private Node _root;
        private int _size;

        public Node Root => _root;
        public int Count => _size;

        public void Add(int value)
        {
            _root = InsertNode(_root, value);
            _size++;
        }
        private Node InsertNode(Node current, int value)
        {
            if (current == null)
                return new Node(value);

            if (value <= current.Value)                                 // якщо однакове - у ліву гілку
                current.Left = InsertNode(current.Left, value);
            else if (value > current.Value)
                current.Right = InsertNode(current.Right, value);

            return current;
        }
        public bool Contains(int value) => SearchNode(_root, value) != null;
        private Node SearchNode(Node current, int value)
        {
            if (current == null || current.Value == value)
                return current;

            if (value <= current.Value)
                return SearchNode(current.Left, value);
            else
                return SearchNode(current.Right, value);
        }
        public void Clear()
        {
            _root = null;
            _size = 0;
        }
        public object[] ToArray()
        {
            var array = new MyList(_size);
            TreeInOrder(_root, array);

            return array.ToArray();
        }
        private void TreeInOrder(Node current, MyList result)
        {
            if (current != null)
            {
                TreeInOrder(current.Left, result);

                result.Add(current.Value);

                TreeInOrder(current.Right, result);
            }
        }
        //public IEnumerator GetEnumerator()
        //{
        //    var tree = this.ToArray();
        //    for (int i = 0; i < Count; i++)
        //    {
        //        yield return tree[i];
        //    }
        //}
        public IEnumerator GetEnumerator() => new BinaryTreeIterator(this);
        private class BinaryTreeIterator : IEnumerator
        {
            private readonly object[] _tree;
            private int _index;
            public object? Current { get; private set; }

            public BinaryTreeIterator(MyBinarySearchTree tree)
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
            }
        }
        public class Node
        {
            public int Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }
    }
}