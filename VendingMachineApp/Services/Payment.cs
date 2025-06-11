public class CashPayment : IPayment
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Accepted ${amount} in cash/coins).");
        return true;
    }
}