using System.Transactions;

namespace HW_4_Bank
{
    public class Account
    {
        public int ID { get; }
        public string ClientName { get; }
        public Money Balance { get; private set; }
        public decimal Rate { get; private set; }
        public List<Transaction> Transactions { get; private set; }


        public Account(int id, int uah, int kopecks, decimal rate, string clientName)
        {
            ID = id;
            ClientName = clientName;
            Balance = new Money(uah, kopecks);
            Rate = rate;
            Transactions = new List<Transaction>();
        }

        // поповнення
        public void DepositingAccount(Money amount)
        {
            Money startBalance = Balance;  // для стартового рахунка при формуванні транзакції

            Balance = Balance.AddMoney(amount);
            Console.WriteLine($"Amount {amount.ShowMoney()} successfully deposited to account #{ID} of client {ClientName}");

            Transactions.Add(new Transaction("Depositing", ID, ClientName, startBalance, amount, Balance));
        }
 
        // зняття
        public void WithdrawingAccount(Money amount)
        {
            Money startBalance = Balance;

            if (!Balance.IsMoreOrEqualMoney(amount))
            {
                Console.WriteLine($"There is unsufficial money at account #{ID} of client {ClientName} to withdraw amounf of {amount.ShowMoney()}.");
                Transactions.Add(new Transaction("Withdrawing", ID, ClientName, startBalance, amount, Balance));
            }

            else
            {
                Balance = Balance.RemoveMoney(amount);
                Console.WriteLine($"Amount {amount.ShowMoney()} successfully withdrawed from account #{ID}");
                Transactions.Add(new Transaction("Withdrawing", ID, ClientName, startBalance, amount, Balance));
            }
        }

        // трансфери 
        public void TransferBetweenAccounts(Account inputAccount, Money amount)
        {
            Money outputStartBalance = Balance;
            Money inputStartBalance = inputAccount.Balance;

            if (Balance.ShowMoney() >= amount.ShowMoney())
            {
                Balance = Balance.RemoveMoney(amount);
                Transactions.Add(new Transaction("Transfer", ID, ClientName, outputStartBalance, amount, Balance));

                inputAccount.Balance = inputAccount.Balance.AddMoney(amount);
                inputAccount.Transactions.Add(new Transaction("Transfer", inputAccount.ID, inputAccount.ClientName, inputStartBalance, amount, inputAccount.Balance));

                Console.WriteLine($"Amount {amount.ShowMoney()} was successfully transfered from account {ID} of client {ClientName}\n" +
                                  $"to account {inputAccount.ID} of client {inputAccount.ClientName}");
            }
            else
            {
                Console.WriteLine($"There is unsufficial money at account #{ID} of client {ClientName} to transfer amounf of {amount.ShowMoney()}.");
                Transactions.Add(new Transaction("Transfer", ID, ClientName, outputStartBalance, amount, Balance));
            }

        }

        // зміна ставки
        public void ChangeRateInAccount(decimal newRate)
        {
            Rate = newRate;
            Console.WriteLine($"Interest rate in account #{ID} of client {ClientName} successfully changed to {Rate}");
        }
       
        // вивід транзакцій по рахунку
        public void ShowTransactions()
        {
            if (Transactions.Count > 0)
            {
                foreach (Transaction t in Transactions)
                {
                    Console.WriteLine($"\nTransactionID: {t.TransactionID}, success: {t.Success}");
                    Console.Write($"Type of transaction: {t.Type}, account: #{t.AccountId}, client: {t.Client}\n" +
                                      $"Balance before transaction: {t.StartBalance}\n" +
                                      $"Amount in transaction:      {t.Amount}\n" +
                                      $"Balance after transaction:  {t.EndBalance}\n");
                }

            }
            else
                Console.WriteLine("No transactions in account.");
        }

    }
}
//-У рахунку є гроші (баланс), ставка. На рахунок можна переказувати гроші та знімати їх. Змінювати ставку. Робити це може лише банк