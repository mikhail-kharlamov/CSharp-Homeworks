using NUnit.Framework;

namespace BurrowsWheeler;

[TestFixture]
public class BurrowsWheelerTransformTests
{
    [Test]
    public void StraightTrasformWithEmptyStringTest()
    {
        var (output, index) = BurrowsWheelerTransform.StraightTransform("");
        Assert.That(string.Empty, Is.EqualTo(output));
        Assert.That(-1, Is.EqualTo(index));
    }

    [Test]
    public void StraightTrasformWithOrdinaryStringTest()
    {
        var (output, index) = BurrowsWheelerTransform.StraightTransform("abacaba");
        Assert.That("bcabaaa", Is.EqualTo(output));
        Assert.That(2, Is.EqualTo(index));
    }

    [Test]
    public void InverseTransformWithEmptyStringTest()
    {
        var output = BurrowsWheelerTransform.InverseTransform("", 1);
        Assert.That(string.Empty, Is.EqualTo(output));
    }

    [Test]
    public void InverseTransformWithIndexOfOriginalStringLessThen0Test()
    {
        var output = BurrowsWheelerTransform.InverseTransform("abacaba", -1);
        Assert.That(string.Empty, Is.EqualTo(output));
    }

    [Test]
    public void InverseTransformWithIndexOfOriginalStringEqualsLengthTest()
    {
        var output = BurrowsWheelerTransform.InverseTransform("abacaba", 7);
        Assert.That(string.Empty, Is.EqualTo(output));
    }

    [Test]
    public void InverseTransformWithOrdinaryStringTest()
    {
        var output = BurrowsWheelerTransform.InverseTransform("bcabaaa", 2);
        Assert.That("abacaba", Is.EqualTo(output));
    }
}