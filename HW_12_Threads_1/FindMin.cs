﻿using System.Numerics;

namespace HW_12_Threads_1
{
    internal class FindMin<T> : Aggregator<T, T> where T : INumber<T>
    {
        public FindMin(int threatsNum, T[] inputArray) : base(threatsNum, inputArray) {}
        protected override void JobItems(Span<T> span, int index, StartParameters<T> parameters)
        {
            if (ThreadsResults[parameters.ThreadIndex] > span[index])
                ThreadsResults[parameters.ThreadIndex] = span[index];
        }
        public override void ThreadsWait()
        {
            base.ThreadsWait();
            Result = ThreadsResults.Min();
        }
    }
}
