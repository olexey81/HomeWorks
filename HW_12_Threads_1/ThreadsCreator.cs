
namespace HW_12_Threads_1
{
    public abstract class ThreadsCreator<T>
    {
        protected readonly int _numThreads;
        protected readonly T[] _arr;
        protected Thread[] _threads;

        public T[] ResultArray => _arr;

        public ThreadsCreator(int threatsNum, T[] arr)
        {
            _numThreads = threatsNum > arr.Length
                    ? arr.Length
                    : threatsNum;
            _arr = arr;
            _threads = new Thread[_numThreads];
        }

        public virtual void ThreadsStart()
        {
            for (int i = 0; i < _numThreads; i++)
            {
                _threads[i] = new Thread(Job!) { Name = $"My thread {i}" };
            }

            var arrMemory = _arr.AsMemory();

            int treadSlice = _arr.Length / _numThreads;
            int remain = _arr.Length - (_arr.Length / _numThreads) * _numThreads;
            for (int i = 0; i < _numThreads; i++)
            {
                Memory<T> memSlice;
                if (i != _numThreads - 1)
                    memSlice = arrMemory.Slice(i * treadSlice, treadSlice);
                else
                    memSlice = arrMemory.Slice(i * treadSlice, treadSlice + remain);

                _threads[i].Start(new StartParameters<T>(memSlice, i));
            }
        }
        public virtual void ThreadsWait()
        {
            foreach (var thread in _threads)
                thread.Join();
        }
        protected void Job(object state)
        {
            //work
            var parameters = (StartParameters<T>)state;
            var span = parameters.MemSlice.Span;
            for (int i = 0; i < span.Length; i++)
            {
                JobItems(span, i, parameters);
            }

        }

        protected virtual void JobItems(Span<T> span, int index, StartParameters<T> parameters) { }

    }
}
