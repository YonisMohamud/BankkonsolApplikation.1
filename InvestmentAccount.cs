

namespace BankkonsolApplikation
{
    public class InvestmentAccount : BankAccount
    {
        public InvestmentAccount(int accountNumber, string accountName, double initialBalance)
            : base(accountNumber, accountName, initialBalance) { }
    }
}