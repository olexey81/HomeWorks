namespace HW_12_Threads_1
{
    internal class PartlyArray<T> : ThreadsCreator<T>
    {
        public T[] PartOfArray { get; private set; }
        public PartlyArray(int threatsNum, T[] inputArray, int startIndex, int length) : base(threatsNum, inputArray.AsMemory(startIndex,length).ToArray())
        {
            if (startIndex > inputArray.Length - 1 || startIndex < 0 || inputArray.Length - startIndex < length || length < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            PartOfArray = new T[length];
            _progressIteration = PartOfArray.Length / 10;
        }

        protected override void JobItems(Span<T> span, int index, StartParameters<T> parameters)
        {
            int realIndex;
            if (parameters.ThreadIndex == 0)
                realIndex = index;
            else
            {
                realIndex = index + (PartOfArray.Length / _numThreads) * parameters.ThreadIndex;
            }
            PartOfArray[realIndex] = span[index];
        }
    }
}
