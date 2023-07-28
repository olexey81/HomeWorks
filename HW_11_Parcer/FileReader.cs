using HW_11_Generator;
using System.Diagnostics;

namespace HW_11_Parcer
{
    internal class FileReader
    {
        private readonly string _filePath;
        private readonly City _cities;

        public City Cities => _cities;

        public FileReader()
        {
            while (true)
            {
                Console.Write("Enter a name for *.txt resourse file: ");
                _filePath = "../../../../" +  Console.ReadLine()! + ".txt";
                if (!_filePath!.StartsWith(' ') && _filePath.Any(char.IsLetterOrDigit))
                    break;
                Console.WriteLine("Incorrect file name - it has consist at least one letter/number and can't start with whitespase");
            }

            _cities = new City();
        }

        public void OpenFile()
        {
            var sw = new Stopwatch();

            sw.Start();
            using (var lines = new StreamReader(_filePath))
            {
                sw.Stop();
                Console.WriteLine($"Time elapsed for reading of file: {sw.Elapsed}");

                ReadOnlySpan<char> line;
                int index;

                sw.Restart();

                while (!lines.EndOfStream)
                {
                    line = lines.ReadLine().AsSpan();
                    //if (line == null) break;

                    index = line.IndexOf(':');
                    _cities.Name.Add(line[..index].ToString());

                    line = line[(index + 1)..];
                    index = line.IndexOf(';');
                    _cities.Area.Add(float.Parse(line[..index]));

                    line = line[(index + 1)..];
                    index = line.IndexOf(';');
                    _cities.Population.Add(int.Parse(line[..index]));

                    line = line[(index + 1)..];
                    index = line.IndexOf('(');
                    _cities.Country.Add(line[..index].ToString());

                    line = line[(index + 1)..];
                    _cities.Region.Add(line[..^1].ToString());

                    _cities.Count++;
                }
                sw.Stop();
                Console.WriteLine($"Time elapsed for parcing: {sw.Elapsed}");
            }
        }
    }
}
