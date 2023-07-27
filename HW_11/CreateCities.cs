using System.Diagnostics;

namespace HW_11_Generator
{
    public static class CreateCities
    {
        public static City CreateCityTitles(string fileName, int rowsNum)   
        {
            City citiesTitles = new City();         // допоміжний для читання назв 

            using (var lines = new StreamReader("../../../../" + fileName))
            {
                //ReadOnlySpan<char> line;
                while (!lines.EndOfStream)
                {
                    var titles = lines.ReadLine().Split(' ');
                    if (titles.Length == 3)
                    {
                        citiesTitles.Name.Add(titles[0]);
                        citiesTitles.Country.Add(titles[1]);
                        citiesTitles.Region.Add(titles[2]);

                        citiesTitles.Count++;
                    }
                }
            }
            
            City cities = new City();
            Random _random = new Random();
            var sw = new Stopwatch();
            (int x, int y) = Console.GetCursorPosition();

            sw.Start();
            for (int i = 0; i < rowsNum; i++)
            {
                int j = _random.Next(0, citiesTitles.Count);
                cities.Name.Add(citiesTitles.Name[j]);
                cities.Area.Add((float)_random.NextDouble() * 500);
                cities.Population.Add(_random.Next(100000, 2000000));
                cities.Country.Add(citiesTitles.Country[j]);
                cities.Region.Add(citiesTitles.Region[j]);
                cities.Count++;

                if (rowsNum * 100 % (i + 1) == 0)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine($"Progress: {i * 100 / rowsNum} %");
                }

            }
            sw.Stop();
            Console.WriteLine($"Time elapsed for creating list of cities: {sw.Elapsed}");

            return cities;
        }
    }
}
