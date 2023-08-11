namespace HW_16_Chat_Client
{
    internal class Reader
    {
        private readonly StreamReader _reader;
        private readonly Client _client;
        public Reader(Client client)
        {
            _client = client;
            _reader = new StreamReader(_client.stream);
        }

        public Task Read()
        {
            return Task.Run(() =>
            {
                string? line = null;
                do
                {
                    line = _reader.ReadLine();
                    if (line.StartsWith('0'))
                    {
                        _client.ClientName = line[1..];             
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(line);                                
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                } while (true);
            });
        }
    }
}
