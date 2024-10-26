

namespace BankkonsolApplikation

{
    public class User
    {
        public PersonalAccount PersonalAccount { get; set; }
        public SavingsAccount SavingsAccount { get; set; }
        public InvestmentAccount InvestmentAccount { get; set; }

        public User(string name)
        {
            // Initial unika kontonummer och saldon
            int personalAccountNumber = 1;
            int savingsAccountNumber = 2;
            int investmentAccountNumber = 3;

            double initialBalanceForAllAccounts = 2500;

            PersonalAccount = new PersonalAccount(personalAccountNumber, $"{name}'s Personal Account", initialBalanceForAllAccounts);
            SavingsAccount = new SavingsAccount(savingsAccountNumber, $"{name}'s Savings Account", initialBalanceForAllAccounts);
            InvestmentAccount = new InvestmentAccount(investmentAccountNumber, $"{name}'s Investment Account", initialBalanceForAllAccounts);
        }

        public void Transfer(BankAccount fromAccount, BankAccount toAccount, double amount)
        {
            if (fromAccount.Withdraw(amount))
            {
                toAccount.Deposit(amount);
                Console.WriteLine($"Successfully transferred {amount} from {fromAccount.AccountName} to {toAccount.AccountName}.");
            }
            else
            {
                Console.WriteLine($"Transfer failed! Insufficient balance in {fromAccount.AccountName}.");
            }
        }
    }
}