// Copyright (c) 2025 Mikhail Kharlamov. Licensed under MIT License.

namespace TestProject1;

using Credit;

public class Tests
{
    [Test]
    public void ConstructorCreatesEmptyList()
    {
        var list = new CustomList<int>();
        Assert.That(list, Is.Empty);
    }

    [Test]
    public void AddItemsTest()
    {
        var list = new CustomList<string>();
        list.Add("first");
        list.Add("second");
        var test = new List<string>() { "first", "second" };
        Assert.That(list, Is.EquivalentTo(test));
    }
    
    [Test]
    public void GetEnumeratorEnumeratesAllItems()
    {
        var list = new CustomList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        var sum = 0;
        foreach (var item in list)
        {
            sum += item;
        }
        
        Assert.That(sum, Is.EqualTo(6));
    }
    
    [Test]
    public void CountNullElementsWithValueTypesCountsZeros()
    {
        var list = new CustomList<int>();
        list.Add(1);
        list.Add(0);
        list.Add(2);
        list.Add(0);
        list.Add(3);
        
        var checker = new IntNullChecker();
        var nullCount = ListUtils.CountNullElements(list, checker);
        
        Assert.That(nullCount, Is.EqualTo(2));
    }

    [Test] public void CountNullElementsWithValueTypesCountsNullReferences()
    {
        var list = new CustomList<int>();
        list.Add(1);
        list.Add(0);
        list.Add(2);
        list.Add(0);
        list.Add(3);
        
        var checker = new IntNullChecker();
        var nullCount = ListUtils.CountNullElements(list, checker);
        
        Assert.That(nullCount, Is.EqualTo(2));
    }
    
    [Test]
    public void CountNullElementsWithValueTypesCountsEmptyStrings()
    {
        var list = new CustomList<string>();
        list.Add("1");
        list.Add("");
        list.Add("2");
        list.Add("");
        list.Add("3");
        
        var checker = new StringNullChecker();
        var nullCount = ListUtils.CountNullElements(list, checker);
        
        Assert.That(nullCount, Is.EqualTo(2));
    }
}