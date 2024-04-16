namespace  SplitTheBill.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitTheBill.Library;
using System;

[TestClass]
public class SplitTheBillTests
{
    [TestMethod]
    public void SplitAmount_ValidInput_ReturnsCorrectSplitAmount()
    {
        // Arrange
        decimal amount = 100.00m;
        int numberOfPeople = 4;
        decimal expectedSplitAmount = 25.00m;
        SplitTheBill splitter = new SplitTheBill();

        // Act
        decimal actualSplitAmount = splitter.SplitAmount(amount, numberOfPeople);

        // Assert
        Assert.AreEqual(expectedSplitAmount, actualSplitAmount);
    }

    [TestMethod]
    public void SplitAmount_ZeroAmount_ThrowsArgumentException()
    {
        // Arrange
        decimal amount = 0.00m;
        int numberOfPeople = 4;
        SplitTheBill splitter = new SplitTheBill();

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => splitter.SplitAmount(amount, numberOfPeople));
    }

    [TestMethod]
    public void SplitAmount_NegativeNumberOfPeople_ThrowsArgumentException()
    {
        // Arrange
        decimal amount = 100.00m;
        int numberOfPeople = -4;
        SplitTheBill splitter = new SplitTheBill();

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => splitter.SplitAmount(amount, numberOfPeople));
    }

    [TestMethod]
    public void CalculateTip_NullMealCosts_ThrowsArgumentNullException()
    {
        // Arrange
        Dictionary<string, decimal> mealCosts = null;
        float tipPercentage = 15;
        SplitTheBill splitter = new SplitTheBill();

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() => splitter.CalculateTip(mealCosts, tipPercentage));
    }

    [TestMethod]
    public void CalculateTip_TipPercentageLessThanZero_ThrowsArgumentException()
    {
        // Arrange
        Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>
        {
            { "Person1", 20.00m },
            { "Person2", 30.00m }
        };
        float tipPercentage = -10;
        SplitTheBill splitter = new SplitTheBill();

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => splitter.CalculateTip(mealCosts, tipPercentage));
    }

    [TestMethod]
    public void CalculateTip_TipPercentageGreaterThan100_ThrowsArgumentException()
    {
        // Arrange
        Dictionary<string, decimal> mealCosts = new Dictionary<string, decimal>
        {
            { "Person1", 20.00m },
            { "Person2", 30.00m }
        };
        float tipPercentage = 110;
        SplitTheBill splitter = new SplitTheBill();

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => splitter.CalculateTip(mealCosts, tipPercentage));
    }
    [TestMethod]
    public void CalculateTipPerPerson_ValidInput_ReturnsCorrectTip()
    {
        // Arrange
        decimal totalPrice = 100.00m;
        int numberOfPatrons = 5;
        float tipPercentage = 15;
        SplitTheBill splitter = new SplitTheBill();

        // Act
        decimal tipPerPerson = splitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);

        // Assert
        decimal expectedTipPerPerson = 3.00m;
        Assert.AreEqual(expectedTipPerPerson, tipPerPerson);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateTipPerPerson_TotalPriceZero_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 0;
        int numberOfPatrons = 5;
        float tipPercentage = 15;
        SplitTheBill splitter = new SplitTheBill();

        // Act
        decimal tipPerPerson = splitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateTipPerPerson_NumberOfPatronsZero_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.00m;
        int numberOfPatrons = 0;
        float tipPercentage = 15;
        SplitTheBill splitter = new SplitTheBill();

        // Act
        decimal tipPerPerson = splitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateTipPerPerson_InvalidTipPercentage_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.00m;
        int numberOfPatrons = 5;
        float tipPercentage = -10;
        SplitTheBill splitter = new SplitTheBill();

        // Act
        decimal tipPerPerson = splitter.CalculateTipPerPerson(totalPrice, numberOfPatrons, tipPercentage);
    }
}
