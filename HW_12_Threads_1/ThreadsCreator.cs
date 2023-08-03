namespace HW_12_Threads_1
{
    public abstract class ThreadsCreator<T>
    {
        protected object locker = new();
        protected T[] _arr;
        protected int _numThreads;
        protected Thread[] _threads;

        protected Thread _abortThread;
        CancellationTokenSource _cancelTokenSource;
        protected CancellationToken _token;

        protected int[] _progressCount;
        protected int _progressIteration;

        public T[] ResultArray => _arr;

        public ThreadsCreator(int threatsNum, T[] arr)
        {
            _numThreads = threatsNum > arr.Length
                    ? arr.Length
                    : threatsNum;
            _arr = arr;
            _threads = new Thread[_numThreads];

            _cancelTokenSource = new CancellationTokenSource();
            _token = _cancelTokenSource.Token;
            _progressCount = new int[_numThreads];
            _progressIteration = _arr.Length / 10;
        }

        public virtual void ThreadsStart()
        {
            for (int i = 0; i < _numThreads; i++)
            {
                _threads[i] = new Thread(Job!) { Name = $"My thread {i}" };
            }
            _abortThread = new Thread(AbortThreads) { IsBackground = true };
            _abortThread.Start(_cancelTokenSource);

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

                _threads[i].Start(new StartParameters<T>(memSlice, i, _token));
            }
        }
        public virtual void ThreadsWait()
        {
            foreach (var thread in _threads)
                thread.Join();
        }
        protected void Job(object state)
        {
            var parameters = (StartParameters<T>)state;
            var span = parameters.MemSlice.Span;
            (int x, int y) = Console.GetCursorPosition();

            for (int i = 0; i < span.Length; i++)
            {
                JobItems(span, i, parameters);

                _progressCount[parameters.ThreadIndex]++ ;
                if (_progressCount[parameters.ThreadIndex] % _progressIteration == 0)
                {
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(x, y + parameters.ThreadIndex);
                    Console.WriteLine($"ThreadID {parameters.ThreadIndex} Progress: {_progressCount[parameters.ThreadIndex]}  of {span.Length}");
                }
                if (_progressCount[parameters.ThreadIndex] == span.Length)
                {
                    Console.SetCursorPosition(x, y + parameters.ThreadIndex);
                    Console.WriteLine($"ThreadID {parameters.ThreadIndex} Progress: {span.Length}  of {span.Length}");
                }

                if (parameters.Token.IsCancellationRequested)
                {
                    Console.WriteLine($"Thread {parameters.ThreadIndex} aborted");
                    _cancelTokenSource.Dispose();
                    return;
                }
            }
            Console.SetCursorPosition(x, y + _numThreads);
        }

        protected void AbortThreads(object state)
        {
            var cancelTokenSource = (CancellationTokenSource)state;

            while (!_token.IsCancellationRequested)
            {
                Thread.Sleep(100);
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    cancelTokenSource.Cancel();
                    break;
                }
            }
        }
        protected abstract void JobItems(Span<T> span, int index, StartParameters<T> parameters);

    }
}
