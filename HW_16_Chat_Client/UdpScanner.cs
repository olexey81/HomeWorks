using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HW_16_Chat_Client
{
    internal class UdpScanner
    {
        private UdpClient _UdpClient;
        private int _serverPort;
        private string _serverIP;
        CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        internal string ServerIP => _serverIP;
        internal int ServerPort => _serverPort;

        public UdpScanner()
        {
            _UdpClient = new UdpClient();
        }

        public async Task ScanNetwork(CancellationToken cancellationToken = default)
        {
            do
            {
                var message = Encoding.UTF8.GetBytes("Is server");
                await _UdpClient.SendAsync(message, new IPEndPoint(IPAddress.Broadcast, 5003));
                Console.WriteLine("Waiting for any local servers...");

                var input = await _UdpClient.ReceiveAsync();
                var unswer = Encoding.UTF8.GetString(input.Buffer);

                if (unswer.StartsWith("Yes"))
                {
                    _serverPort = Convert.ToUInt16(unswer.Substring(unswer.IndexOf(":") + 1).Trim());
                    _serverIP = input.RemoteEndPoint.Address.ToString();

                    Console.WriteLine($"A server was found on {_serverIP} with port {_serverPort}");
                    break;
                }
            } while (true);
        }
    }
}
