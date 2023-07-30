using Microsoft.VisualBasic;

namespace HW_12_Threads_1
{
    internal class RandomeArrCreator : ThreadsCreator<int>
    {
        private Random[] _rand;

        public RandomeArrCreator(int threatsNum, int[] inputArray)
            : base(threatsNum, inputArray)
        {
            Random seed = new Random();
            _rand = new Random[threatsNum];
            for (int i = 0; i < threatsNum; i++)
            {
                _rand[i] = new Random(seed.Next(-inputArray.Length, inputArray.Length));
            }
        }
        protected override void JobItems(Span<int> span, int index, StartParameters<int> parameters)
        {
            span[index] = _rand[parameters.ThreadIndex].Next(-ResultArray.Length, ResultArray.Length);
        }
    }
}
