namespace HW_4_Bank
{
    public class Bank
    {
        private List<Client> clients;
        private List<Account> accounts;

        public List<Account> Accounts { get; }
        
        public Bank()
        {
            clients = new List<Client>();
            accounts = new List<Account>();
            Accounts = accounts;
            //Console.WriteLine("Bank was founded!\n");
        }

        // додавання клієнтів до банка
        public void AddClient(Client client)
        {
            if (!clients.Contains(client))
            {
                clients.Add(client);
                Console.WriteLine($"Client {client.FirstName} {client.LastName} successfully added to the bank.");
            }
            else
                Console.WriteLine($"Client {client.FirstName} {client.LastName} has been added to the bank previously.");
        } 

        // додавання рахунків до банка та клієнта і зв'язання рахунка з клієнтом
        public void AddAccount(Client client)
        {
            Random random = new Random();
            int ID = random.Next(10000000, 99999999);

            Account account = new Account(ID, 10000, 0, 0m, client.FirstName + " " + client.LastName);
            
            accounts.Add(account);
            client.Accounts.Add(account);

            Console.WriteLine($"Account #{account.ID} successfully added for client {client.FirstName} {client.LastName}.");
        }

        // поповнення рахунка
        public void Depositing(Account account, int uah, int kopecks) => account.DepositingAccount(new Money(uah, kopecks));
        
        // зняття з рахунка
        public void Withdrawing(Account account, int uah, int kopecks) => account.WithdrawingAccount(new Money(uah, kopecks));
        
        // переказ між рахунками 
        public void Transfer(Account outputAccount, Account inputAccount, int uah, int kopecks) => outputAccount.TransferBetweenAccounts(inputAccount, new Money(uah, kopecks));
        
        // зміна ставки
        public void ChangeRate(Account account, decimal newRate) => account.ChangeRateInAccount(newRate);
        
        // вивід списка рахунків
        public void GetClientList()
        {
            Console.WriteLine("Clients list:");
            foreach (Client client in clients)
                Console.WriteLine($"{clients.IndexOf(client) + 1}. {client.FirstName} {client.LastName}");
        }

        // вивід списка клієнтів
        public void GetAccountsList()
        {
            Console.WriteLine("\nAccounts list:");
            foreach (Account account in accounts)
                Console.WriteLine($"{accounts.IndexOf(account) + 1}. #{account.ID} client {account.ClientName}");
        }

    }
}

// -Є клас Банк, він містить у собі список клієнтів та рахунків. Не всі клієнти можуть мати рахунки. Можна відкривати рахунки, додавати клієнтів.
// Прив'язувати рахунок до клієнта. Отримувати список усіх рахунків та клієнтів.