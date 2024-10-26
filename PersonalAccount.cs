

namespace BankkonsolApplikation
{
    public class PersonalAccount : BankAccount
    {
        public PersonalAccount(int accountNumber, string accountName, double initialBalance)
            : base(accountNumber, accountName, initialBalance) { }
    }
}