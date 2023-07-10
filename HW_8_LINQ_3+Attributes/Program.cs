using System.Reflection;
using HW_4_Bank;

namespace HW_8_LINQ_3_Menu
{
    public partial class Program
    {
        static void Main()
        {
            Linq3.ShowLinqExamples();
            Console.ReadKey();

            Menu.DetectMenu<MainMenu>().Process();
        }
    }
}
