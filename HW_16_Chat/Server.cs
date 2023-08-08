using System.Net.Sockets;
using System.Net;

namespace HW_16_Chat_Server
{
    internal class Server
    {
        TcpListener listener;
        private static List<ChatClient> clients = new List<ChatClient>();

        public Server()
        {
            listener = new TcpListener(IPAddress.Any, 5002);
        }

        public async Task Start()
        {
            listener.Start();
            Console.WriteLine($"CoolChat started on: {listener.LocalEndpoint}");

            try
            {
                while (true)
                {
                    var client = new ChatClient(await listener.AcceptTcpClientAsync());
                    client.MessageRecive += Client_MessageRecive;
                    clients.Add(client);
                    client.Start();
                }
            }

            finally
            {
                listener.Stop();
            }
        }

        private static void Client_MessageRecive(EndPoint? sender, string? obj)
        {
            if (obj != null)
                clients.ForEach(c => c.SendMessage($"[{sender}]: {obj}"));
        }
    }
}
