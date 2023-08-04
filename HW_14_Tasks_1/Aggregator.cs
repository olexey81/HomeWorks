namespace HW_14_Tasks_1
{
    public abstract class Aggregator<T, TResult> : TasksCreator<T>
    {
        public TResult Result { get; protected set; }
        protected TResult[] TasksResults { get; set; }
        protected Aggregator(int tasksNum, T[] array) : base(tasksNum, array)
        {
            TasksResults = new TResult[_numTasks];
            Array.Fill(TasksResults, default);
            Result = TasksResults[0];
        }
    }
}
