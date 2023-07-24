using HW_5_Collections;

namespace HW_10_Unit_Tests
{
    [TestClass]
    public class MyBinarySearchTreeUT
    {
        private MyBinarySearchTree<int> _tree;

        [TestInitialize]
        public void Init()
        {
            _tree = new MyBinarySearchTree<int>() { 55, 33, 77 };
        }

            [TestMethod]
        public void Add()               
        {
            int initCount = _tree.Count;
            _tree.Add(22);
            Assert.AreEqual(22, _tree.Root.Left.Left.Value);
            _tree.Add(44);
            Assert.AreEqual(44, _tree.Root.Left.Right.Value);
            _tree.Add(66);
            Assert.AreEqual(66, _tree.Root.Right.Left.Value);

            Assert.IsTrue(_tree.Count > initCount);    
        }

        [TestMethod]
        public void Clear()
        {
            _tree.Clear();
            Assert.AreEqual(0, _tree.Count);
            Assert.AreEqual(null, _tree.Root);
        }

        [TestMethod]
        public void Contains()
        {
            int check = 55;
            bool isContains = false;

            foreach (var item in _tree)
            {
                if (item == check)
                    isContains = true;
            }

            Assert.IsTrue(_tree.Contains(check) == isContains);
        }

        [TestMethod]
        public void ToArray()
        {
            Assert.IsInstanceOfType(_tree.ToArray(), typeof(Array));
        }
    }
}