using System.Net.Sockets;
using System.Net;
using System.Text;

namespace HW_16_Chat_Server
{
    internal class UdpReciever
    {
        private UdpClient _UdpClient;
        private int _clientPort;
        private string _clientIP;

        internal string ClientIP => _clientIP;
        internal int ClientPort => _clientPort;
        public UdpReciever()
        {
            _UdpClient = new UdpClient(5003);
        }

        public async Task ScanNetwork()
        {
            do
            {
                var input = await _UdpClient.ReceiveAsync();
                Console.WriteLine("Client asks me on UDP... ");

                Console.WriteLine(Encoding.UTF8.GetString(input.Buffer));
                Console.WriteLine($"{input.RemoteEndPoint.Address}:{input.RemoteEndPoint.Port}");


                var request = Encoding.UTF8.GetString(input.Buffer);

                if (request == "Is server")
                {
                    var unswer = Encoding.UTF8.GetBytes($"Yes. TCP port for connection: {Server.PORT}");
                    _clientPort = input.RemoteEndPoint.Port;
                    _clientIP = input.RemoteEndPoint.Address.ToString();
                    await _UdpClient.SendAsync(unswer, input.RemoteEndPoint);

                    Console.WriteLine($"Connection data sent to {_clientIP} with port {_clientPort}");
                }
            } while (true);
        }

    }
}
