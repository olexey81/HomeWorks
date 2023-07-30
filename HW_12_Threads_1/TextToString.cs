namespace HW_12_Threads_1
{
    internal static class TextToString
    {
        public static string[] Convert()
        {
            string path = "../../../text.txt";
            List<string> linesList = new List<string>();

            using (var lines = new StreamReader(path))
            {
                while (!lines.EndOfStream)
                    linesList.Add(lines.ReadLine()!);
            }

            return linesList.ToArray();
        }
    }
}