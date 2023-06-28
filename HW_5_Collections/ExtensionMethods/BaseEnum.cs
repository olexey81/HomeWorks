using System.Collections;
namespace HW_5_Collections
{
    public class BaseEnum<T> : IEnumerable<T>
    {
        private readonly Func<IEnumerator<T>> _creator;

        public BaseEnum(Func<IEnumerator<T>> creator)
        {
            _creator = creator;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _creator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}