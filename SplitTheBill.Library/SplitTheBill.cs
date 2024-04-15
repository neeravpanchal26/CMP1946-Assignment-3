namespace SplitTheBill.Library;

public class SplitTheBill
{
    public decimal SplitAmount(decimal amount, int numberOfPeople)
    {
        if (numberOfPeople <= 0)
        {
            throw new ArgumentException("Number of people must be greater than zero.");
        }

        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        decimal splitAmount = amount / numberOfPeople;
        return splitAmount;
    }
}