using System.Numerics;

namespace HW_12_Threads_1
{
    public class FindSum<T> : Aggregator<T, T> where T : INumber<T>
    {
        public FindSum(int threatsNum, T[] inputArray) : base(threatsNum, inputArray) {}

        protected override void JobItems(Span<T> span, int index, StartParameters<T> parameters)
        {
            ThreadsResults[parameters.ThreadIndex] += span[index];
        }
        public override void ThreadsWait()
        {
            base.ThreadsWait();
            for (int i = 0; i < ThreadsResults.Length; i++)
                Result += ThreadsResults[i];
        }
    }
}
