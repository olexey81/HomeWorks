using System.Diagnostics;
using System.Text;
using System.Threading;

namespace HW_14_Tasks_1
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int tasksNum = 3;
            var sw = new Stopwatch();
            int size = 80_000_000;

            Console.WriteLine("Генерація випадкового масиву:");
            RandomeArrCreator randArr;
            Console.WriteLine("Tasks: " + tasksNum);
            sw.Restart();
            randArr = new RandomeArrCreator(tasksNum, new int[size]);
            randArr.TasksStart();
            randArr.TasksWait();
            sw.Stop();
            Console.WriteLine("Time: " + sw.Elapsed + "\n");

            Thread.Sleep(2000);
            Console.Clear();




            Console.WriteLine("Генерація масиву відповідно до певної функції f(i), де i – позиція в масиві:");
            FuncArrCreator funcArr;
            Console.WriteLine("Tasks: " + tasksNum);

            sw.Restart();
            funcArr = new FuncArrCreator(tasksNum, new double[size]);
            funcArr.TasksStart();
            funcArr.TasksWait();
            sw.Stop();

            Console.WriteLine("Time: " + sw.Elapsed + "\n");
            Thread.Sleep(2000);
            Console.Clear();





            Console.WriteLine("Генерація масиву для математичних функцій:");
            var a = new RandomeArrCreator(tasksNum, new int[size]);
            a.TasksStart();
            a.TasksWait();

            Thread.Sleep(2000);
            Console.Clear();



            Console.WriteLine("Сума елементів масиву");
            FindSum<int> sum;
            Console.WriteLine("Tasks: " + tasksNum);
            sw.Restart();
            sum = new FindSum<int>(tasksNum, a.ResultArray);
            sum.TasksStart();
            sum.TasksWait();
            sw.Stop();

            Console.WriteLine("Time: " + sw.Elapsed + "\n");
            Thread.Sleep(2000);
            Console.Clear();



            Console.WriteLine("Середнє в масиві");
            FindAverage<int> average;
            Console.WriteLine("Tasks: " + tasksNum);
            sw.Restart();
            average = new FindAverage<int>(tasksNum, a.ResultArray);
            average.TasksStart();
            average.TasksWait();
            sw.Stop();

            Console.WriteLine("Time: " + sw.Elapsed + "\n");
            Thread.Sleep(2000);
            Console.Clear();




            Console.WriteLine("Мін. в масиві");
            FindMin<int> min;
            Console.WriteLine("Tasks: " + tasksNum);
            sw.Restart();
            min = new FindMin<int>(tasksNum, a.ResultArray);
            min.TasksStart();
            min.TasksWait();
            sw.Stop();

            Console.WriteLine("Time: " + sw.Elapsed + "\n");
            Thread.Sleep(2000);
            Console.Clear();




            Console.WriteLine("Мax. в масиві");
            FindMax<int> max;
            Console.WriteLine("Tasks: " + tasksNum);
            sw.Restart();
            max = new FindMax<int>(tasksNum, a.ResultArray);
            max.TasksStart();
            max.TasksWait();
            sw.Stop();

            Console.WriteLine("Time: " + sw.Elapsed + "\n");
            Thread.Sleep(2000);
            Console.Clear();




            Console.WriteLine("Копіювати частину масиву");
            PartlyArray<int> cut;
            Console.WriteLine("Tasks: " + tasksNum);
            sw.Restart();
            cut = new PartlyArray<int>(tasksNum, a.ResultArray, 10_000_000, 50_000_000);
            cut.TasksStart();
            cut.TasksWait();
            sw.Stop();

            Console.WriteLine("Time: " + sw.Elapsed + "\n");
            Thread.Sleep(2000);
            Console.Clear();




            Console.WriteLine("Частотний словник символів у якійсь довгій книзі/тексті");
            FrequencyCharDict dicChar;
            Console.WriteLine("Tasks: " + tasksNum);
            sw.Restart();
            dicChar = new FrequencyCharDict(tasksNum, File.ReadAllLines("../../../text.txt"));
            dicChar.TasksStart();
            dicChar.TasksWait();
            sw.Stop();

            Console.WriteLine("Time: " + sw.Elapsed + "\n");
            Thread.Sleep(2000);
            Console.Clear();




            Console.WriteLine("Частотний словник слів у якійсь довгій книзі/тексті");
            FrequencyWordDict dicWord;
            Console.WriteLine("Tasks: " + tasksNum);
            sw.Restart();
            dicWord = new FrequencyWordDict(tasksNum, File.ReadAllLines("../../../text.txt"));
            dicWord.TasksStart();
            dicWord.TasksWait();
            sw.Stop();

            Console.WriteLine("Time: " + sw.Elapsed + "\n");

        }
    }
}