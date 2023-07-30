namespace HW_12_Threads_1
{
    internal class FuncArrCreator : ThreadsCreator<double>
    {

        public FuncArrCreator(int threatsNum, double[] inputArray) : base(threatsNum, inputArray)

        {
        }

        protected override void JobItems(Span<double> span, int index, StartParameters<double> parameters)
        {
            int realIndex;
            if (parameters.ThreadIndex == 0)
                realIndex = index;
            else
            {
                realIndex = index + (_arr.Length / _numThreads) * parameters.ThreadIndex;
            }

            span[index] = realIndex * realIndex - 10 * Math.Sqrt(realIndex);
        }

    }
}
