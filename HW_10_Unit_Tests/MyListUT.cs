using HW_5_Collections;

namespace HW_10_Unit_Tests
{
    [TestClass]
    public class MyListUT
    {
        protected MyList<int> _list;

        [TestInitialize]
        public virtual void Init()
        {
            _list = new MyList<int>(10) {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        [TestMethod]
        public void Add()               
        {
            int initCapacity = _list.Capacity;
            int initCount = _list.Count;
            _list.Add(11);

            Assert.AreEqual(11, _list[initCount]);
            Assert.IsTrue(_list.Capacity > initCapacity && _list.Count > initCount);    
        }

        [TestMethod]
        public void BinarySearch()
        {
            Assert.IsTrue(_list.BinarySearch(5) > 0);
            Assert.IsFalse(_list.BinarySearch(11) > 0);
        }

        [TestMethod]
        public void Insert()
        {
            int initCount = _list.Count;
            bool isInserted = false;
            _list.Insert(9, 11);

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
        public void Remove()
        {
            int initCount = _list.Count;
            bool isRemoved = true;
            _list.Remove(5);
            foreach (var item in _list)
            {
                if (item == 5)
                    isRemoved = false;
            }
            Assert.IsTrue(isRemoved);
            Assert.IsTrue(_list.Count < initCount);    
            Assert.IsFalse(_list.Remove(11));
        }

        [TestMethod]
        public void RemoveAt()
        {
            int initCount = _list.Count;
            bool isRemoved = true;
            _list.RemoveAt(8);

            foreach (var item in _list)
            {
                if (item == 9)
                    isRemoved = false;
            }

            Assert.IsTrue(isRemoved);
            Assert.IsTrue(_list.Count < initCount);    
            Assert.ThrowsException<IndexOutOfRangeException>(() => _list.RemoveAt(20));
        }

        [TestMethod]
        public void Clear()
        {
            _list.Clear();
            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void Contains()
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
        public void IndexOf()
        {
            int check = 5;
            int index = -1;
            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i] == check)
                    index = i;
            }

            Assert.IsTrue(_list.IndexOf(check) == index);
        }

        [TestMethod]
        public void Reverse()
        {
            _list.Reverse();

            for (int i = 0; i < _list.Count; i++)
                Assert.AreEqual(_list.Count - i, _list[i]);
        }

        [TestMethod]
        public void Sort()
        {
            var listRand = new MyList<int>(10) { 4, 2, 9, 5, 10, 1, 7, 3, 6, 8 };
            listRand.Sort();

            for (int i = 0; i < listRand.Count - 1; i++)
                Assert.IsTrue(listRand[i] < listRand[i + 1]);
        }

        [TestMethod]
        public void ToArray()
        {
            Assert.IsInstanceOfType(_list.ToArray(), typeof(Array));
        }

        [TestMethod]
        public void IsString()
        {
            Assert.IsInstanceOfType(_list.ToString(), typeof(string));
        }
    }
}