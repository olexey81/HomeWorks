using System.Numerics;

namespace HW_12_Threads_1
{
    internal class FindAverage<T> : FindSum<T> where T : INumber<T>
    {
        public decimal Result { get; private set; }
        public FindAverage(int threatsNum, T[] inputArray) : base(threatsNum, inputArray) { }

        public override void ThreadsWait()
        {
            base.ThreadsWait();
            Result = Convert.ToDecimal(base.Result) / _arr.Length;
        }
    }
}
