using System.Diagnostics;

namespace HW_11_Generator
{
    public class FileCreator
    {
        private readonly int _rowsNum;
        private readonly string _resultFileName;
        private readonly City _cities;
        public City Cities => _cities;
        public string ResultFileName => _resultFileName;
        public FileCreator()
        {
            while (true)
            {
                Console.Write("Please enter number of rows to be generated: ");
                if (int.TryParse(Console.ReadLine()!.ToArray(), out int result))
                {
                    _rowsNum = result;
                    break;
                }
                Console.WriteLine("Incorrect number, please try again!");
            }

            while (true)
            {
                Console.Write("Enter a name for *.txt result file: ");
                _resultFileName = Console.ReadLine()! + ".txt";
                if (!_resultFileName!.StartsWith(' ') && _resultFileName.Any(char.IsLetterOrDigit))
                    break;
                Console.WriteLine("Incorrect file name - it has consist at least one letter/number and can't start with whitespase");
            }

            _cities = CreateCities.CreateCityTitles("info.txt", _rowsNum);
        }

        public void CreateFile()
        {
            var sw = new Stopwatch();

            sw.Start();
            int buf = 100000; 
            int all = _cities.Count;

            using (var lines = new StreamWriter($"../../../../{_resultFileName}"))
            {
                for (int begin = 0; begin < all; begin += buf)
                {
                    int batchEnd = Math.Min(begin + buf, all);

                    for (int i = begin; i < batchEnd; i++)
                    {
                        lines.WriteLine($"{_cities.Name[i]}:" +
                                        $"{_cities.Area[i]};" +
                                        $"{_cities.Population[i]};" +
                                        $"{_cities.Country[i]}({_cities.Region[i]})");
                    }

                    lines.Flush(); 
                }
            }
            //using (var lines = new StreamWriter($"../../../../{_resultFileName}"))
            //{
            //    for (int i = 0; i < _cities.Count; i++)
            //    {
            //        lines.WriteLine($"{_cities.Name[i]}:" +
            //                        $"{_cities.Area[i]};" +
            //                        $"{_cities.Population[i]};" +
            //                        $"{_cities.Country[i]}({_cities.Region[i]})");
            //    }
            //}
            sw.Stop();
            Console.WriteLine($"Time elapsed for writing to SSD: {sw.Elapsed}");
        }
    }
}
