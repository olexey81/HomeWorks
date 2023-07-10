namespace HW_4_Bank
{
    interface IClient
    {
        string FirstName { get; }    
        string LastName { get; }    
    }
    public class Client : IClient
    {
        public string FirstName { get; }    
        public string LastName { get; }    
        public List<Account> Accounts { get; }  

        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Accounts = new List<Account>();
        }

        public void GetBalance()            
        {
            if (Accounts.Count > 0)
            {
                Console.WriteLine($"Accounts of client {FirstName} {LastName}:");

                foreach (var account in Accounts)
                {
                    Console.WriteLine($"\nID of account: {account.ID}, amount at account: {account.Balance.ShowMoney()}, account rate: {account.Rate}");
                    account.ShowTransactions();
                }
            }
            else
                Console.WriteLine($"\nClient {FirstName} {LastName} has no any accounts.");
        }
    }
}
//У клієнта є ім'я та прізвище, і список його рахунків. Методи отримання балансу по рахунках.