using System.Diagnostics;

namespace HW_12_Threads_1
{
    internal class Program
    {
        static void Main()
        {
            int threads = 8;
            var sw = new Stopwatch();
            int size = 50_000_000;


            RandomeArrCreator randArr; 

            Console.WriteLine("Генерація випадкового масиву:");
            for (int i = 1; i <= threads; i++)
            {
                sw.Restart();
                randArr = new RandomeArrCreator(i, new int[size]);
                randArr.ThreadsStart();
                randArr.ThreadsWait();
                sw.Stop();

                Console.WriteLine("Threads:" + i + "\t" + "Time: " + sw.Elapsed);

            }

            FuncArrCreator funcArr;
            Console.WriteLine("\nГенерація масиву відповідно до певної функції f(i), де i – позиція в масиві:");
            for (int i = 1; i <= threads; i++)
            {
                sw.Restart();
                funcArr = new FuncArrCreator(i, new double[size]);
                funcArr.ThreadsStart();
                funcArr.ThreadsWait();
                sw.Stop();

                Console.WriteLine("Threads:" + i + "\t" + "Time: " + sw.Elapsed);

            }

            var a = new FuncArrCreator(threads, new double[size]);
            a.ThreadsStart();
            a.ThreadsWait();
            Console.WriteLine("\nСума елементів масиву\r\nСереднє в масиві");
            for (int i = 1; i <= threads; i++)
            {
                sw.Restart();
                var sum = new FindSumAndAverage<double>(i, a.ResultArray);
                sum.ThreadsStart();
                sum.ThreadsWait();
                var res = sum.Sum;
                var average = sum.Average;
                sw.Stop();

                Console.WriteLine("Threads:" + i + "\t" + "Time: " + sw.Elapsed);
            }

            Console.WriteLine("\nМін. в масиві");
            for (int i = 1; i <= threads; i++)
            {
                sw.Restart();
                var min = new FindMin<double>(i, a.ResultArray);
                min.ThreadsStart();
                min.ThreadsWait();
                var res2 = min.MinInArray;
                sw.Stop();

                Console.WriteLine("Threads:" + i + "\t" + "Time: " + sw.Elapsed);
            }

            Console.WriteLine("\nМax. в масиві");
            for (int i = 1; i <= threads; i++)
            {
                sw.Restart();
                var max = new FindMax<double>(i, a.ResultArray);
                max.ThreadsStart();
                max.ThreadsWait();
                var res3 = max.MaxInArray;
                sw.Stop();

                Console.WriteLine("Threads:" + i + "\t" + "Time: " + sw.Elapsed);
            }

            Console.WriteLine("\nКопіювати частину масиву");
            for (int i = 1; i <= threads; i++)
            {
                sw.Restart();

                var cut = new PartlyArray<double>(i, a.ResultArray, 10_000_000, 20_000_000);
                cut.ThreadsStart();
                cut.ThreadsWait();
                sw.Stop();

                Console.WriteLine("Threads:" + i + "\t" + "Time: " + sw.Elapsed);
            }

            var textArr = TextToString.Convert();
            Console.WriteLine("\nЧастотний словник символів у якійсь довгій книзі/тексті");
            for (int i = 1; i <= threads; i++)
            {
                sw.Restart();
                var dicChar = new FrequencyCharDict(i, textArr);
                dicChar.ThreadsStart();
                var chars = dicChar.ThreadsWait();
                sw.Stop();

                Console.WriteLine("Threads:" + i + "\t" + "Time: " + sw.Elapsed);
            }


            Console.WriteLine("\nЧастотний словник слів у якійсь довгій книзі/тексті");
            for (int i = 1; i <= threads; i++)
            {
                sw.Restart();
                var dicWord = new FrequencyWordDict(i, textArr);
                dicWord.ThreadsStart();
                var words = dicWord.ThreadsWait();
                sw.Stop();

                Console.WriteLine("Threads:" + i + "\t" + "Time: " + sw.Elapsed);
            }
        }
    }
}