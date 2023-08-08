using System.Net;
using System.Net.Sockets;

namespace HW_16_Chat_Server
{
    class ChatClient : IDisposable
    {
        private readonly TcpClient _tcpClient;
        private readonly NetworkStream _stream;
        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;
        private Task? _process;

        public ChatClient(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
            Log("connected");

            _stream = _tcpClient.GetStream();
            _reader = new StreamReader(_stream);
            _writer = new StreamWriter(_stream);
        }

        public void Dispose()
        {
            _stream.Close();
        }

        public Task Start()
        {
            return _process = Task.Run(() =>
            {
                string? line = null;
                do
                {
                    line = _reader.ReadLine();
                    Log(line);

                    MessageRecive?.Invoke(_tcpClient.Client.RemoteEndPoint, line);

                } while (!string.IsNullOrEmpty(line));
            });
        }

        private void Log(string? message)
        {
            Console.WriteLine($"[{_tcpClient.Client.RemoteEndPoint}]: {message}");
        }

        public void SendMessage(string message)
        {
            _writer.WriteLine(message);
            _writer.Flush();
        }

        public event Action<EndPoint?, string?> MessageRecive;
    }
}
