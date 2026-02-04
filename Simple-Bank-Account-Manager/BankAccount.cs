namespace Simple_Bank_Account_Manager;

public class BankAccount
{
    // Static Field
    private static int accountNumberSeed;

    // Properties
    public string AccountHolderName { get; private set; }
    public string AccountNumber { get; private set; }
    public decimal Balance { get; private set; }

    // Static Constructor
    static BankAccount()
    {
        Random random = new Random();
        accountNumberSeed = random.Next(1000000000, 1999999999);
    }

    // Constructor
    public BankAccount(string accountHolderName, decimal initialDeposit)
    {
        AccountHolderName = accountHolderName;
        AccountNumber = accountNumberSeed++.ToString();
        Balance = initialDeposit;
    }

    // Methods
    public string Deposit(decimal depositAmount)
    {
        if (depositAmount < 0)
        {
            return "Deposit failed, deposit amount must be greater than zero!";
        }

        Balance += depositAmount;
        return $"Deposit successful, current balance: {Balance.ToString("C")}";
    }

    public string Withdraw(decimal withdrawAmount)
    {
        if (withdrawAmount < 0)
        {
            return "Withdraw failed, withdraw amount must be greater than zero!";
        }

        if (withdrawAmount > Balance)
        {
            return "Withdraw failed, insufficient balance to withdraw!";
        }

        Balance -= withdrawAmount;
        return $"Withdraw successful, current balance: {Balance.ToString("C")}";
    }

    public override string ToString()
    {
        return $"Account Details:\nAccount Holder Name:\t{AccountHolderName}\nAccount Number:\t{AccountNumber}\nBalance:\t{Balance.ToString("C")}";
    }
}   
