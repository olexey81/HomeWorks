using System.Numerics;

namespace HW_14_Tasks_1
{
    public class FindSum<T> : Aggregator<T, decimal> where T : INumber<T>
    {
        public FindSum(int tasksNum, T[] inputArray) : base(tasksNum, inputArray) {}

        protected override void JobItems(Span<T> span, int index, int taskIndex)
        {
            TasksResults[taskIndex] += Convert.ToDecimal(span[index]);
        }
        public override void TasksWait()
        {
            base.TasksWait();
            for (int i = 0; i < TasksResults.Length; i++)
                Result += TasksResults[i];
        }
    }
}
