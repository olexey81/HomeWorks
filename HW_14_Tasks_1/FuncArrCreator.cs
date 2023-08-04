namespace HW_14_Tasks_1
{
    internal class FuncArrCreator : TasksCreator<double>
    {

        public FuncArrCreator(int tasksNum, double[] inputArray) : base(tasksNum, inputArray) {}

        protected override void JobItems(Span<double> span, int index, int taskIndex)
        {
            int realIndex;
            if (taskIndex == 0)
                realIndex = index;
            else
                realIndex = index + (_arr.Length / _numTasks) * taskIndex;

            span[index] = realIndex * realIndex - 10 * Math.Sqrt(realIndex);
        }

    }
}
