
namespace HW_12_Threads_1
{
    public abstract class Aggregator<T, TResult> : ThreadsCreator<T>
    {
        public TResult Result { get; protected set; }
        public TResult[] ThreadsResults { get; protected set; }
        protected Aggregator(int threatsNum, T[] array) : base(threatsNum, array)
        {
            ThreadsResults = new TResult[_numThreads];
            Array.Fill(ThreadsResults, default);
            Result = ThreadsResults[0];
        }
    }
}
