namespace HW_9_File_Manager
{
    internal class KeyReader
    {
        private int _index = 0;
        private string[]? _list;
        private string _current = string.Empty;
        private string _previous = "Root directory:";
        private TextReader? _textfile;

        public int Index { get { return _index; } }
        public string[] List { get { return _list; } }
        public string Previous { get { return _previous; } }

        public KeyReader(string[] list)
        {
            _list = list;
        }


        public bool Select()
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.DownArrow)
                _index = Math.Min(++_index, _list.Length - 1);

            else if (key.Key == ConsoleKey.UpArrow)
                _index = Math.Max(--_index, 0);

            else if (key.Key == ConsoleKey.Enter && _list.Length > 0)
            {
                _current = _list[_index];
                _previous = _current;
                if (!Directory.Exists(_current))
                {
                    _textfile = new TextReader();
                    _textfile.TxtReader(_current);
                }
                else
                    try
                    {
                        _list = Directory.GetFileSystemEntries(_current);
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                _index = 0;
            }

            else if (key.Key == ConsoleKey.Backspace)
            {
                if (_current == string.Empty || Directory.GetParent(_current) == null)
                {
                    _list = Directory.GetLogicalDrives();
                    _previous = "Root directory:";
                }
                else
                {
                    _current = Directory.GetParent(_current).FullName;
                    _previous = _current;
                    _list = Directory.GetFileSystemEntries(_current);
                }
            }

            else if (key.Key == ConsoleKey.PageDown)
            {
                _index = _list.Length - 1;
            }

            else if (key.Key == ConsoleKey.PageUp)
            {
                _index = 0;
            }

            else if (key.Key == ConsoleKey.Escape)
                return true;

            return false;
        }
    }
}
