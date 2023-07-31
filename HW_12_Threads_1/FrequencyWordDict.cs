namespace HW_12_Threads_1
{
    internal class FrequencyWordDict : Aggregator<string, Dictionary<string, int>>
    {
        private Dictionary<string, int>[] _dics;

        public FrequencyWordDict(int threatsNum, string[] array) : base(threatsNum, array)
        {
            _dics = new Dictionary<string, int>[threatsNum];
            for (int i = 0; i < threatsNum; i++)
            {
                _dics[i] = new Dictionary<string, int>();
            }
        }
        public override Dictionary<string, int> ThreadsWait()
        {
            foreach (var thread in _threads)
                thread.Join();
            _progressThread.Join();

            var res = new Dictionary<string, int>();
            foreach (var dic in _dics)
            {
                foreach (var kvp in dic)
                {
                    if (!dic.TryGetValue(kvp.Key, out int count))
                        res.Add(kvp.Key, count);
                    else
                        res[kvp.Key] = count + 1;

                }
            }
            return res;
        }

        protected override void JobItems(Span<string> span, int index, StartParameters<string> parameters)
        {
            var dic = _dics[parameters.ThreadIndex];

            for (int i = 0; i < span.Length; i++)
            {
                var str = span[i].Split(' ', ',', '.', '?', '!', ':', ';', '"', '\'', '(', ')', '-', '`', '’', '‘');

                foreach (var ch in str)
                {
                    if (!dic.TryGetValue(ch, out int count))
                        dic[ch] = 1;
                    else
                        dic[ch] = count + 1;
                }
            }
        }
        protected override void Progres()
        {
            _progrIteration = 100;
            base.Progres();
        }
    }
}
