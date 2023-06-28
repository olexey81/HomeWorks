namespace HW_6_LINQ_1
{
    internal class Program
    {
        static void Main()
        {
            //      Виведіть усі числа від 10 до 50 через кому
            Console.WriteLine(string.Join(",", Enumerable.Range(10, 41)));

            //      Виведіть лише ті числа від 10 до 50, які можна поділити на 3
            Console.WriteLine(string.Join(",", Enumerable.Range(10, 41).Where(x => x % 3 == 0)));

            //      Виведіть слово "Linq" 10 разів
            Console.WriteLine(string.Join(" ", Enumerable.Repeat("Linq", 10)));

            //      Вивести всі слова з буквою «а» в рядку «aaa; abb; ccc; dap»
            Console.WriteLine(string.Join(" ", "aaa; abb; ccc; dap".Split("; ").Where(x => x.Contains("a"))));

            //      Виведіть кількість літер «а» у словах з цією літерою в рядку «aaa; abb; ccc; dap» через кому
            Console.WriteLine(string.Join(", ", "aaa; abb; ccc; dap".Split("; ").Where(x => x.Contains("a")).Select(w => w.Count(x => x == 'a'))));

            //      Вивести true, якщо слово "abb" існує в рядку "aaa;xabbx;abb;ccc;dap", інакше false
            Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(";").Contains("abb"));

            //      Отримати найдовше слово в рядку "aaa;xabbx;abb;ccc;dap"
            Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').MaxBy(x => x.Length));

            //      Обчислити середню довжину слова в рядку "aaa;xabbx;abb;ccc;dap"
            Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(";").Average(w => w.Length));

            //      Вивести найкоротше слово в рядку "aaa;xabbx;abb;ccc;dap;zh" у зворотному порядку.
            Console.WriteLine(string.Concat("aaa;xabbx;abb;ccc;dap;zh".Split(";").MinBy(x => x.Length).Reverse()));

            //      Вивести true, якщо в першому слові, яке починається з "aa", усі літери "b" (За винятком "аа"), інакше false "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh"
            Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(";").Where(x => x.StartsWith("aa")).Any(c => c.Skip(2).All(s => s == 'b')));

            //      Вивести останнє слово в послідовності, за винятком перших двох елементів, які закінчуються на "bb" (використовуйте послідовність із 10 завдання)
            Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(";").Skip(2).Where(x => x.EndsWith("bb")).Last());

        }
    }
}