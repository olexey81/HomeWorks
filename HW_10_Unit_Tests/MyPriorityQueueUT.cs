using HW_5_Collections;
using System.Reflection;

namespace HW_10_Unit_Tests
{
    [TestClass]
    public class MyPriorityQueueUT : MyQueueUT
    {
        [TestInitialize]
        public override void Init()
        {
            _queue = new MyPriorityQueue<int>();
            for (int i = 1; i < 11; i++)
                _queue.Enqueue(i);

            _items = (MyList<int>?)typeof(MyPriorityQueue<int>)
                .GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(_queue);
        }
    }
}