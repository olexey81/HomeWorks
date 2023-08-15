using System.Net.Sockets;

namespace HW_16_Chat_Client
{
    internal class Client
    {
        private readonly TcpClient _tcpClient;
        internal NetworkStream stream;
        internal string? ClientName { get; set; }

        public Client(UdpScanner serverData)
        {
            _tcpClient = new TcpClient(AddressFamily.InterNetwork);
            _tcpClient.Connect(serverData.ServerIP, serverData.ServerPort);
            stream = _tcpClient.GetStream();

            Console.WriteLine($"Client started on {_tcpClient.Client.LocalEndPoint}");
            Console.WriteLine("To send a private message type \"/private username\" before message");
        }
    }
}
