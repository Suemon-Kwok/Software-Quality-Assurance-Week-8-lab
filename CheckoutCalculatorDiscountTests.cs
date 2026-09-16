using FoodDeliveryCheckout.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoodDeliveryCheckout.Tests;

[TestClass]
public class CheckoutCalculatorDiscountTests
{
    [TestMethod]
    [DataRow(100, CustomerType.Regular, 0)]
    [DataRow(100, CustomerType.Premium, 10)]
    [DataRow(100, CustomerType.Student, 15)]
    [DataRow(50, CustomerType.Premium, 5)]
    [DataRow(80, CustomerType.Student, 12)]
    public void CalculateDiscount_ValidSubtotalAndCustomerType_ReturnsExpectedDiscount(
        double subtotal,
        CustomerType customerType,
        double expectedDiscount)
    {
        // Arrange
        var calculator = new CheckoutCalculator();

        // Act
        decimal result = calculator.CalculateDiscount((decimal)subtotal, customerType);

        // Assert
        Assert.AreEqual((decimal)expectedDiscount, result);
    }

    [TestMethod]
    public void CalculateDiscount_NegativeSubtotal_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var calculator = new CheckoutCalculator();

        // Act & Assert
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => calculator.CalculateDiscount(-1, CustomerType.Regular));
    }

    [TestMethod]
    [DataRow(100, 5)]
    [DataRow(50, 2.5)]
    [DataRow(20, 1)]
    public void CalculateServiceFee_ValidSubtotal_ReturnsFivePercent(
        double subtotal,
        double expectedFee)
    {
        // Arrange
        var calculator = new CheckoutCalculator();

        // Act
        decimal result = calculator.CalculateServiceFee((decimal)subtotal);

        // Assert
        Assert.AreEqual((decimal)expectedFee, result);
    }

    [TestMethod]
    public void CalculateServiceFee_NegativeSubtotal_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var calculator = new CheckoutCalculator();

        // Act & Assert
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => calculator.CalculateServiceFee(-1));
    }
}
