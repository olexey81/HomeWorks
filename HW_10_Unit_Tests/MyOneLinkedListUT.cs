using HW_5_Collections;

namespace HW_10_Unit_Tests
{
    [TestClass]
    public class MyOneLinkedListUT
    {
        protected MyOneLinkedList<int> _list;

        [TestInitialize]
        public virtual void Init()
        {
            _list = new MyOneLinkedList<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

            [TestMethod]
        public virtual void Add()               
        {
            int initCount= _list.Count;
            _list.Add(11);

            Assert.AreEqual(11, _list.Last);
            Assert.IsTrue(_list.Count > initCount);
        }

        [TestMethod]
        public virtual void AddFirst()               
        {
            int initCount= _list.Count;
            _list.AddFirst(11);

            Assert.AreEqual(11, _list.First);
            Assert.IsTrue(_list.Count > initCount);
        }

        [TestMethod]
        public virtual void BinarySearch()
        {
            Assert.IsTrue(_list.BinarySearch(5) > 0);
            Assert.IsFalse(_list.BinarySearch(11) > 0);
        }

        [TestMethod]
        public virtual void Insert()
        {
            int initCount= _list.Count;
            bool isInserted = false;
            _list.Insert(5, 11);

            foreach (var item in _list)
            {
                if (item == 11)
                    isInserted = true;
            }
            Assert.IsTrue(isInserted);
            Assert.IsTrue(_list.Count > initCount);
            Assert.ThrowsException<IndexOutOfRangeException>(() => _list.Insert(20, 11));
        }

        [TestMethod]
        public virtual void Remove()
        {
            int initCount= _list.Count;
            bool isRemoved = true;
            _list.Remove(5);
            foreach (var item in _list)
            {
                if (item == 5)
                    isRemoved = false;
            }
            Assert.IsTrue(isRemoved);
            Assert.IsTrue(_list.Count < initCount);
        }

        [TestMethod]
        public virtual void RemoveFirst()
        {
            int initCount = _list.Count;
            _list.RemoveFirst();

            Assert.AreEqual(2, _list.First);
            Assert.IsTrue(_list.Count < initCount);
        }

        [TestMethod]
        public virtual void RemoveLast()
        {
            int initCount = _list.Count;
            _list.RemoveLast();

            Assert.AreEqual(9, _list.Last);
            Assert.IsTrue(_list.Count < initCount);
        }

        [TestMethod]
        public virtual void Clear()
        {
            _list.Clear();
            Assert.AreEqual(0, _list.Count);
            Assert.ThrowsException<NullReferenceException>(() => _list.First);
            Assert.ThrowsException<NullReferenceException>(() => _list.Last);
        }

        [TestMethod]
        public virtual void Contains()
        {
            int check = 5;
            bool isContains = false;

            foreach (var item in _list)
            {
                if (item == check)
                    isContains = true;
            }

            Assert.IsTrue(_list.Contains(check) == isContains);
        }

        [TestMethod]
        public virtual void Sort()
        {
            var listRand = new MyOneLinkedList<int>() { 4, 2, 9, 5, 10, 1, 7, 3, 6, 8 };
            listRand.Sort();
            int current = 0;

            foreach (var item in listRand)
            {
                Assert.IsTrue(item > current);
                current = item;
            }

        }

        [TestMethod]
        public virtual void ToArray()
        {
            Assert.IsInstanceOfType(_list.ToArray(), typeof(Array));
        }
    }
}