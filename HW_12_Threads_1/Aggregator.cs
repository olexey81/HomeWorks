namespace HW_12_Threads_1
{
    public abstract class Aggregator<T, TResult> : ThreadsCreator<T>
    {
        protected Aggregator(int threatsNum, T[] array) : base(threatsNum, array)
        {
        }

        public new abstract TResult ThreadsWait();
    }
}
