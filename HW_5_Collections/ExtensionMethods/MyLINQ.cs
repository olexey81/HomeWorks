using System.Collections;
namespace HW_5_Collections
{
    public static class MyLINQ
    {
        //public static IEnumerable MyFilter(this IEnumerable enumerable, Predicate<object?> predicate)
        //{
        //    foreach (var item in enumerable)
        //    {
        //        if (predicate(item))
        //            yield return item;
        //    }
        //}
        public static IEnumerable MyFilter(this IEnumerable enumerable, Predicate<object?> predicate)
        {
            return new BaseEnum(() => new FilterIterator(enumerable, predicate));
        }
        class FilterIterator : IEnumerator
        {
            private readonly IEnumerator _iter;
            private readonly Predicate<object?> _predicate;

            public FilterIterator(IEnumerable enumerable, Predicate<object?> predicate)
            {
                _iter = enumerable.GetEnumerator();
                _predicate = predicate;
            }

            public object Current => _iter.Current;

            public bool MoveNext()
            {
                bool res;
                do
                {
                    res = _iter.MoveNext();
                }
                while (res && !_predicate(Current));

                return res;
            }

            public void Reset()
            {
            }
        }

        //public static IEnumerable MySkip(this IEnumerable enumerable, int numb)
        //{
        //    int count = 1;
        //    foreach (var item in enumerable)
        //    {
        //        if (count > numb)
        //            yield return item;
        //        count++;
        //    }
        //}
        public static IEnumerable MySkip(this IEnumerable enumerable, int numb)
        {
            return new BaseEnum(() => new SkipIterator(enumerable, numb));
        }
        class SkipIterator : IEnumerator
        {
            private readonly IEnumerator _iter;
            private readonly int _numb;
            private int _count = 0;
            public SkipIterator(IEnumerable enumerable, int numb)
            {
                _iter = enumerable.GetEnumerator();
                _numb = numb;
            }

            public object Current => _iter.Current;

            public bool MoveNext()
            {
                bool res;
                if (_count < _numb)
                {
                    do
                    {
                        res = _iter.MoveNext();
                        _count++;
                    }
                    while (res && _count < _numb);
                }
                res = _iter.MoveNext();
                return res;
            }

            public void Reset()
            {
            }
        }

        //public static IEnumerable MySkipWhile(this IEnumerable enumerable, Predicate<object?> predicate)
        //{
        //    foreach (var item in enumerable)
        //    {
        //        if (predicate(item))
        //            yield return item;
        //    }
        //}
        public static IEnumerable MySkipWhile(this IEnumerable enumerable, Predicate<object?> predicate)
        {
            return new BaseEnum(() => new SkipWhileIterator(enumerable, predicate));
        }
        class SkipWhileIterator : IEnumerator
        {
            private readonly IEnumerator _iter;
            private readonly Predicate<object?> _predicate;

            public SkipWhileIterator(IEnumerable enumerable, Predicate<object?> predicate)
            {
                _iter = enumerable.GetEnumerator();
                _predicate = predicate;
            }

            public object Current => _iter.Current;

            public bool MoveNext()
            {
                bool res;
                do
                {
                    res = _iter.MoveNext();
                }
                while (res && _predicate(Current));

                return res;
            }

            public void Reset()
            {
            }
        }

        //public static IEnumerable MyTake(this IEnumerable enumerable, int numb)
        //{
        //    int count = 1;
        //    foreach (var item in enumerable)
        //    {
        //        if (count <= numb)
        //            yield return item;
        //        count++;
        //    }
        //}
        public static IEnumerable MyTake(this IEnumerable enumerable, int numb)
        {
            return new BaseEnum(() => new TakeIterator(enumerable, numb));
        }
        class TakeIterator : IEnumerator
        {
            private readonly IEnumerator _iter;
            private readonly int _numb;
            private int _count = 0;
            public TakeIterator(IEnumerable enumerable, int numb)
            {
                _iter = enumerable.GetEnumerator();
                _numb = numb;
            }

