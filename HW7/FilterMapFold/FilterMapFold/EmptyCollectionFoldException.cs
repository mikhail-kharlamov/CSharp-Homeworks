namespace FilterMapFold.Exceptions;

public class EmptyCollectionFoldException : InvalidOperationException
{
    public EmptyCollectionFoldException()
        : base("Cannot perform fold on an empty collection without an initial value.")
    {
    }
}