using FoodDeliveryCheckout.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoodDeliveryCheckout.Tests;

[TestClass]
public class CheckoutCalculatorDeliveryTests
{
    [TestMethod]
    [DataRow(DeliveryZone.Local, 3.99)]
    [DataRow(DeliveryZone.Suburban, 6.99)]
    [DataRow(DeliveryZone.Rural, 12.99)]
    public void CalculateDeliveryFee_ValidZone_ReturnsExpectedFee(
        DeliveryZone zone,
        double expectedFee)
    {
        // Arrange
        var calculator = new CheckoutCalculator();

        // Act
        decimal result = calculator.CalculateDeliveryFee(zone);

        // Assert
        Assert.AreEqual((decimal)expectedFee, result);
    }
}
