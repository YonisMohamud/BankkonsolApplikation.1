

namespace BankkonsolApplikation
{
    public abstract class BankAccount
    {
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }

        public BankAccount(int accountNumber, string accountName, double initialBalance)
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
            Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{AccountName} - Account Number: {AccountNumber}, Balance: {Balance}";
        }
    }
}