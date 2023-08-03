using System.Numerics;

namespace HW_12_Threads_1
{
    internal class FindMax<T> : Aggregator<T, T> where T : INumber<T> 
    {
        public FindMax(int threatsNum, T[] inputArray) : base(threatsNum, inputArray) {}
        protected override void JobItems(Span<T> span, int index, StartParameters<T> parameters)
        {
            if (ThreadsResults[parameters.ThreadIndex] < span[index])
                ThreadsResults[parameters.ThreadIndex] = span[index];
        }
        public override void ThreadsWait()
        {
            base.ThreadsWait();
            Result = ThreadsResults.Max();
        }
    }
}
