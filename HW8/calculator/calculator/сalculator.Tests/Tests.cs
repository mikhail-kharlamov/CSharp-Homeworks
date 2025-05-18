namespace Calculator.Tests;

using Calculator;

public class Tests
{
    private CalculatorLogic calculator;

    [SetUp]
    public void Setup()
    {
        this.calculator = new CalculatorLogic();
    }

    [Test]
    public void CalculatorLogicSimpleArithmeticTest()
    {
        this.calculator.AddDigit('2');
        Assert.That(this.calculator.GetDisplay(), Is.EqualTo("2"));
        this.calculator.AddDigit('3');
        Assert.That(this.calculator.GetDisplay(), Is.EqualTo("23"));
        this.calculator.SetOperator('+');
        Assert.That(this.calculator.GetDisplay(), Is.EqualTo("23"));
        this.calculator.AddDigit('3');
        Assert.That(this.calculator.GetDisplay(), Is.EqualTo("3"));
        this.calculator.SetOperator('-');
        Assert.That(this.calculator.GetDisplay(), Is.EqualTo("26"));
        this.calculator.AddDigit('5');
        Assert.That(this.calculator.GetDisplay(), Is.EqualTo("5"));
        this.calculator.SetOperator('/');
        Assert.That(this.calculator.GetDisplay(), Is.EqualTo("21"));
        this.calculator.AddDigit('3');
        Assert.That(this.calculator.GetDisplay(), Is.EqualTo("3"));
        this.calculator.SetOperator('*');
        Assert.That(this.calculator.GetDisplay(), Is.EqualTo("7"));
        this.calculator.AddDigit('2');
        Assert.That(this.calculator.GetDisplay(), Is.EqualTo("2"));
        this.calculator.SetOperator('=');
        Assert.That(this.calculator.GetDisplay(), Is.EqualTo("14"));
    }
}