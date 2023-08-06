using System;
using System.Threading.Tasks;

namespace HW_14_Tasks_1
{
    public abstract class TasksCreator<T>
    {
        protected T[] _arr;
        protected int _numTasks;
        protected Task[] _tasks;

        protected Task _abortTasks;
        CancellationTokenSource _cancelTokenSource;

        protected int[] _progressCount;
        protected int _progressIteration;

        public T[] ResultArray => _arr;

        public TasksCreator(int tasksNum, T[] arr)
        {
            _numTasks = tasksNum > arr.Length
                    ? arr.Length
                    : tasksNum;
            _arr = arr;
            _tasks = new Task[_numTasks];

            _cancelTokenSource = new CancellationTokenSource();
            _progressCount = new int[_numTasks];
        }

        public virtual void TasksStart()
        {
            _abortTasks = new Task(() => AbortTasks(_cancelTokenSource));
            _abortTasks.Start();

            var arrMemory = _arr.AsMemory();

            int treadSlice = _arr.Length / _numTasks;
            int remain = _arr.Length - (_arr.Length / _numTasks) * _numTasks;
            _progressIteration = treadSlice / 10 > 0 
                ? treadSlice / 10
                : 1 ;

            for (int i = 0; i < _numTasks; i++)
            {
                Memory<T> memSlice;
                if (i != _numTasks - 1)
                    memSlice = arrMemory.Slice(i * treadSlice, treadSlice);
                else
                    memSlice = arrMemory.Slice(i * treadSlice, treadSlice + remain);
                int taskIndex = i;
                _tasks[i] = Task.Factory.StartNew(() => Job(memSlice, taskIndex), _cancelTokenSource.Token) ;
            }
        }
        public virtual void TasksWait()
        {
            Task.WaitAll(_tasks);
        }
        protected void Job(Memory<T> memSlice, int taskIndex)
        {
            var span = memSlice.Span;
            (int x, int y) = Console.GetCursorPosition();

            for (int i = 0; i < span.Length; i++)
            {
                if (_cancelTokenSource.Token.IsCancellationRequested)
                {
                    Console.Clear();
                    Console.WriteLine($"All threads are aborted");
                    _cancelTokenSource.Dispose();
                    return;
                }

                JobItems(span, i, taskIndex);

                ProgressVisulizator(taskIndex, span, x, y);

            }
            Console.SetCursorPosition(0, y + _numTasks);
        }

        protected void AbortTasks(CancellationTokenSource cancelTokenSource)
        {
            while (!_cancelTokenSource.Token.IsCancellationRequested)
            {
                Thread.Sleep(200);
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    cancelTokenSource.Cancel();
                    break;
                }
            }
        }
        protected abstract void JobItems(Span<T> span, int index, int taskIndex);

        private void ProgressVisulizator(int taskIndex, Span<T> span, int x, int y)
        {
            _progressCount[taskIndex]++;

            if (_progressCount[taskIndex] % _progressIteration == 0)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y + taskIndex);

                Console.WriteLine($"ThreadID {taskIndex} Progress: {_progressCount[taskIndex]}  of {span.Length}");
            }
            if (_progressCount[taskIndex] == span.Length)
            {
                Console.SetCursorPosition(x, y + taskIndex);
                Console.WriteLine($"ThreadID {taskIndex} Progress: {span.Length}  of {span.Length}");
            }
        }
    }
}
