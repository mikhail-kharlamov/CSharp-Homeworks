namespace PriorityQueue;

public class PriorityQueue
{
    private BinaryHeap Data = new();

    public void Enqueue(int priority, int value)
    {
        this.Data.Insert(priority, value);
    }

    public int Dequeue()
    {
        return this.Data.ExtractMaximum();
    }
}