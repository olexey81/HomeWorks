﻿using System.Numerics;

namespace HW_14_Tasks_1
{
    internal class FindMin<T> : Aggregator<T, T> where T : INumber<T>
    {
        public FindMin(int threatsNum, T[] inputArray) : base(threatsNum, inputArray) {}
        protected override void JobItems(Span<T> span, int index, int taskIndex)
        {
            if (TasksResults[taskIndex] > span[index])
                TasksResults[taskIndex] = span[index];
        }
        public override void TasksWait()
        {
            base.TasksWait();
            Result = TasksResults.Min();
        }
    }
}
