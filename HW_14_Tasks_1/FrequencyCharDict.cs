namespace HW_14_Tasks_1
{
    internal class FrequencyCharDict : FrequencyWordDict
    {
        public Dictionary<char, int> Result { get; protected set; }
        public FrequencyCharDict(int threatsNum, string[] array) : base(threatsNum, array)
        {
            Result = new Dictionary<char, int>();
        }

        protected override void JobItems(Span<string> span, int index, int taskIndex)
        {
            var str = span[index];
            foreach (var ch in str)
            {
                if (!TasksResults[taskIndex].TryGetValue(ch.ToString(), out int count))
                    TasksResults[taskIndex][ch.ToString()] = 1;
                else
                    TasksResults[taskIndex][ch.ToString()] = count + 1;
            }
        }
        public override void TasksWait()
        {
            base.TasksWait();
            foreach (var kvp in base.Result)
                Result[kvp.Key[0]] = kvp.Value;
        }
    }
}
