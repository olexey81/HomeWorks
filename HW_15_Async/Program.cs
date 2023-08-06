using System.Diagnostics;

namespace HW_15_Async
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var sw = new Stopwatch();
            Console.WriteLine("Generation started");
            sw.Start();
            var gen = new Generator("d:/data.bin");
            await gen.Do();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine("Generation completed");


            Console.WriteLine("\n\nParsing started");
            sw.Restart();
            var parser = new Parser("d:/data.bin");
            await parser.Parse();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine("Parsing complited");
        }
    }
}