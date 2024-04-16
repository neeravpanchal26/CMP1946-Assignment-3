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
    public Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
    {
        if (mealCosts == null)
        {
            throw new ArgumentNullException(nameof(mealCosts), "Meal costs dictionary cannot be null.");
        }

        if (tipPercentage < 0 || tipPercentage > 100)
        {
            throw new ArgumentException("Tip percentage must be between 0 and 100.");
        }

        decimal totalMealCost = 0;
        foreach (var kvp in mealCosts)
        {
            totalMealCost += kvp.Value;
        }

        decimal totalTipAmount = totalMealCost * (decimal)(tipPercentage / 100);

        Dictionary<string, decimal> tipAmounts = new Dictionary<string, decimal>();
        foreach (var kvp in mealCosts)
        {
            decimal tipAmount = kvp.Value / totalMealCost * totalTipAmount;
            tipAmounts.Add(kvp.Key, tipAmount);
        }

        return tipAmounts;
    }
    public decimal CalculateTipPerPerson(decimal totalPrice, int numberOfPatrons, float tipPercentage)
    {
        if (totalPrice <= 0)
        {
            throw new ArgumentException("Total price must be greater than zero.", nameof(totalPrice));
        }

        if (numberOfPatrons <= 0)
        {
            throw new ArgumentException("Number of patrons must be greater than zero.", nameof(numberOfPatrons));
        }

        if (tipPercentage < 0 || tipPercentage > 100)
        {
            throw new ArgumentException("Tip percentage must be between 0 and 100.", nameof(tipPercentage));
        }

        decimal totalTipAmount = totalPrice * (decimal)(tipPercentage / 100);
        decimal tipPerPerson = totalTipAmount / numberOfPatrons;

        return tipPerPerson;
    }
}