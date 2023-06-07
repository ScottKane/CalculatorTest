using CalculatorTest.Shared;
using CalculatorTest.Server.Services;
using NUnit.Framework;

namespace CalculatorTest.Tests;

[TestFixture]
public class SimpleCalculatorTests
{
    private ISimpleCalculator _calculator = null!;

    [SetUp]
    public void Setup() => _calculator = new CalculatorService();

    [TestCase(5, 3, 8)]    // Positive numbers addition
    [TestCase(-5, -3, -8)] // Negative numbers addition
    [TestCase(0, 5, 5)]    // Zero with positive number addition
    [TestCase(0, -5, -5)]  // Zero with negative number addition
    [TestCase(5, 0, 5)]    // Positive number with zero addition
    [TestCase(-5, 0, -5)]  // Negative number with zero addition
    [TestCase(0, 0, 0)]    // Zero with zero addition
    public async Task Add_ValidInputs_ReturnsExpectedResult(int start, int amount, int expected)
    {
        // Arrange
        var request = new AddRequest(start, amount);

        // Act
        var response = await _calculator.Add(request);

        // Assert
        Assert.That(response.Value, Is.EqualTo(expected));
    }

    [TestCase(5, 3, 2)]    // Positive numbers subtraction
    [TestCase(-5, -3, -2)] // Negative numbers subtraction
    [TestCase(0, 5, -5)]   // Zero with positive number subtraction
    [TestCase(0, -5, 5)]   // Zero with negative number subtraction
    [TestCase(5, 0, 5)]    // Positive number with zero subtraction
    [TestCase(-5, 0, -5)]  // Negative number with zero subtraction
    [TestCase(0, 0, 0)]    // Zero with zero subtraction
    public async Task Subtract_ValidInputs_ReturnsExpectedResult(int start, int amount, int expected)
    {
        // Arrange
        var request = new SubtractRequest(start, amount);

        // Act
        var response = await _calculator.Subtract(request);

        // Assert
        Assert.That(response.Value, Is.EqualTo(expected));
    }
}