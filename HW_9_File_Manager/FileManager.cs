namespace HW_9_File_Manager
{
    internal class FileManager
    {
        private Visualizator _showList;
        private KeyReader _keyReader;


        public FileManager()
        {
            _keyReader = new KeyReader(new Drives().DriveList);
            _showList = new Visualizator();
        }

        public void Process()
        {
            do
            {
                Console.CursorVisible = false;
                Console.Clear();
                Console.WriteLine($"Current directory:");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(_keyReader.Previous + "\n");
                Console.ResetColor();
                Console.WriteLine("Date:\t   Time:\tName:\n");

                _showList.ShowList(_keyReader.List, _keyReader.Index);

                Console.WriteLine("\vHelp:\nUpArrow / DownArrow - navigation;\n" +
                    "Enter - select item;\nBackspase - return to previous level\n" +
                    "PageUp / PageDown - first / last item\nEsc - terminate program");
            }
            while (!_keyReader.Select());
        }
    }
}
