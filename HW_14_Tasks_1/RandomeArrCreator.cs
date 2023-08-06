namespace HW_14_Tasks_1
{
    internal class RandomeArrCreator : TasksCreator<int>
    {
        private Random[] _rand;

        public RandomeArrCreator(int tasksNum, int[] inputArray) : base(tasksNum, inputArray)
        {
            Random seed = new Random();
            _rand = new Random[_numTasks];
            for (int i = 0; i < _numTasks; i++)
                _rand[i] = new Random(seed.Next(-inputArray.Length, inputArray.Length));
        }
        protected override void JobItems(Span<int> span, int index, int taskIndex)
        {
            span[index] = _rand[taskIndex].Next(-ResultArray.Length, ResultArray.Length);
        }
    }
}
