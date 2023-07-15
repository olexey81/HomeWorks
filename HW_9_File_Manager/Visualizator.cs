namespace HW_9_File_Manager
{
    internal class Visualizator
    {
        public void ShowList(string[] list, int index)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (!Directory.Exists(list[i]))
                    Console.ForegroundColor = ConsoleColor.Cyan;
                if (i == index)
                    Console.ForegroundColor = ConsoleColor.Green;
                if (list[i].Length > 3)
                    Console.WriteLine(Directory.GetCreationTime(list[i]) + "\t" + string.Join("", list[i].Reverse().TakeWhile(c => c != '\\').Reverse()));
                else
                    Console.WriteLine(Directory.GetCreationTime(list[i]) + "\t" + list[i]);
                Console.ResetColor();
            }
            if (list.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Directory is empty");
                Console.ResetColor();
            }
        }
    }
}
