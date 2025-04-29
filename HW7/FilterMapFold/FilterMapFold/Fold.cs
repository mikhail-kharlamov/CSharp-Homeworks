namespace FilterMapFold;

using FilterMapFold.Exceptions;

public static partial class HigherOrderFunctions
{
    public static T Fold<T>(IEnumerable<T> source, Func<T, T, T> function)
    {
        if (!source.Any())
        {
            throw new EmptyCollectionFoldException();
        }
        var collection = source.ToList();
        var result = collection[0];
        for (var i = 1; i < collection.Count; i++)
        {
            result = function(result, collection[i]);
        }
        return result;
    }
}