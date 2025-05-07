namespace MyLinq.Tests;

public class Tests
{
    [Test]
    public void GetPrimesAndTakeTest()
    {
        var result = new int[5] { 2, 3, 5, 7, 11 };
        Assert.That(MyLinq.GetPrimes().Take(5), Is.EquivalentTo(result));
    }
    
    [Test]
    public void GetPrimesSkipAndTakeTest()
    {
        var result = new int[5] { 31, 37, 41, 43, 47 };
        Assert.That(MyLinq.GetPrimes().Skip(10).Take(5), Is.EquivalentTo(result));
    }
    
    [Test]
    public void SkipAndTakeTest()
    {
        var originalArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var resultArray = new int[5] { 4, 5, 6, 7, 8 };
        Assert.That(originalArray.Skip(3).Take(5), Is.EquivalentTo(resultArray));
    }
}