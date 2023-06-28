using System.Collections;
namespace HW_5_Collections
{
    public class BaseEnum : IEnumerable
    {
        private readonly Func<IEnumerator> _creator;

        public BaseEnum(Func<IEnumerator> creator)
        {
            _creator = creator;
        }

        public IEnumerator GetEnumerator()
        {
            return _creator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}