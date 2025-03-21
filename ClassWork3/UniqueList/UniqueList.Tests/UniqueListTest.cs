using System;
using System.Collections.Generic;
using NUnit.Framework;
using UniqueList;

namespace UniqueList.Tests;

[TestFixture]
[TestOf(typeof(UniqueList))]
public class UniqueListTest
{

    [Test]
    public void AddElementShouldAddedAnElementToTheList()
    {
        var list = new UniqueList();
        list.Add(1, 0);
        Assert.That(list[0], Is.EqualTo(1));
    }
    
    [Test]
    public void AddManyElementsShouldAddedManyElementsToTheList()
    {
        MyList list = new UniqueList();
        list.Add(1, 0);
        Assert.Throws<NotUniqueElementException>(() => list.Add(1, 1));
    }
}