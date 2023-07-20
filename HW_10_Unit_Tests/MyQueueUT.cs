using HW_5_Collections;
using System.Reflection;

namespace HW_10_Unit_Tests
{
    [TestClass]
    public class MyQueueUT
    {
        protected MyQueue<int> _queue;
        protected MyList<int> _items;
        
        [TestInitialize]
        public virtual void Init()
        {
            _queue = new MyQueue<int>(10);
            for (int i = 1; i < 11; i++)
                _queue.Enqueue(i);

            _items = (MyList<int>?)typeof(MyQueue<int>)
                .GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(_queue);
        }


            [TestMethod]
        public void Enqueue()              
        {
            int initCount = _queue.Count;
            _queue.Enqueue(11);

            if (_queue is MyPriorityQueue<int>)
                Assert.AreEqual(11, _items[0]);
            else
                Assert.AreEqual(11, _items[initCount]);

            Assert.IsTrue(_queue.Count > initCount);    
        }

        [TestMethod]
        public void Dequeue()              
        {
            int initCount = _queue.Count;
            _queue.Dequeue();

            if (_queue is MyPriorityQueue<int>)
                Assert.AreEqual(9, _items[0]);
            else
                Assert.AreEqual(2, _items[0]);
            Assert.IsTrue(_queue.Count < initCount);
            _queue.Clear();
            Assert.ThrowsException<InvalidOperationException>(() => _queue.Dequeue());

        }

        [TestMethod]
        public void Peek()              
        {
            int initCount = _queue.Count;
            _queue.Peek();

            Assert.AreEqual(_queue.Peek(), _items[0]);
            if (_queue is MyPriorityQueue<int>)
                Assert.AreEqual(10, _items[0]);
            else
                Assert.AreEqual(1, _items[0]);
            Assert.IsTrue(_queue.Count == initCount);    
            _queue.Clear();
            Assert.ThrowsException<InvalidOperationException>(() => _queue.Dequeue());
        }


        [TestMethod]
        public void Clear()
        {
            _queue.Clear();
            Assert.AreEqual(0, _queue.Count);
        }

        [TestMethod]
        public void Contains()
        {
            int check = 5;
            bool isContains = false;

            foreach (var item in _queue)
            {
                if (item == check)
                    isContains = true;
            }

            Assert.IsTrue(_queue.Contains(check) == isContains);
        }


        [TestMethod]
        public void ToArray()
        {
            Assert.IsInstanceOfType(_queue.ToArray(), typeof(Array));
        }
    }
}