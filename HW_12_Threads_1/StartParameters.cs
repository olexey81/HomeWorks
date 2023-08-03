
namespace HW_12_Threads_1
{
    public class StartParameters<T>
    {
        public int ThreadIndex { get; init; }
        public Memory<T> MemSlice { get; init; }
        public CancellationToken Token { get; init; }
        public StartParameters(Memory<T> memSlice, int threadNum, CancellationToken token)
        {
            MemSlice = memSlice;  
            ThreadIndex = threadNum;
            Token = token;
        }
    }
}
