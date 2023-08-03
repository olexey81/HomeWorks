namespace HW_12_Threads_1
{
    internal class FrequencyWordDict : Aggregator<string, Dictionary<string, int>>
    {
        public FrequencyWordDict(int threatsNum, string[] array) : base(threatsNum, array)
        {
            for (int i = 0; i < _numThreads; i++)
            {
                ThreadsResults[i] = new Dictionary<string, int>();
            }
            Result = new Dictionary<string, int>();
        }

        protected override void JobItems(Span<string> span, int index, StartParameters<string> parameters)
        {
            var str = span[index].Split(' ', ',', '.', '?', '!', ':', ';', '"', '\'', '(', ')', '-', '`', '’', '‘');

            foreach (var word in str)
            {
                if (!ThreadsResults[parameters.ThreadIndex].TryGetValue(word, out int count))
                    ThreadsResults[parameters.ThreadIndex][word] = 1;
                else
                    ThreadsResults[parameters.ThreadIndex][word] = count + 1;
            }
        }
        public override void ThreadsWait()
        {
            base.ThreadsWait();

            foreach (var dic in ThreadsResults)
            {
                foreach (var kvp in dic)
                {
                    if (!Result.TryGetValue(kvp.Key, out int count))
                        Result.Add(kvp.Key, kvp.Value);
                    else
                        Result[kvp.Key] = count + kvp.Value;
                }
            }
        }
    }
}
