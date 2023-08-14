using HW_16_Chat_Server;

namespace HW_16_Chat
{
    internal class Program
    {
        static async Task Main()
        {
            var server = new Server();
            await server.Start();
        }
    }
}