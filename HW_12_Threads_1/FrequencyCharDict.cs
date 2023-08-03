namespace HW_12_Threads_1
{
    internal class FrequencyCharDict : FrequencyWordDict
    {
        public Dictionary<char, int> Result { get; protected set; }
        public FrequencyCharDict(int threatsNum, string[] array) : base(threatsNum, array)
        {
            Result = new Dictionary<char, int>();
        }

        protected override void JobItems(Span<string> span, int index, StartParameters<string> parameters)
        {
            var str = span[index];
            foreach (var ch in str)
            {
                if (!ThreadsResults[parameters.ThreadIndex].TryGetValue(ch.ToString(), out int count))
                    ThreadsResults[parameters.ThreadIndex][ch.ToString()] = 1;
                else
                    ThreadsResults[parameters.ThreadIndex][ch.ToString()] = count + 1;
            }
        }
        public override void ThreadsWait()
        {
            base.ThreadsWait();
            foreach (var kvp in base.Result)
                Result[kvp.Key[0]] = kvp.Value;
        }
    }
}
