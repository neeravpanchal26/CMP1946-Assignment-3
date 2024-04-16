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
}
