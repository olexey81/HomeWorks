using HW_16_Chat_lib;

namespace HW_16_Chat_Client
{
    internal class Writer
    {
        private readonly StreamWriter _writer;
        private readonly Client _client;
        public Writer(Client client)
        {
            _client = client;
            _writer = new StreamWriter(_client.stream);
        }

        public Task Write()
        {
            return Task.Run(() =>
            {
                do
                {
                    var line = Console.ReadLine();

                    if (line.StartsWith("/private"))
                    {
                        _client.stream.WriteByte((byte)MessageType.Private);  
                        line = line.Split(' ', 2)[1];
                    }
                    else
                    {
                        _client.stream.WriteByte((byte)MessageType.Common);
                    }

                    _writer.WriteLine(line);
                    _writer.Flush();
                }
                while (true);
            });
        }
    }
}
