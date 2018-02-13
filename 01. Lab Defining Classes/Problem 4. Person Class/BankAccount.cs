
public class BankAccount
{

    private int id;
    private decimal balance;


    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public void Deposit(decimal amount)
    {
        this.balance += amount;
    }
    public void Withdraw(decimal amount)
    {
        this.balance -= amount;
    }

    public override string ToString()
    {
        return $"Account ID{this.Id}, balance {this.Balance:f2}";
    }
}

