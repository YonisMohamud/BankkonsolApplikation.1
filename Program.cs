namespace BankkonsolApplikation
{
    internal class Program
    {
       
            static void Main(string[] args)
            {
                // Välkomstmeddelande
                Console.WriteLine("Välkommen till YonisM Bank!");

                // Skapa en användare med initiala konton
                User user = new User("Yonis");

                bool programRunning = true;

                // Visa menyn tills användaren väljer att avsluta
                while (programRunning)
                {
                    // Meny
                    Console.WriteLine("\nVälj ett alternativ:");
                    Console.WriteLine("1. Visa kontoinformation");
                    Console.WriteLine("2. Överför pengar mellan konton");
                    Console.WriteLine("3. Sätt in pengar");
                    Console.WriteLine("4. Ta ut pengar");
                    Console.WriteLine("5. Avsluta programmet");

                    int menuChoice;

                    // Kontrollerar om inmatningen är giltig (1-5)
                    while (!int.TryParse(Console.ReadLine(), out menuChoice) || menuChoice < 1 || menuChoice > 5)
                    {
                        Console.WriteLine("Ange ett giltigt alternativ (1-5).");
                    }

                    switch (menuChoice)
                    {
                        case 1:
                            // Visa kontoinformation
                            ShowAccountInfo(user);
                            break;
                        case 2:
                            // Överför pengar mellan konton
                            TransferBetweenAccounts(user);
                            break;
                        case 3:
                            // Sätt in pengar på ett konto
                            DepositToAccount(user);
                            break;
                        case 4:
                            // Ta ut pengar från ett konto
                            WithdrawFromAccount(user);
                            break;
                        case 5:
                            // Avsluta programmet
                            Console.WriteLine("Tack för att du använder Bankapplikationen. Hej då!");
                            programRunning = false; // Avslutar programmet
                            break;
                    }
                }
            }

            // Funktion för att visa kontoinformation
            private static void ShowAccountInfo(User user)
            {
                Console.WriteLine(user.PersonalAccount);
                Console.WriteLine(user.SavingsAccount);
                Console.WriteLine(user.InvestmentAccount);
            }

            // Funktion för att hantera överföringar mellan konton
            private static void TransferBetweenAccounts(User user)
            {
                Console.WriteLine("Hur mycket vill du överföra?");
                double amount;
                while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                {
                    Console.WriteLine("Ange ett giltigt belopp.");
                }

                Console.WriteLine("Från vilket konto vill du överföra?");
                Console.WriteLine("1. Personal Account");
                Console.WriteLine("2. Savings Account");
                Console.WriteLine("3. Investment Account");

                BankAccount fromAccount = ChooseAccount(user);

                Console.WriteLine("Till vilket konto vill du överföra?");
                Console.WriteLine("1. Personal Account");
                Console.WriteLine("2. Savings Account");
                Console.WriteLine("3. Investment Account");

                BankAccount toAccount = ChooseAccount(user);

                if (fromAccount != null && toAccount != null && fromAccount != toAccount)
                {
                    user.Transfer(fromAccount, toAccount, amount);
                }
                else
                {
                    Console.WriteLine("Ogiltig överföring. Du kan inte överföra till samma konto.");
                }
            }

            // Ny funktion för att sätta in pengar
            private static void DepositToAccount(User user)
            {
                Console.WriteLine("Vilket konto vill du sätta in pengar på?");
                Console.WriteLine("1. Personal Account");
                Console.WriteLine("2. Savings Account");
                Console.WriteLine("3. Investment Account");

                BankAccount account = ChooseAccount(user);

                Console.WriteLine("Hur mycket vill du sätta in?");
                double amount;
                while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                {
                    Console.WriteLine("Ange ett giltigt belopp.");
                }

                if (account != null)
                {
                    account.Deposit(amount);
                    Console.WriteLine($"Du har satt in {amount} på {account.AccountName}. Nytt saldo: {account.Balance}");
                }
            }

            // Ny funktion för att ta ut pengar
            private static void WithdrawFromAccount(User user)
            {
                Console.WriteLine("Vilket konto vill du ta ut pengar från?");
                Console.WriteLine("1. Personal Account");
                Console.WriteLine("2. Savings Account");
                Console.WriteLine("3. Investment Account");

                BankAccount account = ChooseAccount(user);

                Console.WriteLine("Hur mycket vill du ta ut?");
                double amount;
                while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                {
                    Console.WriteLine("Ange ett giltigt belopp.");
                }

                if (account != null)
                {
                    if (account.Withdraw(amount))
                    {
                        Console.WriteLine($"Du har tagit ut {amount} från {account.AccountName}. Nytt saldo: {account.Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Uttag misslyckades! Otillräckligt saldo.");
                    }
                }
            }

            // Funktion för att låta användaren välja ett konto
            private static BankAccount ChooseAccount(User user)
            {
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Ange ett giltigt alternativ (1-3).");
                }

                switch (choice)
                {
                    case 1:
                        return user.PersonalAccount;
                    case 2:
                        return user.SavingsAccount;
                    case 3:
                        return user.InvestmentAccount;
                    default:
                        return null;
                }
            }
        }
    }

