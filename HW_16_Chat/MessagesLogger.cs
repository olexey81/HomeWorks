namespace HW_16_Chat_Server
{
    internal class MessagesLogger
    {
        private const string _path = "../../../History.txt";

        internal static void SaveToFile(string sender, string? recipient, string? obj)
        {
            File.AppendAllText(_path, $"<{sender}> <{recipient}> <{obj}> <{DateTime.Now}>\n");
        }
    }
}
