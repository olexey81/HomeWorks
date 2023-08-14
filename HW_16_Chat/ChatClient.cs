using HW_16_Chat_lib;
using System.Net;
using System.Net.Sockets;

namespace HW_16_Chat_Server
{
    class ChatClient : IDisposable
    {
        private int _messageType = -1;
        private readonly TcpClient _tcpClient;
        internal readonly EndPoint? _endPoint;
        internal readonly NetworkStream _stream;
        internal readonly StreamReader _reader;
        private readonly StreamWriter _writer;
        public event Action<string, string?, string?>? MessageSent;     

        internal string? Name { get; set; }

        public ChatClient(TcpClient tcpClient) 
        {
            _tcpClient = tcpClient;
            _endPoint = tcpClient.Client.RemoteEndPoint;

            _stream = _tcpClient.GetStream();
            _reader = new StreamReader(_stream);
            _writer = new StreamWriter(_stream);       
        }


        public Task Start()
        {
            Console.WriteLine($"Client from {_endPoint} now is \"{Name}\"");

            return Task.Run(() =>
            {
                string? line = null;
                do
                {
                    _messageType = _stream.ReadByte();

                    switch (_messageType)
                    {
                        case (int)MessageType.Common:
                            line = _reader.ReadLine();        
                            Log(line);                        
                            MessageSent?.Invoke(Name!, null, line); 
                            break;

                        case (int)MessageType.Private:
                            line = _reader.ReadLine();
                            string[] lines = line.Split(' ', 2);
                            Log(line);                          
                            MessageSent?.Invoke(Name!, lines[0], lines[1]);    

                            break;
                    }

                } while (!string.IsNullOrEmpty(line));
            });
        }

        private void Log(string? message)
        {
            if (_messageType == 3)
                Console.WriteLine($"Private message from user [{Name}]: {message}");   
            else
                Console.WriteLine($"Common message from user [{Name}]: {message}");  
        }

        public void SendMessage(string message)
        {
            _writer.WriteLine(message);                     
            _writer.Flush();
        }

        public string UnswerToServer() => _reader.ReadLine()![1..];

        public void Dispose()
        {
            _stream.Close();
            _reader.Close();
            _writer.Close();
        }
        
    }
}
