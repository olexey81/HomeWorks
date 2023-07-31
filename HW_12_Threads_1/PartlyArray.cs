namespace HW_12_Threads_1
{
    internal class PartlyArray<T> : ThreadsCreator<T>
    {
        private readonly T[] _partArr;
        private readonly int _startIndex;
        private readonly int _length;
        public T[] PartOfArray => _partArr;
        public PartlyArray(int threatsNum, T[] inputArray, int startIndex, int length) : base(threatsNum, inputArray)
        {
            if (startIndex > inputArray.Length - 1 || startIndex < 0 || inputArray.Length - startIndex < length || length < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            _partArr = new T[length];
            _startIndex = startIndex;
            _length = length;
        }


        public override void ThreadsStart()
        {

            for (int i = 0; i < _numThreads; i++)
            {
                _threads[i] = new Thread(Job!) {Name = $"My thread {i}" };
            }
            _progressThread = new Thread(Progres) { Name = "Progress" };
            _progressThread.Start();

            _abortThread = new Thread(AbortThreads);
            _abortThread.Start();

            var arrMemory = _arr.AsMemory();

            int treadSlice = _length / _numThreads;
            int remain = _length - (_length / _numThreads) * _numThreads;
            for (int i = 0; i < _numThreads; i++)
            {
                Memory<T> memSlice;
                if (i != _numThreads - 1)
                    memSlice = arrMemory.Slice(i * treadSlice + _startIndex, treadSlice);
                else
                    memSlice = arrMemory.Slice(i * treadSlice + _startIndex, treadSlice + remain);

                _threads[i].Start(new StartParameters<T>(memSlice, i));
            }
        }

        protected override void JobItems(Span<T> span, int index, StartParameters<T> parameters)
        {
            int realIndex;
            if (parameters.ThreadIndex == 0)
                realIndex = index;
            else
            {
                realIndex = index + (_length / _numThreads) * parameters.ThreadIndex;
            }
            _partArr[realIndex] = span[index];

        }

        protected override void Progres()
        {
            _progrMaxValue = _length;
            _progrIteration = _progrMaxValue / 50;
            base.Progres();
        }
    }
}
