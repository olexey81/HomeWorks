using System.Numerics;

namespace HW_12_Threads_1
{
    public class FindSumAndAverage<T> : Aggregator<T, double> 
        where T : INumber<T>
    {
        private readonly T[] _sum;
        public double Sum { get; private set; }
        public double Average { get; private set; }

        public FindSumAndAverage(int threatsNum, T[] inputArray) : base(threatsNum, inputArray)
        {
            _sum = new T[threatsNum];
        }

        protected override void JobItems(Span<T> span, int index, StartParameters<T> parameters)
        {
            _sum[parameters.ThreadIndex] += span[index];
        }
        public override double ThreadsWait()
        {
            foreach (var thread in _threads)
                thread.Join();


            for (int i = 0; i < _sum.Length; i++)
            {
                Sum += Convert.ToDouble(_sum[i]);
            }
            Average = Sum / _arr.Length;
            return Sum;
        }

    }
}
