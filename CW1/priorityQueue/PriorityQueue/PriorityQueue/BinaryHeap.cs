namespace PriorityQueue;

public class BinaryHeap
{
    private (int, int)[] Heap { get; set; } = new (int, int)[10];

    private int HeapSize { get; set; } = 0;

    private void ResetHeap()
    {
        var newHeap = new (int, int)[this.Heap.Length * 2];
        this.Heap.CopyTo(newHeap, 0);
        this.Heap = newHeap;
    }

    private void IncreaseKey(int index, (int, int) item)
    {
        if (item.Item1 < this.Heap[index].Item1)
        {
            throw new Exception(); //TODO!!!!!!!!!
        }
        this.Heap[index] = item;
        while (index > 1 && this.Heap[index / 2].Item1 < this.Heap[index].Item1)
        {
            (this.Heap[index], this.Heap[index / 2]) = (this.Heap[index / 2], this.Heap[index]);
            index /= 2;
        }
    }

    public void Insert(int key, int value)
    {
        if (this.HeapSize == 0)
        {
            this.Heap[0] = (key, value);
            this.HeapSize = 1;
            return;
        }
        
        this.HeapSize++;
        if (this.HeapSize == this.Heap.Length)
        {
            this.ResetHeap();
        }
        this.Heap[this.HeapSize] = (0, 0);
        this.IncreaseKey(this.HeapSize, (key, value));
    }

    public int ExtractMaximum()
    {
        if (this.HeapSize < 1)
        {
            throw new Exception(); //TODO!!!!!!!!!
        }
        var maximum = this.Heap[0];
        this.HeapSize--;
        this.Heapify(0);
        return maximum.Item2;
    }

    private void Heapify(int index)
    {
        var left = index * 2 + 1;
        var right = index * 2 + 2;
        var largest = index;
        if (left < this.HeapSize && this.Heap[left].Item1 > this.Heap[largest].Item1)
        {
            largest = left;
        }

        if (right < this.HeapSize && this.Heap[right].Item1 > this.Heap[largest].Item1)
        {
            largest = right;
        }

        if (largest != index)
        {
            (this.Heap[index], this.Heap[largest]) = (this.Heap[largest], this.Heap[index]);
            this.Heapify(largest);
        }
    }
}