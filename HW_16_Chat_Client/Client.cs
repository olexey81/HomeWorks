using System.Net.Sockets;

namespace HW_16_Chat_Client
{
    internal class Client
    {
        private readonly TcpClient _tcpClient;
        internal NetworkStream stream;
        internal string? ClientName { get; set; }

        public Client()
        {
            _tcpClient = new TcpClient(AddressFamily.InterNetwork);
            _tcpClient.Connect("192.168.50.50", 5002);
            stream = _tcpClient.GetStream();

            Console.WriteLine($"Client started on {_tcpClient.Client.LocalEndPoint}");
            Console.WriteLine("To send a private message type \"/private username\" before message");
        }
    }
}
