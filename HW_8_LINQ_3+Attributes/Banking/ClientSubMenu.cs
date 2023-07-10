using HW_8_LINQ_3_Menu;

namespace HW_4_Bank
{
    public class ClientSubMenu
    {
        [SubMenu("Other options", 1)]                               
        public ClientSubMenu2 SubMenu { get; set; }

        [MenuAction("Transfer", 2)]
        public void Transfer()
        {
            Console.Clear();
            Menu.Bank.GetAccountsList();
            string? temp; 
            Console.Write("Enter output account number:");
            temp = Console.ReadLine();
            int.TryParse(temp, out int outAcc);
            Console.Write("Enter input account number:");
            temp = Console.ReadLine();
            int.TryParse(temp, out int inAcc);
            Console.WriteLine("Enter amount in UAH");
            temp = Console.ReadLine();
            int.TryParse(temp, out int uah);
            Console.WriteLine("Enter amount in kop");
            temp = Console.ReadLine();
            int.TryParse(temp, out int kop);

            Menu.Bank.Transfer(Menu.Bank.Accounts.First(a => a.ID == outAcc), Menu.Bank.Accounts.First(a => a.ID == inAcc), uah, kop);
            foreach (var account in Menu.Bank.Accounts)
                account.ShowTransactions();

            Console.WriteLine("Press any key to continue");
            Console.Read();

        }



        [MenuAction("Back", 0)]
        public void Back()
        {
            Menu.DetectMenu<ClientMainMenu>().Process();
        }
    }
}
