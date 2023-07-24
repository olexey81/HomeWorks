using HW_5_Collections;

namespace HW_10_Unit_Tests
{
    [TestClass]
    public class MyObservableListUT : MyListUT
    {
        [TestInitialize]
        public override void Init()
        {
            _list = new MyObservableList<int>(10) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }
    }
}