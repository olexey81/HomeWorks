namespace HW_14_Tasks_1
{
    internal class FrequencyWordDict : Aggregator<string, Dictionary<string, int>>
    {
        public FrequencyWordDict(int tasksNum, string[] array) : base(tasksNum, array)
        {
            for (int i = 0; i < _numTasks; i++)
            {
                TasksResults[i] = new Dictionary<string, int>();
            }
            Result = new Dictionary<string, int>();
        }

        protected override void JobItems(Span<string> span, int index, int taskIndex)
        {
            var str = span[index].Split(' ', ',', '.', '?', '!', ':', ';', '"', '\'', '(', ')', '-', '`', '’', '‘');

            foreach (var word in str)
            {
                if (!TasksResults[taskIndex].TryGetValue(word, out int count))
                    TasksResults[taskIndex][word] = 1;
                else
                    TasksResults[taskIndex][word] = count + 1;
            }
        }
        public override void TasksWait()
        {
            base.TasksWait();

            foreach (var dic in TasksResults)
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
