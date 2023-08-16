namespace HW_16_Chat_Client
{
    internal class Program
    {
        static async Task Main()
        {
            var serverData = new UdpScanner();
            await serverData.ScanNetwork();
            Client newClient = new Client(serverData);
            Task read = new Reader(newClient).Read();
            Task write = new Writer(newClient).Write();

            Task.WaitAll(read, write);
        }
    }
}