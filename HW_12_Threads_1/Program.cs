using System.Diagnostics;
using System.Text;

namespace HW_12_Threads_1
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int threads = 3;
            var sw = new Stopwatch();
            int size = 87_370_156;
            Console.SetBufferSize(600, 10000);

            //var a = new RandomeArrCreator(threads, new int[size]);
            //a.ThreadsStart();
            //a.ThreadsWait();

            //Console.WriteLine("Генерація випадкового масиву:");
            //RandomeArrCreator randArr;
            //for (int i = 1; i <= threads; i++)
            //{
            //    Console.WriteLine("Threads: " + i);
            //    sw.Restart();
            //    randArr = new RandomeArrCreator(i, new int[size]);
            //    randArr.ThreadsStart();
            //    randArr.ThreadsWait();
            //    sw.Stop();
            //    Console.WriteLine("Time: " + sw.Elapsed + "\n");
            //    Thread.Sleep(1000);
            //}

            //Console.WriteLine("\nГенерація масиву відповідно до певної функції f(i), де i – позиція в масиві:");
            //FuncArrCreator funcArr;
            //for (int i = 1; i <= threads; i++)
            //{
            //    Console.WriteLine("Threads: " + i);

            //    sw.Restart();
            //    funcArr = new FuncArrCreator(i, new double[size]);
            //    funcArr.ThreadsStart();
            //    funcArr.ThreadsWait();
            //    sw.Stop();

            //    Console.WriteLine("Time: " + sw.Elapsed + "\n");
            //}




            //Console.WriteLine("\nСума елементів масиву");
            //FindSum<int> sum;
            //for (int i = 1; i <= threads; i++)
            //{
            //    Console.WriteLine("Threads: " + i);
            //    sw.Restart();
            //    sum = new FindSum<int>(i, a.ResultArray);
            //    sum.ThreadsStart();
            //    sum.ThreadsWait();
            //    sw.Stop();

            //    Console.WriteLine("Time: " + sw.Elapsed + "\n");
            //}

            //Console.WriteLine("\nСереднє в масиві");
            //FindAverage<int> average;
            //for (int i = 1; i <= threads; i++)
            //{
            //    Console.WriteLine("Threads: " + i);
            //    sw.Restart();
            //    average = new FindAverage<int>(i, a.ResultArray);
            //    average.ThreadsStart();
            //    average.ThreadsWait();
            //    sw.Stop();

            //    Console.WriteLine("Time: " + sw.Elapsed + "\n");
            //}


            //Console.WriteLine("\nМін. в масиві");
            //FindMin<int> min;
            //for (int i = 1; i <= threads; i++)
            //{
            //    Console.WriteLine("Threads: " + i);
            //    sw.Restart();
            //    min = new FindMin<int>(i, a.ResultArray);
            //    min.ThreadsStart();
            //    min.ThreadsWait();
            //    sw.Stop();

            //    Console.WriteLine("Time: " + sw.Elapsed + "\n");
            //}

            //Console.WriteLine("\nМax. в масиві");
            //FindMax<int> max;
            //for (int i = 1; i <= threads; i++)
            //{
            //    Console.WriteLine("Threads: " + i);
            //    sw.Restart();
            //    max = new FindMax<int>(i, a.ResultArray);
            //    max.ThreadsStart();
            //    max.ThreadsWait();
            //    sw.Stop();

            //    Console.WriteLine("Time: " + sw.Elapsed + "\n");
            //}


            //Console.WriteLine("\nКопіювати частину масиву");
            //PartlyArray<int> cut;
            //for (int i = 1; i <= threads; i++)
            //{
            //    Console.WriteLine("Threads: " + i);
            //    sw.Restart();
            //    cut = new PartlyArray<int>(i, a.ResultArray, 10_000_000, 20_000_000);
            //    cut.ThreadsStart();
            //    cut.ThreadsWait();
            //    sw.Stop();

            //    Console.WriteLine("Time: " + sw.Elapsed + "\n");
            //}
            //Console.WriteLine();

            //Console.WriteLine("\nЧастотний словник символів у якійсь довгій книзі/тексті");
            //FrequencyCharDict dicChar;
            //for (int i = 1; i <= threads; i++)
            //{
            //    Console.WriteLine("Threads: " + i);
            //    sw.Restart();
            //    dicChar = new FrequencyCharDict(i, File.ReadAllLines("../../../text.txt"));
            //    dicChar.ThreadsStart();
            //    dicChar.ThreadsWait();
            //    sw.Stop();

            //    Console.WriteLine("Time: " + sw.Elapsed + "\n");
            //    Thread.Sleep(1000);
            //}

            //Console.WriteLine("\nЧастотний словник слів у якійсь довгій книзі/тексті");
            //FrequencyWordDict dicWord;
            //for (int i = 1; i <= threads; i++)
            //{
            //    Console.WriteLine("Threads: " + i);
            //    sw.Restart();
            //    dicWord = new FrequencyWordDict(i, File.ReadAllLines("../../../text.txt"));
            //    dicWord.ThreadsStart();
            //    dicWord.ThreadsWait();
            //    sw.Stop();

            //    Console.WriteLine("Time: " + sw.Elapsed + "\n");
            //    Thread.Sleep(1000);
            //}
        }
    }
}