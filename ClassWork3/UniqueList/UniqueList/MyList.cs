namespace UniqueList;

public class MyList
{
    protected List<int> list = [];

    public int this[int index]
    {
        get => list[index];
        set => list[index] = value;
    }

    public virtual void Add(int value, int index)
    {
        list.Insert(index, value);
    }

    public void Remove(int index)
    {
        list.RemoveAt(index);
    }
}