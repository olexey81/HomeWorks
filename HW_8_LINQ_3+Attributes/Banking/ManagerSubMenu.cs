using HW_8_LINQ_3_Menu;

namespace HW_4_Bank
{
    public class ManagerSubMenu
    {
        [MenuAction("Show clients", 1)]          // елементи головного меню - елемент
        public void ShowClient()
        {
            Console.Clear();
            Menu.Bank.GetClientList();

            Console.WriteLine("Press any key to continue");
            Console.Read();
        }

        [MenuAction("Add client and accounts", 2)]          // елементи головного меню - елемент
        public void AddClient()
        {
            Console.Clear();
            Console.WriteLine("Enter client's first name:");
            var clientNameFirst = Console.ReadLine();
            Console.WriteLine("Enter client's last name:");
            var clientNameLast = Console.ReadLine();
            var client = new Client(clientNameFirst, clientNameLast);
            Menu.Bank.AddClient(client);

            bool accAdd = true;
            while (accAdd)
            {
                Console.WriteLine("Press 1 if you want to add an account to client: ");
                var select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Menu.Bank.AddAccount(client);
                        break;
                    default:
                        accAdd = false;
                        break;
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.Read();
        }

        [MenuAction("Back", 0)]
        public void Back()
        {
            Menu.DetectMenu<ManagerMainMenu>().Process();
        }

    }
}