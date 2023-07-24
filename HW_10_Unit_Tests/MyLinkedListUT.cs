using HW_5_Collections;

namespace HW_10_Unit_Tests
{
    [TestClass]
    public class MyLinkedListUT : MyOneLinkedListUT  
    {
        [TestInitialize]
        public override void Init()
        {
            _list = new MyLinkedList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

    }
}