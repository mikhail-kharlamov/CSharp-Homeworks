namespace FilterMapFold.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FilterFunctionOrdinaryDataTest()
    {
        var collection = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var resultCollection = new int[] { 0, 2, 4, 6, 8 };
        var predicate = new Func<int, bool>(i => i % 2 == 0);
        Assert.That(HigherOrderFunctions.Filter(collection, predicate), Is.EquivalentTo(resultCollection));
    }

    [Test]
    public void FilterEmptyCollectionTest()
    {
        var collection = new int[] { };
        var resultCollection = new int[] { };
        var predicate = new Func<int, bool>(i => i % 2 == 0);
        Assert.That(HigherOrderFunctions.Filter(collection, predicate), Is.EquivalentTo(resultCollection));
    }

    [Test]
    public void FilterEmptyPredicateTest() //TODO rename method
    {
        var collection = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var resultCollection = new int[] { };
        var predicate = new Func<int, bool>(i => i % 11 == 0);
        Assert.That(HigherOrderFunctions.Filter(collection, predicate), Is.EquivalentTo(resultCollection));
    }
    
    [Test]
    public void MapFunctionOrdinaryDataTest()
    {
        var collection = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var resultCollection = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18 };
        var function = new Func<int, int>(i => i * 2);
        Assert.That(HigherOrderFunctions.Map(collection, function), Is.EquivalentTo(resultCollection));
    }

    [Test]
    public void MapEmptyCollectionTest()
    {
        var collection = new int[] { };
        var resultCollection = new int[] { };
        var function = new Func<int, int>(i => i * 2);
        Assert.That(HigherOrderFunctions.Map(collection, function), Is.EquivalentTo(resultCollection));
    }
    
    [Test]
    public void FoldFunctionOrdinaryDataTest()
    {
        var collection = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var function = new Func<int, int, int>((x, y) => x + y);
        Assert.That(HigherOrderFunctions.Fold(collection, function), Is.EqualTo(45));
    }

    /*[Test]
    public void FoldEmptyCollectionTest() //TODO fix
    {
        var collection = new int[] { };
        var function = new Func<int, int, int>((x, y) => x + y);
        var result = HigherOrderFunctions.Fold(collection, function);
        Assert.That(HigherOrderFunctions.Fold(collection, function), Is.EqualTo(45));
    }*/
}