
using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Reflection;

namespace HW_12_Threads_1
{
    public abstract class ThreadsCreator<T>
    {
        protected readonly int _numThreads;
        protected readonly T[] _arr;
        protected Thread[] _threads;
        protected Thread _progressThread;
        protected Thread _abortThread;
        protected int _progrCount = 0;
        protected int _progrIteration;
        protected int _progrMaxValue;
        protected bool _stopFlag = false;


        public T[] ResultArray => _arr;

        public ThreadsCreator(int threatsNum, T[] arr)
        {
            _numThreads = threatsNum > arr.Length
                    ? arr.Length
                    : threatsNum;
            _arr = arr;
            _threads = new Thread[_numThreads];
            _progrMaxValue = _arr.Length;
            _progrIteration = _progrMaxValue / 20;
        }

        public virtual void ThreadsStart()
        {
            for (int i = 0; i < _numThreads; i++)
            {
                _threads[i] = new Thread(Job!) { Name = $"My thread {i}" };
            }

            _progressThread = new Thread(Progres) { Name = "Progress" };
            _progressThread.Start();

            _abortThread = new Thread(AbortThreads);
            _abortThread.Start();

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
            _progressThread.Join();
            _abortThread.Join();

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
                Interlocked.Increment(ref _progrCount);
                if (_stopFlag)
                    Environment.Exit(0);
            }
        }
        protected virtual void Progres()
        {
            (int x, int y) = Console.GetCursorPosition();
            while (_progrCount != _progrMaxValue)
            {
                if (_progrCount % _progrIteration == 0)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine($"Progress: {_progrCount}  of {_progrMaxValue}");
                }
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine($"Progress: {_progrMaxValue}  of {_progrMaxValue}");
        }

        protected void AbortThreads()
        {
            while (!_stopFlag && _progrCount != _progrMaxValue)
            {
                if (Console.KeyAvailable)
                {

                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                        _stopFlag = true;
                }
            }
        }


        protected virtual void JobItems(Span<T> span, int index, StartParameters<T> parameters)
        {
        }

    }
}
