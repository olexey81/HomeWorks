
using System.Collections;
namespace HW_5_Collections
{
    public static class MyLINQGeneric
    {
        //public static IEnumerable<T> MyFilter<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        //{
        //    foreach (var item in enumerable)
        //    {
        //        if (predicate(item))
        //            yield return item;
        //    }
        //}
        public static IEnumerable<T> MyFilter<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        {
            return new BaseEnum<T>(() => new FilterIterator<T>(enumerable, predicate));
        }
        class FilterIterator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> _iter;
            private readonly Predicate<T> _predicate;

            public FilterIterator(IEnumerable<T> enumerable, Predicate<T> predicate)
            {
                _iter = enumerable.GetEnumerator();
                _predicate = predicate;
            }

            public T Current => _iter.Current;

            object IEnumerator.Current => Current;

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

            public void Dispose()
            {
            }
        }

        //public static IEnumerable<T> MySkip<T>(this IEnumerable<T> enumerable, int numb)
        //{
        //    int count = 1;
        //    foreach (var item in enumerable)
        //    {
        //        if (count > numb)
        //            yield return item;
        //        count++;
        //    }
        //}
        public static IEnumerable<T> MySkip<T>(this IEnumerable<T> enumerable, int numb)
        {
            return new BaseEnum<T>(() => new SkipIterator<T>(enumerable, numb));
        }
        class SkipIterator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> _iter;
            private readonly int _numb;
            private int _count = 0;
            public SkipIterator(IEnumerable<T> enumerable, int numb)
            {
                _iter = enumerable.GetEnumerator();
                _numb = numb;
            }

            public T Current => _iter.Current;

            object IEnumerator.Current => Current;

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
            public void Dispose()
            {
            }
        }

        //public static IEnumerable<T> MySkipWhile<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        //{
        //    foreach (var item in enumerable)
        //    {
        //        if (predicate(item))
        //            yield return item;
        //    }
        //}
        public static IEnumerable<T> MySkipWhile<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        {
            return new BaseEnum<T>(() => new SkipWhileIterator<T>(enumerable, predicate));
        }
        class SkipWhileIterator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> _iter;
            private readonly Predicate<T> _predicate;

            public SkipWhileIterator(IEnumerable<T> enumerable, Predicate<T> predicate)
            {
                _iter = enumerable.GetEnumerator();
                _predicate = predicate;
            }

            public T Current => _iter.Current;

            object IEnumerator.Current => Current;

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
            public void Dispose()
            {
            }
        }

        //public static IEnumerable<T> MyTake<T>(this IEnumerable<T> enumerable, int numb)
        //{
        //    int count = 1;
        //    foreach (var item in enumerable)
        //    {
        //        if (count <= numb)
        //            yield return item;
        //        count++;
        //    }
        //}
        public static IEnumerable<T> MyTake<T>(this IEnumerable<T> enumerable, int numb)
        {
            return new BaseEnum<T>(() => new TakeIterator<T>(enumerable, numb));
        }
        class TakeIterator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> _iter;
            private readonly int _numb;
            private int _count = 0;
            public TakeIterator(IEnumerable<T> enumerable, int numb)
            {
                _iter = enumerable.GetEnumerator();
                _numb = numb;
            }

            public T Current => _iter.Current;
            object IEnumerator.Current => Current;

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
            public void Dispose()
            {
            }

        }

        //public static IEnumerable<T> MyTakeWhile<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        //{
        //    foreach (var item in enumerable)
        //    {
        //        if (predicate(item))
        //            yield return item;
        //    }
        //}
        public static IEnumerable<T> MyTakeWhile<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        {
            return new BaseEnum<T>(() => new TakeWhileIterator<T>(enumerable, predicate));
        }
        class TakeWhileIterator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> _iter;
            private readonly Predicate<T> _predicate;

            public TakeWhileIterator(IEnumerable<T> enumerable, Predicate<T> predicate)
            {
                _iter = enumerable.GetEnumerator();
                _predicate = predicate;
            }

            public T Current => _iter.Current;
            object IEnumerator.Current => Current;

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
            public void Dispose()
            {
            }
        }

        public static T MyFirst<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        {
            foreach (var item in enumerable)
            {
                if (predicate(item))
                    return item;
            }
            return default;
        }
        public static T MyFirstOrDefault<T>(this IEnumerable<T> enumerable, Predicate<T> predicate, T defaultValue)
        {
            foreach (var item in enumerable)
            {
                if (predicate(item))
                    return item;
            }
            return defaultValue;

        }

        public static T MyLast<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
        {
            T last = default;

            foreach (var item in enumerable)
            {
                if (predicate(item))
                    last = item;
            }
            return last;
        }
        public static T MyLastOrDefault<T>(this IEnumerable<T> enumerable, Predicate<T> predicate, T defaultValue)
        {
            T last = defaultValue;

            foreach (var item in enumerable)
            {
                if (predicate(item))
                    last = item;
            }
            return last;

        }

        //public static IEnumerable<TRes> MySelect<TItem, TRes>(this IEnumerable<TItem> enumerable, Func<TItem, TRes> selector)
        //{
        //    foreach (var item in enumerable)
        //        yield return selector(item);
        //}
        public static IEnumerable<TRes> MySelect<TItem, TRes>(this IEnumerable<TItem> enumerable, Func<TItem, TRes> selector)
        {
            return new BaseEnum<TRes>(() => new SelectIterator<TItem, TRes>(enumerable, selector));
        }
        class SelectIterator<TItem, TRes> : IEnumerator<TRes>
        {
            private readonly IEnumerator<TItem> _iter;
            private Func<TItem, TRes> _selector;
            public SelectIterator(IEnumerable<TItem> enumerable, Func<TItem, TRes> selector)
            {
                _iter = enumerable.GetEnumerator();
                _selector = selector;
            }

            public TRes Current { get; private set; }
            object IEnumerator.Current => Current;

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
            public void Dispose()
            {
            }
        }

        public static bool MyAll<T>(this IEnumerable<T> enumerable, Func<T, bool> selector)
        {
            foreach (var item in enumerable)
            {
                if (!selector(item))
                    return false;
            }
            return true;
        }
        public static bool MyAny<T>(this IEnumerable<T> enumerable, Func<T, bool> selector)
        {
            foreach (var item in enumerable)
            {
                if (selector(item))
                    return true;
            }
            return false;
        }

        public static T[] MyToArray<T>(this IEnumerable<T> enumerable)
        {
            int count = 0;
            foreach (var item in enumerable)
            {
                count++;
            }
            T[] array = new T[count];
            int i = 0;
            foreach (var item in enumerable)
            {
                array[i++] = item;
            }

            return array;
        }
        public static MyList<T> MyToList<T>(this IEnumerable<T> enumerable)
        {
            MyList<T> list = new MyList<T>();
            foreach (var item in enumerable)
            {
                list.Add(item);
            }
            return list;
        }
    }
}