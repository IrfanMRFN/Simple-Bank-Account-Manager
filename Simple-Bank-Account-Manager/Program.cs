namespace Simple_Bank_Account_Manager;

public class Program
{
    public static void Main(string[] args)
    {
        const int _minInitialDeposit = 10;

        Console.WriteLine("=== Welcome to Simple Bank ===");
        Console.Write("Enter your name to create an account: ");
        string? name = Console.ReadLine();
        while (!IsValidString(name))
        {
            Console.Write("Please re-enter your name: ");
            name = Console.ReadLine();
        }

        decimal initialDeposit = GetValidDecimal("Enter your initial deposit amount: ", _minInitialDeposit - 1);

        BankAccount myAccount = new BankAccount(name, initialDeposit);
        Console.WriteLine("\nAccount created successfully!");

        bool exit = false;
        do
        {
            Console.WriteLine("\nWhat do you want to do next?");
            Console.WriteLine("1. View Account Details\n2. Deposit\n3. Withdraw\n4. Exit");
            Console.Write("Enter your choice (1-4): ");

            string? choice = Console.ReadLine();
            while (!IsValidString(choice))
            {
                Console.Write("Please re-enter your choice (1-4): ");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    Console.WriteLine(myAccount.ToString());
                    break;

                case "2":
                    decimal depositAmount = GetValidDecimal("Enter deposit amount: ", 0);

                    Console.WriteLine(myAccount.Deposit(depositAmount));
                    break;

                case "3":
                    decimal withdrawAmount = GetValidDecimal("Enter withdraw amount: ", 0);

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

    private static decimal GetValidDecimal(string prompt, decimal minValue = 0)
    {
        decimal value;
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (decimal.TryParse(input, out value) && value > minValue)
            {
                return value;
            }
            Console.WriteLine($"Invalid input. Please enter a valid decimal number and greater than {minValue}!");
        }
    }

    private static bool IsValidString(string? input)
    {
        if (!string.IsNullOrWhiteSpace(input))
        {
            return true;
        }

        Console.WriteLine("Input cannot be empty!");
        return false;
    }
}