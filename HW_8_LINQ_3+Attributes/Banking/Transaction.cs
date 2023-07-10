using System.Text;

namespace HW_4_Bank
{
    public class Transaction
    {
        public string Type { get; init; }
        public int AccountId { get; init; }
        public string Client { get; init; }
        public decimal StartBalance { get; init; }
        public decimal Amount { get; init; }
        public decimal EndBalance { get; init; }
        public bool Success { get; init; }
        public string TransactionID { get; init; }


        public Transaction(string type, int id, string client, Money startBalance, Money amount, Money endBalance)
        {
            Type = type;
            AccountId = id;
            Client = client;
            StartBalance = startBalance.ShowMoney();
            Amount = amount.ShowMoney();
            EndBalance = endBalance.ShowMoney();
            if (StartBalance != EndBalance)
                Success = true;
            TransactionID = Guid.NewGuid().ToString();
        }
    }
}
