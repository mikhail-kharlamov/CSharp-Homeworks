namespace UniqueList;

public class UniqueList : MyList
{
    public override void Add(int value, int index)
    {
        if (list.Any(element => element == value))
        {
            throw new NotUniqueElementException();
        }

        list.Insert(index, value);
    }
}