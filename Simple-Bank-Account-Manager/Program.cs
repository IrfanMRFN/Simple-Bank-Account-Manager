namespace Simple_Bank_Account_Manager;

public class Program
{
    public static void Main(string[] args)
    {
        const int _minInitialDeposit = 10;

        Console.WriteLine("=== Welcome to Simple Bank ===");
        Console.Write("Enter your name to create an account: ");
        string? name = Console.ReadLine();
        
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Your name cannot be empty!");
            Console.Write("Please re-enter your name: ");
            name = Console.ReadLine();
        }
        
        Console.Write("Enter your initial deposit amount: ");
        string? depositInput = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(depositInput))
        {
            Console.WriteLine("Initial deposit cannot be empty!");
            Console.Write("Please re-enter your initial deposit amount: ");
            depositInput = Console.ReadLine();
        }

        while (decimal.TryParse(depositInput, out decimal initialDepositCheck) == false || initialDepositCheck < _minInitialDeposit)
        {
            Console.WriteLine("Initial deposit must be a valid number and at least 10!");
            Console.Write("Please re-enter your initial deposit amount: ");
            depositInput = Console.ReadLine();
        }

        decimal initialDeposit = decimal.Parse(depositInput);
        BankAccount myAccount = new BankAccount(name, initialDeposit);
        Console.WriteLine("\nAccount created successfully!");
        
        bool exit = false;
        do
        {
            Console.WriteLine("\nWhat do you want to do next?");
            Console.WriteLine("1. View Account Details\n2. Deposit\n3. Withdraw\n4. Exit");
            Console.Write("Enter your choice (1-4): ");
            string? choice = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Choice cannot be empty!");
                Console.Write("Please re-enter your choice (1-4): ");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    Console.WriteLine(myAccount.ToString());
                    break;
                case "2":
                    Console.Write("Enter deposit amount: ");
                    string? depositAmountInput = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(depositAmountInput))
                    {
                        Console.WriteLine("Deposit amount cannot be empty!");
                        Console.Write("Please re-enter deposit amount: ");
                        depositAmountInput = Console.ReadLine();
                    }
                    while (decimal.TryParse(depositAmountInput, out decimal depositAmountCheck) == false || depositAmountCheck <= 0)
                    {
                        Console.WriteLine("Deposit amount must be a valid number and greater than zero!");
                        Console.Write("Please re-enter deposit amount: ");
                        depositAmountInput = Console.ReadLine();
                    }
                    decimal depositAmount = decimal.Parse(depositAmountInput);
                    Console.WriteLine(myAccount.Deposit(depositAmount));
                    break;
                case "3":
                    Console.Write("Enter withdraw amount: ");
                    string? withdrawAmountInput = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(withdrawAmountInput))
                    {
                        Console.WriteLine("Withdraw amount cannot be empty!");
                        Console.Write("Please re-enter withdraw amoung: ");
                        withdrawAmountInput = Console.ReadLine();
                    }
                    while (decimal.TryParse(withdrawAmountInput, out decimal withdrawAmountCheck) == false || withdrawAmountCheck < 0)
                    {
                        Console.WriteLine("Withdraw amount must be a valid number and greater than zero!");
                        Console.Write("Please re-enter withdraw amount: ");
                        withdrawAmountInput = Console.ReadLine();
                    }
                    decimal withdrawAmount = decimal.Parse(withdrawAmountInput);
                    Console.WriteLine(myAccount.Withdraw(withdrawAmount));
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Thank you for using Simple Bank. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 4.");
                    break;
            }
        } while (!exit);

    }
}