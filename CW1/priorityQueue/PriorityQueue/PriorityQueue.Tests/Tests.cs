namespace PriorityQueue.Tests;

public class Tests
{
    [Test]
    public void BinaryHeapInsertAndExtractMaximumTest()
    {
        var heap = new BinaryHeap();
        heap.Insert(4, 1);
        heap.Insert(3, 2);
        heap.Insert(2, 3);
        heap.Insert(1, 4);
        Assert.That(heap.ExtractMaximum(), Is.EqualTo(1));
    }

    [Test]
    public void BinaryHeapEmptyExtractMaximumTest()
    {
        var heap = new BinaryHeap();
        Assert.Throws<Exception>(() => heap.ExtractMaximum());
    }
}