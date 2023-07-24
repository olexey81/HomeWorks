using HW_5_Collections;
using System.Reflection;

namespace HW_10_Unit_Tests
{
    [TestClass]
    public class MyStackUT
    {
        private MyStack<int> _stack;
        private MyList<int> _items;

        [TestInitialize]
        public virtual void Init()
        {
            _stack = new MyStack<int>(10);
            for (int i = 1; i < 11; i++)
                _stack.Push(i);

            _items = (MyList<int>?)typeof(MyStack<int>)
                .GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(_stack);
        }

        [TestMethod]
        public void Push()              
        {
            int initCount = _stack.Count;
            _stack.Push(11);

            Assert.AreEqual(11, _items[initCount]);

            Assert.IsTrue(_stack.Count > initCount);    
        }

        [TestMethod]
        public void Pop()
        {
            int initCount = _stack.Count;
            _stack.Pop();

            Assert.AreEqual(9, _items[_items.Count - 1]);
            Assert.IsTrue(_stack.Count < initCount);
            _stack.Clear();
            Assert.ThrowsException<InvalidOperationException>(() => _stack.Pop());
        }

        [TestMethod]
        public void Peek()
        {
            int initCount = _stack.Count;
            _stack.Peek();

            Assert.AreEqual(_stack.Peek(), _items[initCount - 1]);
            Assert.AreEqual(1, _items[0]);
            Assert.IsTrue(_stack.Count == initCount);
            _stack.Clear();
            Assert.ThrowsException<InvalidOperationException>(() => _stack.Pop());
        }

        [TestMethod]
        public void Clear()
        {
            _stack.Clear();
            Assert.AreEqual(0, _stack.Count);
        }

        [TestMethod]
        public void Contains()
        {
            int check = 5;
            bool isContains = false;

            foreach (var item in _stack)
            {
                if (item == check)
                    isContains = true;
            }

            Assert.IsTrue(_stack.Contains(check) == isContains);
        }

        [TestMethod]
        public void ToArray()
        {
            Assert.IsInstanceOfType(_stack.ToArray(), typeof(Array));
        }
    }
}