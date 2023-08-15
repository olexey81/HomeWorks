using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace HW_16_Chat_Server
{
    internal class Server
    {
        private readonly TcpListener listener;
        private List<ChatClient> _clients;
        private Dictionary<string, string> _namesAndPasswords;
        private readonly object _locker = new();
        internal const int PORT = 5002;
        public Server()
        {
            listener = new TcpListener(IPAddress.Any, PORT);       
            _clients = new List<ChatClient>();                                        
            _namesAndPasswords = new Dictionary<string, string>();                    
        }

        public async Task Start()
        {
            listener.Start();                                                         
            Console.WriteLine($"LocalChat started on: {listener.LocalEndpoint}");
            var recieverUDP = new UdpReciever();
            _ = Task.Run(recieverUDP.ScanNetwork);

            try
            {
                while (true)
                {

                    Console.WriteLine("Waiting for client connection...");
                    var client = new ChatClient(await listener.AcceptTcpClientAsync());
                    Console.WriteLine($"Client on {client._endPoint} connected to server");
                    _ = Task.Run(async () =>
                    {
                        Loginer(client);                                             

                        client.MessageSent += SendMessageToClients;                  
                        await client.Start();                                        
                    });
                }
            }

            finally
            {
                listener.Stop();
            }
        }

        private void SendMessageToClients(string sender, string? recipient, string? obj) 
        {
            foreach (var cl in _clients.Where(c =>
            {
                if (recipient != "all")
                    return c.Name != sender && c.Name == recipient;
                else
                    return c.Name != sender;
            }))
            {
                cl.SendMessage($"Message from {sender} to {recipient}: {obj}");
            }
            MessagesLogger.SaveToFile(sender, recipient, obj);
            Console.WriteLine("Message logged");
        }

        private void Loginer(ChatClient client)                                         
        {
            bool approvedName;
            string clientName;
            string clientUnswer;
            string path = "../../../clients.json";

            if (File.Exists(path))
                lock (_locker)
                {
                    _namesAndPasswords = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(path));
                }

    point:  client.SendMessage("Enter 1 to register a new user, enter 2 to login:");
            clientUnswer = client.UnswerToServer();
            switch (clientUnswer)
            {
                case "1":
                    do
                    {
                        client.SendMessage("Enter login to register:");
                        clientName = client.UnswerToServer();
                        approvedName = true;

                        if (_namesAndPasswords!.ContainsKey(clientName))
                        {
                            client.SendMessage("This login is already used, please choose another login:");
                            approvedName = false;
                        }
                        else
                        {
                            client.SendMessage("Enter your new password:");
                            clientUnswer = client.UnswerToServer();
                            lock (_locker)
                            {
                                _namesAndPasswords.Add(clientName, clientUnswer);
                            }
                        }
                    } while (!approvedName);
                    break;

                case "2":
                    client.SendMessage("Enter your login:");
                    clientName = client.UnswerToServer();
                    if (_namesAndPasswords!.TryGetValue(clientName, out string? pass))
                    {
                        client.SendMessage("Enter your password:");
                        clientUnswer = client.UnswerToServer();
                        if (pass == clientUnswer)
                            break;
                        else
                        {
                            client.SendMessage("Incorrect password");
                            goto point;
                        }
                    }
                    else
                    {
                        client.SendMessage("Incorrect login");
                        goto point;
                    }

                default:
                    client.SendMessage("Incorrect enter!");
                    goto point;
            }

            client.Name = clientName;

            lock (_locker)
            {
                _clients.Add(client);
                File.WriteAllText(path, JsonSerializer.Serialize(_namesAndPasswords));
            }
            client.SendMessage($"0{clientName}");                                           
            client.SendMessage($"You joined the chat as \"{clientName}\"");
        }
    }
}
