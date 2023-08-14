namespace HW_16_Chat_Client
{
    internal class Program
    {
        static async Task Main()
        {

            Client newClient = new();
            Task read = new Reader(newClient).Read();
            Task write = new Writer(newClient).Write();

            Task.WaitAll(read, write);
        }
    }
}