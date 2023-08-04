namespace HW_14_Tasks_1
{
    internal class PartlyArray<T> : TasksCreator<T>
    {
        public T[] PartOfArray { get; private set; }
        public PartlyArray(int tasksNum, T[] inputArray, int startIndex, int length) : base(tasksNum, inputArray.AsMemory(startIndex,length).ToArray())
        {
            if (startIndex > inputArray.Length - 1 || startIndex < 0 || inputArray.Length - startIndex < length || length < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            PartOfArray = new T[length];
        }

        protected override void JobItems(Span<T> span, int index, int taskIndex)
        {
            int realIndex;
            if (taskIndex == 0)
                realIndex = index;
            else
            {
                realIndex = index + (PartOfArray.Length / _numTasks) * taskIndex;
            }
            PartOfArray[realIndex] = span[index];
        }
    }
}
