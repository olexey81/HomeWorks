using HW_11_Generator;
using System.Diagnostics;
using System.Text.Json;

namespace HW_11_Parcer
{
    internal class Serializer
    {
        private readonly City _cities;

        public Serializer(City cities)
        {
            _cities = cities;
        }
        public void JSFileCreator()
        {
            var sw = new Stopwatch();
            sw.Start();

            //string json = JsonSerializer.Serialize(_cities);
            File.WriteAllText("../../../../cities.json", JsonSerializer.Serialize(_cities));

            sw.Stop();
            Console.WriteLine($"Time elapsed for serialization: {sw.Elapsed}");

        }
        public City JSFileReader()
        {
            var sw = new Stopwatch();
            sw.Start();

            //string json = File.ReadAllText("../../../../cities.json");
            var citiesDeserialized = JsonSerializer.Deserialize<City>(File.ReadAllText("../../../../cities.json"));

            sw.Stop();
            Console.WriteLine($"Time elapsed for deserialization: {sw.Elapsed}");

            return citiesDeserialized;
        }
    }
}