            public object Current => _iter.Current;

            public bool MoveNext()
            {
                if (_count < _numb)
                {
                    _count++;
                    return _iter.MoveNext();
                }
                return false;
            }

            public void Reset()
            {
            }
        }

        //public static IEnumerable MyTakeWhile(this IEnumerable enumerable, Predicate<object?> predicate)
        //{
        //    foreach (var item in enumerable)
        //    {
        //        if (predicate(item))
        //            yield return item;
        //    }
        //}
        public static IEnumerable MyTakeWhile(this IEnumerable enumerable, Predicate<object?> predicate)
        {
            return new BaseEnum(() => new TakeWhileIterator(enumerable, predicate));
        }
        class TakeWhileIterator : IEnumerator
        {
            private readonly IEnumerator _iter;
            private readonly Predicate<object?> _predicate;

            public TakeWhileIterator(IEnumerable enumerable, Predicate<object?> predicate)
            {
                _iter = enumerable.GetEnumerator();
                _predicate = predicate;
            }

            public object Current => _iter.Current;

            public bool MoveNext()
            {
                bool res;
                do
                {
                    res = _iter.MoveNext();
                }
                while (res && !_predicate(Current));

                return res;
            }

            public void Reset()
            {
            }
        }

        public static object? MyFirst(this IEnumerable enumerable, Predicate<object?> predicate)
        {
            foreach (var item in enumerable)
            {
                if (predicate(item))
                    return item;
            }
            return null;
        }

        public static object MyFirstOrDefault(this IEnumerable enumerable, Predicate<object?> predicate, object defaultValue)
        {
            foreach (var item in enumerable)
            {
                if (predicate(item))
                    return item;
            }
            return defaultValue;

        }

        public static object? MyLast(this IEnumerable enumerable, Predicate<object?> predicate)
        {
            object last = null;

            foreach (var item in enumerable)
            {
                if (predicate(item))
                    last = item;
            }
            return last;
        }
        public static object MyLastOrDefault(this IEnumerable enumerable, Predicate<object?> predicate, object defaultValue)
        {
            object last = defaultValue;

            foreach (var item in enumerable)
            {
                if (predicate(item))
                    last = item;
            }
            return last;

        }

        //public static IEnumerable MySelect(this IEnumerable enumerable, Func<object, object> selector)
        //{
        //    foreach (var item in enumerable)
        //        yield return selector(item);
        //}
        public static IEnumerable MySelect(this IEnumerable enumerable, Func<object, object> selector)
        {
            return new BaseEnum(() => new SelectIterator(enumerable, selector));
        }
        class SelectIterator : IEnumerator
        {
            private readonly IEnumerator _iter;
            private Func<object, object> _selector;
            public SelectIterator(IEnumerable enumerable, Func<object, object> selector)
            {
                _iter = enumerable.GetEnumerator();
                _selector = selector;
            }

            public object? Current { get; private set; }

            public bool MoveNext()
            {
                while (_iter.MoveNext())
                {
                    Current = _selector(_iter.Current);
                    return true;
                }
                return false;
            }

            public void Reset()
            {
            }
        }

        public static bool MyAll(this IEnumerable enumerable, Func<object, bool> selector)
        {
            foreach (var item in enumerable)
            {
                if (!selector(item))
                    return false;
            }
            return true;
        }
        public static bool MyAny(this IEnumerable enumerable, Func<object, bool> selector)
        {
            foreach (var item in enumerable)
            {
                if (selector(item))
                    return true;
            }
            return false;
        }

        public static object[] MyToArray(this IEnumerable enumerable)
        {
            int count = 0;
            foreach (var item in enumerable)
            {
                count++;
            }
            object[] array = new object[count];
            int i = 0;
            foreach (var item in enumerable)
            {
                array[i++] = item;
            }

            return array;
        }
        public static MyList MyToList(this IEnumerable enumerable)
        {
            MyList list = new MyList();
            foreach (var item in enumerable)
            {
                list.Add(item);
            }
            return list;
        }
    }
}